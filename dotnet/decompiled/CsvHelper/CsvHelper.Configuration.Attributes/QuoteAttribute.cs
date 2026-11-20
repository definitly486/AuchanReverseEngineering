using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class QuoteAttribute : Attribute, IClassMapper
{
	public char Quote { get; private set; }

	public QuoteAttribute(char quote)
	{
		Quote = quote;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.Quote = Quote;
	}
}
