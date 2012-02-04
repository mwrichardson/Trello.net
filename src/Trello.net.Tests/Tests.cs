using NUnit.Framework;
using TrelloNet;


namespace Trello.net.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            Api.Init(TestConstants.OAuthAccessToken, TestConstants.ApiKey);
        }

        [Test]
        public void get_card_test()
        {

            Api.Init(TestConstants.OAuthAccessToken, TestConstants.ApiKey);
            dynamic cards = Api.Get().Cards("");
            Assert.AreEqual("4f2bf38d72b7c1293517af86", cards[0]["id"]);
            //cards[0]["id"].Should().Be("4f2bf38d72b7c1293517af86");
        }

        [Test]
        public void test2()
        {

           
            dynamic cards = Api.Get().Cards("");
            Assert.AreEqual("4f2bf38d72b7c1293517af86", cards[0]["id"]);
            //cards[0]["id"].Should().Be("4f2bf38d72b7c1293517af86");
        }
    }


    public static class TestConstants
    {
        public const string ApiKey = "ce55781ad91b8024c67b6fe52c3f732a";

        //detroitproapitest
        public const string OAuthAccessToken = "1304827778ec13c9065d55ee47541d2f048dc996b70b68ba6f7e00bfa723692e"; 
    }
}
