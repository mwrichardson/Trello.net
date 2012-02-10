using System;
using System.Collections.Generic;


namespace TrelloNet.Domain
{
    public class Board : Entity
    {
        public string Name { get; set; }

        public List<Action> Actions { get; set; }
        //public string IdMemberCreator { get; set; }
        //public IEnumerable<CardData> Data { get; set; }
        //public string Type { get; set; }
        //public DateTime Date { get; set; }
    }

    public class Action : Entity
    {
        public string IdMemberCreator { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

        public Data Data { get; set; }
        
    }

    public class Data : Entity
    {

         //"card": {
         //               "id": "4f2abcd7bb07915e11835cff",
         //               "name": "Need help?",
         //               "desc": "We got you covered: https://trello.com/help\n\nYou can get to the help page any time from the 'i' button in the header."
         //           },
         //           "board": {
         //               "id": "4f2abcd7bb07915e11835ca5",
         //               "name": "Welcome Board"
         //           },
         //           "old": {
         //               "desc": "We got you covered: https://trello.com/help"
         //           }
    }
}