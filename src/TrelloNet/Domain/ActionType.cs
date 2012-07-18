namespace TrelloNet.Domain
{
    public enum ActionType
    {        
        AddAttachmentToCard,
        AddChecklistToCard,
        AddMemberToBoard,
        AddMemberToCard,
        AddMemberToOrganization,
        AddToOrganizationBoard,
        CommentCard,
        CopyCommentCard,
        ConvertToCardFromCheckItem,
        CopyBoard,
        CreateBoard,
        CreateCard,
        CopyCard,
        CreateList,
        CreateOrganization,
        DeleteAttachmentFromCard,
        DeleteBoardInvitation,
        DeleteOrganizationInvitation,
        MoveCardFromBoard,
        MoveCardToBoard,
        RemoveAdminFromBoard,
        RemoveAdminFromOrganization,
        RemoveChecklistFromCard,
        RemoveFromOrganizationBoard,
        RemoveMemberFromCard,
        UpdateBoard,
        UpdateCard,
        UpdateCheckItemStateOnCard,
        UpdateChecklist,
        UpdateMember,
        UpdateOrganization,

        // The Trello API actually expects these ones to have colons in place of the underscores below.
        // This is handled on outbound requests with String.Replace() - in future the deserialization
        // behaviour needs to be modified so actions coming back as xxxx:xxxx get mapped to these members.
        UpdateCard_idList,
        UpdateCard_closed,
        UpdateCard_desc,
        UpdateCard_name
    }
}