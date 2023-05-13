using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections.Specialized;

namespace Phinanze.Models.Repositories.Http
{
    /// <summary>
    /// A class to inititate and handle HTTP web requests
    /// </summary>
    /// <typeparam name="T">Genric of IModel type</typeparam>
    public class HttpRequest<T> where T : IModel
    {
        //Fields
        private string _url;
        private NameValueCollection _defaultRequestParams;
        private HttpResponseTypes _responseType;

        /// <summary>
        /// Creates a new HttpRequest object with the given URL. The URL cannot be modified later. 
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
        public bool IsSuccessful { get; private set; }

        /// <summary>
        /// The response returned from the last HTTP request, if ResponseType is ListOfIModel
        /// </summary>
        public List<T> ResponseModelList { get; private set; }

        /// <summary>
        /// The response returned from the last HTTP request, if ResponseType is SingleIModel
        /// </summary>
        public T ResponseModel { get; private set; }

        /// <summary>
        /// The response returned from the last HTTP request, if ResponseType is String
        /// </summary>
        public string ResponseString { get; private set; }

        /// <summary>
        /// The list of errors from the last http operation in the <\error-code, error-message> format
        /// </summary>
        public Dictionary<string, string> Errors { get; private set; }

        /// <summary>
        /// NameValueCollection object to add parameters to send with HTTP request. 
        /// Auto-cleared after the request is completed. 
        /// </summary>
        public NameValueCollection RequestParams { get; private set; }

        public HttpResponseTypes GetResponseType { get => _responseType; }

        private HttpRequest(string url)
        {
            _url = url;
            ResponseModelList = new List<T>();
            Errors = new Dictionary<string, string>();
            RequestParams = new NameValueCollection();
            IsSuccessful = false;
            _responseType = null;

            _defaultRequestParams = new NameValueCollection()
            {
                ["_UserId"] = "1",
                ["_AuthToken"] = "1"
            };
        }

        public HttpRequest<T> ResponseType(HttpResponseTypes resType)
        {
            _responseType = resType;
            return this;
        }

        /// <summary>
        /// Http GET method to make a GET request to the assigned URL
        /// </summary>
        /// <returns>This HttpRequest object</returns>
        public HttpRequest<T> Get()
        {   
            PreRequestConfig();

            try
            {
                WebClient webClient = new WebClient();

                foreach(string key in RequestParams.Keys)
                {
                    webClient.QueryString.Add(key, RequestParams[key]);
                }
                foreach(string key in _defaultRequestParams.Keys)
                {
                    webClient.QueryString.Add(key, _defaultRequestParams[key]);
                }

                byte[] resultBytes = webClient.DownloadData(_url);

                ProcessResponse(resultBytes);
                PostRequestConfig();
            }
            catch(WebException e)
            {
                Errors.Add("Web", e.Message);       
            }
            catch(Exception e)
            {
                Errors.Add("App", e.Message);
            }
            return this;
        }

        /// <summary>
        /// Make a Http POST request to the associated URL
        /// </summary>
        /// <returns>This HttpRequest<typeparamref name="T"/> object</returns>
        public HttpRequest<T> Post()
        {
            PreRequestConfig();

            try
            {
                WebClient webClient = new WebClient();

                foreach(string key in _defaultRequestParams.Keys)
                {
                    RequestParams.Add(key, _defaultRequestParams[key]);
                }

                byte[] resultBytes = webClient.UploadValues(_url, "POST", RequestParams);

                ProcessResponse(resultBytes);
                PostRequestConfig();
        }
            catch (WebException e)
            {
                Errors.Add("Web", e.Message);
            }
            catch (Exception e)
            {
                Errors.Add("App", e.Message);
            }
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

        private void ProcessResponse(byte[] bytes)
        {
            string responseStr = Encoding.UTF8.GetString(bytes);
            JavaScriptSerializer js = new JavaScriptSerializer();

            if (_responseType.Type == HttpResponseTypes.ListOfIModelType)
            {
                ResponseModelList = js.Deserialize<List<T>>(responseStr); ;
                ResponseModel = default(T);
                ResponseString = responseStr;
            }
            else if (_responseType.Type == HttpResponseTypes.SingleIModelType)
            {
                ResponseModel = js.Deserialize<T>(responseStr);
                ResponseModelList.Add(ResponseModel);
                ResponseString = responseStr;
            }
            else if (_responseType.Type == HttpResponseTypes.StringType)
            {
                ResponseString = responseStr;
            }
            IsSuccessful = true;
        }

        /// <summary>
        /// Configuration prior to initiating a HTTP request
        /// </summary>
        private void PreRequestConfig()
        {
            if (_responseType == null)
            {
                throw new ArgumentNullException("ResponseType must be selected before making a HTTP request");
            }

            IsSuccessful = false;
            ResponseModelList.Clear();
            ResponseModel = default(T);
            ResponseString = null;
            Errors.Clear();
        }

        /// <summary>
        /// Configuration after a HTTP request is completed
        /// </summary>
        private void PostRequestConfig()
        {
            RequestParams.Clear();
        }

        /// <summary>
        /// Checkes if a url is of acceptable format
        /// </summary>
        /// <param name="url"></param>
        private static bool IsValidURL(string url)
        {
            return url.Split(':')[0].Equals("https");
        }

    }

}
