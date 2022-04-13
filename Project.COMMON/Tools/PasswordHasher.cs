using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.Tools
{
    //password hash işlemleri 
    //password hash
    public static class PasswordHasher
    {
        public static string Crypt(string c)
        {
            char[] charArray = c.ToCharArray();
            string hashedData = "";

            foreach (char item in charArray)
            {
                hashedData += Convert.ToChar(item + 3).ToString();
            }
            return hashedData;
        }
        //DeleteCrypt
        public static string DeCrypt(string c)
        {
            char[] charArray = c.ToCharArray();
            string decryptedData = "";

            foreach (char item in charArray)
            {
                decryptedData += Convert.ToChar(item - 3).ToString();
            }
            return decryptedData;
        }
    }
}
