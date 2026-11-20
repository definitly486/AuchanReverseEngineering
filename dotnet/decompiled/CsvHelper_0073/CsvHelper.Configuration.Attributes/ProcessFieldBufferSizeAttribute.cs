using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class ProcessFieldBufferSizeAttribute : Attribute, IClassMapper
{
	public int ProcessFieldBufferSize { get; private set; }

	public ProcessFieldBufferSizeAttribute(int processFieldBufferSize)
	{
		ProcessFieldBufferSize = processFieldBufferSize;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.ProcessFieldBufferSize = ProcessFieldBufferSize;
	}
}
