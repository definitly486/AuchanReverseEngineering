using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class MemberTypesAttribute : Attribute, IClassMapper
{
	public MemberTypes MemberTypes { get; private set; }

	public MemberTypesAttribute(MemberTypes memberTypes)
	{
		MemberTypes = memberTypes;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.MemberTypes = MemberTypes;
	}
}
