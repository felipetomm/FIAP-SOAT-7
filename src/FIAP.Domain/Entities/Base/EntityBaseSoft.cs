namespace FIAP.Domain.Entities.Base;

public abstract class EntityBaseSoft<TId> : EntityBase<TId>
{
    public virtual DateTime Created { get; set; }

    public virtual DateTime? Modified { get; set; }

    public virtual Guid Hash { get; set; }

    public virtual bool Deleted { get; set; }
}