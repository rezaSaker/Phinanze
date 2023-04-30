using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections.Specialized;

namespace Phinanze.Models.Repositories.Http
{
    /// <summary>
    /// A class to make Http requests using a builder design pattern
    /// </summary>
    /// <typeparam name="T">Genric of IModel type</typeparam>
    public class HttpRequest<T> where T : IModel
    {
        private class Error
        {
            public string Type { get; set; }
            public string Message { get; set; }
        }

        //Fields
        private string _url;
        private string _postSuccessResponse;
        private bool _isSuccessful;
        private List<T> _responseValues;
        private List<Error> _errors;
        private NameValueCollection _queryParams;

        //Properties
        /// <summary>
        /// Starts a new HttpRequest with the given URL
        /// </summary>
        /// <param name="url">The Url to be used by the HttpRequest</param>
        /// <returns>A new HttpRequest<typeparamref name="T"/> object</returns>
        public static HttpRequest<T> URL(string url)
        {
            #if DEBUG
                return new HttpRequest<T>(url);
            #endif

            if (IsValidURL(url))
            {
                return new HttpRequest<T>(url);
            }
            throw new ArgumentException("The URL must be secure Https URL");
        }

        /// <summary>
        /// The current Url assigned to this HttpRequest object
        /// </summary>
        public string CurrentUrl { get => _url; }

        /// <summary>
        /// Indicates if the http operation was successful
        /// </summary>
        public bool IsSuccessful { get => _isSuccessful; }

        public List<T> ResponseValues {  get => _responseValues; }

        /// <summary>
        /// The list of errors from the last http operation in the <error-code, error-message> format
        /// </summary>
        public Dictionary<string, string> Errors
        {
            get
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                foreach(Error e in _errors)
                {
                    errors[e.Type] = e.Message;
                }
                return errors;
            }
        }

        /// <summary>
        /// API response of the last successful POST request
        /// </summary>
        public string PostSuccessResponse { get => _postSuccessResponse; }

        /// <summary>
        /// Set parameters to send with a http request. Auto-cleared after the request is returned. 
        /// </summary>
        /// <param name="key">The name of the parameter</param>
        /// <param name="value">The value of the parameter</param>
        /// <exception cref="ArgumentException">Thrown when adding unauthorized parameters</exception>
        public void AddQueryParams(string key, string value)
        {
            if(key.Equals("_UserId") || key.Equals("_AuthToken"))
            {
                throw new ArgumentException("Unauthorized query parameter");
            }
            else { _queryParams[key] = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">The Url to be assigned to this HttpRequest object</param>
        private HttpRequest(string url)
        {
            _url = url;
            _responseValues = new List<T>();
            _errors = new List<Error>();
            _isSuccessful = false;
            _postSuccessResponse = string.Empty;

            _queryParams = new NameValueCollection()
            {
                ["_UserId"] = "1",
                ["_AuthToken"] = "1"
            };
        }

        /// <summary>
        /// Http GET method to make a GET request to the assigned URL
        /// </summary>
        /// <returns>This HttpRequest object</returns>
        public HttpRequest<T> Get()
        {
            PreRequestSetup();

            try
            {
                WebClient webClient = new WebClient();
                NameValueCollection query = new NameValueCollection();

                foreach (string key in _queryParams.Keys)
                {
                    webClient.QueryString.Add(key, _queryParams[key]);
                }

                byte[] resultBytes = webClient.DownloadData(_url);
                string resultJson = Encoding.UTF8.GetString(resultBytes);

                JavaScriptSerializer js = new JavaScriptSerializer();
                _responseValues = js.Deserialize<List<T>>(resultJson);

                _isSuccessful = true;
            }
            catch(WebException e)
            {
                _errors.Add(new Error() { Type = "Web", Message = e.Message });       
            }
            catch(Exception e)
            {
                _errors.Add(new Error() { Type = "App", Message = e.Message });
            }

            PostRequestConfig();
            return this;
        }

        /// <summary>
        /// Make a Http POST request to the associated URL
        /// </summary>
        /// <returns>This HttpRequest<typeparamref name="T"/> object</returns>
        public HttpRequest<T> Post()
        {
            PreRequestSetup();

            try
            {
                WebClient webClient = new WebClient();

                byte[] resultBytes = webClient.UploadValues(_url, "POST", _queryParams);
                string resultString = Encoding.UTF8.GetString(resultBytes);

                _isSuccessful = true;
                _postSuccessResponse = resultString;
            }
            catch (WebException e)
            {
                _errors.Add(new Error() { Type = "Web", Message = e.Message });
            }
            catch (Exception e)
            {
                _errors.Add(new Error() { Type = "App", Message = e.Message });
            }

            PostRequestConfig();
            return this;
        }
        
        /// <summary>
        /// Makes a Http PUT request to the associated URL
        /// </summary>
        /// <returns>This HttpRequest<typeparamref name="T"/> object</returns>
        public HttpRequest<T> Put()
        {
            return Post();
        }

        /// <summary>
        /// Makes a Http DELETE request to the associated URL
        /// </summary>
        /// <returns>This HttpRequest<typeparamref name="T"/> object</returns>
        public HttpRequest<T> Delete()
        {
            return Post();
        }

        public T JsonToObject(string json)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return (T)js.DeserializeObject(json);
        }

        /**
         * Private utility methods
         */
        private void PreRequestSetup()
        {
            _isSuccessful = false;
            _responseValues.Clear();
            _errors.Clear();
            _postSuccessResponse = string.Empty;
        }

        private void PostRequestConfig()
        {
            NameValueCollection nvc = new NameValueCollection();

            foreach(string key in _queryParams.Keys)
            {
                if(!key.Equals("_UserId") && !key.Equals("_AuthToken"))
                {
                    nvc.Add(key, _queryParams[key]);
                }
            }
            _queryParams = nvc;
        }

        private static bool IsValidURL(string url)
        {
            return url.Split(':')[0].Equals("https");
        }

    }

}
