using System.Collections.Generic;
using RestSharp;
using TrelloNet.Domain;

namespace TrelloNet.Actions
{
    public class GetAction : BaseAction
    {
        public GetAction(ServiceManager serviceManager) : base(serviceManager)
        {
        }

        public IEnumerable<Card> Cards(string boardId)
        {
            var request = new RestRequest("/1/boards/{board_id}/cards", Method.GET);

            //request.AddParameter("cards", "all");
            request.AddUrlSegment("board_id", boardId);
            var response = ServiceManager.Execute<List<Card>>(request);
            return response;
        }

        public Board Actions(string boardId)
        {
            var request = new RestRequest("/1/boards/{board_id}", Method.GET);
            request.AddParameter("actions", "all");
            var response = ServiceManager.Execute<Board>(request);
            return response;
        }

        public IEnumerable<Board> Boards()
        {
            var request = new RestRequest
            {
                Resource = "/1/members/me/boards"
            };
            //request.AddParameter("actions", "all");
            var response = ServiceManager.Execute<List<Board>>(request);
            return response;
        }
    }
}