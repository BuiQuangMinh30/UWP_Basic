using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2012E_Helloworld.Config
{
    class ApiConfig
    {
        public static string ApiDomain = "https://music-i-like.herokuapp.com/api";
        public static string AccountPath = "/v1/accounts";

        public static string SongPath = "/v1/songs";
        public static string MySongPath = "/v1/songs/mine";

        public static string MediaType = "application/json";
        public static string AccountLoginPath = "/v1/accounts/authentication";
    }
}
