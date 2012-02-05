using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TrelloNet;


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
            var cards = Api.Get().Cards("4f2bf38d72b7c1293517af86");
            cards.Should().NotBeNull();
            cards.FirstOrDefault().Name.Should().Be("Create strong types for resources currently returning dynamic");
            //cards.FirstOrDefault().
            //Assert.AreEqual("Welcome to Trello!", car);
            //Assert.AreEqual("Trello.net API/Router Board", board["name"]);
        }

        [Test]
        public void get_boards_should_return_boards_authenticated_user_has_access()
        {
            var boards = Api.Get().Boards();
            boards.Should().NotBeNull();
            boards.FirstOrDefault().Id.Should().Be("4f2bf38d72b7c1293517af86");
        }
    }
}
