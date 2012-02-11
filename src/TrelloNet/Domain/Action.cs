using System;

namespace TrelloNet.Domain
{
    public class Action : Entity
    {
        public string IdMemberCreator { get; set; }

        //TODO: Make this an enum.
        public ActionType Type { get; set; }

        public DateTime Date { get; set; }
        public Data Data { get; set; }
    }

    public enum ActionType
    {
       createCard
       ,commentCard
       ,updateCard
       ,updateCardidList //WAT?
       ,updateCardclosed //WAT?
       ,updateCarddesc
       ,updateCardname
       ,addMemberToCard
       ,removeMemberFromCard
       ,updateCheckItemStateOnCard
       ,addAttachmentToCard
       ,removeAttachmentFromCard
       ,addChecklistToCard
       ,removeChecklistFromCard
       ,createList
       ,updateList
       ,createBoard
       ,updateBoard
       ,addMemberToBoard
       ,removeMemberFromBoard
       ,addToOrganizationBoard
       ,removeFromOrganizationBoard
       ,createOrganization
       ,updateOrganization
    }
}