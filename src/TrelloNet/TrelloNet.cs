using TrelloNet.Actions;

namespace TrelloNet
{
    public static class TrelloNet
    {
        private static GetAction _getAction;
        private static CreateAction _createAction;
        private static UpdateAction _updateAction;
        private static DeleteAction _deleteAction;
        
        public static void Init(string token, string key)
        {
            _getAction = new GetAction(new ServiceManager(token, key));
            _createAction = new CreateAction(new ServiceManager(token, key));
            _updateAction = new UpdateAction(new ServiceManager(token, key));
            _deleteAction = new DeleteAction(new ServiceManager(token, key));
        }

     

        public static GetAction Get()
        {
            return _getAction;
        }

        public static CreateAction Create()
        {
            return _createAction;
        }

        public static UpdateAction Update()
        {
            return _updateAction;
        }

        public static DeleteAction Delete()
        {
            return _deleteAction;
        }


    }
}