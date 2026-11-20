using System.Runtime.CompilerServices;

namespace System.Data;

[Serializable]
[TypeForwardedFrom("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class InvalidConstraintException : DataException
{
	public InvalidConstraintException(string? s)
		: base(s ?? "DataSet_DefaultInvalidConstraintException")
	{
		base.HResult = -2146232028;
	}
}
