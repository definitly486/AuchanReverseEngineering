using System;
using System.Collections.Generic;

namespace Java.Interop;

internal static class TypeManagerMapDictionaries
{
	private static Dictionary<string, Type>? _jniToManaged;

	private static Dictionary<Type, string>? _managedToJni;

	public static readonly object AccessLock = new object();

	public static Dictionary<string, Type> JniToManaged
	{
		get
		{
			if (_jniToManaged == null)
			{
				_jniToManaged = new Dictionary<string, Type>(StringComparer.Ordinal);
			}
			return _jniToManaged;
		}
	}

	public static Dictionary<Type, string> ManagedToJni
	{
		get
		{
			if (_managedToJni == null)
			{
				_managedToJni = new Dictionary<Type, string>();
			}
			return _managedToJni;
		}
	}
}
