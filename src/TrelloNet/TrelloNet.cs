namespace Trello.net.Tests
{
    public static class TrelloNet
    {

        private static Resources _resources;

        static TrelloNet()
        {
            _resources = new Resources();
        }

        public static Resources Get()
        {
            return _resources;
        }


    }
}