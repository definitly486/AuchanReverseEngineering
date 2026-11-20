using System;
using System.Diagnostics.CodeAnalysis;

namespace NLog.Config;

internal interface IFactory
{
	void Clear();

	void RegisterType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicProperties)] Type type, string itemNamePrefix);
}
public interface IFactory<TBaseType> where TBaseType : class
{
	bool TryCreateInstance(string typeAlias, out TBaseType? result);
}
