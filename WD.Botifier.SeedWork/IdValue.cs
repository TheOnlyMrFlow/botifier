using System;

namespace WD.Botifier.SeedWork;

public abstract class IdValue : IEquatable<IdValue>
{
    public Guid Value { get; }

    protected IdValue(Guid value) 
        => Value = value;

    public override bool Equals(object? obj) 
        => obj is IdValue other && Equals(other);

    public override int GetHashCode() 
        => Value.GetHashCode();

    public bool Equals(IdValue? other) 
        => Value == other?.Value;

    public static bool operator ==(IdValue? obj1, IdValue? obj2) 
        => obj1?.Equals(obj2) ?? Equals(obj2, null);

    public static bool operator !=(IdValue x, IdValue y)
        => !(x == y);
}