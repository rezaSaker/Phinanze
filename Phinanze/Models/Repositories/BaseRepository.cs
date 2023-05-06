using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Phinanze.Models.DBContext;
using Phinanze.Models.Validations;
using Phinanze.Models.Repositories.Http;

namespace Phinanze.Models.Repositories
{
    /// <summary>
    /// Base class for all repository classes
    /// </summary>
    /// <typeparam name="T">The model associated with the child repository class</typeparam>
    public abstract class BaseRepository<T> where T : IModel
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseRepository() { }

        /// <summary>
        /// Save (insert/update) the associated model in the associated table in the DB
        /// </summary>
        /// <param name="model">The associated model</param>
        /// <param name="modelName">Name of the associated model</param>
        /// <returns>True if the save is successful, otherwise false</returns>
        public bool Save(T model, string modelName)
        {
            if(!EntityValidator.Validate(model).IsValid)
            {
                return false;
            }

            HttpRequest<T> http;

            if(model.Id == 0) // if it is a new entry for insert
            {
                http = HttpRequest<T>.URL(DB.Insert_Url(modelName));
            }
            else // if it is an existing entry for update
            {
                http = HttpRequest<T>.URL(DB.Update_Url(modelName));
                http.AddQueryParams("Id", model.Id.ToString());
            }

            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach(PropertyInfo property in properties)
            {
                if(property.Name != "Id")
                {
                    http.AddQueryParams(property.Name, property.GetValue((object)model).ToString());
                }
            }

            if(http.Post().IsSuccessful)
            {
                if(model.Id == 0)
                {
                    Int32.TryParse(http.PostSuccessResponse, out int id);
                    model.Id = id;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get all data associated with the given model for this user 
        /// </summary>
        /// <param name="modelName">Name of the associated model</param>
        /// <returns>All entries associated with the current user in the table associated with Model T</returns>
        protected static List<T> GetAll(string modelName)
        {
            HttpRequest<T> http = HttpRequest<T>.URL(DB.GetAll_Url(modelName));
            
            if(http.Get().IsSuccessful)
            {
                return http.ResponseValues;
            }

            //TODO: Implement unsuccessful request handler here
            return null;
        }

        /// <summary>
        /// Find a specific entry by id from a given DB table
        /// </summary>
        /// <param name="param">Name of the field to search by</param>
        /// <param name="value">Value of field to search for</param>
        /// <param name="modelName">Name of the associated model</param>
        /// <returns>The specific entry from the table associated with Model T, or null if no data found for given id</returns>
        protected static List<T> GetBy(string param, string value, string modelName)
        {
            HttpRequest<T> http = HttpRequest<T>.URL(DB.GetBy_Url(modelName));

            http.AddQueryParams("param", param);
            http.AddQueryParams("value", value);

            if (http.Get().IsSuccessful)
            {
                return http.ResponseValues;
            }

            //TODO: Implement unsuccessful request handler here
            return new List<T>();
        }

        /// <summary>
        /// Delete a specific entry from the table associated with the given table
        /// </summary>
        /// <param name="model">The model to be deleted</param>
        /// <param name="modelName">Name of the associated model</param>
        protected static bool Delete(T model, string modelName)
        {
            HttpRequest<T> http = HttpRequest<T>.URL(DB.Delete_Url(modelName));
            http.AddQueryParams("Id", model.Id.ToString());
            return http.Delete().IsSuccessful;
        }
    }
}
