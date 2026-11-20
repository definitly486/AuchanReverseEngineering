using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using Android.Runtime;
using Java.Lang;

namespace Java.Interop;

internal static class JavaConvert
{
	private static Dictionary<Type, Func<nint, JniHandleOwnership, object>> JniHandleConverters = new Dictionary<Type, Func<nint, JniHandleOwnership, object>>
	{
		{
			typeof(bool),
			delegate(nint handle, JniHandleOwnership transfer)
			{
				using Java.Lang.Boolean boolean = new Java.Lang.Boolean(handle, transfer | JniHandleOwnership.DoNotRegister);
				return boolean.BooleanValue();
			}
		},
		{
			typeof(byte),
			delegate(nint handle, JniHandleOwnership transfer)
			{
				using Java.Lang.Byte obj = new Java.Lang.Byte(handle, transfer | JniHandleOwnership.DoNotRegister);
				return (byte)obj.ByteValue();
			}
		},
		{
			typeof(sbyte),
			delegate(nint handle, JniHandleOwnership transfer)
			{
				using Java.Lang.Byte obj = new Java.Lang.Byte(handle, transfer | JniHandleOwnership.DoNotRegister);
				return obj.ByteValue();
			}
		},
		{
			typeof(char),
			delegate(nint handle, JniHandleOwnership transfer)
			{
				using Character character = new Character(handle, transfer | JniHandleOwnership.DoNotRegister);
				return character.CharValue();
			}
		},
		{
			typeof(short),
			delegate(nint handle, JniHandleOwnership transfer)
			{
				using Short obj = new Short(handle, transfer | JniHandleOwnership.DoNotRegister);
				return obj.ShortValue();
			}
		},
		{
			typeof(int),
			delegate(nint handle, JniHandleOwnership transfer)
			{
				using Integer integer = new Integer(handle, transfer | JniHandleOwnership.DoNotRegister);
				return integer.IntValue();
			}
		},
		{
			typeof(long),
			delegate(nint handle, JniHandleOwnership transfer)
			{
				using Long obj = new Long(handle, transfer | JniHandleOwnership.DoNotRegister);
				return obj.LongValue();
			}
		},
		{
			typeof(float),
			delegate(nint handle, JniHandleOwnership transfer)
			{
				using Float obj = new Float(handle, transfer | JniHandleOwnership.DoNotRegister);
				return obj.FloatValue();
			}
		},
		{
			typeof(double),
			delegate(nint handle, JniHandleOwnership transfer)
			{
				using Java.Lang.Double obj = new Java.Lang.Double(handle, transfer | JniHandleOwnership.DoNotRegister);
				return obj.DoubleValue();
			}
		},
		{
			typeof(string),
			delegate(nint handle, JniHandleOwnership transfer)
			{
				using Java.Lang.String obj = new Java.Lang.String(handle, transfer | JniHandleOwnership.DoNotRegister);
				return obj.ToString();
			}
		}
	};

	private static Dictionary<string, Type> TypeMappings = new Dictionary<string, Type>(9, StringComparer.Ordinal)
	{
		{
			"java/lang/Boolean",
			typeof(bool)
		},
		{
			"java/lang/Byte",
			typeof(byte)
		},
		{
			"java/lang/Character",
			typeof(char)
		},
		{
			"java/lang/Short",
			typeof(short)
		},
		{
			"java/lang/Integer",
			typeof(int)
		},
		{
			"java/lang/Long",
			typeof(long)
		},
		{
			"java/lang/Float",
			typeof(float)
		},
		{
			"java/lang/Double",
			typeof(double)
		},
		{
			"java/lang/String",
			typeof(string)
		}
	};

	private static Dictionary<Type, Func<object, IJavaObject>> JavaObjectConverters = new Dictionary<Type, Func<object, IJavaObject>>
	{
		{
			typeof(bool),
			(object value) => new Java.Lang.Boolean((bool)value)
		},
		{
			typeof(byte),
			(object value) => new Java.Lang.Byte((sbyte)(byte)value)
		},
		{
			typeof(sbyte),
			(object value) => new Java.Lang.Byte((sbyte)value)
		},
		{
			typeof(char),
			(object value) => new Character((char)value)
		},
		{
			typeof(short),
			(object value) => new Short((short)value)
		},
		{
			typeof(int),
			(object value) => new Integer((int)value)
		},
		{
			typeof(long),
			(object value) => new Long((long)value)
		},
		{
			typeof(float),
			(object value) => new Float((float)value)
		},
		{
			typeof(double),
			(object value) => new Java.Lang.Double((double)value)
		},
		{
			typeof(string),
			(object value) => new Java.Lang.String(value.ToString())
		}
	};

	private static Dictionary<Type, Func<object, nint>> LocalJniHandleConverters = new Dictionary<Type, Func<object, nint>>
	{
		{
			typeof(bool),
			delegate(object value)
			{
				using Java.Lang.Boolean value2 = new Java.Lang.Boolean((bool)value);
				return JNIEnv.ToLocalJniHandle(value2);
			}
		},
		{
			typeof(byte),
			delegate(object value)
			{
				using Java.Lang.Byte value2 = new Java.Lang.Byte((sbyte)(byte)value);
				return JNIEnv.ToLocalJniHandle(value2);
			}
		},
		{
			typeof(sbyte),
			delegate(object value)
			{
				using Java.Lang.Byte value2 = new Java.Lang.Byte((sbyte)value);
				return JNIEnv.ToLocalJniHandle(value2);
			}
		},
		{
			typeof(char),
			delegate(object value)
			{
				using Character value2 = new Character((char)value);
				return JNIEnv.ToLocalJniHandle(value2);
			}
		},
		{
			typeof(short),
			delegate(object value)
			{
				using Short value2 = new Short((short)value);
				return JNIEnv.ToLocalJniHandle(value2);
			}
		},
		{
			typeof(int),
			delegate(object value)
			{
				using Integer value2 = new Integer((int)value);
				return JNIEnv.ToLocalJniHandle(value2);
			}
		},
		{
			typeof(long),
			delegate(object value)
			{
				using Long value2 = new Long((long)value);
				return JNIEnv.ToLocalJniHandle(value2);
			}
		},
		{
			typeof(float),
			delegate(object value)
			{
				using Float value2 = new Float((float)value);
				return JNIEnv.ToLocalJniHandle(value2);
			}
		},
		{
			typeof(double),
			delegate(object value)
			{
				using Java.Lang.Double value2 = new Java.Lang.Double((double)value);
				return JNIEnv.ToLocalJniHandle(value2);
			}
		},
		{
			typeof(string),
			delegate(object value)
			{
				if (value == null)
				{
					return IntPtr.Zero;
				}
				using Java.Lang.String value2 = new Java.Lang.String(value.ToString());
				return JNIEnv.ToLocalJniHandle(value2);
			}
		},
		{
			typeof(Array),
			(object value) => JNIEnv.NewArray((Array)value)
		},
		{
			typeof(Android.Runtime.JavaObject),
			(object value) => (value != null) ? JNIEnv.ToLocalJniHandle(new Android.Runtime.JavaObject(value)) : IntPtr.Zero
		}
	};

	private static Func<nint, JniHandleOwnership, object?>? GetJniHandleConverter(Type? target)
	{
		if (target == null)
		{
			return null;
		}
		if (JniHandleConverters.TryGetValue(target, out Func<nint, JniHandleOwnership, object> value))
		{
			return value;
		}
		if (target.IsArray)
		{
			return (nint h, JniHandleOwnership t) => JNIEnv.GetArray(h, t, target.GetElementType());
		}
		if (target.IsGenericType && target.GetGenericTypeDefinition() == typeof(IDictionary<, >))
		{
			return GetJniHandleConverterForType(MakeGenericType(typeof(JavaDictionary<, >), target.GetGenericArguments()));
		}
		if (typeof(IDictionary).IsAssignableFrom(target))
		{
			return (nint h, JniHandleOwnership t) => JavaDictionary.FromJniHandle(h, t);
		}
		if (target.IsGenericType && target.GetGenericTypeDefinition() == typeof(IList<>))
		{
			return GetJniHandleConverterForType(MakeGenericType(typeof(JavaList<>), target.GetGenericArguments()));
		}
		if (typeof(IList).IsAssignableFrom(target))
		{
			return (nint h, JniHandleOwnership t) => JavaList.FromJniHandle(h, t);
		}
		if (target.IsGenericType && target.GetGenericTypeDefinition() == typeof(ICollection<>))
		{
			return GetJniHandleConverterForType(MakeGenericType(typeof(JavaCollection<>), target.GetGenericArguments()));
		}
		if (typeof(ICollection).IsAssignableFrom(target))
		{
			return (nint h, JniHandleOwnership t) => JavaCollection.FromJniHandle(h, t);
		}
		return null;
		[UnconditionalSuppressMessage("Trimming", "IL2055", Justification = "We don't think the IDictionary, IList, or ICollection code paths occur if JavaDictionary<,>, JavaList<>, and JavaCollection<> do not exist.")]
		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
		static Type MakeGenericType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] Type type, params Type[] typeArguments)
		{
			return type.MakeGenericType(typeArguments);
		}
	}

	private static Func<nint, JniHandleOwnership, object> GetJniHandleConverterForType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] Type t)
	{
		MethodInfo method = t.GetMethod("FromJniHandle", BindingFlags.Static | BindingFlags.Public);
		return (Func<nint, JniHandleOwnership, object>)Delegate.CreateDelegate(typeof(Func<nint, JniHandleOwnership, object>), method);
	}

	public static T? FromJniHandle<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(nint handle, JniHandleOwnership transfer)
	{
		bool set;
		return FromJniHandle<T>(handle, transfer, out set);
	}

	public static T? FromJniHandle<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(nint handle, JniHandleOwnership transfer, out bool set)
	{
		if (handle == IntPtr.Zero)
		{
			set = false;
			return default(T);
		}
		IJavaObject javaObject = (IJavaObject)Java.Lang.Object.PeekObject(handle);
		if (javaObject != null)
		{
			T result = FromJavaObject<T>(javaObject, out set);
			if (set)
			{
				JNIEnv.DeleteRef(handle, transfer);
				return result;
			}
		}
		set = true;
		if (typeof(IJavaObject).IsAssignableFrom(typeof(T)))
		{
			return Java.Lang.Object._GetObject<T>(handle, transfer);
		}
		Func<nint, JniHandleOwnership, object> func = GetJniHandleConverter(typeof(T)) ?? GetJniHandleConverter(GetTypeMapping(handle));
		if (func != null)
		{
			return (T)func(handle, transfer);
		}
		IJavaPeerable javaPeerable = Java.Lang.Object.GetObject(handle, transfer);
		if (javaPeerable is T)
		{
			return (T)javaPeerable;
		}
		return (T)Convert.ChangeType(javaPeerable, typeof(T), CultureInfo.InvariantCulture);
	}

	public static object? FromJniHandle(nint handle, JniHandleOwnership transfer, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType = null)
	{
		if (handle == IntPtr.Zero)
		{
			return null;
		}
		IJavaObject javaObject = (IJavaObject)Java.Lang.Object.PeekObject(handle);
		if (javaObject != null)
		{
			object obj = FromJavaObject(javaObject, targetType);
			if (obj != null)
			{
				JNIEnv.DeleteRef(handle, transfer);
				return obj;
			}
		}
		if (targetType != null && typeof(IJavaObject).IsAssignableFrom(targetType))
		{
			return Java.Lang.Object.GetObject(handle, transfer, targetType);
		}
		Func<nint, JniHandleOwnership, object> func = ((targetType != null) ? (GetJniHandleConverter(targetType) ?? GetJniHandleConverter(GetTypeMapping(handle))) : GetJniHandleConverter(GetTypeMapping(handle)));
		if (func != null)
		{
			return func(handle, transfer);
		}
		IJavaPeerable javaPeerable = Java.Lang.Object.GetObject(handle, transfer);
		if (javaPeerable != null && (targetType == null || targetType.IsAssignableFrom(javaPeerable.GetType())))
		{
			return javaPeerable;
		}
		return Convert.ChangeType(javaPeerable, targetType, CultureInfo.InvariantCulture);
	}

	private static Type? GetTypeMapping(nint handle)
	{
		JniObjectReference reference = JniEnvironment.Types.GetObjectClass(new JniObjectReference(handle));
		try
		{
			string jniTypeNameFromClass = JniEnvironment.Types.GetJniTypeNameFromClass(reference);
			if (TypeMappings.TryGetValue(jniTypeNameFromClass, out Type value))
			{
				return value;
			}
			if (JniEnvironment.Types.IsAssignableFrom(reference, new JniObjectReference(JavaDictionary.map_class)))
			{
				return typeof(JavaDictionary);
			}
			if (JniEnvironment.Types.IsAssignableFrom(reference, JavaList.list_members.JniPeerType.PeerReference))
			{
				return typeof(JavaList);
			}
			if (JniEnvironment.Types.IsAssignableFrom(reference, new JniObjectReference(JavaCollection.collection_class)))
			{
				return typeof(JavaCollection);
			}
			return null;
		}
		finally
		{
			JniObjectReference.Dispose(ref reference);
		}
	}

	internal static string? GetJniClassForType(Type type)
	{
		foreach (KeyValuePair<string, Type> typeMapping in TypeMappings)
		{
			if (typeMapping.Value == type)
			{
				return typeMapping.Key;
			}
		}
		return null;
	}

	public static T? FromJavaObject<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(IJavaObject? value)
	{
		bool set;
		return FromJavaObject<T>(value, out set);
	}

	public static T? FromJavaObject<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(IJavaObject? value, out bool set)
	{
		if (value == null)
		{
			set = false;
			return default(T);
		}
		if (typeof(IJavaObject).IsAssignableFrom(typeof(T)))
		{
			set = true;
			return value._JavaCast<T>();
		}
		if (value is Android.Runtime.JavaObject javaObject)
		{
			set = true;
			if (javaObject.Instance is T)
			{
				return (T)javaObject.Instance;
			}
			return (T)Convert.ChangeType(javaObject.Instance, typeof(T), CultureInfo.InvariantCulture);
		}
		if (value is T)
		{
			set = true;
			return (T)value;
		}
		nint num = JNIEnv.ToLocalJniHandle(value);
		if (num == IntPtr.Zero)
		{
			set = false;
			return default(T);
		}
		set = true;
		Func<nint, JniHandleOwnership, object> jniHandleConverter = GetJniHandleConverter(typeof(T));
		if (jniHandleConverter != null)
		{
			return (T)jniHandleConverter(num, JniHandleOwnership.TransferLocalRef);
		}
		JNIEnv.DeleteLocalRef(num);
		return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
	}

	public static object? FromJavaObject(IJavaObject value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType = null)
	{
		if (value == null)
		{
			return null;
		}
		if (targetType != null && typeof(IJavaObject).IsAssignableFrom(targetType))
		{
			return JavaObjectExtensions.JavaCast(value, targetType);
		}
		if (value is Android.Runtime.JavaObject javaObject)
		{
			if (targetType == null)
			{
				return javaObject.Instance;
			}
			return Convert.ChangeType(javaObject.Instance, targetType, CultureInfo.InvariantCulture);
		}
		if (targetType == null || targetType.IsAssignableFrom(value.GetType()))
		{
			return value;
		}
		nint num = JNIEnv.ToLocalJniHandle(value);
		if (num == IntPtr.Zero)
		{
			return null;
		}
		Func<nint, JniHandleOwnership, object> jniHandleConverter = GetJniHandleConverter(targetType);
		if (jniHandleConverter != null)
		{
			return jniHandleConverter(num, JniHandleOwnership.TransferLocalRef);
		}
		JNIEnv.DeleteLocalRef(num);
		return Convert.ChangeType(value, targetType, CultureInfo.InvariantCulture);
	}

	private static Func<object, IJavaObject>? GetJavaObjectConverter(Type source)
	{
		if (JavaObjectConverters.TryGetValue(source, out Func<object, IJavaObject> value))
		{
			return value;
		}
		return null;
	}

	public static IJavaObject? ToJavaObject<T>([AllowNull] T value)
	{
		if (value is IJavaObject)
		{
			return (IJavaObject)(object)value;
		}
		if (value == null)
		{
			return null;
		}
		Func<object, IJavaObject> javaObjectConverter = GetJavaObjectConverter(typeof(T));
		if (javaObjectConverter != null)
		{
			return javaObjectConverter(value);
		}
		return new Android.Runtime.JavaObject(value);
	}

	private static Func<object, nint> GetLocalJniHandleConverter(object value)
	{
		Type type = value.GetType();
		if (LocalJniHandleConverters.TryGetValue(type, out Func<object, nint> value2))
		{
			return value2;
		}
		if (value != null && LocalJniHandleConverters.TryGetValue(value.GetType(), out value2))
		{
			return value2;
		}
		if (type.IsArray)
		{
			return LocalJniHandleConverters[typeof(Array)];
		}
		return LocalJniHandleConverters[typeof(Android.Runtime.JavaObject)];
	}

	internal static nint ToLocalJniHandle(object? value)
	{
		if (value == null)
		{
			return IntPtr.Zero;
		}
		if (value is IJavaObject value2)
		{
			return JNIEnv.ToLocalJniHandle(value2);
		}
		return GetLocalJniHandleConverter(value)(value);
	}

	public static TReturn WithLocalJniHandle<TValue, TReturn>(TValue value, Func<nint, TReturn> action)
	{
		nint num = ToLocalJniHandle(value);
		try
		{
			return action(num);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
	}

	public static TReturn WithLocalJniHandle<TReturn>(object? value, Func<nint, TReturn> action)
	{
		nint num = ToLocalJniHandle(value);
		try
		{
			return action(num);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
	}
}
