using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data.Mappings;
using Domain.Events;
using FluentValidation.Results;

namespace Infrastructure.Data.Contexts;

public class SqlDbContext : DbContext
{
    private readonly IDomainEventHandler _domainEventService;

    public SqlDbContext(DbContextOptions<SqlDbContext> options, IDomainEventHandler domainEventService) : base(options)
        => _domainEventService = domainEventService;

    public SqlDbContext(DbContextOptions<SqlDbContext> option) : base(option)
    {

        this.Database.EnsureCreated();
    }



    public virtual DbSet<User> Users { get; set; }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        await DispatchEvents();

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new UsersMapping());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Ignore<ValidationResult>();
        modelBuilder.Ignore<DomainEvent>();

        var dateTimeConverter = new ValueConverter<DateTime, DateTime>(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    property.SetValueConverter(dateTimeConverter);
            }
        }

        base.OnModelCreating(modelBuilder);
    }

    private async Task DispatchEvents()
    {
        while (true)
        {
            try
            {
                var domainEventEntity = ChangeTracker.Entries<IHasDomainEvent>()
                  .Select(x => x.Entity.DomainEvents)
                  .SelectMany(x => x)
                  .Where(domainEvent => !domainEvent.IsPublished)
                  .FirstOrDefault();

                if (domainEventEntity is null) break;

                domainEventEntity.IsPublished = true;

                await _domainEventService.Publish(domainEventEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}