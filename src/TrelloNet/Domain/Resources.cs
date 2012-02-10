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

        public IEnumerable<Card> Cards(string boardId)
        {
            var request = new RestRequest("/1/boards/{board_id}/cards", Method.GET);
        
            //request.AddParameter("cards", "all");
            request.AddUrlSegment("board_id", boardId);
            var response = _serviceManager.Execute<List<Card>>(request);
            return response;
        }

        public Board Actions(string boardId)
        {
            var request = new RestRequest("/1/boards/{board_id}", Method.GET);
            request.AddParameter("actions", "all");
            var response = _serviceManager.Execute<Board>(request);
            return response;
        }

        public IEnumerable<Board> Boards()
        {
            var request = new RestRequest
            {
                Resource = "/1/members/me/boards"
            };
            request.AddParameter("actions", "all");
            var response = _serviceManager.Execute<List<Board>>(request);
            return response;
        }
    }
}