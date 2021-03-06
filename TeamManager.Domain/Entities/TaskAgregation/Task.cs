using Ardalis.GuardClauses;
using System.Collections.Generic;
using TeamManager.Domain.Entities.CommentAgregation;
using TeamManager.Domain.Entities.ProjectAgregation;
using TeamManager.Domain.Enums;
using TeamManager.Domain.Events;
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

        public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

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
            TaskState = taskState;
        }

        public void Reslove(TaskState state)
        {
            TaskState = state;
            AddDomainEvent(new TaskResolvedDomainEvent(this));
        }


        #region Privete fields

        private readonly List<Comment> _comments = new List<Comment>();

        #endregion Privete fields
    }
}

