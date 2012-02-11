using System;
using FluentAssertions;
using NUnit.Framework;
using TrelloNet.Domain;

namespace Trello.net.Tests
{
    [TestFixture]
    public class Actions_Tests : TestBase
    {
        [Test]
        public void get_actions_test()
        {
            var actions = TrelloNet.TrelloNet.Get().Actions(TrelloNetBoardId);
            actions.Should().NotBeNull();
            actions.ForEach(x => Console.WriteLine(x.Type));
        }

        [Test]
        public void get_filtered_actions_test()
        {
            var actions = TrelloNet.TrelloNet.Get().Actions(TrelloNetBoardId, ActionType.CreateCard);
            actions.Should().NotBeNull();
            actions.ForEach(x => Console.WriteLine(x.Type));
            actions.ForEach(x => Assert.IsTrue(x.Type == ActionType.CreateCard));
        }

        [Test]
        public void get_filters_actions_test()
        {
            var actions = TrelloNet.TrelloNet.Get().Actions(TrelloNetBoardId, new[] { ActionType.CreateCard, ActionType.UpdateList, });
            actions.Should().NotBeNull();
            actions.ForEach(x => Console.WriteLine(x.Type));
            //actions.ForEach(x => Assert.IsTrue(x.Type == ActionType.CreateCard));
        }

    }
}