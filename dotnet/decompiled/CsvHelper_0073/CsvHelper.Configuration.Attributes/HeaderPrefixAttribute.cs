using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
public class HeaderPrefixAttribute : Attribute, IMemberReferenceMapper, IParameterReferenceMapper
{
	public string? Prefix { get; private set; }

	public bool Inherit { get; private set; }

	public HeaderPrefixAttribute()
	{
	}

	public HeaderPrefixAttribute(string prefix)
	{
		Prefix = prefix;
	}

	public HeaderPrefixAttribute(bool inherit)
	{
		Inherit = inherit;
	}

	public HeaderPrefixAttribute(string prefix, bool inherit)
	{
		Prefix = prefix;
		Inherit = inherit;
	}

	public void ApplyTo(MemberReferenceMap referenceMap)
	{
		referenceMap.Data.Inherit = Inherit;
		referenceMap.Data.Prefix = Prefix ?? (referenceMap.Data.Member.Name + ".");
	}

	public void ApplyTo(ParameterReferenceMap referenceMap)
	{
		referenceMap.Data.Inherit = Inherit;
		referenceMap.Data.Prefix = Prefix ?? (referenceMap.Data.Parameter.Name + ".");
	}
}
