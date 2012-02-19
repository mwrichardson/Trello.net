using System;
using FluentAssertions;
using NUnit.Framework;
using TrelloNet;

namespace Trello.net.Tests
{
     [TestFixture]
    public class Get_Card_Tests : TestBase
    {
         [Test]
         public void by_id()
         {
             var card = TrelloWrapper.Get().Card(TrellCardId);
             card.Should().NotBeNull();
             card.IdMembers.Should().NotBeEmpty();

         }
        
    }
}