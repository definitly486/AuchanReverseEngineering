using System;

namespace NLog;

[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public sealed class MessageTemplateFormatMethodAttribute : Attribute
{
	public string ParameterName { get; }

	public MessageTemplateFormatMethodAttribute(string parameterName)
	{
		ParameterName = parameterName;
	}
}
