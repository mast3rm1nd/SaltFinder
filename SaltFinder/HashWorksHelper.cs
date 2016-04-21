using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SaltFinder
{
    class HashWorksHelper
    {


        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            //MD5 md5 = MD5.Create();
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);

                // step 2, convert byte array to hex string
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                //md5.Clear();
                return sb.ToString().ToLower();
            }
        }

        //public static string FindSalt(string targetHash, string targetPassword)
        //{
        //    char[] allChars = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 
        //                       'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
        //                       'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
        //                       'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
        //                       'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7',
        //                       '8', '9', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*',
        //                       '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', 
        //                       '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'};

        //    for(int length = 1;; length++)
        //        for(string salt = GetInitialSalt(length); salt !=  GetFinalSalt(length);
        //}

        public static string GetInitialSalt(int length)
        {
            char[] allChars = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 
                               'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                               'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                               'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
                               'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7',
                               '8', '9', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*',
                               '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', 
                               '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'};

            string salt = "";
            for (int i = 0; i < length; i++)
                salt += allChars[0].ToString();

            return salt;
        }

        public static string GetFinalSalt(int length)
        {
            char[] allChars = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 
                               'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                               'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                               'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
                               'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7',
                               '8', '9', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*',
                               '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', 
                               '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'};

            string salt = "";
            for (int i = 0; i < length; i++)
                salt += allChars[allChars.Length].ToString();

            return salt;
        }
    }
}
