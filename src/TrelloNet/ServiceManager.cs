using System;
using System.Globalization;
using System.Web.Script.Serialization;
using RestSharp;

namespace TrelloNet
{
    public class ServiceManager
    {
        private RestClient _restClient;
        
        public ServiceManager(string oauthToken, string key)
        {
            _restClient = new RestClient("https://api.trello.com")
                              {
                                  Authenticator = new OAuth2UriQueryParameterAuthenticator(oauthToken)

                              };
            _restClient.AddDefaultParameter("key", key);
        }


        public T Execute<T>(RestRequest request)  where T : new()
        {
            var response = _restClient.Execute<T>(request);
            return response.Data;

            //Console.WriteLine(response.Content.ToString(CultureInfo.InvariantCulture));

            //var javaScriptSerializer = new JavaScriptSerializer();
            //var deserialized = javaScriptSerializer.Deserialize<T>(response.Content);
            //return deserialized;
        }
    }
}