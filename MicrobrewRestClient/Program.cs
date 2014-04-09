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
        private const string JSONPATH = @"C:\Users\jfa\Documents\JSON\";
        private static string _userToken; 

        public static void Main(string[] args)
        {
            Console.WriteLine("Logging in");
            Login("johnfredrik", "test");

            Console.WriteLine("Adding Origins");
            AddOrigins();
            Console.WriteLine("Origins Added");
            Console.WriteLine("Adding Suppliers");
            AddSupplier();
            Console.WriteLine("Suppliers Added");
            Console.WriteLine("Adding Hops");
            AddHops();
            Console.WriteLine("Hops Added");
            Console.WriteLine("Adding Fermentables");
            AddFermentables();
            Console.WriteLine("Fermentables Added");
            Console.WriteLine("Adding Yeasts");
            AddYeasts();
            Console.WriteLine("Yeasts Added");
            Console.WriteLine("Adding Others");
            AddOthers();
            Console.WriteLine("Others Added");
            
                Console.WriteLine("Adding Beer");
                AddBeer();
                Console.WriteLine("Beer Added");
           
            Console.WriteLine("-----------------");
                
            Console.WriteLine("Press Enter to Exit");
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

        private static void AddFermentables()
        {
            using (var file = new StreamReader(JSONPATH + "fermentable.json"))
            {
                string jsonString = file.ReadToEnd();
                //  Console.WriteLine(jsonString);
                var request = new RestRequest("fermentables/", Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization-Token", _userToken);
                request.AddParameter("text/json", jsonString, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;

                var response = restClient.Execute(request);
                Console.WriteLine(response.StatusCode);
            }
        }

        private static void AddYeasts()
        {
            using (var file = new StreamReader(JSONPATH + "yeast.json"))
            {
                string jsonString = file.ReadToEnd();
                //  Console.WriteLine(jsonString);
                var request = new RestRequest("yeasts/", Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization-Token", _userToken);
                request.AddParameter("text/json", jsonString, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;

                var response = restClient.Execute(request);
                Console.WriteLine(response.StatusCode);
            }
        }

        private static void AddOthers()
        {
            using (var file = new StreamReader(JSONPATH + "other.json"))
            {
                string jsonString = file.ReadToEnd();
                //  Console.WriteLine(jsonString);
                var request = new RestRequest("others/", Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization-Token", _userToken);
                request.AddParameter("text/json", jsonString, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;

                var response = restClient.Execute(request);
                Console.WriteLine(response.StatusCode);
            }
        }

        private static void AddOrigins()
        {
            using (var file = new StreamReader(JSONPATH + "origin.json"))
            {
                string jsonString = file.ReadToEnd();
                //  Console.WriteLine(jsonString);
                var request = new RestRequest("origins/", Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization-Token", _userToken);
                request.AddParameter("text/json", jsonString, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;

                var response = restClient.Execute(request);
                Console.WriteLine(response.StatusCode);
            }
        }

        private static void AddSupplier()
        {
            using (var file = new StreamReader(JSONPATH + "supplier.json"))
            {
                string jsonString = file.ReadToEnd();
                //  Console.WriteLine(jsonString);
                var request = new RestRequest("suppliers/", Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization-Token", _userToken);
                request.AddParameter("text/json", jsonString, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;

                var response = restClient.Execute(request);
                Console.WriteLine(response.StatusCode);
            }
        }

        private static void AddBeer()
        {
            using (var file = new StreamReader(JSONPATH + "beer.json"))
            {
                string jsonString = file.ReadToEnd();
                //  Console.WriteLine(jsonString);
                var request = new RestRequest("beers/", Method.POST);
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
