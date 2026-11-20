using System.Runtime.CompilerServices;

namespace System.Security.Authentication;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class AuthenticationException : SystemException
{
	public AuthenticationException(string? message)
		: base(message)
	{
	}

	public AuthenticationException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}
}
