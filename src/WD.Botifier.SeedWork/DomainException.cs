using System;

namespace WD.Botifier.SeedWork;

public abstract class DomainException : Exception
{
    public string ErrorCode { get; }
    
    protected DomainException(string code)
    {
        ErrorCode = code;
        ;
    }
}