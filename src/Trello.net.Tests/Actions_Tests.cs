using System;
using FluentAssertions;
using NUnit.Framework;

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

    }
}