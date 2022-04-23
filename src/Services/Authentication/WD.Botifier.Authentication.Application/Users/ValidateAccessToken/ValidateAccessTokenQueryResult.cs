using System.Collections.Generic;
using OneOf;
using OneOf.Types;

namespace WD.Botifier.Authentication.Application.Users.ValidateAccessToken;

[GenerateOneOf]
public partial class ValidateAccessTokenQueryResult : OneOfBase<Dictionary<string, string>, ValidateAccessTokenQueryInvalidTokenResult>
{
    
}

public class ValidateAccessTokenQueryInvalidTokenResult { }