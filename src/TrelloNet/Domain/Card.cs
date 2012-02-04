using System;
using System.Collections.Generic;

namespace TrelloNet.Domain
{
    public class Card : Entity
    {

        public string IdMemberCreator { get; set; }
        public IEnumerable<CardData> Data { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }
}