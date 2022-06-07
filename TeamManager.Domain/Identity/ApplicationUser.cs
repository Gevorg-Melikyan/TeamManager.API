using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using TeamManager.Domain.Entities.TaskAgregation;

namespace TeamManager.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PictureUri { get; set; }
        public bool IsDeleted { get; set; }
        public IReadOnlyCollection<Task> Tasks => _tasks.AsReadOnly();


        #region Private fields

        private readonly List<Task> _tasks = new List<Task>();

        #endregion Private fields
    }
}