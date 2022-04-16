﻿using System;
using System.Linq;
using WD.Botifier.SeedWork;

namespace WD.Botifier.Authentication.Domain.Users.ClearPasswords;

public class ClearPassword : ValueObject
{
    public ClearPassword(string? value)
    {
        value ??= "";
        
        var brokenRule = new IBusinessRule[]
        {
            new PasswordMustBeatLeastTenCharactersRule(value),
            new PasswordMustHaveAtLeastOneLowercaseLetterRule(value),
            new PasswordMustHaveAtLeastOneUppercaseLetterRule(value),
            new PasswordMustHaveAtLeastOneSpecialCharacterRule(value),
        }.FirstOrDefault(rule => rule.IsBroken());

        if (brokenRule is not null)
            throw new BusinessRuleValidationException(brokenRule);
            
        Value = value;
    }

    public string Value { get; }

    public override string ToString() => Value;
}
