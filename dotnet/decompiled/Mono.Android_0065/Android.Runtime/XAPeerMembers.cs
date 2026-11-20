using System;
using System.Collections.Generic;
using Java.Interop;
using Java.Lang;

namespace Android.Runtime;

public class XAPeerMembers : JniPeerMembers
{
	private static Dictionary<string, JniPeerMembers> LegacyPeerMembers = new Dictionary<string, JniPeerMembers>(StringComparer.Ordinal);

	public XAPeerMembers(string jniPeerTypeName, Type managedPeerType)
		: base(jniPeerTypeName, managedPeerType)
	{
	}

	public XAPeerMembers(string jniPeerTypeName, Type managedPeerType, bool isInterface)
		: base(jniPeerTypeName, managedPeerType, isInterface)
	{
	}

	protected override bool UsesVirtualDispatch(IJavaPeerable value, Type? declaringType)
	{
		Type thresholdType = GetThresholdType(value);
		if (thresholdType != null)
		{
			return thresholdType == value.GetType();
		}
		return base.UsesVirtualDispatch(value, declaringType);
	}

	protected override JniPeerMembers GetPeerMembers(IJavaPeerable value)
	{
		Type thresholdType = GetThresholdType(value);
		if (thresholdType == null || value.JniPeerMembers.ManagedPeerType == thresholdType)
		{
			return base.GetPeerMembers(value);
		}
		string className = Java.Interop.TypeManager.GetClassName(GetThresholdClass(value));
		lock (LegacyPeerMembers)
		{
			if (!LegacyPeerMembers.TryGetValue(className, out JniPeerMembers value2))
			{
				value2 = new XAPeerMembers(className, thresholdType);
				LegacyPeerMembers.Add(className, value2);
			}
			return value2;
		}
	}

	private static Type? GetThresholdType(IJavaPeerable value)
	{
		if (value is Java.Lang.Object obj)
		{
			return obj.GetThresholdType();
		}
		if (value is Throwable throwable)
		{
			return throwable.GetThresholdType();
		}
		return null;
	}

	private static nint GetThresholdClass(IJavaPeerable value)
	{
		if (value is Java.Lang.Object obj)
		{
			return obj.GetThresholdClass();
		}
		if (value is Throwable throwable)
		{
			return throwable.GetThresholdClass();
		}
		return IntPtr.Zero;
	}
}
