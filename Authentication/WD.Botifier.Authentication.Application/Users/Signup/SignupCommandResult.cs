using OneOf;
using OneOf.Types;

namespace WD.Botifier.Authentication.Application.Users.Signup;

[GenerateOneOf]
public partial class SignupCommandResult : OneOfBase<Success, SignupCommandEMailAlreadyTakenResult> { }

public class SignupCommandEMailAlreadyTakenResult { }