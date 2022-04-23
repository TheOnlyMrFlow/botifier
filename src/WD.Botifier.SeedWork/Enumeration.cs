using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WD.Botifier.SeedWork;

public class Enumeration
{
    public string Name { get; }

    protected Enumeration(string name) => Name = name;

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration 
        => typeof(T)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();

    public override bool Equals(object? obj) 
        => obj is Enumeration otherValue && Equals(otherValue);

    protected bool Equals(Enumeration other) 
        => Name == other.Name;

    public override int GetHashCode() 
        => Name.GetHashCode();
}