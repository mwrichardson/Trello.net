using System;
using System.Globalization;
using System.Web.Script.Serialization;
using NUnit.Framework;
using RestSharp;


namespace Trello.net.Tests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void test()
        {
            var request = new RestRequest
                              {
                                  Resource = "/1/members/me/boards"
                              };

            var client = new RestClient("https://api.trello.com")
                             {
                                 Authenticator = new OAuth2UriQueryParameterAuthenticator("02c7301e3c04f2e2841846bdece6d0db4be9e8cb078b87aa0923665b1fad22e0")

                             };
            client.AddDefaultParameter("key", "1bf6786c573d795f2b7fc8837c008aab");
            var response = client.Execute<dynamic>(request);
            Console.WriteLine(response.Content.ToString(CultureInfo.InvariantCulture));

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var d = jss.Deserialize<dynamic>(response.Content);

            Console.WriteLine(d[0]["id"]);


            var cards = TrelloNet.Get().Cards("");

        }
    }
}
