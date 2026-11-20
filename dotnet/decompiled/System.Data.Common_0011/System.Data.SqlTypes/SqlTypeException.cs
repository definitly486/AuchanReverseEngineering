using System.Runtime.CompilerServices;

namespace System.Data.SqlTypes;

[Serializable]
[TypeForwardedFrom("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class SqlTypeException : SystemException
{
	public SqlTypeException(string? message)
		: this(message, null)
	{
	}

	public SqlTypeException(string? message, Exception? e)
		: base(message, e)
	{
		base.HResult = -2146232016;
	}
}
