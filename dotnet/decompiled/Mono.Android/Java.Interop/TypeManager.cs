using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Android.Runtime;
using Java.Lang;
using Microsoft.Android.Runtime;

namespace Java.Interop;

public static class TypeManager
{
	private class TypeNameComparer : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			if ((object)x == y)
			{
				return 0;
			}
			if (x == null)
			{
				return -1;
			}
			if (y == null)
			{
				return 1;
			}
			int num = x.IndexOf(':');
			int num2 = y.IndexOf(':');
			int num3 = string.CompareOrdinal(x, 0, y, 0, System.Math.Max(num, num2));
			if (num3 != 0)
			{
				return num3;
			}
			if (num >= 0 && num2 >= 0)
			{
				return num - num2;
			}
			if (num < 0)
			{
				return x.Length - num2;
			}
			return num - y.Length;
		}
	}

	[Register("mono/android/TypeManager", DoNotGenerateAcw = true)]
	internal class JavaTypeManager : Java.Lang.Object
	{
		[Register("activate", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V", "")]
		private static void n_Activate(nint jnienv, nint jclass, nint typename_ptr, nint signature_ptr, nint jobject, nint parameters_ptr)
		{
			TypeManager.n_Activate(jnienv, jclass, typename_ptr, signature_ptr, jobject, parameters_ptr);
		}

		[UnmanagedCallersOnly]
		private static void n_Activate_mm(nint jnienv, nint jclass, nint typename_ptr, nint signature_ptr, nint jobject, nint parameters_ptr)
		{
			try
			{
				TypeManager.n_Activate(jnienv, jclass, typename_ptr, signature_ptr, jobject, parameters_ptr);
			}
			catch (System.Exception e)
			{
				AndroidEnvironment.UnhandledException(e);
			}
		}

		internal static Delegate GetActivateHandler()
		{
			return TypeManager.GetActivateHandler();
		}
	}

	private static readonly TypeNameComparer JavaNameComparer = new TypeNameComparer();

	private static _JniMarshal_PPLLLL_V? cb_activate;

	private static readonly Type[] XAConstructorSignature = new Type[2]
	{
		typeof(nint),
		typeof(JniHandleOwnership)
	};

	private static readonly Type[] JIConstructorSignature = new Type[2]
	{
		typeof(JniObjectReference).MakeByRefType(),
		typeof(JniObjectReferenceOptions)
	};

	private static Dictionary<string, List<Converter<string, Type?>>>? packageLookup;

	internal static bool ActivationEnabled => !JniEnvironment.WithinNewObjectScope;

	internal static string GetClassName(nint class_ptr)
	{
		nint ptr = RuntimeNativeMethods.monodroid_TypeManager_get_java_class_name(class_ptr);
		string result = Marshal.PtrToStringAnsi(ptr);
		RuntimeNativeMethods.monodroid_free(ptr);
		return result;
	}

	internal static string? GetJniTypeName(Type type)
	{
		lock (TypeManagerMapDictionaries.AccessLock)
		{
			if (TypeManagerMapDictionaries.ManagedToJni.TryGetValue(type, out string value))
			{
				return value;
			}
		}
		return null;
	}

	public static string? LookupTypeMapping(string[] mappings, string javaType)
	{
		int num = Array.BinarySearch(mappings, javaType, JavaNameComparer);
		if (num < 0)
		{
			return null;
		}
		int num2 = mappings[num].IndexOf(':');
		return mappings[num].Substring(num2 + 1);
	}

	internal static Delegate GetActivateHandler()
	{
		return new _JniMarshal_PPLLLL_V(n_Activate);
	}

	[UnconditionalSuppressMessage("Trimming", "IL2057", Justification = "Type.GetType() can never statically know the string value from parameter 'signature'.")]
	private static Type[] GetParameterTypes(string? signature)
	{
		if (string.IsNullOrEmpty(signature))
		{
			return Array.Empty<Type>();
		}
		string[] array = signature.Split(':');
		Type[] array2 = new Type[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = Type.GetType(array[i], throwOnError: true);
		}
		return array2;
	}

	[DebuggerDisableUserUnhandledExceptions]
	[UnconditionalSuppressMessage("Trimming", "IL2057", Justification = "Type.GetType() can never statically know the string value from parameter 'typename_ptr'.")]
	private static void n_Activate(nint jnienv, nint jclass, nint typename_ptr, nint signature_ptr, nint jobject, nint parameters_ptr)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IJavaPeerable javaPeerable = Java.Lang.Object.PeekObject(jobject);
			IJavaPeerable javaPeerable2 = javaPeerable;
			if (javaPeerable2 != null)
			{
				JniManagedPeerStates jniManagedPeerState = javaPeerable2.JniManagedPeerState;
				if (!jniManagedPeerState.HasFlag(JniManagedPeerStates.Activatable) && !jniManagedPeerState.HasFlag(JniManagedPeerStates.Replaceable))
				{
					return;
				}
			}
			if (!ActivationEnabled)
			{
				if (Logger.LogGlobalRef)
				{
					Logger.Log(LogLevel.Info, "monodroid-gref", FormattableString.Invariant($"warning: Skipping managed constructor invocation for handle 0x{jobject:x} (key_handle 0x{JNIEnv.IdentityHash(jobject):x}). Please use JNIEnv.StartCreateInstance() + JNIEnv.FinishCreateInstance() instead of JNIEnv.NewObject() and/or JNIEnv.CreateInstance()."));
				}
				return;
			}
			Type type = Type.GetType(JNIEnv.GetString(typename_ptr, JniHandleOwnership.DoNotTransfer), throwOnError: true);
			if (type.IsGenericTypeDefinition)
			{
				throw new NotSupportedException("Constructing instances of generic types from Java is not supported, as the type parameters cannot be determined.", CreateJavaLocationException());
			}
			Type[] parameterTypes = GetParameterTypes(JNIEnv.GetString(signature_ptr, JniHandleOwnership.DoNotTransfer));
			object[] objectArray = JNIEnv.GetObjectArray(parameters_ptr, parameterTypes);
			ConstructorInfo constructor = type.GetConstructor(parameterTypes);
			if (constructor == null)
			{
				throw CreateMissingConstructorException(type, parameterTypes);
			}
			if (javaPeerable != null)
			{
				constructor.Invoke(javaPeerable, objectArray);
			}
			else
			{
				Activate(jobject, constructor, objectArray);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[UnconditionalSuppressMessage("Trimming", "IL2072", Justification = "RuntimeHelpers.GetUninitializedObject() does not statically know the return value from ConstructorInfo.DeclaringType.")]
	internal static void Activate(nint jobject, ConstructorInfo cinfo, object?[]? parms)
	{
		try
		{
			object uninitializedObject = RuntimeHelpers.GetUninitializedObject(cinfo.DeclaringType);
			if (uninitializedObject is IJavaPeerable javaPeerable)
			{
				javaPeerable.SetPeerReference(new JniObjectReference(jobject));
				cinfo.Invoke(uninitializedObject, parms);
				return;
			}
			throw new InvalidOperationException($"Unsupported type: '{uninitializedObject}'");
		}
		catch (System.Exception innerException)
		{
			string text = FormattableString.Invariant($"Could not activate JNI Handle 0x{jobject:x} (key_handle 0x{JNIEnv.IdentityHash(jobject):x}) of Java type '{JNIEnv.GetClassNameFromInstance(jobject)}' as managed type '{cinfo?.DeclaringType?.FullName}'.");
			Logger.Log(LogLevel.Warn, "monodroid", text);
			Logger.Log(LogLevel.Warn, "monodroid", CreateJavaLocationException().ToString());
			throw new NotSupportedException(text, innerException);
		}
	}

	private static System.Exception CreateMissingConstructorException(Type type, Type[] ptypes)
	{
		System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
		stringBuilder.Append("Unable to find ");
		if (ptypes.Length == 0)
		{
			stringBuilder.Append("the default constructor");
		}
		else
		{
			stringBuilder.Append("a constructor with signature (").Append(ptypes[0].FullName);
			for (int i = 1; i < ptypes.Length; i++)
			{
				stringBuilder.Append(", ").Append(ptypes[i].FullName);
			}
			stringBuilder.Append(")");
		}
		stringBuilder.Append(" on type ").Append(type.FullName).Append(".  Please provide the missing constructor.");
		return new NotSupportedException(stringBuilder.ToString(), CreateJavaLocationException());
	}

	private static System.Exception CreateJavaLocationException()
	{
		using Error error = new Error("Java callstack:");
		return new JavaLocationException(error.ToString());
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Type monodroid_typemap_java_to_managed(string java_type_name);

	private static Type monovm_typemap_java_to_managed(string java_type_name)
	{
		return monodroid_typemap_java_to_managed(java_type_name);
	}

	internal static Type? GetJavaToManagedType(string class_name)
	{
		lock (TypeManagerMapDictionaries.AccessLock)
		{
			return GetJavaToManagedTypeCore(class_name);
		}
	}

	private static Type? GetJavaToManagedTypeCore(string class_name)
	{
		if (TypeManagerMapDictionaries.JniToManaged.TryGetValue(class_name, out Type value))
		{
			return value;
		}
		_ = 1;
		value = monovm_typemap_java_to_managed(class_name);
		if (value != null)
		{
			TypeManagerMapDictionaries.JniToManaged.Add(class_name, value);
			return value;
		}
		if (Logger.LogAssembly)
		{
			JNIEnv.LogTypemapTrace(new StackTrace(fNeedFileInfo: true));
		}
		return null;
	}

	[UnconditionalSuppressMessage("Trimming", "IL2067", Justification = "TypeManager.CreateProxy() does not statically know the value of the 'type' local variable.")]
	[UnconditionalSuppressMessage("Trimming", "IL2072", Justification = "TypeManager.CreateProxy() does not statically know the value of the 'type' local variable.")]
	internal static IJavaPeerable? CreateInstance(nint handle, JniHandleOwnership transfer, Type? targetType)
	{
		Type type = null;
		nint num = JNIEnv.GetObjectClass(handle);
		string class_name = GetClassName(num);
		lock (TypeManagerMapDictionaries.AccessLock)
		{
			while (num != IntPtr.Zero)
			{
				type = GetJavaToManagedTypeCore(class_name);
				if (type != null)
				{
					break;
				}
				nint superclass = JNIEnv.GetSuperclass(num);
				JNIEnv.DeleteLocalRef(num);
				class_name = null;
				num = superclass;
				if (num != IntPtr.Zero)
				{
					class_name = GetClassName(num);
				}
			}
		}
		if (num != IntPtr.Zero)
		{
			JNIEnv.DeleteLocalRef(num);
			num = IntPtr.Zero;
		}
		if (targetType != null && (type == null || !targetType.IsAssignableFrom(type)))
		{
			type = targetType;
		}
		if (type == null)
		{
			class_name = JNIEnv.GetClassNameFromInstance(handle);
			JNIEnv.DeleteRef(handle, transfer);
			throw new NotSupportedException(FormattableString.Invariant($"Internal error finding wrapper class for '{class_name}'. (Where is the Java.Lang.Object wrapper?!)"), CreateJavaLocationException());
		}
		if (type.IsInterface || type.IsAbstract)
		{
			Type? invokerType = JavaObjectExtensions.GetInvokerType(type);
			if (invokerType == null)
			{
				throw new NotSupportedException("Unable to find Invoker for type '" + type.FullName + "'. Was it linked away?", CreateJavaLocationException());
			}
			type = invokerType;
		}
		JniTypeSignature jniTypeSignature = JNIEnvInit.androidRuntime?.TypeManager.GetTypeSignature(type) ?? default(JniTypeSignature);
		if (!jniTypeSignature.IsValid || jniTypeSignature.SimpleReference == null)
		{
			throw new ArgumentException("Could not determine Java type corresponding to `" + type.AssemblyQualifiedName + "`.", "targetType");
		}
		JniObjectReference reference = default(JniObjectReference);
		JniObjectReference reference2 = default(JniObjectReference);
		try
		{
			try
			{
				reference = JniEnvironment.Types.FindClass(jniTypeSignature.SimpleReference);
			}
			catch (System.Exception innerException)
			{
				throw new ArgumentException("Could not find Java class `" + jniTypeSignature.SimpleReference + "`.", "targetType", innerException);
			}
			reference2 = JniEnvironment.Types.GetObjectClass(new JniObjectReference(handle));
			if (!JniEnvironment.Types.IsAssignableFrom(reference2, reference))
			{
				if (Logger.LogAssembly)
				{
					string log = $"Handle 0x{handle:x} is of type '{JNIEnv.GetClassNameFromInstance(handle)}' which is not assignable to '{jniTypeSignature.SimpleReference}'";
					Logger.Log(LogLevel.Debug, "monodroid-assembly", log);
				}
				if (Microsoft.Android.Runtime.RuntimeFeature.IsAssignableFromCheck)
				{
					return null;
				}
			}
		}
		finally
		{
			JniObjectReference.Dispose(ref reference2);
			JniObjectReference.Dispose(ref reference);
		}
		IJavaPeerable javaPeerable = null;
		try
		{
			javaPeerable = (IJavaPeerable)CreateProxy(type, handle, transfer);
			if (Runtime.IsGCUserPeer(javaPeerable.PeerReference.Handle))
			{
				javaPeerable.SetJniManagedPeerState(JniManagedPeerStates.Activatable | JniManagedPeerStates.Replaceable);
			}
		}
		catch (MissingMethodException innerException2)
		{
			nint num2 = JNIEnv.IdentityHash(handle);
			JNIEnv.DeleteRef(handle, transfer);
			throw new NotSupportedException(FormattableString.Invariant($"Unable to activate instance of type {type} from native handle 0x{handle:x} (key_handle 0x{num2:x})."), innerException2);
		}
		return javaPeerable;
	}

	internal static object CreateProxy([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type type, nint handle, JniHandleOwnership transfer)
	{
		IJavaPeerable javaPeerable = GetUninitializedObject(type);
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
		ConstructorInfo constructor = type.GetConstructor(bindingAttr, null, XAConstructorSignature, null);
		if (constructor != null)
		{
			constructor.Invoke(javaPeerable, new object[2] { handle, transfer });
			return javaPeerable;
		}
		constructor = type.GetConstructor(bindingAttr, null, JIConstructorSignature, null);
		if (constructor != null)
		{
			JniObjectReference jniObjectReference = new JniObjectReference(handle);
			JniObjectReferenceOptions jniObjectReferenceOptions = JniObjectReferenceOptions.Copy;
			constructor.Invoke(javaPeerable, new object[2] { jniObjectReference, jniObjectReferenceOptions });
			JNIEnv.DeleteRef(handle, transfer);
			return javaPeerable;
		}
		GC.SuppressFinalize(javaPeerable);
		throw new MissingMethodException("No constructor found for " + type.FullName + "::.ctor(System.IntPtr, Android.Runtime.JniHandleOwnership)", CreateJavaLocationException());
		static IJavaPeerable GetUninitializedObject([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type type2)
		{
			IJavaPeerable obj = (IJavaPeerable)RuntimeHelpers.GetUninitializedObject(type2);
			obj.SetJniManagedPeerState(JniManagedPeerStates.Activatable | JniManagedPeerStates.Replaceable);
			return obj;
		}
	}

	public static void RegisterType(string java_class, Type t)
	{
		string jniName = JNIEnv.GetJniName(t);
		lock (TypeManagerMapDictionaries.AccessLock)
		{
			if (!TypeManagerMapDictionaries.JniToManaged.TryGetValue(java_class, out Type _))
			{
				TypeManagerMapDictionaries.JniToManaged.Add(java_class, t);
				if (string.Compare(jniName, java_class, StringComparison.OrdinalIgnoreCase) != 0)
				{
					TypeManagerMapDictionaries.ManagedToJni.Add(t, java_class);
				}
			}
			else if (t != typeof(TypeManager))
			{
				Logger.Log(LogLevel.Warn, "monodroid", FormattableString.Invariant($"Type Registration Skipped for {java_class} to {t} "));
			}
		}
	}

	[MemberNotNull("packageLookup")]
	private static void LazyInitPackageLookup()
	{
		if (packageLookup == null)
		{
			packageLookup = new Dictionary<string, List<Converter<string, Type>>>(StringComparer.Ordinal);
		}
	}

	public static void RegisterPackage(string package, Converter<string, Type> lookup)
	{
		LazyInitPackageLookup();
		lock (packageLookup)
		{
			if (!packageLookup.TryGetValue(package, out List<Converter<string, Type>> value))
			{
				packageLookup.Add(package, value = new List<Converter<string, Type>>());
			}
			value.Add(lookup);
		}
	}

	public static void RegisterPackages(string[] packages, Converter<string, Type?>[] lookups)
	{
		LazyInitPackageLookup();
		if (packages == null)
		{
			throw new ArgumentNullException("packages");
		}
		if (lookups == null)
		{
			throw new ArgumentNullException("lookups");
		}
		if (packages.Length != lookups.Length)
		{
			throw new ArgumentException("`packages` and `lookups` arrays must have same number of elements.");
		}
		lock (packageLookup)
		{
			for (int i = 0; i < packages.Length; i++)
			{
				string key = packages[i];
				Converter<string, Type> item = lookups[i];
				if (!packageLookup.TryGetValue(key, out List<Converter<string, Type>> value))
				{
					packageLookup.Add(key, value = new List<Converter<string, Type>>());
				}
				value.Add(item);
			}
		}
	}
}
