using System;
using System.Collections.Generic;

namespace TrelloNet.Domain
{
    public class Card : Entity
    {

        //"id": "4eea503791e31d1746000080",
        //"name": "Finish my awesome application",
        //"idList": "4eea4ffc91e31d174600004a",
        //"url": "https://trello.com/card/board/finish-my-awesome-application/4eea4ffc91e31d1746000046/4eea503791e31d1746000080"
        public string Name { get; set; }
        public string Url { get; set; }
        public string IdList { get; set; }



        //This is actions...ooops wrong place.
        //public string IdMemberCreator { get; set; }
        //public IEnumerable<CardData> Data { get; set; }
        //public string Type { get; set; }
        //public DateTime Date { get; set; }
    }
}