using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WineTravelBlog.Models;

namespace WineTravelBlog.Models
{
    public class WineCategory
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        

        public static List<WineCategory> GetCategories()
        {
            var client = new RestClient("http://services.wine.com/api/beta2/service.svc/json");
            var request = new RestRequest("categorymap?filter=categories(490)&apikey=" + EnvironmentVariables.ApiKey + "");

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            Console.WriteLine(response);
            Console.WriteLine(jsonResponse);
            var categoryList = JsonConvert.DeserializeObject<List<WineCategory>>(jsonResponse["Categories"].ToString());
            return categoryList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

    }

}
