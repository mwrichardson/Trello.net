namespace TrelloNet.Actions
{
    public class BaseAction
    {
         protected static ServiceManager ServiceManager;

         public BaseAction(ServiceManager serviceManager)
        {
            ServiceManager = serviceManager;
        }
    }
}