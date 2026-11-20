using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class IncludePrivateMembersAttribute : Attribute, IClassMapper
{
	public bool IncludePrivateMembers { get; private set; }

	public IncludePrivateMembersAttribute(bool includePrivateMembers = true)
	{
		IncludePrivateMembers = includePrivateMembers;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.IncludePrivateMembers = IncludePrivateMembers;
	}
}
