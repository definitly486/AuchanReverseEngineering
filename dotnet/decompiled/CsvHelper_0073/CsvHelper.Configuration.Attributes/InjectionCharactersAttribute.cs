using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class InjectionCharactersAttribute : Attribute, IClassMapper
{
	public char[] InjectionCharacters { get; private set; }

	public InjectionCharactersAttribute(string injectionCharacters)
	{
		InjectionCharacters = (from s in Regex.Split(injectionCharacters, "\\s+")
			select s[0]).ToArray();
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.InjectionCharacters = InjectionCharacters;
	}
}
