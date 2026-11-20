using System.Runtime.CompilerServices;

namespace System.Data;

[Serializable]
[TypeForwardedFrom("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class NoNullAllowedException : DataException
{
	public NoNullAllowedException(string? s)
		: base(s ?? "DataSet_DefaultNoNullAllowedException")
	{
		base.HResult = -2146232026;
	}
}
