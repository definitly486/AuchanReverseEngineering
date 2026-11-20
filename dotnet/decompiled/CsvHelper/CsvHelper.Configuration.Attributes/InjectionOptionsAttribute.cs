using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class InjectionOptionsAttribute : Attribute, IClassMapper
{
	public InjectionOptions InjectionOptions { get; private set; }

	public InjectionOptionsAttribute(InjectionOptions injectionOptions)
	{
		InjectionOptions = injectionOptions;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.InjectionOptions = InjectionOptions;
	}
}
