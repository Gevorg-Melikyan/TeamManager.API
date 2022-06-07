using Ardalis.GuardClauses;
using System.Collections.Generic;
using TeamManager.Domain.Entities.ProjectAggregation;
using TeamManager.Domain.Entities.TaskAgregation;
using TeamManager.Domain.Identity;
using TeamManager.Domain.Interfaces;

namespace TeamManager.Domain.Entities.ProjectAgregation
{
    public class Project : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }
        public string ProjectManagerId { get; private set; }
        public ApplicationUser ProjectManager { get; private set; }
        public IReadOnlyCollection<ProjectMember> Members => _members.AsReadOnly();
        public IReadOnlyCollection<Task> Tasks => _tasks.AsReadOnly();

        public Project(string name, string pmId)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.NullOrWhiteSpace(pmId, nameof(pmId));

            Name = name;
            ProjectManagerId = pmId;
        }

        private Project()
        {
        }



        #region Privete fields

        private readonly List<Task> _tasks = new List<Task>();
        private readonly List<ProjectMember> _members = new List<ProjectMember>();


        #endregion
    }
}
