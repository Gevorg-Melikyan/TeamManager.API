using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TeamManager.Domain.Entities;
using TeamManager.Domain.Entities.ProjectAggregation;

namespace TeamManager.Domain.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectMember> ProjectMembers { get; set; }
        DbSet<Domain.Entities.TaskAgregation.Task> Tasks { get; set; }


        DbSet<TEntity> WriterSet<TEntity>() where TEntity : EntityBase;
        IQueryable<TEntity> ReaderSet<TEntity>() where TEntity : EntityBase;
        Task<int> SaveChangesAsync(CancellationToken token = default);
        int SaveChanges();
        DatabaseFacade Database { get; }
        EntityEntry Entry(object entity);
    }
}
