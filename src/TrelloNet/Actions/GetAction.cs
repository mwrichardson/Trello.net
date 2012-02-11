using System.Collections.Generic;
using System.Linq;
using RestSharp;
using TrelloNet.Domain;
using TrelloNet.Extensions;

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

        //TODO: FIX THIS!!!!

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

        public List<Action> Actions(string boardId, ActionType action)
        {
            //"4f2bf38d72b7c1293517af86"
            var request = new RestRequest("/1/boards/{board_id}", Method.GET);
            request.AddUrlSegment("board_id", boardId);
            request.AddParameter("actions", action.ToString().LowerFirst());
            var board = ServiceManager.Execute<Board>(request);
            var response = board.Actions;
            return response;
        }

        public List<Action> Actions(string boardId, ActionType[] actions)
        {
            //"4f2bf38d72b7c1293517af86"
            var request = new RestRequest("/1/boards/{board_id}", Method.GET);
            request.AddUrlSegment("board_id", boardId);
            request.AddParameter("actions", string.Join(",", actions.ToList().Select(x=>x.ToString().LowerFirst())));
            var board = ServiceManager.Execute<Board>(request);
            var response = board.Actions;
            return response;
        }

        //TODO: FIX THIS!!!! ^^^
        //Clean up overloads....This Actions method(s) is some yuck.

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