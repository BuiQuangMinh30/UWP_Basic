
using Newtonsoft.Json;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelloNewtonsoft
{
    class Program
    {
        private static string ApiUrl = "https://music-i-like.herokuapp.com/api/v1/accounts";
        static void Main(string[] args)
        {
            var account = new Account()
            {
                firstName = "Bui",
                lastName = "Minh",
                password = "123123",
                address = "Hanoi",
                phone = "0912345678",
                avatar = "https://res.cloudinary.com/dftxlzy81/image/upload/v1642645880/vov_mua_giai_nhiet_ha_noi_9_zuon_gxycq8.jpg",
                gender = 1,
                email = "minh@gmail.com",
                birthday = "2002-10-30"
            };
            Process(account);
            Console.ReadLine();
        }

        static async void Process(Account account)
        {
            // object -> json string.            
            var jsonString = JsonConvert.SerializeObject(account);
            Console.WriteLine("Serialize object");
            Console.WriteLine(jsonString);

            HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(ApiUrl);

            HttpContent contentToSend = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(ApiUrl, contentToSend);
            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                // good case.
                var content = await result.Content.ReadAsStringAsync();
                Account returnAccount = JsonConvert.DeserializeObject<Account>(content);
                Console.WriteLine(returnAccount.id);
                Console.WriteLine(returnAccount.firstName);
            }
            else
            {
                // bad case. show error cho người dùng.
                Console.WriteLine("Error 500 ");
            }
        }

    }
}
