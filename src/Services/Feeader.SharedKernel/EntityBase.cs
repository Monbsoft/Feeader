using Monbsoft.Feeader.SharedKernel.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monbsoft.Feeader.SharedKernel;

public abstract class EntityBase
{
    private readonly List<IDomainEvent> _domainEvents;

    public EntityBase()
    {
        _domainEvents = new List<IDomainEvent>();
    }

    [NotMapped]
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;
    public Guid Id { get; set; }

    public override bool Equals(object? obj)
    {
        var other = obj as EntityBase;

        if (ReferenceEquals(other, null))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (Id == Guid.Empty || other.Id == Guid.Empty)
            return false;

        return Id.Equals(other.Id);
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    internal void ClearDomainEvents() => _domainEvents.Clear();
    protected virtual void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

}
