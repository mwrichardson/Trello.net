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



        public List<Action> Actions(string boardId)
        {
            return Actions(boardId, null, null);
        }

        public List<Action> Actions(string boardId, ActionType action)
        {
            return Actions(boardId, action, null);
        }

        public List<Action> Actions(string boardId, ActionType[] actions)
        {
            return Actions(boardId, null, actions);
        }

        public List<Action> Actions(string boardId,  ActionType? action, ActionType[] actions)
        {
            var request = new RestRequest("/1/boards/{board_id}", Method.GET);
            request.AddUrlSegment("board_id", boardId);
            
            if(actions!=null)
                request.AddParameter("actions", string.Join(",", actions.ToList().Select(x => x.ToString().LowerFirst())));

            if(action.HasValue)
                request.AddParameter("actions", action.ToString().LowerFirst());


            if(!action.HasValue && actions==null)
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