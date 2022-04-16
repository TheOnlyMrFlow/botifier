using System;

namespace WD.Botifier.SeedWork;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class ValueObjectEqualityIgnoreMemberAttribute : Attribute
{
}