using System;
using AndroidX.Fragment.App;
using Java.Lang;

namespace Auchan.Android.Extensions;

public static class FragmentFactoryExtensions
{
	public static T Instantiate<T>(this FragmentFactory factory) where T : Fragment
	{
		Class obj = Class.FromType(typeof(T));
		return (T)factory.Instantiate(obj.ClassLoader, obj.Name);
	}

	public static Fragment Instantiate(this FragmentFactory factory, Type type)
	{
		Class obj = Class.FromType(type);
		return factory.Instantiate(obj.ClassLoader, obj.Name);
	}
}
