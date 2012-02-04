using System;
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
            dynamic board = Api.Get().Cards("4f2bf38d72b7c1293517af86");
            Assert.AreEqual("Welcome to Trello!", board["cards"][0]["name"]);
            Assert.AreEqual("Trello.net API/Router Board", board["name"]);
        }

        [Test]
        public void get_boards_should_return_boards_authenticated_user_has_access()
        {
            dynamic cards = Api.Get().Boards();
            Assert.AreEqual("4f2bf38d72b7c1293517af86", cards[0]["id"]);
            //cards[0]["id"].Should().Be("4f2bf38d72b7c1293517af86");
        }
    }
}
