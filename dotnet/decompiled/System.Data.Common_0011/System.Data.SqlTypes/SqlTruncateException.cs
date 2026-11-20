using System.Runtime.CompilerServices;

namespace System.Data.SqlTypes;

[Serializable]
[TypeForwardedFrom("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public sealed class SqlTruncateException : SqlTypeException
{
	public SqlTruncateException()
		: this("SqlMisc_TruncationMessage", null)
	{
	}

	public SqlTruncateException(string? message, Exception? e)
		: base(message, e)
	{
		base.HResult = -2146232014;
	}
}
