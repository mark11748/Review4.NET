using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Review4_.NET.Models
{
    public class Repo
    {
        private static string _visibility { get; set; }
        private static string _affiliation { get; set; }


        public Repo()
        {
            _visibility = "public";
            _affiliation = "owner:mark11748";
        }

        public static List<Repo> GetRepos()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("/mark11748/repos", Method.GET);
            request.AddParameter("visibility", _visibility);
            request.AddParameter("affiliation", _affiliation);

            client.Authenticator = new HttpBasicAuthenticator("{{Account SID}}", "{{Auth Token}}");

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var repoList = JsonConvert.DeserializeObject<List<Repo>>(jsonResponse["messages"].ToString());
            return repoList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient client,RestRequest request)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
