using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Script.Serialization;
using RestSharp;

namespace TrelloNet.Domain
{
    public class Resources
    {
        internal static ServiceManager _serviceManager;

        public void SetServiceManager(ServiceManager serviceManager)
        {

            _serviceManager = serviceManager;
        }

        public dynamic Cards(string boardId)
        {
            var request = new RestRequest("/1/boards/{board_id}", Method.GET);
        
            request.AddParameter("cards", "all");
            request.AddUrlSegment("board_id", boardId);
            var response = _serviceManager.Execute(request);
            return response;
        }


        public dynamic Boards()
        {
            var request = new RestRequest
            {
                Resource = "/1/members/me/boards"
            };
            var response = _serviceManager.Execute(request);
            return response;
        }
    }
}