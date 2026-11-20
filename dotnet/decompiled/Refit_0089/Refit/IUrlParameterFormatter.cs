using System;
using System.Reflection;

namespace Refit;

public interface IUrlParameterFormatter
{
	string? Format(object? value, ICustomAttributeProvider attributeProvider, Type type);
}
