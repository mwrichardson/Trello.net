using System;
using FluentAssertions;
using NUnit.Framework;
using TrelloNet;
using TrelloNet.Domain;

namespace Trello.net.Tests
{
    [TestFixture]
    public class Get_Member_Tests : TestBase
    {
        [Test]
        public void member_by_username()
        {
            var member = TrelloWrapper.Get().Member(TrelloMemberUsername);
            member.Should().NotBeNull();
            member.FullName.Should().Be("Eric Polerecky");
            member.Initials.Should().Be("EP");
        }


        [Test]
        public void member_by_id()
        {
            var member = TrelloWrapper.Get().Member(TrelloMemberId);
            member.Should().NotBeNull();
            member.FullName.Should().Be("Eric Polerecky");
            member.Initials.Should().Be("EP");
            member.Cards.Should().BeEmpty();
        }


        [Test]
        public void member_cards()
        {
            var member = TrelloWrapper.Get().Member(TrelloMemberId, CardType.All);
            member.Should().NotBeNull();
            member.FullName.Should().Be("Eric Polerecky");
            member.Initials.Should().Be("EP");
            member.Cards.Should().NotBeEmpty();
            member.Cards.ForEach(x => Console.WriteLine(x.Name));
        }


      
     

    }
}