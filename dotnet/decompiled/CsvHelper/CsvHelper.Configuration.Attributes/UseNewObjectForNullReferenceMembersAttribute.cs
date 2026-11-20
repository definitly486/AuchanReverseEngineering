using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class UseNewObjectForNullReferenceMembersAttribute : Attribute, IClassMapper
{
	public bool UseNewObjectForNullReferenceMembers { get; private set; }

	public UseNewObjectForNullReferenceMembersAttribute(bool useNewObjectForNullReferenceMembers = true)
	{
		UseNewObjectForNullReferenceMembers = useNewObjectForNullReferenceMembers;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.UseNewObjectForNullReferenceMembers = UseNewObjectForNullReferenceMembers;
	}
}
