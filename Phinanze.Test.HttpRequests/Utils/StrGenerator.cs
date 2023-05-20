using System;

namespace Phinanze.Test.App.Utils
{
    public class StrGenerator
    {
        public static string Const(int length = 12)
        {
            string str = "";
            string chars = "123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

            int index = 0;
            for (int i = 0; i < length; i++, index++)
            {
                if (index % 61 == 0) index = 0;
                str += chars[index];
            }
            return str;
        }

        public static string Rand(int length = 12)
        {
            string str = "";
            string chars = "123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                str += chars[random.Next(0, 61)];
            }
            return str;
        }
    }
}
