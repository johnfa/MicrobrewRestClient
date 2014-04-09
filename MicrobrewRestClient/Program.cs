using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrobrewRestClient
{
    public class Program
    {
        private static readonly IRestClient restClient = new RestClient("http://localhost:54663");
        private const string JSONPATH = @"json\";
        private static string _userToken; 

        public static void Main(string[] args)
        {
            Console.WriteLine("Logging in");
            Login("johnfredrik", "test");
            AddHops();
            Console.ReadLine();
        }

        private static void  Login(string username, string password)
        {
            var byteToken = Encoding.UTF8.GetBytes(username + ":" + password);
            var encodedToken = Convert.ToBase64String(byteToken);
            var request = new RestRequest("users/login",Method.POST);
            request.AddHeader("Authorization", "Basic " + encodedToken);

            var response = restClient.Execute(request);
            _userToken = response.Headers.Where(h => h.Name.Equals("Authorization-Token")).SingleOrDefault().Value.ToString();
           

        }

        private static void AddHops()
        {
            using (var file = new StreamReader(JSONPATH + "hop.json"))
            {
                string jsonString = file.ReadToEnd();
              //  Console.WriteLine(jsonString);
                var request = new RestRequest("hops/", Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization-Token", _userToken);
                request.AddParameter("text/json", jsonString, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;

                    var response = restClient.Execute(request);
                   Console.WriteLine(response.StatusCode);
            }
        }
    }
}
