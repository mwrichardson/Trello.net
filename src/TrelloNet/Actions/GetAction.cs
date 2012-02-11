using System.Collections.Generic;
using RestSharp;
using TrelloNet.Domain;

namespace TrelloNet.Actions
{
    public class GetAction
    {
        public GetAction()
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


        public List<Action> Actions(string boardId)
        {
            //"4f2bf38d72b7c1293517af86"
            var request = new RestRequest("/1/boards/{board_id}", Method.GET);
            request.AddUrlSegment("board_id", boardId);
            request.AddParameter("actions", "all");
            var board = ServiceManager.Execute<Board>(request);
            var response = board.Actions;
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