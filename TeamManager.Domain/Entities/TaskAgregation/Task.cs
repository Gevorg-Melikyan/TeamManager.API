using Ardalis.GuardClauses;
using TeamManager.Domain.Entities.ProjectAggregation;
using TeamManager.Domain.Enums;
using TeamManager.Domain.Identity;
using TeamManager.Domain.Interfaces;

namespace TeamManager.Domain.Entities.TaskAgregation
{
    public class Task : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public long ProjectId { get; private set; }
        public virtual Project Project { get; private set; }
        public string ApplicationUserId { get; private set; }
        public ApplicationUser ApplicationUser { get; private set; }
        public TaskState TaskState { get; private set; }
        public TaskState TaskState1 { get; }

        public Task(
            string name,
            string description,
            long projectId,
            string applicationUserId,
            TaskState taskState)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NegativeOrZero(projectId, nameof(projectId));
            Guard.Against.NullOrEmpty(applicationUserId, nameof(applicationUserId));

            Name = name;
            Description = description;

            ProjectId = projectId;
            ApplicationUserId = applicationUserId;
            TaskState = taskState;
        }

        private Task()
        {
        }

        public Task(long id, string name, string description, long projectId, string applicationUserId, TaskState taskState)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NegativeOrZero(projectId, nameof(projectId));
            Guard.Against.NullOrEmpty(applicationUserId, nameof(applicationUserId));

            Id = id;
            Name = name;
            Description = description;
            ProjectId = projectId;
            ApplicationUserId = applicationUserId;
            TaskState1 = taskState;
        }




        #region Privete fields


        #endregion Privete fields
    }
}

