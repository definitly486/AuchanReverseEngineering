using System.Runtime.CompilerServices;

namespace System.Data;

[Serializable]
[TypeForwardedFrom("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class DataException : SystemException
{
	public DataException(string? s)
		: base(s ?? "DataSet_DefaultDataException")
	{
		base.HResult = -2146232032;
	}

	public DataException(string? s, Exception? innerException)
		: base(s ?? "DataSet_DefaultDataException", innerException)
	{
	}
}
