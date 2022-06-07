using Ardalis.GuardClauses;
using TeamManager.Domain.Entities.ProjectAgregation;
using TeamManager.Domain.Identity;

namespace TeamManager.Domain.Entities.ProjectAggregation
{
    public class ProjectMember : EntityBase
    {
        public string Possition { get; private set; }
        public string ApplicationUserId { get; private set; }
        public ApplicationUser ApplicationUser { get; private set; }
        public long ProjectId { get; private set; }
        public Project Project { get; private set; }
        public ProjectMember()
        {

        }
        public ProjectMember(string possition, string userId, long projectId)
        {
            Guard.Against.Null(possition, nameof(possition));
            Guard.Against.Default(possition, nameof(possition));
            Guard.Against.NegativeOrZero(projectId, nameof(projectId));
            Guard.Against.NullOrWhiteSpace(userId, nameof(userId));


            Possition = possition;
            ApplicationUserId = userId;
            ProjectId = projectId;
        }
    }
}
