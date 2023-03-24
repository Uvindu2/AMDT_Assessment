using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMDT_Assessment.Common
{
    public static class CommonMethods
    {
        //Key
        public static string key = "abcefs@@fxsbdv@";

        //Convert to Encrypt Password
        public static string CovertToEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";

            password += key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }
        //Convert to Decrypt Password

        public static string CovertToDecrypt(string base64EncodeData)

        {
            if (string.IsNullOrEmpty(base64EncodeData)) return "";

            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result=Encoding.UTF8.GetString(base64EncodeBytes);
            result=result.Substring(0,result.Length - key.Length);
            return result;

   
        }
    }
}
