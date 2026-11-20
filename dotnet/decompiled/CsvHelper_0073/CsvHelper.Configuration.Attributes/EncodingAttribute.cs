using System;
using System.Text;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class EncodingAttribute : Attribute, IClassMapper
{
	public Encoding Encoding { get; private set; }

	public EncodingAttribute(string name)
	{
		Encoding = System.Text.Encoding.GetEncoding(name);
	}

	public EncodingAttribute(int codepage)
	{
		Encoding = System.Text.Encoding.GetEncoding(codepage);
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.Encoding = Encoding;
	}
}
