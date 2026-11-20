using System.Runtime.CompilerServices;

namespace System.Data.SqlTypes;

[Serializable]
[TypeForwardedFrom("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public sealed class SqlNullValueException : SqlTypeException
{
	public SqlNullValueException()
		: this("SqlMisc_NullValueMessage", null)
	{
	}

	public SqlNullValueException(string? message, Exception? e)
		: base(message, e)
	{
		base.HResult = -2146232015;
	}
}
