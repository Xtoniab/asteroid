using System;
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
        private const string BasePath = "https://sarchuk.ru/api";


        static RestApiClient()
        {
            RestClient.DefaultRequestHeaders["Access-Control-Allow-Origin"] = "*";
            RestClient.DefaultRequestHeaders["Access-Control-Allow-Methods"] = "DELETE, POST, GET, OPTIONS";
            RestClient.DefaultRequestHeaders["Access-Control-Allow-Headers"] = "Content-Type, Authorization, X-Requested-With";
        }
        public static void GetTop10Players(Action<UserData[]> callback){
      
            RestClient.GetArray<UserData>(BasePath + "/scores/highscores").Then(res =>
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
            var currentRequest = new RequestHelper {
                Uri = BasePath + "/scores",
                Body = new UserData {
                    username = username,
                    value = score
                }
            };
            RestClient.Post<UserData>(currentRequest)
                .Then(res => RestClient.ClearDefaultParams());
        }
    }
}