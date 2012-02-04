using TrelloNet.Domain;

namespace TrelloNet
{
    public static class Api
    {
       
        private static Resources _resources;

        public static void Init(string token, string key)
        {
            _resources.SetServiceManager(new ServiceManager(token, key));
        }

        static Api()
        {
            _resources = new Resources();
        }

        public static Resources Get()
        {
            return _resources;
        }

        public static Resources Create()
        {
            return _resources;
        }

        public static Resources Update()
        {
            return _resources;
        }

        public static Resources Delete()
        {
            return _resources;
        }


    }
}