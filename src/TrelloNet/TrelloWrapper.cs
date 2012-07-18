using TrelloNet.Actions;
using System.Diagnostics;

namespace TrelloNet
{
    public static class TrelloWrapper
    {
        private static GetAction _getAction;
        private static CreateAction _createAction;
        private static UpdateAction _updateAction;
        private static DeleteAction _deleteAction;
        
        public static void Init(string token, string key)
        {
            ServiceManager.Init(token,key);
            _getAction = new GetAction();
            _createAction = new CreateAction();
            _updateAction = new UpdateAction();
            _deleteAction = new DeleteAction();
        }

        [DebuggerStepThrough]
        public static GetAction Get()
        {
            return _getAction;
        }

        [DebuggerStepThrough]
        public static CreateAction Create()
        {
            return _createAction;
        }

        [DebuggerStepThrough]
        public static UpdateAction Update()
        {
            return _updateAction;
        }

        [DebuggerStepThrough]
        public static DeleteAction Delete()
        {
            return _deleteAction;
        }


    }
}