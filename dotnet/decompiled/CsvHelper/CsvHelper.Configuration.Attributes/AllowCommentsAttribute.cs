using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class AllowCommentsAttribute : Attribute, IClassMapper
{
	public bool AllowComments { get; private set; }

	public AllowCommentsAttribute(bool allowComments = true)
	{
		AllowComments = allowComments;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.AllowComments = AllowComments;
	}
}
