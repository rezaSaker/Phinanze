using System;
using System.Collections.Generic;
using System.Reflection;
using Phinanze.Models.DBInfo;
using Phinanze.Models.Validations;
using Phinanze.Models.Repositories.Http;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace Phinanze.Models.Repositories
{
    /// <summary>
    /// Base class for all repository classes
    /// </summary>
    /// <typeparam name="T">The model associated with the child repository class</typeparam>
    public class Repository<T> where T : IModel
    {
        private int? _id; 
        private T _model; 
        private List<T> _localCopyOfAllEntries; 
        private string _responseStringFromLastSaveRequest; 

        private static bool _resetLocalCopyOfAllEntries = true; // Indicates whether _localCopyOfAllEntries needs to be reset

        // The Id of the child model (NULL if the model hasn't been saved into DB)
        public int Id
        {
            get { return (int)_id; }
            set
            {
                if (_id == null) _id = (int?)value;
                else throw new ArgumentException("Model id property cannot be changed");
            }
        }

        /// <summary>
        /// The child model
        /// </summary>
        protected T Model
        {
            get {  return _model; }
            set
            {
                if (_model == null) _model = value;
                else throw new ArgumentException("Model is already assigned");
            }
        }

        /// <summary>
        /// Response String from the last save request
        /// </summary>
        public string ResponseStringFromLastSaveRequest()
        {
            return _responseStringFromLastSaveRequest; 
        }

        public Repository() 
        {
            _id = null;
            _model = default(T);
        }

        /// <summary>
        /// Save (upsert) the model into the database
        /// </summary>
        /// <returns>True if the save is successful, otherwise false</returns>
        public bool Save()
        {
            _responseStringFromLastSaveRequest = String.Empty;
            EntityValidationResult validator = EntityValidator.Validate(_model);

            if (!validator.IsValid)
            {
                validator.Errors.ForEach(error => _responseStringFromLastSaveRequest += error.ErrorMessage + '\n');
                return false;
            }

            HttpRequest<T> http;

            if(_id == null) // if it is a new entry for insert
            {
                http = HttpRequest<T>.URL(API_URL.Insert_Url(_model.GetType().Name)).ResponseType(HttpResponseTypes.SingleIModel());
            }
            else // if it is an existing entry for update
            {
                http = HttpRequest<T>.URL(API_URL.Update_Url(_model.GetType().Name)).ResponseType(HttpResponseTypes.String());
                http.RequestParams.Add("Id", _id.ToString());
            }

            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach(PropertyInfo property in properties)
            {
                if(property.Name != "Id")
                {
                    http.RequestParams.Add(property.Name, property.GetValue((object)_model).ToString());
                }
            }

            if(http.Post().IsSuccessful)
            {
                if(http.GetResponseType.Type == HttpResponseTypes.SingleIModelType && _id == null)
                {
                    _id = http.ResponseModel.Id;
                }
                _resetLocalCopyOfAllEntries = true;
                return true;
            }

            _responseStringFromLastSaveRequest += http.ResponseString;
            return false;
        }

        /// <summary>
        /// Permanently deletes a specific entry from the associated DB table
        /// </summary>
        /// <returns>True for successful delete, or false.</returns>
        public bool Delete()
        {
            HttpRequest<T> http = HttpRequest<T>.URL(API_URL.Delete_Url(_model.GetType().Name));
            http.RequestParams.Add("Id", Id.ToString());

            if(http.ResponseType(HttpResponseTypes.String()).Delete().IsSuccessful)
            {
                _resetLocalCopyOfAllEntries = true;
            }
            return http.IsSuccessful;
        }

        /// <summary>
        /// Get all entries from the associated DB table. 
        /// </summary>
        /// <returns>All entries associated with the current user from the associated DB table</returns>
        public List<T> All()
        {
            if(_localCopyOfAllEntries.IsNullOrEmpty() || _resetLocalCopyOfAllEntries)
            {
                _localCopyOfAllEntries = HttpRequest<T>
                    .URL(API_URL.GetAll_Url(typeof(T).Name))
                    .ResponseType(HttpResponseTypes
                    .ListOfIModel())
                    .Get()
                    .ResponseModelList;

                _resetLocalCopyOfAllEntries = false;
            }
            return _localCopyOfAllEntries.Select(e => Clone(e)).ToList();
        }

        public T One(int id)
        {
            if (_localCopyOfAllEntries.IsNullOrEmpty() || _resetLocalCopyOfAllEntries)
            {
                return Where("id", id.ToString()).FirstOrDefault();
            }

            T entry = _localCopyOfAllEntries.Find(e => e.Id == id);
            return entry != null ? Clone(entry) : default(T);
        }

        /// <summary>
        /// Find entries by the value of a column from the associated DB table
        /// </summary>
        /// <param name="param">Name of the column to search in</param>
        /// <param name="value">Value of field to search for</param>
        /// <returns>All entires from the table that match the search criteria, or null if no entry is found</returns>
        public List<T> Where(string param, string value)
        {
            HttpRequest<T> http = HttpRequest<T>.URL(API_URL.GetBy_Url(typeof(T).Name));

            http.RequestParams.Add("param", param);
            http.RequestParams.Add("value", value);

            return http.ResponseType(HttpResponseTypes.ListOfIModel()).Get().ResponseModelList;
        }

        /// <summary>
        /// Find entries by the value of a column from the associated DB table
        /// </summary>
        /// <param name="param">Name of the column to search in</param>
        /// <param name="value">Value of field to search for</param>
        /// <returns>All entires from the table that match the search criteria, or null if no entry is found</returns>
        public List<T> Where(string param, int value)
        {
            return Where(param, value.ToString());
        }

        /// <summary>
        /// Find entries by the value of a column from the associated DB table
        /// </summary>
        /// <param name="param">Name of the column to search in</param>
        /// <param name="value">Value of field to search for</param>
        /// <returns>All entires from the table that match the search criteria, or null if no entry is found</returns>
        public List<T> Where(string param, double value)
        {
            return Where(param, value.ToString());
        }

        /// <summary>
        /// Find entries by the value of a column from the associated DB table
        /// </summary>
        /// <param name="param">Name of the column to search in</param>
        /// <param name="value">Value of field to search for</param>
        /// <returns>All entires from the table that match the search criteria, or null if no entry is found</returns>
        public List<T> Where(string param, bool value)
        {
            return Where(param, value.ToString());
        }

        public T Clone(T original)
        {
            T newObject = (T)Activator.CreateInstance(original.GetType());

            foreach (var originalProp in original.GetType().GetProperties())
            {
                originalProp.SetValue(newObject, originalProp.GetValue(original));
            }

            return newObject;
        }
    }
}
