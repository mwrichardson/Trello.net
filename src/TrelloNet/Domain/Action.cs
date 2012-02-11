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
       CreateCard
       ,CommentCard
       ,UpdateCard
       ,UpdateCardidList //WAT?
       ,UpdateCardclosed //WAT?
       ,UpdateCarddesc
       ,UpdateCardname
       ,AddMemberToCard
       ,RemoveMemberFromCard
       ,UpdateCheckItemStateOnCard
       ,AddAttachmentToCard
       ,RemoveAttachmentFromCard
       ,AddChecklistToCard
       ,RemoveChecklistFromCard
       ,CreateList
       ,UpdateList
       ,CreateBoard
       ,UpdateBoard
       ,AddMemberToBoard
       ,RemoveMemberFromBoard
       ,AddToOrganizationBoard
       ,RemoveFromOrganizationBoard
       ,CreateOrganization
       ,UpdateOrganization
    }
}