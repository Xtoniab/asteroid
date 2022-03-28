using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Proyecto26;
using UnityEngine;

namespace DefaultNamespace
{

    [Serializable]
    public class UserData
    {
        public string username;
        public int value;

        public override string ToString(){
            return JsonUtility.ToJson (this, true);
        }
    }
    
    public static class RestApiClient
    {
        private const string url = "ajasfj2japsjfjko";
        private const string BasePath = "https://xtoniab.com/api";


        static RestApiClient()
        {
            RestClient.DefaultRequestHeaders["Access-Control-Allow-Origin"] = "*";
            RestClient.DefaultRequestHeaders["Access-Control-Allow-Methods"] = "DELETE, POST, GET, OPTIONS";
            RestClient.DefaultRequestHeaders["Access-Control-Allow-Headers"] = "Content-Type, Authorization, X-Requested-With";
        }

        public static void GetTopPlayers(Action<UserData[]> callback){
      
            RestClient.GetArray<UserData>(BasePath + "/scores/highscores?limit=50").Then(res =>
            {
                callback?.Invoke(res);
            });
        }

        public static void GetHighestScore(string username, Action<int> callback)
        {
            RestClient.GetArray<UserData>(BasePath + $"/scores/top/1?username={username}").Then(res =>
            {
                if (res.Length == 0)
                {
                    callback?.Invoke(0);
                }
                
                callback?.Invoke(res[0].value);
            });
        }
        
        public static void SetHighestScore(string username, int score)
        {
            var md5 = CreateMD5($"{username}_{score}_{url}");
           
            var currentRequest = new RequestHelper {
                Params = new Dictionary<string, string>()
                {
                    ["key"] = md5.ToLower()
                },
                Uri = BasePath + "/scores",
                Body = new UserData {
                    username = username,
                    value = score
                }
            };
            RestClient.Post<UserData>(currentRequest)
                .Then(res => RestClient.ClearDefaultParams());
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        
        /// <summary>
        /// Converts an array of bytes into a hexadecimal string 
        /// </summary>
        /// <param name="hashValue"></param>
        /// <returns></returns>
        public static string GetHexStringFromHash(byte[] hashValue) {
            string hexString = String.Empty;

            foreach (byte b in hashValue) {
                hexString += b.ToString("x2");
            }

            return hexString;
        }
    }
}