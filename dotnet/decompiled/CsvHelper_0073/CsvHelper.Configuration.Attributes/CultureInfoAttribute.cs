using System;
using System.Globalization;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
public class CultureInfoAttribute : Attribute, IClassMapper, IMemberMapper, IParameterMapper
{
	public CultureInfo CultureInfo { get; private set; }

	public CultureInfoAttribute(string name)
	{
		switch (name)
		{
		case "InvariantCulture":
			CultureInfo = System.Globalization.CultureInfo.InvariantCulture;
			break;
		case "CurrentCulture":
			CultureInfo = System.Globalization.CultureInfo.CurrentCulture;
			break;
		case "CurrentUICulture":
			CultureInfo = System.Globalization.CultureInfo.CurrentUICulture;
			break;
		case "InstalledUICulture":
			CultureInfo = System.Globalization.CultureInfo.InstalledUICulture;
			break;
		default:
			CultureInfo = System.Globalization.CultureInfo.GetCultureInfo(name);
			break;
		}
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.CultureInfo = CultureInfo;
	}

	public void ApplyTo(MemberMap memberMap)
	{
		memberMap.Data.TypeConverterOptions.CultureInfo = CultureInfo;
	}

	public void ApplyTo(ParameterMap parameterMap)
	{
		parameterMap.Data.TypeConverterOptions.CultureInfo = CultureInfo;
	}
}
