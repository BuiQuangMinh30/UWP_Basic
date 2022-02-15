using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_UWP.Config
{
    class ApiConfig
    {
        public static string ApiDomain = "https://music-i-like.herokuapp.com";
        public static string MediaType = "application/json";

        public static string SongPath = "/api/v1/songs";
        public static string MySongPath = "/api/v1/songs/mine";

        public static string AccountPath = "/api/v1/accounts";
        public static string AccountLoginPath = "/api/v1/accounts/authentication";
    }
}
