﻿using System.Linq;
using FluentAssertions;
using NUnit.Framework;


namespace Trello.net.Tests
{
    [TestFixture]
    public class Tests : TestBase
    {
        [Test]
        public void get_card_test()
        {
            //The only way to get cards is to call in and request a board. the board has an array of cards on it.
            //we might want to create C# domain objects for each response type.
            //we prob want to but I have not got around it it just yet.
            var cards = TrelloNet.TrelloWrapper.Get().Cards(TrelloNetBoardId);
            cards.Should().NotBeNull();
            cards.FirstOrDefault(x => x.Id == "4f2ec5f89b7c4ed736a2391b").Name.Should().Be("List of connected systems for routing");
        }

     

        [Test]
        public void get_boards_should_return_boards_authenticated_user_has_access()
        {
            var boards = TrelloNet.TrelloWrapper.Get().Boards();

            boards.Should().NotBeNull();
            //Trello.net API/Router Board this board ID = 4f2bf38d72b7c1293517af86;
            boards.FirstOrDefault(x => x.Id == TrelloNetBoardId).Should().NotBeNull();
        }
    }
}
