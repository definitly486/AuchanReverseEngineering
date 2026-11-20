using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class InjectionEscapeCharacterAttribute : Attribute, IClassMapper
{
	public char InjectionEscapeCharacter { get; private set; }

	public InjectionEscapeCharacterAttribute(char injectionEscapeCharacter)
	{
		InjectionEscapeCharacter = injectionEscapeCharacter;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.InjectionEscapeCharacter = InjectionEscapeCharacter;
	}
}
