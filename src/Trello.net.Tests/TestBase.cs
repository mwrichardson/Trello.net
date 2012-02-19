using NUnit.Framework;
using TrelloNet;

namespace Trello.net.Tests
{
    public class TestBase
    {

        protected const string TrelloNetBoardId = "4f2bf38d72b7c1293517af86";
        protected const string TrelloMemberUsername = "ericpolerecky";
        protected const string TrelloMemberId = "4f2abcd7bb07915e11835c8c";
        protected const string TrellCardId = "4f2ec363efab2bbd4eb7af3c";

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            //I don't have a specifc test around this cause I started writing code using restsharp in my tests (tdd and all)
            //and kept my tests passing as I moved shit around.
            //when we support public and private boards (only work with private boards now) we will want some test.
            TrelloNet.TrelloWrapper.Init(TestConstants.OAuthAccessToken, TestConstants.ApiKey);
        }
    }
}