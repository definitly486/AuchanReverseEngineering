using System.Runtime.CompilerServices;

namespace System.Data;

[Serializable]
[TypeForwardedFrom("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class VersionNotFoundException : DataException
{
	public VersionNotFoundException(string? s)
		: base(s ?? "DataSet_DefaultVersionNotFoundException")
	{
		base.HResult = -2146232023;
	}
}
