using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using T2012E_Helloworld.Config;
using T2012E_Helloworld.Empty;

namespace T2012E_Helloworld.Service
{
    public class SongService
    {
        public void Create()
        {

        }

        public async Task<List<Song>> GetList()
        {
            List<Song> listSong = new List<Song>();
            using (HttpClient httpClient = new HttpClient())
            {
              
                var result = await httpClient.GetAsync($"{ ApiConfig.ApiDomain}{ApiConfig.SongPath}");
                var content = await result.Content.ReadAsStringAsync();
                
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    listSong = JsonConvert.DeserializeObject<List<Song>>(content);
                }
                else
                { 
                    Console.WriteLine("Error 500");
                }
            }
            return listSong;
        }
        
        public async Task<List<Song>> GetMyList()
        {
            List<Song> listSong = new List<Song>();
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {App.currentCredential.access_token}");
                var result = await httpClient.GetAsync($"{ ApiConfig.ApiDomain}{ApiConfig.MySongPath}");
                var content = await result.Content.ReadAsStringAsync();

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    listSong = JsonConvert.DeserializeObject<List<Song>>(content);
                }
                else
                {
                    Console.WriteLine("Error 500");
                }
            }
            return listSong;
        
        }
    }
}
