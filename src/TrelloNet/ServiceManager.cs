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


        public dynamic Execute(RestRequest request)
        {
            var response = _restClient.Execute<dynamic>(request);
            Console.WriteLine(response.Content.ToString(CultureInfo.InvariantCulture));

            var javaScriptSerializer = new JavaScriptSerializer();
            var deserialized = javaScriptSerializer.Deserialize<dynamic>(response.Content);
            return deserialized;
        }
    }
}