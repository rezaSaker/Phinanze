using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models.Repositories.Http
{
    public class HttpResponseTypes
    {
        public const string SingleIModelType = "SingleIModel";
        public const string ListOfIModelType = "ListOfIModel";
        public const string StringType = "String";

        public string Type { get; private set; }

        public static HttpResponseTypes SingleIModel()
        {
            return new HttpResponseTypes(SingleIModelType);
        }

        public static HttpResponseTypes ListOfIModel()
        {
            return new HttpResponseTypes(ListOfIModelType);
        }

        public static HttpResponseTypes String()
        {
            return new HttpResponseTypes(StringType);
        }

        private HttpResponseTypes(string resType)
        {
            Type = resType;
        }
    }
}
