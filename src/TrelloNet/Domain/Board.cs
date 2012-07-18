using System.Collections.Generic;
using System.Linq;
using System;

namespace TrelloNet.Domain
{
    public class Board : Entity, IEquatable<Board>
    {
        public string Name { get; set; }

        private List<Action> _Actions;
        public List<Action> Actions
        {
            get
            {
                if (_Actions == null)
                {
                    _Actions = TrelloWrapper.Get().Actions(Id).ToList();
                }

                return _Actions;
            }
            internal set { _Actions = value; }
        }

        public DateTime CreationDate
        {
            get
            {
                var boardCreated = Actions.FirstOrDefault(a => a.Type == ActionType.CreateBoard);

                return (boardCreated != null)
                    ? boardCreated.Date
                    : Actions.Min(a => a.Date);
            }
        }

        //public string IdMemberCreator { get; set; }

        private List<Card> _Cards;
        public List<Card> Cards
        {
            get
            {
                if (_Cards == null)
                {
                    _Cards = TrelloWrapper.Get().Cards(Id, this).ToList();
                }

                return _Cards;
            }
        }
        //public string Type { get; set; }
        //public DateTime Date { get; set; }

        public bool Equals(Board other)
        {
            return this.Id == other.Id;
        }
    }
}