using System.Runtime.CompilerServices;

namespace System.Data;

[Serializable]
[TypeForwardedFrom("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class EvaluateException : InvalidExpressionException
{
	public EvaluateException(string? s)
		: base(s)
	{
	}
}
