namespace FIAP.Domain.Entities.Base;

public abstract class EntityBase : EntityBase<long> { }
public abstract class EntityBase<TId>
{
    protected EntityBase()
    {
    }

    protected EntityBase(TId id)
    {
        Id = id;
    }

    public TId Id { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is not EntityBase<TId>) return false;
        if (ReferenceEquals(this, obj)) return true;

        return Equals((EntityBase<TId>)obj) && Id.Equals((obj as EntityBase<TId>).Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}