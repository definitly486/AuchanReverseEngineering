using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class ExceptionMessagesContainRawDataAttribute : Attribute, IClassMapper
{
	public bool ExceptionMessagesContainRawData { get; private set; }

	public ExceptionMessagesContainRawDataAttribute(bool exceptionMessagesContainRawData = true)
	{
		ExceptionMessagesContainRawData = exceptionMessagesContainRawData;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.ExceptionMessagesContainRawData = ExceptionMessagesContainRawData;
	}
}
