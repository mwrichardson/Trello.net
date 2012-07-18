using System.Collections.Generic;
using System.Linq;
using RestSharp;
using TrelloNet.Domain;
using TrelloNet.Extensions;

namespace TrelloNet.Actions
{
    public class GetAction
    {

        public Card Card(string CardId, ActionType[] actions = null)
        {
            var request = CreateRequest("/1/cards/{card_id}");
            request.AddUrlSegment("card_id", CardId);
            AddActionsParameter(request, actions);
            var response = ServiceManager.Execute<Card>(request);
            return response;
        }

        public IEnumerable<Card> Cards(string boardId, ActionType[] actions = null)
        {
            return Cards(boardId, null, actions);
        }

        public IEnumerable<Card> Cards(string boardId, Board boardInstance, ActionType[] actions = null)
        {
            var request = CreateRequest("/1/boards/{board_id}/cards");
            request.AddParameter("cards", "all");
            request.AddUrlSegment("board_id", boardId);

            AddActionsParameter(request, actions);

            var response = ServiceManager.Execute<List<Card>>(request);

            if (boardInstance != null && response != null)
            {
                foreach (var card in response)
                {
                    card.Board = boardInstance;
                }
            }

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
            var request = CreateRequest("/1/boards/{board_id}");
            request.AddUrlSegment("board_id", boardId);

            AddActionsParameter(
                request,
                (action != null)
                    ? new[] { action.Value }
                    : actions);

            var board = ServiceManager.Execute<Board>(request);
            var response = board.Actions;
            return response;
        }

        public Board Board(string boardId, ActionType[] actions = null)
        {
            var request = CreateRequest(System.String.Format("/1/boards/{0}", boardId));

            AddActionsParameter(request, actions);

            var response = ServiceManager.Execute<Board>(request);
            return response;
        }
        
        public IEnumerable<Board> Boards(ActionType[] actions = null)
        {
            var request = CreateRequest("/1/members/me/boards");
            AddActionsParameter(request, actions);
            var response = ServiceManager.Execute<List<Board>>(request);
            return response;
        }

        public Member Member(string usernameOrId, CardType cardType = CardType.None)
        {
            var request = new RestRequest("/1/members/{username}", Method.GET);
            request.AddUrlSegment("username", usernameOrId);

            request.AddParameter("cards", cardType.ToString().ToLower());

            var member = ServiceManager.Execute<Member>(request);
            return member;
        }

        private static RestRequest CreateRequest(string resource, Method method = Method.GET)
        {
            return new RestRequest(resource, Method.GET)
            {
                DateFormat = "yyyy-MM-ddTHH:mm:ss.fffZ" // This enables dates to be deserialized properly
            };
        }

        private static void AddActionsParameter(RestRequest request, ActionType[] actions)
        {
            request.AddParameter("actions",
                (actions != null) ? string.Join(",", actions.Select(x => x.ToString().Replace("_", ":").LowerFirst()))
                : "all");
        }
    }
}