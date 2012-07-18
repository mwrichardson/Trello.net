using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloNet.Domain
{
    public class Badges
    {
        public int Votes { get; set; }
        private DateTime? _Due;

        public DateTime? Due
        {
            get { return _Due; }
            set { _Due = value; }
        }
    }
}
