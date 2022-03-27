using System;
using System.Security.AccessControl;

namespace WD.Botifier.BotRegistry.Application;

[AttributeUsage(AttributeTargets.Property)] 
public class UserToAuthenticateAttribute : Attribute
{
    
}