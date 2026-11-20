using System.Collections.Generic;
using System.Reflection;

namespace Refit;

public class RestMethodParameterInfo
{
	public string? Name { get; set; }

	public ParameterInfo ParameterInfo { get; set; }

	public bool IsObjectPropertyParameter { get; set; }

	public List<RestMethodParameterProperty> ParameterProperties { get; set; } = new List<RestMethodParameterProperty>();

	public ParameterType Type { get; set; }

	public RestMethodParameterInfo(string name, ParameterInfo parameterInfo)
	{
		Name = name;
		ParameterInfo = parameterInfo;
	}

	public RestMethodParameterInfo(bool isObjectPropertyParameter, ParameterInfo parameterInfo)
	{
		IsObjectPropertyParameter = isObjectPropertyParameter;
		ParameterInfo = parameterInfo;
	}
}
