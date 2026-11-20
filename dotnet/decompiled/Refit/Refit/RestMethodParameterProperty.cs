using System.Reflection;

namespace Refit;

public class RestMethodParameterProperty
{
	public string Name { get; set; }

	public PropertyInfo PropertyInfo { get; set; }

	public RestMethodParameterProperty(string name, PropertyInfo propertyInfo)
	{
		Name = name;
		PropertyInfo = propertyInfo;
	}
}
