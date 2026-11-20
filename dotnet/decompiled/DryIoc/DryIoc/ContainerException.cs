using System;
using System.Runtime.Serialization;
using System.Text;
using DryIoc.ImTools;

namespace DryIoc;

[Serializable]
public class ContainerException : InvalidOperationException
{
	public readonly int Error;

	public readonly ContainerException[] CollectedExceptions;

	public readonly object Details;

	public string ErrorName => DryIoc.Error.NameOf(Error);

	public static ContainerException Of(ErrorCheck errorCheck, int errorCode, object arg0, object arg1 = null, object arg2 = null, object arg3 = null, Exception innerException = null)
	{
		return new ContainerException(errorCode, string.Format(GetMessage(errorCheck, errorCode), Print(arg0), Print(arg1), Print(arg2), Print(arg3)), innerException);
	}

	protected static string GetMessage(ErrorCheck errorCheck, int errorCode)
	{
		if (errorCode != -1)
		{
			return DryIoc.Error.Messages[errorCode];
		}
		return Throw.GetDefaultMessage(errorCheck);
	}

	protected static string Print(object arg)
	{
		if (arg != null)
		{
			return new StringBuilder().Print(arg).ToString();
		}
		return string.Empty;
	}

	public ContainerException(int error, ContainerException[] exceptions)
		: this(error, GetMessage(ErrorCheck.CollectedExceptions, error), null)
	{
		CollectedExceptions = exceptions;
	}

	public ContainerException(int error, string message)
		: this(error, message, null)
	{
	}

	private ContainerException(object details, int error, string message)
		: this(error, message, null)
	{
		Details = details;
	}

	public static object WithDetails(object details, int error, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null)
	{
		throw new ContainerException(details, error, string.Format(GetMessage(ErrorCheck.Unspecified, error), Print(arg0), Print(arg1), Print(arg2), Print(arg3)));
	}

	public ContainerException(int errorCode, string message, Exception innerException)
		: this(errorCode, message, innerException, (int e, string m, Exception _) => FormatMessage(DryIoc.Error.NameOf(e), m))
	{
	}

	protected static string FormatMessage(string errorName, string message)
	{
		return $"code: Error.{errorName};{"\n"}message: {message}";
	}

	protected ContainerException(int errorCode, string message, Exception innerException, Func<int, string, Exception, string> formatMessage)
		: base(formatMessage(errorCode, message, innerException), innerException)
	{
		Error = errorCode;
	}

	protected ContainerException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public string TryGetDetails(IContainer container)
	{
		int error = Error;
		if (error == DryIoc.Error.WaitForScopedServiceIsCreatedTimeoutExpired)
		{
			int num = (int)Details;
			string text = null;
			if (num > 65535)
			{
				int decoratorFactoryId = num & 0xFFFF;
				num >>= 16;
				text = GetDecoratorMessage(container, decoratorFactoryId);
			}
			string text2 = GetServiceMessage(container, num);
			if (text != null)
			{
				return text + "\n" + text2;
			}
			return text2;
		}
		return string.Empty;
		static string GetDecoratorMessage(IContainer container2, int num2)
		{
			foreach (DecoratorRegistrationInfo decoratorRegistration in container2.GetDecoratorRegistrations())
			{
				Factory factory = decoratorRegistration.Factory;
				if (factory.FactoryID == num2)
				{
					return $"Decorator registration related to the problem is:{"\n"}{decoratorRegistration}";
				}
				ImHashMap<KV<Type, object>, ReflectionFactory> generatedFactories = factory.GeneratedFactories;
				if (generatedFactories != null)
				{
					foreach (ImHashMapEntry<KV<Type, object>, ReflectionFactory> item in factory.GeneratedFactories.Enumerate())
					{
						ReflectionFactory value = item.Value;
						if (value.FactoryID == num2)
						{
							return $"Decorator registration related to the problem is:{"\n"}{decoratorRegistration}{"\n"}Specifically, the generated closed-generic factory is:{"\n"}{value}";
						}
					}
				}
			}
			return $"Unable to find the Decorator registration for the problematic factory with FactoryID={num2}";
		}
		static string GetServiceMessage(IContainer container2, int factoryId)
		{
			foreach (ServiceRegistrationInfo serviceRegistration in container2.GetServiceRegistrations())
			{
				Factory factory = serviceRegistration.Factory;
				if (factory.FactoryID == factoryId)
				{
					return $"Service registration related to the problem is:{"\n"}{serviceRegistration}";
				}
				ImHashMap<KV<Type, object>, ReflectionFactory> generatedFactories = factory.GeneratedFactories;
				if (generatedFactories != null)
				{
					foreach (ImHashMapEntry<KV<Type, object>, ReflectionFactory> item2 in factory.GeneratedFactories.Enumerate())
					{
						ReflectionFactory value = item2.Value;
						if (value.FactoryID == factoryId)
						{
							return $"Service registration related to the problem is:{"\n"}{serviceRegistration}{"\n"}Specifically, the generated closed-generic factory is:{"\n"}{value}";
						}
					}
				}
			}
			return $"Unable to find the Service registration for the problematic factory with FactoryID={factoryId}";
		}
	}
}
