using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class BufferSizeAttribute : Attribute, IClassMapper
{
	public int BufferSize { get; private set; }

	public BufferSizeAttribute(int bufferSize)
	{
		BufferSize = bufferSize;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.BufferSize = BufferSize;
	}
}
