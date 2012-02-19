using System;
using FluentAssertions;
using NUnit.Framework;
using TrelloNet;
using TrelloNet.Domain;

namespace Trello.net.Tests
{
    [TestFixture]
    public class Get_Actions_Tests : TestBase
    {
        [Test]
        public void all_actions_by_boardid()
        {
            var actions = TrelloWrapper.Get().Actions(TrelloNetBoardId);
            actions.Should().NotBeNull();
            actions.ForEach(x => Console.WriteLine(x.Type));
        }

        [Test]
        public void actions_filtered_by_single_actionType()
        {
            var actions = TrelloWrapper.Get().Actions(TrelloNetBoardId, ActionType.CreateCard);
            actions.Should().NotBeNull();
            actions.ForEach(x => Console.WriteLine(x.Type));
            actions.ForEach(x => Assert.IsTrue(x.Type == ActionType.CreateCard));
        }

        [Test]
        public void actions_filtered_by_array_of_actionTypes()
        {
            var actions = TrelloWrapper.Get().Actions(TrelloNetBoardId, new[] { ActionType.CreateCard, ActionType.UpdateList, });
            actions.Should().NotBeNull();
            actions.ForEach(x => Console.WriteLine(x.Type));
            actions.ForEach(x => Assert.IsTrue((x.Type == ActionType.CreateCard || x.Type == ActionType.UpdateList)));
        }

    }
}