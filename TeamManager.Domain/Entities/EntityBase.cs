using MediatR;
using System;
using System.Collections.Generic;

namespace TeamManager.Domain.Entities
{
    public abstract class EntityBase
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDt { get; set; }
        public bool IsDeleted { get; set; }

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        #region Private fields

        private readonly List<INotification> _domainEvents = new List<INotification>();

        #endregion Private fields
    }
}