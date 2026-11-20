using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using Java.Lang;

namespace Android.Runtime;

public static class AndroidEnvironment
{
	private static object lock_ = new object();

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
	private static Type? httpMessageHandlerType;

	public static event EventHandler<RaiseThrowableEventArgs>? UnhandledExceptionRaiser;

	[DllImport("libc")]
	private static extern void exit(int status);

	public static void FailFast(string? message)
	{
		Logger.Log(LogLevel.Fatal, "Mono.Android", message);
		exit(-1);
	}

	public static void RaiseThrowable(Throwable throwable)
	{
		if (throwable == null)
		{
			throw new ArgumentNullException("throwable");
		}
		JNIEnv.Throw(throwable.Handle);
	}

	internal static void UnhandledException(System.Exception e)
	{
		if (!TryRaiseUnhandledException(e))
		{
			RaiseThrowable(Throwable.FromException(e));
		}
	}

	internal static bool TryRaiseUnhandledException(System.Exception e)
	{
		EventHandler<RaiseThrowableEventArgs> unhandledExceptionRaiser = AndroidEnvironment.UnhandledExceptionRaiser;
		if (unhandledExceptionRaiser != null)
		{
			RaiseThrowableEventArgs e2 = new RaiseThrowableEventArgs(e);
			Delegate[] invocationList = unhandledExceptionRaiser.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				((EventHandler<RaiseThrowableEventArgs>)invocationList[i])(null, e2);
				if (e2.Handled)
				{
					return true;
				}
			}
		}
		return false;
	}

	private static void NotifyTimeZoneChanged()
	{
		System.Threading.Thread currentThread = System.Threading.Thread.CurrentThread;
		var array = new[]
		{
			new
			{
				Description = "Thread.CurrentCulture.ClearCachedData()",
				Method = (Action)currentThread.CurrentCulture.ClearCachedData
			},
			new
			{
				Description = "Thread.CurrentUICulture.ClearCachedData()",
				Method = (Action)currentThread.CurrentUICulture.ClearCachedData
			}
		};
		foreach (var anon in array)
		{
			try
			{
				anon.Method();
			}
			catch (System.Exception ex)
			{
				Logger.Log(LogLevel.Warn, "MonoAndroid", FormattableString.Invariant($"Ignoring exception from {anon.Description}: {ex}"));
			}
		}
	}

	private static HttpMessageHandler GetHttpMessageHandler()
	{
		if ((object)httpMessageHandlerType == null)
		{
			string text = Environment.GetEnvironmentVariable("XA_HTTP_CLIENT_HANDLER_TYPE")?.Trim();
			Type type = null;
			if (!string.IsNullOrEmpty(text))
			{
				type = TypeGetType(text);
			}
			if ((object)type == null || !IsAcceptableHttpMessageHandlerType(type))
			{
				type = GetFallbackHttpMessageHandlerType();
			}
			httpMessageHandlerType = type;
		}
		return ((HttpMessageHandler)Activator.CreateInstance(httpMessageHandlerType)) ?? throw new InvalidOperationException("Could not create an instance of HTTP message handler type " + httpMessageHandlerType.AssemblyQualifiedName);
		[UnconditionalSuppressMessage("Trimming", "IL2057", Justification = "Preserved by the MarkJavaObjects trimmer step.")]
		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
		static Type? TypeGetType(string typeName)
		{
			return Type.GetType(typeName, throwOnError: false);
		}
	}

	private static bool IsAcceptableHttpMessageHandlerType(Type handlerType)
	{
		if (Extends(handlerType, "System.Net.Http.HttpClientHandler, System.Net.Http"))
		{
			Logger.Log(LogLevel.Warn, "MonoAndroid", "The type " + handlerType.AssemblyQualifiedName + " cannot be used as the native HTTP handler because it is derived from System.Net.Htt.HttpClientHandler. Use a type that extends System.Net.Http.HttpMessageHandler instead.");
			return false;
		}
		if (!Extends(handlerType, "System.Net.Http.HttpMessageHandler, System.Net.Http"))
		{
			Logger.Log(LogLevel.Warn, "MonoAndroid", "The type " + handlerType.AssemblyQualifiedName + " set as the default HTTP handler is invalid. Use a type that extends System.Net.Http.HttpMessageHandler.");
			return false;
		}
		return true;
	}

	private static bool Extends(Type handlerType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] string baseTypeName)
	{
		return Type.GetType(baseTypeName, throwOnError: false)?.IsAssignableFrom(handlerType) ?? false;
	}

	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
	private static Type GetFallbackHttpMessageHandlerType()
	{
		Type? result = Type.GetType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android", throwOnError: false) ?? throw new InvalidOperationException("The Xamarin.Android.Net.AndroidMessageHandler, Mono.Android was not found. The type was probably linked away.");
		Logger.Log(LogLevel.Info, "MonoAndroid", "Using Xamarin.Android.Net.AndroidMessageHandler, Mono.Android as the native HTTP message handler.");
		return result;
	}
}
