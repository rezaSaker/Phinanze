using System;

namespace Phinanze.Models.DBContext
{
    public class DB: Host
    {
        private const string EXT = ".php";

        public static readonly Func<string, string> GetAll_Url = modelName => CreateUrl("get", modelName);
        public static readonly Func<string, string> GetBy_Url = modelName => CreateUrl("find", modelName);
        public static readonly Func<string, string> Insert_Url = modelName => CreateUrl("insert", modelName);
        public static readonly Func<string, string> Update_Url = modelName => CreateUrl("update", modelName);
        public static readonly Func<string, string> Delete_Url = modelName => CreateUrl("delete", modelName);
        public static readonly string Authentication_Url = Host.URL + "authenticate" + EXT;

        private static string CreateUrl(string type, string modelName)
        {
            return Host.URL + type + modelName + EXT;
        }
    }
}
