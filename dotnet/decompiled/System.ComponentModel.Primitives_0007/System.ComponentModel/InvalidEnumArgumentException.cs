using System.Runtime.CompilerServices;

namespace System.ComponentModel;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class InvalidEnumArgumentException : ArgumentException
{
	public InvalidEnumArgumentException()
		: this(null)
	{
	}

	public InvalidEnumArgumentException(string? message)
		: base(message)
	{
	}

	public InvalidEnumArgumentException(string? argumentName, int invalidValue, Type enumClass)
		: base(System.SR.Format("The value of argument '{0}' ({1}) is invalid for Enum type '{2}'.", argumentName, invalidValue, enumClass?.Name), argumentName)
	{
		ArgumentNullException.ThrowIfNull(enumClass, "enumClass");
	}
}
