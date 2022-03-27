namespace WD.Botifier.SeedWork;

public abstract class TypedIdValueBase : IEquatable<TypedIdValueBase>
{
    public Guid Value { get; }

    protected TypedIdValueBase(Guid value) 
        => Value = value;

    public override bool Equals(object? obj) 
        => obj is TypedIdValueBase other && Equals(other);

    public override int GetHashCode() 
        => Value.GetHashCode();

    public bool Equals(TypedIdValueBase? other) 
        => Value == other?.Value;

    public static bool operator ==(TypedIdValueBase? obj1, TypedIdValueBase? obj2) 
        => obj1?.Equals(obj2) ?? Equals(obj2, null);

    public static bool operator !=(TypedIdValueBase x, TypedIdValueBase y)
        => !(x == y);
}