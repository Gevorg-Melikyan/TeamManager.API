using IdentityServer4.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TeamManager.Domain.Entities;
using TeamManager.Domain.Entities.CommentAgregation;
using TeamManager.Domain.Entities.ProjectAggregation;
using TeamManager.Domain.Entities.ProjectAgregation;
using TeamManager.Domain.Identity;
using TeamManager.Domain.Interfaces;

namespace TeamManager.Infra.Data.AppContexts
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            IIdentityService identityService = null, IMediator mediator = null) : base(options, operationalStoreOptions)
        {
            _identityService = identityService;
            _mediator = mediator;
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectMember> ProjectMembers { get; set; }
        public virtual DbSet<Domain.Entities.TaskAgregation.Task> Tasks { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<TEntity> WriterSet<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>();
        }

        public IQueryable<TEntity> ReaderSet<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>().AsQueryable();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<EntityBase>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            AddTimeStamp(entities);

            await _mediator.DispatchDomainEventsAsync(entities, cancellationToken).ConfigureAwait(false);

            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public void AddTimeStamp(IEnumerable<EntityEntry<EntityBase>> entities)
        {
            string currentUserId = _identityService.UserIdentity;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedDt = DateTime.UtcNow;
                    entity.Entity.CreatedBy = currentUserId;
                }
                entity.Entity.UpdatedDt = DateTime.UtcNow;
                entity.Entity.UpdatedBy = currentUserId;
            }
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}

