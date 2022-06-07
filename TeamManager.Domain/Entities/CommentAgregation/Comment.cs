using Ardalis.GuardClauses;
using TeamManager.Domain.Entities.TaskAgregation;
using TeamManager.Domain.Identity;
using TeamManager.Domain.Interfaces;

namespace TeamManager.Domain.Entities.CommentAgregation
{
    public class Comment : EntityBase, IAggregateRoot
    {
        public string Text { get; private set; }
        public string CommentAuthorId { get; private set; }
        public ApplicationUser CommentAuthor { get; private set; }

        public long TaskId { get; set; }
        public Task Task { get; set; }

        public Comment(string text, string userId)
        {
            Guard.Against.NullOrWhiteSpace(text, nameof(text));
            Guard.Against.NullOrWhiteSpace(userId, nameof(userId));

            Text = text;
            CommentAuthorId = userId;
        }

        private Comment()
        {
        }



        #region Privete fields


        #endregion
    }
}

