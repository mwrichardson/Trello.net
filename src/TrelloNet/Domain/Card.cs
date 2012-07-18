using System.Collections.Generic;
using System;
using System.Linq;

namespace TrelloNet.Domain
{
    public class Card : Entity
    {
        private Board _Board;
        public Board Board
        {
            get
            {
                if (_Board == null)
                {
                    _Board = TrelloWrapper.Get().Board(IdBoard);
                }

                return _Board;
            }
            internal set { _Board = value; }
        }

        public DateTime CreationDate
        {
            get
            {
                return Actions.Single(a => a.Type == ActionType.CreateCard || a.Type == ActionType.ConvertToCardFromCheckItem).Date;
            }
        }

        public string IdBoard { get; set; }

        public Badges Badges { get; set; }

        public TimeSpan? TimeUntilDue
        {
            get
            {
                return (Badges.Due != null)
                    ? (TimeSpan?)(Badges.Due.Value.Date - DateTime.Now.Date)
                    : null;
            }
        }

        public TimeSpan? OverdueBy
        {
            get
            {
                return (Badges.Due != null)
                    ? (TimeSpan?)(DateTime.Now.Date - Badges.Due.Value.Date)
                    : null;
            }
        }

        public TimeSpan? InferredEstimate
        {
            get
            {
                return (Badges.Due != null)
                    ? (TimeSpan?)(Badges.Due.Value.Date - CreationDate.Date)
                    : null;
            }
        }

        public List<Action> Actions { get; set; }

        public string Name { get; set; }
        public string Desc { get; set; }
        public string Url { get; set; }
        public string IdList { get; set; }
        public bool Closed { get; set; }
        public string IdShort { get; set; }

        //TODO: find a way to lazy load the members.
        //TODO: or something better than this.
        public List<string> IdMembers { get; set; }
    }
}