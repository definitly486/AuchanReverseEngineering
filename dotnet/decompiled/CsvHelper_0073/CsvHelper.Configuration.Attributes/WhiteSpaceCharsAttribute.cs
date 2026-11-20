using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class WhiteSpaceCharsAttribute : Attribute, IClassMapper
{
	public char[] WhiteSpaceChars { get; private set; }

	public WhiteSpaceCharsAttribute(string whiteSpaceChars)
	{
		WhiteSpaceChars = (from s in Regex.Split(whiteSpaceChars, "\\s")
			select s[0]).ToArray();
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.WhiteSpaceChars = WhiteSpaceChars;
	}
}
