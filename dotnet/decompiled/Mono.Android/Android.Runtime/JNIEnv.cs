using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Java.Interop;
using Java.Interop.Tools.TypeNameMappings;
using Java.Lang;

namespace Android.Runtime;

public static class JNIEnv
{
	[ThreadStatic]
	private static byte[]? mvid_bytes;

	private static Dictionary<Type, Func<Type?, nint, int, object?>>? nativeArrayElementToManaged;

	private static Dictionary<Type, Action<Array, nint>>? copyManagedToNativeArray;

	private static Dictionary<Type, Func<Type?, nint, int, Array>>? nativeArrayToManaged;

	private static Dictionary<Type, Func<Array, nint>>? createManagedToNativeArray;

	private static Dictionary<Type, Action<nint, int, object?>>? setNativeArrayElement;

	public static nint Handle => JniEnvironment.EnvironmentPointer;

	private static Dictionary<Type, Func<Type?, nint, int, object?>> NativeArrayElementToManaged
	{
		get
		{
			if (nativeArrayElementToManaged != null)
			{
				return nativeArrayElementToManaged;
			}
			Dictionary<Type, Func<Type, nint, int, object>> value = CreateNativeArrayElementToManaged();
			Interlocked.CompareExchange(ref nativeArrayElementToManaged, value, null);
			return nativeArrayElementToManaged;
		}
	}

	private static Dictionary<Type, Action<Array, nint>> CopyManagedToNativeArray
	{
		get
		{
			if (copyManagedToNativeArray != null)
			{
				return copyManagedToNativeArray;
			}
			Dictionary<Type, Action<Array, nint>> value = CreateCopyManagedToNativeArray();
			Interlocked.CompareExchange(ref copyManagedToNativeArray, value, null);
			return copyManagedToNativeArray;
		}
	}

	private static Dictionary<Type, Func<Type?, nint, int, Array>> NativeArrayToManaged
	{
		get
		{
			if (nativeArrayToManaged != null)
			{
				return nativeArrayToManaged;
			}
			Dictionary<Type, Func<Type, nint, int, Array>> value = CreateNativeArrayToManaged();
			Interlocked.CompareExchange(ref nativeArrayToManaged, value, null);
			return nativeArrayToManaged;
		}
	}

	private static Dictionary<Type, Func<Array, nint>> CreateManagedToNativeArray
	{
		get
		{
			if (createManagedToNativeArray != null)
			{
				return createManagedToNativeArray;
			}
			Dictionary<Type, Func<Array, nint>> value = CreateCreateManagedToNativeArray();
			Interlocked.CompareExchange(ref createManagedToNativeArray, value, null);
			return createManagedToNativeArray;
		}
	}

	private static Dictionary<Type, Action<nint, int, object?>> SetNativeArrayElement
	{
		get
		{
			if (setNativeArrayElement != null)
			{
				return setNativeArrayElement;
			}
			Dictionary<Type, Action<nint, int, object>> value = CreateSetNativeArrayElement();
			Interlocked.CompareExchange(ref setNativeArrayElement, value, null);
			return setNativeArrayElement;
		}
	}

	private static Array ArrayCreateInstance(Type elementType, int length)
	{
		return Array.CreateInstance(elementType, length);
	}

	private static Type MakeArrayType(Type type)
	{
		return type.MakeArrayType();
	}

	internal static nint IdentityHash(nint v)
	{
		return JniEnvironment.References.GetIdentityHashCode(new JniObjectReference(v));
	}

	public static void CheckHandle(nint jnienv)
	{
		new JniTransition(jnienv).Dispose();
	}

	internal static bool IsGCUserPeer(nint value)
	{
		if (value == IntPtr.Zero)
		{
			return false;
		}
		if (!IsInstanceOf(value, JNIEnvInit.grefIGCUserPeer_class))
		{
			return IsInstanceOf(value, JNIEnvInit.grefGCUserPeerable_class);
		}
		return true;
	}

	internal static bool ShouldWrapJavaException(Throwable? t, [CallerMemberName] string? caller = null)
	{
		if (t == null)
		{
			RuntimeNativeMethods.monodroid_log(LogLevel.Warn, LogCategories.Default, "ShouldWrapJavaException was not passed a valid `Java.Lang.Throwable` instance. Called from method `" + caller + "`");
			return false;
		}
		bool num = JNIEnvInit.BoundExceptionType == BoundExceptionType.System;
		if (!num)
		{
			RuntimeNativeMethods.monodroid_log(LogLevel.Warn, LogCategories.Default, $"Not wrapping exception of type {t.GetType().FullName} from method `{caller}`. This will change in a future release.");
		}
		return num;
	}

	private static void MonoDroidUnhandledException(System.Exception ex)
	{
		RuntimeNativeMethods.monodroid_unhandled_exception(ex);
	}

	internal static void PropagateUncaughtException(nint env, nint javaThreadPtr, nint javaExceptionPtr)
	{
		if (!JNIEnvInit.PropagateExceptions)
		{
			return;
		}
		Throwable throwable = Java.Lang.Object.GetObject<Throwable>(env, javaExceptionPtr, JniHandleOwnership.DoNotTransfer);
		if (Debugger.IsAttached)
		{
			AndroidRuntimeInternal.mono_unhandled_exception?.Invoke(throwable);
		}
		try
		{
			System.Exception ex = (throwable as JavaProxyThrowable)?.InnerException;
			Logger.Log(LogLevel.Info, "MonoDroid", "UNHANDLED EXCEPTION:");
			Logger.Log(LogLevel.Info, "MonoDroid", throwable.ToString());
			_ = 1;
			MonoDroidUnhandledException(ex ?? throwable);
		}
		catch (System.Exception ex2)
		{
			Logger.Log(LogLevel.Error, "monodroid", "Exception thrown while raising AppDomain.UnhandledException event: " + ex2.ToString());
		}
	}

	public static nint AllocObject(string jniClassName)
	{
		nint num = FindClass(jniClassName);
		try
		{
			return AllocObject(num);
		}
		finally
		{
			DeleteGlobalRef(num);
		}
	}

	public static nint AllocObject(Type type)
	{
		nint num = FindClass(type);
		try
		{
			return AllocObject(num);
		}
		finally
		{
			DeleteGlobalRef(num);
		}
	}

	public unsafe static nint StartCreateInstance(nint jclass, nint constructorId, JValue* constructorParameters)
	{
		return AllocObject(jclass);
	}

	public unsafe static nint StartCreateInstance(nint jclass, nint constructorId, params JValue[] constructorParameters)
	{
		fixed (JValue* constructorParameters2 = constructorParameters)
		{
			return StartCreateInstance(jclass, constructorId, constructorParameters2);
		}
	}

	public unsafe static void FinishCreateInstance(nint instance, nint jclass, nint constructorId, JValue* constructorParameters)
	{
		CallNonvirtualVoidMethod(instance, jclass, constructorId, constructorParameters);
	}

	public unsafe static void FinishCreateInstance(nint instance, nint jclass, nint constructorId, params JValue[] constructorParameters)
	{
		fixed (JValue* constructorParameters2 = constructorParameters)
		{
			FinishCreateInstance(instance, jclass, constructorId, constructorParameters2);
		}
	}

	public unsafe static nint StartCreateInstance(Type type, string jniCtorSignature, JValue* constructorParameters)
	{
		return AllocObject(type);
	}

	public unsafe static nint StartCreateInstance(Type type, string jniCtorSignature, params JValue[] constructorParameters)
	{
		fixed (JValue* constructorParameters2 = constructorParameters)
		{
			return StartCreateInstance(type, jniCtorSignature, constructorParameters2);
		}
	}

	public unsafe static nint StartCreateInstance(string jniClassName, string jniCtorSignature, JValue* constructorParameters)
	{
		return AllocObject(jniClassName);
	}

	public unsafe static nint StartCreateInstance(string jniClassName, string jniCtorSignature, params JValue[] constructorParameters)
	{
		fixed (JValue* constructorParameters2 = constructorParameters)
		{
			return StartCreateInstance(jniClassName, jniCtorSignature, constructorParameters2);
		}
	}

	public unsafe static void FinishCreateInstance(nint instance, string jniCtorSignature, JValue* constructorParameters)
	{
		InvokeConstructor(instance, jniCtorSignature, constructorParameters);
	}

	public unsafe static void FinishCreateInstance(nint instance, string jniCtorSignature, params JValue[] constructorParameters)
	{
		fixed (JValue* constructorParameters2 = constructorParameters)
		{
			FinishCreateInstance(instance, jniCtorSignature, constructorParameters2);
		}
	}

	public unsafe static void InvokeConstructor(nint instance, string jniCtorSignature, JValue* constructorParameters)
	{
		nint objectClass = GetObjectClass(instance);
		try
		{
			nint methodID = GetMethodID(objectClass, "<init>", jniCtorSignature);
			if (methodID == IntPtr.Zero)
			{
				throw new ArgumentException(FormattableString.Invariant($"Could not find constructor JNI signature '{jniCtorSignature}' on type '{JniEnvironment.Types.GetJniTypeNameFromClass(new JniObjectReference(objectClass))}'."));
			}
			CallNonvirtualVoidMethod(instance, objectClass, methodID, constructorParameters);
		}
		finally
		{
			DeleteLocalRef(objectClass);
		}
	}

	public static nint FindClass(Type type)
	{
		int arrayInfo = JavaNativeTypeManager.GetArrayInfo(type, out type);
		try
		{
			JniTypeSignature jniTypeSignature = JNIEnvInit.androidRuntime?.TypeManager.GetTypeSignature(type) ?? default(JniTypeSignature);
			if (!jniTypeSignature.IsValid || jniTypeSignature.SimpleReference == null)
			{
				jniTypeSignature = new JniTypeSignature("java/lang/Object");
			}
			JniObjectReference reference = JniEnvironment.Types.FindClass(jniTypeSignature.AddArrayRank(arrayInfo).Name);
			nint handle = reference.NewGlobalRef().Handle;
			JniObjectReference.Dispose(ref reference);
			return handle;
		}
		catch (Throwable throwable)
		{
			if (!(throwable is NoClassDefFoundError) && !(throwable is ClassNotFoundException))
			{
				throw;
			}
			RuntimeNativeMethods.monodroid_log(LogLevel.Warn, LogCategories.Default, $"JNIEnv.FindClass(Type) caught unexpected exception: {throwable}");
			string jniTypeName = Java.Interop.TypeManager.GetJniTypeName(type);
			if (jniTypeName != null)
			{
				throwable.Dispose();
				return FindClass(JavaNativeTypeManager.ToJniName(jniTypeName, arrayInfo));
			}
			jniTypeName = JavaNativeTypeManager.ToJniNameFromAttributes(type);
			if (jniTypeName != null)
			{
				throwable.Dispose();
				return FindClass(JavaNativeTypeManager.ToJniName(jniTypeName, arrayInfo));
			}
			throw;
		}
	}

	public static nint FindClass(string classname)
	{
		JniObjectReference reference = JniEnvironment.Types.FindClass(classname);
		nint result = NewGlobalRef(reference.Handle);
		JniObjectReference.Dispose(ref reference);
		return result;
	}

	public static nint FindClass(string className, ref nint cachedJniClassHandle)
	{
		if (cachedJniClassHandle != IntPtr.Zero)
		{
			return cachedJniClassHandle;
		}
		nint num = FindClass(className);
		if (Interlocked.CompareExchange(ref cachedJniClassHandle, num, IntPtr.Zero) != IntPtr.Zero)
		{
			DeleteGlobalRef(num);
		}
		return cachedJniClassHandle;
	}

	public static void Throw(nint obj)
	{
		if (obj == IntPtr.Zero)
		{
			throw new ArgumentException("'obj' must not be IntPtr.Zero.", "obj");
		}
		JniEnvironment.Exceptions.Throw(new JniObjectReference(obj));
	}

	internal static void DeleteRef(nint handle, JniHandleOwnership transfer)
	{
		switch (transfer)
		{
		case JniHandleOwnership.TransferLocalRef:
			DeleteLocalRef(handle);
			break;
		case JniHandleOwnership.TransferGlobalRef:
			DeleteGlobalRef(handle);
			break;
		case JniHandleOwnership.DoNotTransfer:
			break;
		}
	}

	public static nint NewGlobalRef(nint jobject)
	{
		return new JniObjectReference(jobject).NewGlobalRef().Handle;
	}

	public static void DeleteGlobalRef(nint jobject)
	{
		JniObjectReference reference = new JniObjectReference(jobject, JniObjectReferenceType.Global);
		JniObjectReference.Dispose(ref reference);
	}

	public static nint NewLocalRef(nint jobject)
	{
		return new JniObjectReference(jobject).NewLocalRef().Handle;
	}

	public static void DeleteLocalRef(nint jobject)
	{
		JniObjectReference reference = new JniObjectReference(jobject, JniObjectReferenceType.Local);
		JniObjectReference.Dispose(ref reference);
	}

	public static string GetClassNameFromInstance(nint jobject)
	{
		return JniEnvironment.Types.GetJniTypeNameFromInstance(new JniObjectReference(jobject));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern nint monodroid_typemap_managed_to_java(Type type, byte* mvid);

	internal static void LogTypemapTrace(StackTrace st)
	{
		string text = st.ToString()?.Trim();
		if (!string.IsNullOrEmpty(text))
		{
			RuntimeNativeMethods.monodroid_log(LogLevel.Warn, LogCategories.Assembly, "typemap: called from");
			string[] array = text.Split('\n');
			foreach (string message in array)
			{
				RuntimeNativeMethods.monodroid_log(LogLevel.Warn, LogCategories.Assembly, message);
			}
		}
	}

	private unsafe static nint monovm_typemap_managed_to_java(Type type, byte* mvidptr)
	{
		return monodroid_typemap_managed_to_java(type, mvidptr);
	}

	internal unsafe static string? TypemapManagedToJava(Type type)
	{
		if (mvid_bytes == null)
		{
			mvid_bytes = new byte[16];
		}
		Span<byte> destination = new Span<byte>(mvid_bytes);
		byte[] array = null;
		if (!type.Module.ModuleVersionId.TryWriteBytes(destination))
		{
			RuntimeNativeMethods.monodroid_log(LogLevel.Warn, LogCategories.Default, "Failed to obtain module MVID using the fast method, falling back to the slow one");
			array = type.Module.ModuleVersionId.ToByteArray();
		}
		else
		{
			array = mvid_bytes;
		}
		nint num;
		fixed (byte* mvidptr = array)
		{
			_ = 1;
			num = monovm_typemap_managed_to_java(type, mvidptr);
		}
		if (num == IntPtr.Zero)
		{
			if (Logger.LogAssembly)
			{
				RuntimeNativeMethods.monodroid_log(LogLevel.Warn, LogCategories.Default, $"typemap: failed to map managed type to Java type: {type.AssemblyQualifiedName} (Module ID: {type.Module.ModuleVersionId}; Type token: {type.MetadataToken})");
				LogTypemapTrace(new StackTrace(fNeedFileInfo: true));
			}
			return null;
		}
		return Marshal.PtrToStringAnsi(num);
	}

	public static string GetJniName(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		JniTypeSignature jniTypeSignature = JNIEnvInit.androidRuntime?.TypeManager.GetTypeSignature(type) ?? default(JniTypeSignature);
		if (jniTypeSignature.SimpleReference != null)
		{
			return jniTypeSignature.Name;
		}
		return JavaNativeTypeManager.ToJniName(type);
	}

	public static nint ToLocalJniHandle(IJavaObject? value)
	{
		if (value == null)
		{
			return IntPtr.Zero;
		}
		if (value is IJavaObjectEx javaObjectEx)
		{
			return javaObjectEx.ToLocalJniHandle();
		}
		return NewLocalRef(value.Handle);
	}

	public static string? GetCharSequence(nint jobject, JniHandleOwnership transfer)
	{
		if (jobject == IntPtr.Zero)
		{
			return null;
		}
		JniObjectReference value = JniEnvironment.Object.ToString(new JniObjectReference(jobject));
		return JniEnvironment.Strings.ToString(ref value, JniObjectReferenceOptions.CopyAndDispose);
	}

	public static string? GetString(nint value, JniHandleOwnership transfer)
	{
		if (value == IntPtr.Zero)
		{
			return null;
		}
		string? result = JniEnvironment.Strings.ToString(new JniObjectReference(value));
		DeleteRef(value, transfer);
		return result;
	}

	public static nint NewString(string? text)
	{
		if (text == null)
		{
			return IntPtr.Zero;
		}
		return JniEnvironment.Strings.NewString(text).Handle;
	}

	private static void AssertCompatibleArrayTypes(Type sourceType, nint destArray)
	{
		nint num = FindClass(sourceType);
		nint objectClass = GetObjectClass(destArray);
		try
		{
			if (!IsAssignableFrom(num, objectClass))
			{
				throw new InvalidCastException(FormattableString.Invariant($"Unable to cast from '{JniEnvironment.Types.GetJniTypeNameFromClass(new JniObjectReference(num))}' to '{JniEnvironment.Types.GetJniTypeNameFromClass(new JniObjectReference(objectClass))}'."));
			}
		}
		finally
		{
			DeleteGlobalRef(num);
			DeleteLocalRef(objectClass);
		}
	}

	private static void AssertCompatibleArrayTypes(nint sourceArray, Type destType)
	{
		nint num = FindClass(destType);
		nint objectClass = GetObjectClass(sourceArray);
		try
		{
			if (!IsAssignableFrom(objectClass, num))
			{
				throw new InvalidCastException(FormattableString.Invariant($"Unable to cast from '{JniEnvironment.Types.GetJniTypeNameFromClass(new JniObjectReference(objectClass))}' to '{JniEnvironment.Types.GetJniTypeNameFromClass(new JniObjectReference(num))}'."));
			}
		}
		finally
		{
			DeleteGlobalRef(num);
			DeleteLocalRef(objectClass);
		}
	}

	public static void CopyArray(nint src, bool[] dest)
	{
		if (dest == null)
		{
			throw new ArgumentNullException("dest");
		}
		AssertCompatibleArrayTypes(src, typeof(bool[]));
		_GetBooleanArrayRegion(src, 0, dest.Length, dest);
	}

	public static void CopyArray(nint src, string[] dest)
	{
		if (dest == null)
		{
			throw new ArgumentNullException("dest");
		}
		for (int i = 0; i < dest.Length; i++)
		{
			dest[i] = GetString(GetObjectArrayElement(src, i), JniHandleOwnership.TransferLocalRef);
		}
	}

	private static Dictionary<Type, Func<Type?, nint, int, object?>> CreateNativeArrayElementToManaged()
	{
		return new Dictionary<Type, Func<Type, nint, int, object>>
		{
			{
				typeof(bool),
				delegate(Type? type, nint source, int index)
				{
					bool[] array = new bool[1];
					_GetBooleanArrayRegion(source, index, 1, array);
					return array[0];
				}
			},
			{
				typeof(byte),
				delegate(Type? type, nint source, int index)
				{
					byte[] array = new byte[1];
					_GetByteArrayRegion(source, index, 1, array);
					return array[0];
				}
			},
			{
				typeof(char),
				delegate(Type? type, nint source, int index)
				{
					char[] array = new char[1];
					_GetCharArrayRegion(source, index, 1, array);
					return array[0];
				}
			},
			{
				typeof(short),
				delegate(Type? type, nint source, int index)
				{
					short[] array = new short[1];
					_GetShortArrayRegion(source, index, 1, array);
					return array[0];
				}
			},
			{
				typeof(int),
				delegate(Type? type, nint source, int index)
				{
					int[] array = new int[1];
					_GetIntArrayRegion(source, index, 1, array);
					return array[0];
				}
			},
			{
				typeof(long),
				delegate(Type? type, nint source, int index)
				{
					long[] array = new long[1];
					_GetLongArrayRegion(source, index, 1, array);
					return array[0];
				}
			},
			{
				typeof(float),
				delegate(Type? type, nint source, int index)
				{
					float[] array = new float[1];
					_GetFloatArrayRegion(source, index, 1, array);
					return array[0];
				}
			},
			{
				typeof(double),
				delegate(Type? type, nint source, int index)
				{
					double[] array = new double[1];
					_GetDoubleArrayRegion(source, index, 1, array);
					return array[0];
				}
			},
			{
				typeof(string),
				delegate(Type? type, nint source, int index)
				{
					nint objectArrayElement = GetObjectArrayElement(source, index);
					return (type == typeof(Java.Lang.String)) ? ((IEnumerable<char>)new Java.Lang.String(objectArrayElement, JniHandleOwnership.TransferLocalRef)) : ((IEnumerable<char>)GetString(objectArrayElement, JniHandleOwnership.TransferLocalRef));
				}
			},
			{
				typeof(IJavaObject),
				delegate(Type? type, nint source, int index)
				{
					AssertIsJavaObject(type);
					return GetObject(GetObjectArrayElement(source, index), type);
				}
			},
			{
				typeof(Array),
				(Type? type, nint source, int index) => GetArray(GetObjectArrayElement(source, index), JniHandleOwnership.TransferLocalRef, type)
			}
		};
		[UnconditionalSuppressMessage("Trimming", "IL2067", Justification = "FIXME: https://github.com/xamarin/xamarin-android/issues/8724")]
		static object? GetObject(nint e, Type t)
		{
			return Java.Lang.Object.GetObject(e, JniHandleOwnership.TransferLocalRef, t);
		}
	}

	private static TValue GetConverter<TValue>(Dictionary<Type, TValue> dict, Type? elementType, nint array)
	{
		if (elementType != null)
		{
			if (elementType.IsEnum)
			{
				elementType = System.Enum.GetUnderlyingType(elementType);
			}
			if (dict.TryGetValue(elementType, out TValue value))
			{
				return value;
			}
		}
		if (array != IntPtr.Zero)
		{
			string classNameFromInstance = GetClassNameFromInstance(array);
			if (classNameFromInstance == null || classNameFromInstance.Length < 1 || classNameFromInstance[0] != '[')
			{
				throw new InvalidOperationException("Unsupported java array type: " + classNameFromInstance);
			}
			switch (classNameFromInstance[1])
			{
			case 'B':
				return dict[typeof(byte)];
			case 'C':
				return dict[typeof(char)];
			case 'D':
				return dict[typeof(double)];
			case 'F':
				return dict[typeof(float)];
			case 'I':
				return dict[typeof(int)];
			case 'J':
				return dict[typeof(long)];
			case 'S':
				return dict[typeof(short)];
			case 'Z':
				return dict[typeof(bool)];
			case '[':
				if (elementType == null || elementType.IsArray)
				{
					return dict[typeof(Array)];
				}
				break;
			}
			if (classNameFromInstance == "[Ljava/lang/String;")
			{
				return dict[typeof(string)];
			}
		}
		if (elementType != null && elementType.IsArray)
		{
			return dict[typeof(Array)];
		}
		AssertIsJavaObject(elementType);
		return dict[typeof(IJavaObject)];
	}

	private unsafe static void _GetBooleanArrayRegion(nint array, int start, int length, bool[] buffer)
	{
		fixed (bool* buffer2 = buffer)
		{
			JniEnvironment.Arrays.GetBooleanArrayRegion(new JniObjectReference(array), start, length, buffer2);
		}
	}

	private unsafe static void _GetByteArrayRegion(nint array, int start, int length, byte[] buffer)
	{
		fixed (byte* buffer2 = buffer)
		{
			JniEnvironment.Arrays.GetByteArrayRegion(new JniObjectReference(array), start, length, (sbyte*)buffer2);
		}
	}

	private unsafe static void _GetCharArrayRegion(nint array, int start, int length, char[] buffer)
	{
		fixed (char* buffer2 = buffer)
		{
			JniEnvironment.Arrays.GetCharArrayRegion(new JniObjectReference(array), start, length, buffer2);
		}
	}

	private unsafe static void _GetShortArrayRegion(nint array, int start, int length, short[] buffer)
	{
		fixed (short* buffer2 = buffer)
		{
			JniEnvironment.Arrays.GetShortArrayRegion(new JniObjectReference(array), start, length, buffer2);
		}
	}

	private unsafe static void _GetIntArrayRegion(nint array, int start, int length, int[] buffer)
	{
		fixed (int* buffer2 = buffer)
		{
			JniEnvironment.Arrays.GetIntArrayRegion(new JniObjectReference(array), start, length, buffer2);
		}
	}

	private unsafe static void _GetLongArrayRegion(nint array, int start, int length, long[] buffer)
	{
		fixed (long* buffer2 = buffer)
		{
			JniEnvironment.Arrays.GetLongArrayRegion(new JniObjectReference(array), start, length, buffer2);
		}
	}

	private unsafe static void _GetFloatArrayRegion(nint array, int start, int length, float[] buffer)
	{
		fixed (float* buffer2 = buffer)
		{
			JniEnvironment.Arrays.GetFloatArrayRegion(new JniObjectReference(array), start, length, buffer2);
		}
	}

	private unsafe static void _GetDoubleArrayRegion(nint array, int start, int length, double[] buffer)
	{
		fixed (double* buffer2 = buffer)
		{
			JniEnvironment.Arrays.GetDoubleArrayRegion(new JniObjectReference(array), start, length, buffer2);
		}
	}

	public static void CopyArray(nint src, Array dest, Type? elementType = null)
	{
		if (dest == null)
		{
			throw new ArgumentNullException("dest");
		}
		if (elementType != null && elementType.IsValueType)
		{
			AssertCompatibleArrayTypes(src, MakeArrayType(elementType));
		}
		if (elementType != null && elementType.IsArray)
		{
			for (int i = 0; i < dest.Length; i++)
			{
				nint objectArrayElement = GetObjectArrayElement(src, i);
				try
				{
					Array array = (Array)dest.GetValue(i);
					if (array == null)
					{
						dest.SetValue(GetArray(objectArrayElement, JniHandleOwnership.DoNotTransfer, elementType.GetElementType()), i);
					}
					else
					{
						CopyArray(objectArrayElement, array, elementType.GetElementType());
					}
				}
				finally
				{
					DeleteLocalRef(objectArrayElement);
				}
			}
		}
		else
		{
			Func<Type, nint, int, object> converter = GetConverter(NativeArrayElementToManaged, elementType, src);
			for (int j = 0; j < dest.Length; j++)
			{
				dest.SetValue(converter(elementType, src, j), j);
			}
		}
	}

	private static void AssertIsJavaObject(Type? targetType)
	{
		if (targetType != null && !typeof(IJavaObject).IsAssignableFrom(targetType))
		{
			throw new NotSupportedException("Don't know how to convert type '" + targetType.FullName + "' to an Android.Runtime.IJavaObject.");
		}
	}

	public static void CopyArray<T>(nint src, T[] dest)
	{
		if (dest == null)
		{
			throw new ArgumentNullException("dest");
		}
		if (typeof(T).IsValueType)
		{
			AssertCompatibleArrayTypes(src, typeof(T[]));
		}
		if (typeof(T).IsArray)
		{
			CopyArray(src, dest, typeof(T));
			return;
		}
		Func<Type, nint, int, object> converter = GetConverter(NativeArrayElementToManaged, typeof(T), src);
		for (int i = 0; i < dest.Length; i++)
		{
			dest[i] = (T)converter(typeof(T), src, i);
		}
	}

	public unsafe static void CopyArray(bool[] src, nint dest)
	{
		if (src == null)
		{
			throw new ArgumentNullException("src");
		}
		AssertCompatibleArrayTypes(typeof(bool[]), dest);
		fixed (bool* buffer = src)
		{
			JniEnvironment.Arrays.SetBooleanArrayRegion(new JniObjectReference(dest), 0, src.Length, buffer);
		}
	}

	public static void CopyArray(string[] src, nint dest)
	{
		if (src == null)
		{
			throw new ArgumentNullException("src");
		}
		for (int i = 0; i < src.Length; i++)
		{
			nint num = NewString(src[i]);
			JniEnvironment.Arrays.SetObjectArrayElement(new JniObjectReference(dest), i, new JniObjectReference(num));
			DeleteLocalRef(num);
		}
	}

	public static void CopyArray(IJavaObject[] src, nint dest)
	{
		if (src == null)
		{
			throw new ArgumentNullException("src");
		}
		for (int i = 0; i < src.Length; i++)
		{
			IJavaObject javaObject = src[i];
			JniEnvironment.Arrays.SetObjectArrayElement(new JniObjectReference(dest), i, new JniObjectReference(javaObject?.Handle ?? IntPtr.Zero));
		}
	}

	private static Dictionary<Type, Action<Array, nint>> CreateCopyManagedToNativeArray()
	{
		return new Dictionary<Type, Action<Array, nint>>
		{
			{
				typeof(bool),
				delegate(Array source, nint dest)
				{
					CopyArray((bool[])source, dest);
				}
			},
			{
				typeof(byte),
				delegate(Array source, nint dest)
				{
					CopyArray((byte[])source, dest);
				}
			},
			{
				typeof(char),
				delegate(Array source, nint dest)
				{
					CopyArray((char[])source, dest);
				}
			},
			{
				typeof(short),
				delegate(Array source, nint dest)
				{
					CopyArray((short[])source, dest);
				}
			},
			{
				typeof(int),
				delegate(Array source, nint dest)
				{
					CopyArray((int[])source, dest);
				}
			},
			{
				typeof(long),
				delegate(Array source, nint dest)
				{
					CopyArray((long[])source, dest);
				}
			},
			{
				typeof(float),
				delegate(Array source, nint dest)
				{
					CopyArray((float[])source, dest);
				}
			},
			{
				typeof(double),
				delegate(Array source, nint dest)
				{
					CopyArray((double[])source, dest);
				}
			},
			{
				typeof(string),
				delegate(Array source, nint dest)
				{
					if (source is string[] src)
					{
						CopyArray(src, dest);
					}
					else
					{
						if (!(source is IJavaObject[] src2))
						{
							throw new NotSupportedException("Don't know how to copy '" + source.GetType().FullName + "' to '" + GetClassNameFromInstance(dest) + "'.");
						}
						CopyArray(src2, dest);
					}
				}
			},
			{
				typeof(IJavaObject),
				delegate(Array source, nint dest)
				{
					CopyArray((IJavaObject[])source, dest);
				}
			},
			{
				typeof(Array),
				delegate(Array source, nint dest)
				{
					int length = source.GetLength(0);
					for (int i = 0; i < length; i++)
					{
						nint objectArrayElement = GetObjectArrayElement(dest, i);
						Array obj = (Array)source.GetValue(i);
						CopyArray(obj, obj.GetType().GetElementType(), objectArrayElement);
						DeleteLocalRef(objectArrayElement);
					}
				}
			}
		};
	}

	public static void CopyArray(Array source, Type elementType, nint dest)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (elementType == null)
		{
			throw new ArgumentNullException("elementType");
		}
		if (elementType.IsValueType)
		{
			AssertCompatibleArrayTypes(MakeArrayType(elementType), dest);
		}
		GetConverter(CopyManagedToNativeArray, elementType, dest)(source, dest);
	}

	public static void CopyArray<T>(T[] src, nint dest)
	{
		if (src == null)
		{
			throw new ArgumentNullException("src");
		}
		CopyArray(src, typeof(T), dest);
	}

	public static Array? GetArray(nint array_ptr, JniHandleOwnership transfer, Type? element_type = null)
	{
		try
		{
			return _GetArray(array_ptr, element_type);
		}
		finally
		{
			DeleteRef(array_ptr, transfer);
		}
	}

	private static Dictionary<Type, Func<Type?, nint, int, Array>> CreateNativeArrayToManaged()
	{
		return new Dictionary<Type, Func<Type, nint, int, Array>>
		{
			{
				typeof(bool),
				delegate(Type? type, nint source, int len)
				{
					bool[] array = new bool[len];
					CopyArray(source, array);
					return array;
				}
			},
			{
				typeof(byte),
				delegate(Type? type, nint source, int len)
				{
					byte[] array = new byte[len];
					CopyArray(source, array);
					return array;
				}
			},
			{
				typeof(char),
				delegate(Type? type, nint source, int len)
				{
					char[] array = new char[len];
					CopyArray(source, array);
					return array;
				}
			},
			{
				typeof(short),
				delegate(Type? type, nint source, int len)
				{
					short[] array = new short[len];
					CopyArray(source, array);
					return array;
				}
			},
			{
				typeof(ushort),
				delegate(Type? type, nint source, int len)
				{
					ushort[] array = new ushort[len];
					CopyArray(source, array);
					return array;
				}
			},
			{
				typeof(int),
				delegate(Type? type, nint source, int len)
				{
					int[] array = new int[len];
					CopyArray(source, array);
					return array;
				}
			},
			{
				typeof(uint),
				delegate(Type? type, nint source, int len)
				{
					uint[] array = new uint[len];
					CopyArray(source, array);
					return array;
				}
			},
			{
				typeof(long),
				delegate(Type? type, nint source, int len)
				{
					long[] array = new long[len];
					CopyArray(source, array);
					return array;
				}
			},
			{
				typeof(ulong),
				delegate(Type? type, nint source, int len)
				{
					ulong[] array = new ulong[len];
					CopyArray(source, array);
					return array;
				}
			},
			{
				typeof(float),
				delegate(Type? type, nint source, int len)
				{
					float[] array = new float[len];
					CopyArray(source, array);
					return array;
				}
			},
			{
				typeof(double),
				delegate(Type? type, nint source, int len)
				{
					double[] array = new double[len];
					CopyArray(source, array);
					return array;
				}
			},
			{
				typeof(string),
				delegate(Type? type, nint source, int len)
				{
					if (type != null && typeof(Java.Lang.Object).IsAssignableFrom(type))
					{
						Java.Lang.String[] array = new Java.Lang.String[len];
						CopyArray(source, array);
						return array;
					}
					string[] array2 = new string[len];
					CopyArray(source, array2);
					return array2;
				}
			},
			{
				typeof(IJavaObject),
				delegate(Type? type, nint source, int len)
				{
					Array array = ArrayCreateInstance(type, len);
					CopyArray(source, array, type);
					return array;
				}
			},
			{
				typeof(Array),
				delegate(Type? type, nint source, int len)
				{
					Array array = ArrayCreateInstance(type, len);
					CopyArray(source, array, type);
					return array;
				}
			}
		};
	}

	private static Array? _GetArray(nint array_ptr, Type? element_type)
	{
		if (array_ptr == IntPtr.Zero)
		{
			return null;
		}
		if (element_type != null && element_type.IsValueType)
		{
			AssertCompatibleArrayTypes(array_ptr, MakeArrayType(element_type));
		}
		int arg = _GetArrayLength(array_ptr);
		return GetConverter(NativeArrayToManaged, element_type, array_ptr)(element_type, array_ptr, arg);
	}

	private static int _GetArrayLength(nint array_ptr)
	{
		return JniEnvironment.Arrays.GetArrayLength(new JniObjectReference(array_ptr));
	}

	public static object?[]? GetObjectArray(nint array_ptr, Type[] element_types)
	{
		if (array_ptr == IntPtr.Zero)
		{
			return null;
		}
		int num = _GetArrayLength(array_ptr);
		if (num == 0)
		{
			return Array.Empty<object>();
		}
		Func<Type, nint, int, object> converter = GetConverter(NativeArrayElementToManaged, null, array_ptr);
		object[] array = new object[num];
		for (int i = 0; i < num; i++)
		{
			Type type = ((element_types != null && i < element_types.Length) ? element_types[i] : null);
			object obj = (array[i] = converter((type == null || type.IsValueType) ? null : type, array_ptr, i));
			array[i] = ((type == null || type.IsInstanceOfType(obj)) ? obj : Convert.ChangeType(obj, type, CultureInfo.InvariantCulture));
		}
		return array;
	}

	public static T[]? GetArray<T>(nint array_ptr)
	{
		if (array_ptr == IntPtr.Zero)
		{
			return null;
		}
		if (typeof(T).IsValueType)
		{
			AssertCompatibleArrayTypes(array_ptr, typeof(T[]));
		}
		T[] array = new T[_GetArrayLength(array_ptr)];
		CopyArray(array_ptr, array);
		return array;
	}

	public static T GetArrayItem<T>(nint array_ptr, int index)
	{
		if (array_ptr == IntPtr.Zero)
		{
			throw new ArgumentException("array_ptr");
		}
		if (index < 0 || index >= GetArrayLength(array_ptr))
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return (T)GetConverter(NativeArrayElementToManaged, typeof(T), array_ptr)(typeof(T), array_ptr, index);
	}

	public static int GetArrayLength(nint array_ptr)
	{
		if (array_ptr == IntPtr.Zero)
		{
			return 0;
		}
		return _GetArrayLength(array_ptr);
	}

	public unsafe static nint NewArray(bool[]? array)
	{
		if (array == null)
		{
			return IntPtr.Zero;
		}
		JniObjectReference array2 = JniEnvironment.Arrays.NewBooleanArray(array.Length);
		fixed (bool* buffer = array)
		{
			JniEnvironment.Arrays.SetBooleanArrayRegion(array2, 0, array.Length, buffer);
		}
		return array2.Handle;
	}

	public static nint NewArray(string[]? array)
	{
		if (array == null)
		{
			return IntPtr.Zero;
		}
		nint num = NewObjectArray(array.Length, Class.String, IntPtr.Zero);
		CopyArray(array, num);
		return num;
	}

	public static nint NewObjectArray(int length, nint elementClass, nint initialElement)
	{
		return JniEnvironment.Arrays.NewObjectArray(length, new JniObjectReference(elementClass), new JniObjectReference(initialElement)).Handle;
	}

	public static nint NewObjectArray<T>(params T[]? values)
	{
		if (values == null)
		{
			return IntPtr.Zero;
		}
		nint num = GetArrayElementClass(values);
		if (JniEnvironment.Types.GetJniTypeNameFromClass(new JniObjectReference(num)) == "mono/android/runtime/JavaObject")
		{
			DeleteGlobalRef(num);
			num = NewGlobalRef(Class.Object);
		}
		try
		{
			nint lrefArray = NewObjectArray(values.Length, num, IntPtr.Zero);
			int i = 0;
			while (i < values.Length)
			{
				JavaConvert.WithLocalJniHandle(values[i], delegate(nint lref)
				{
					SetObjectArrayElement(lrefArray, i, lref);
					return IntPtr.Zero;
				});
				int num2 = i + 1;
				i = num2;
			}
			return lrefArray;
		}
		finally
		{
			DeleteGlobalRef(num);
		}
	}

	private static nint GetArrayElementClass<T>(T[] values)
	{
		Type typeFromHandle = typeof(T);
		string jniClassForType = JavaConvert.GetJniClassForType(typeFromHandle);
		if (jniClassForType != null)
		{
			return FindClass(jniClassForType);
		}
		if (typeFromHandle.IsValueType)
		{
			return NewGlobalRef(Class.Object);
		}
		return FindClass(typeFromHandle);
	}

	public static nint NewArray(IJavaObject[]? array)
	{
		if (array == null)
		{
			return IntPtr.Zero;
		}
		nint num = FindClass(array.GetType().GetElementType());
		nint num2;
		try
		{
			num2 = NewObjectArray(array.Length, num, IntPtr.Zero);
		}
		finally
		{
			DeleteGlobalRef(num);
		}
		CopyArray(array, num2);
		return num2;
	}

	private static Dictionary<Type, Func<Array, nint>> CreateCreateManagedToNativeArray()
	{
		return new Dictionary<Type, Func<Array, nint>>
		{
			{
				typeof(bool),
				(Array source) => NewArray((bool[])source)
			},
			{
				typeof(byte),
				(Array source) => NewArray((byte[])source)
			},
			{
				typeof(char),
				(Array source) => NewArray((char[])source)
			},
			{
				typeof(short),
				(Array source) => NewArray((short[])source)
			},
			{
				typeof(int),
				(Array source) => NewArray((int[])source)
			},
			{
				typeof(long),
				(Array source) => NewArray((long[])source)
			},
			{
				typeof(float),
				(Array source) => NewArray((float[])source)
			},
			{
				typeof(double),
				(Array source) => NewArray((double[])source)
			},
			{
				typeof(string),
				(Array source) => NewArray((string[])source)
			},
			{
				typeof(IJavaObject),
				(Array source) => NewArray((IJavaObject[])source)
			},
			{
				typeof(Array),
				(Array source) => NewArray(source)
			}
		};
	}

	public static nint NewArray(Array value, Type? elementType = null)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if ((object)elementType == null)
		{
			elementType = value.GetType().GetElementType();
		}
		if (elementType.IsArray)
		{
			nint num = FindClass(elementType);
			try
			{
				return NewArray(value, elementType, num);
			}
			finally
			{
				DeleteGlobalRef(num);
			}
		}
		return GetConverter(CreateManagedToNativeArray, elementType, IntPtr.Zero)(value);
	}

	public static nint NewArray<T>(T[]? array)
	{
		if (array == null)
		{
			return IntPtr.Zero;
		}
		if (typeof(T).IsArray)
		{
			nint num = FindClass(typeof(T));
			try
			{
				return NewArray(array, typeof(T), num);
			}
			finally
			{
				DeleteGlobalRef(num);
			}
		}
		return GetConverter(CreateManagedToNativeArray, typeof(T), IntPtr.Zero)(array);
	}

	private static nint NewArray(Array value, Type elementType, nint elementClass)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		nint num = IntPtr.Zero;
		try
		{
			num = NewObjectArray(value.Length, elementClass, IntPtr.Zero);
			for (int i = 0; i < value.Length; i++)
			{
				nint num2 = NewArray((Array)value.GetValue(i), elementType.GetElementType());
				SetObjectArrayElement(num, i, num2);
				DeleteLocalRef(num2);
			}
			return num;
		}
		catch
		{
			DeleteLocalRef(num);
			throw;
		}
	}

	private static Dictionary<Type, Action<nint, int, object?>> CreateSetNativeArrayElement()
	{
		return new Dictionary<Type, Action<nint, int, object>>
		{
			{
				typeof(bool),
				delegate(nint dest, int index, object? value)
				{
					bool[] array = new bool[1] { (bool)value };
					_SetBooleanArrayRegion(dest, index, array.Length, array);
				}
			},
			{
				typeof(byte),
				delegate(nint dest, int index, object? value)
				{
					byte[] array = new byte[1] { (byte)value };
					_SetByteArrayRegion(dest, index, array.Length, array);
				}
			},
			{
				typeof(char),
				delegate(nint dest, int index, object? value)
				{
					char[] array = new char[1] { (char)value };
					_SetCharArrayRegion(dest, index, array.Length, array);
				}
			},
			{
				typeof(short),
				delegate(nint dest, int index, object? value)
				{
					short[] array = new short[1] { (short)value };
					_SetShortArrayRegion(dest, index, array.Length, array);
				}
			},
			{
				typeof(int),
				delegate(nint dest, int index, object? value)
				{
					int[] array = new int[1] { (int)value };
					_SetIntArrayRegion(dest, index, array.Length, array);
				}
			},
			{
				typeof(long),
				delegate(nint dest, int index, object? value)
				{
					long[] array = new long[1] { (long)value };
					_SetLongArrayRegion(dest, index, array.Length, array);
				}
			},
			{
				typeof(float),
				delegate(nint dest, int index, object? value)
				{
					float[] array = new float[1] { (float)value };
					_SetFloatArrayRegion(dest, index, array.Length, array);
				}
			},
			{
				typeof(double),
				delegate(nint dest, int index, object? value)
				{
					double[] array = new double[1] { (double)value };
					_SetDoubleArrayRegion(dest, index, array.Length, array);
				}
			},
			{
				typeof(string),
				delegate(nint dest, int index, object? value)
				{
					nint num = NewString(value.ToString());
					try
					{
						SetObjectArrayElement(dest, index, num);
					}
					finally
					{
						DeleteLocalRef(num);
					}
				}
			},
			{
				typeof(IJavaObject),
				delegate(nint dest, int index, object? value)
				{
					SetObjectArrayElement(dest, index, (value == null) ? IntPtr.Zero : ((IJavaObject)value).Handle);
				}
			},
			{
				typeof(Array),
				delegate(nint dest, int index, object? value)
				{
					nint num = NewArray((Array)value);
					SetObjectArrayElement(dest, index, num);
					DeleteLocalRef(num);
				}
			}
		};
	}

	private unsafe static void _SetBooleanArrayRegion(nint array, int start, int length, bool[] buffer)
	{
		fixed (bool* buffer2 = buffer)
		{
			JniEnvironment.Arrays.SetBooleanArrayRegion(new JniObjectReference(array), start, length, buffer2);
		}
	}

	private unsafe static void _SetByteArrayRegion(nint array, int start, int length, byte[] buffer)
	{
		fixed (byte* buffer2 = buffer)
		{
			JniEnvironment.Arrays.SetByteArrayRegion(new JniObjectReference(array), start, length, (sbyte*)buffer2);
		}
	}

	private unsafe static void _SetCharArrayRegion(nint array, int start, int length, char[] buffer)
	{
		fixed (char* buffer2 = buffer)
		{
			JniEnvironment.Arrays.SetCharArrayRegion(new JniObjectReference(array), start, length, buffer2);
		}
	}

	private unsafe static void _SetShortArrayRegion(nint array, int start, int length, short[] buffer)
	{
		fixed (short* buffer2 = buffer)
		{
			JniEnvironment.Arrays.SetShortArrayRegion(new JniObjectReference(array), start, length, buffer2);
		}
	}

	private unsafe static void _SetIntArrayRegion(nint array, int start, int length, int[] buffer)
	{
		fixed (int* buffer2 = buffer)
		{
			JniEnvironment.Arrays.SetIntArrayRegion(new JniObjectReference(array), start, length, buffer2);
		}
	}

	private unsafe static void _SetLongArrayRegion(nint array, int start, int length, long[] buffer)
	{
		fixed (long* buffer2 = buffer)
		{
			JniEnvironment.Arrays.SetLongArrayRegion(new JniObjectReference(array), start, length, buffer2);
		}
	}

	private unsafe static void _SetFloatArrayRegion(nint array, int start, int length, float[] buffer)
	{
		fixed (float* buffer2 = buffer)
		{
			JniEnvironment.Arrays.SetFloatArrayRegion(new JniObjectReference(array), start, length, buffer2);
		}
	}

	private unsafe static void _SetDoubleArrayRegion(nint array, int start, int length, double[] buffer)
	{
		fixed (double* buffer2 = buffer)
		{
			JniEnvironment.Arrays.SetDoubleArrayRegion(new JniObjectReference(array), start, length, buffer2);
		}
	}

	public static void SetArrayItem<T>(nint array_ptr, int index, T value)
	{
		if (array_ptr == IntPtr.Zero)
		{
			throw new ArgumentException("array_ptr");
		}
		if (index < 0 || index >= GetArrayLength(array_ptr))
		{
			throw new ArgumentOutOfRangeException("index");
		}
		GetConverter(SetNativeArrayElement, typeof(T), array_ptr)(array_ptr, index, value);
	}

	public unsafe static void CopyArray(nint src, uint[] dest)
	{
		if (src != IntPtr.Zero)
		{
			fixed (uint* buffer = dest)
			{
				JniEnvironment.Arrays.GetIntArrayRegion(new JniObjectReference(src), 0, dest.Length, (int*)buffer);
			}
		}
	}

	public unsafe static void CopyArray(nint src, ushort[] dest)
	{
		if (src != IntPtr.Zero)
		{
			fixed (ushort* buffer = dest)
			{
				JniEnvironment.Arrays.GetShortArrayRegion(new JniObjectReference(src), 0, dest.Length, (short*)buffer);
			}
		}
	}

	public unsafe static void CopyArray(nint src, ulong[] dest)
	{
		if (src != IntPtr.Zero)
		{
			fixed (ulong* buffer = dest)
			{
				JniEnvironment.Arrays.GetLongArrayRegion(new JniObjectReference(src), 0, dest.Length, (long*)buffer);
			}
		}
	}

	[DllImport("libjnigraphics.so")]
	private static extern int AndroidBitmap_lockPixels(nint env, nint jbitmap, out nint addrPtr);

	[DllImport("libjnigraphics.so")]
	private static extern int AndroidBitmap_unlockPixels(nint env, nint jbitmap);

	internal static int AndroidBitmap_lockPixels(nint jbitmap, out nint addrPtr)
	{
		return AndroidBitmap_lockPixels(Handle, jbitmap, out addrPtr);
	}

	internal static int AndroidBitmap_unlockPixels(nint jbitmap)
	{
		return AndroidBitmap_unlockPixels(Handle, jbitmap);
	}

	public static nint GetSuperclass(nint jclass)
	{
		return JniEnvironment.Types.GetSuperclass(new JniObjectReference(jclass)).Handle;
	}

	public static bool IsAssignableFrom(nint clazz1, nint clazz2)
	{
		return JniEnvironment.Types.IsAssignableFrom(new JniObjectReference(clazz1), new JniObjectReference(clazz2));
	}

	public static nint AllocObject(nint jclass)
	{
		return JniEnvironment.Object.AllocObject(new JniObjectReference(jclass)).Handle;
	}

	public static nint GetObjectClass(nint jobject)
	{
		return JniEnvironment.Types.GetObjectClass(new JniObjectReference(jobject)).Handle;
	}

	public static bool IsInstanceOf(nint obj, nint clazz)
	{
		return JniEnvironment.Types.IsInstanceOf(new JniObjectReference(obj), new JniObjectReference(clazz));
	}

	public static nint GetMethodID(nint kls, string name, string signature)
	{
		return JniEnvironment.InstanceMethods.GetMethodID(new JniObjectReference(kls), name, signature).ID;
	}

	public static nint CallObjectMethod(nint jobject, nint jmethod)
	{
		return JniEnvironment.InstanceMethods.CallObjectMethod(new JniObjectReference(jobject), new JniMethodInfo(jmethod, isStatic: false)).Handle;
	}

	public unsafe static nint CallObjectMethod(nint jobject, nint jmethod, JValue* parms)
	{
		return JniEnvironment.InstanceMethods.CallObjectMethod(new JniObjectReference(jobject), new JniMethodInfo(jmethod, isStatic: false), (JniArgumentValue*)parms).Handle;
	}

	public unsafe static nint CallObjectMethod(nint jobject, nint jmethod, params JValue[] parms)
	{
		fixed (JValue* parms2 = parms)
		{
			return CallObjectMethod(jobject, jmethod, parms2);
		}
	}

	public static bool CallBooleanMethod(nint jobject, nint jmethod)
	{
		return JniEnvironment.InstanceMethods.CallBooleanMethod(new JniObjectReference(jobject), new JniMethodInfo(jmethod, isStatic: false));
	}

	public unsafe static bool CallBooleanMethod(nint jobject, nint jmethod, JValue* parms)
	{
		return JniEnvironment.InstanceMethods.CallBooleanMethod(new JniObjectReference(jobject), new JniMethodInfo(jmethod, isStatic: false), (JniArgumentValue*)parms);
	}

	public unsafe static bool CallBooleanMethod(nint jobject, nint jmethod, params JValue[] parms)
	{
		fixed (JValue* parms2 = parms)
		{
			return CallBooleanMethod(jobject, jmethod, parms2);
		}
	}

	public static int CallIntMethod(nint jobject, nint jmethod)
	{
		return JniEnvironment.InstanceMethods.CallIntMethod(new JniObjectReference(jobject), new JniMethodInfo(jmethod, isStatic: false));
	}

	public unsafe static int CallIntMethod(nint jobject, nint jmethod, JValue* parms)
	{
		return JniEnvironment.InstanceMethods.CallIntMethod(new JniObjectReference(jobject), new JniMethodInfo(jmethod, isStatic: false), (JniArgumentValue*)parms);
	}

	public static long CallLongMethod(nint jobject, nint jmethod)
	{
		return JniEnvironment.InstanceMethods.CallLongMethod(new JniObjectReference(jobject), new JniMethodInfo(jmethod, isStatic: false));
	}

	public static void CallVoidMethod(nint jobject, nint jmethod)
	{
		JniEnvironment.InstanceMethods.CallVoidMethod(new JniObjectReference(jobject), new JniMethodInfo(jmethod, isStatic: false));
	}

	public unsafe static void CallVoidMethod(nint jobject, nint jmethod, JValue* parms)
	{
		JniEnvironment.InstanceMethods.CallVoidMethod(new JniObjectReference(jobject), new JniMethodInfo(jmethod, isStatic: false), (JniArgumentValue*)parms);
	}

	public unsafe static void CallVoidMethod(nint jobject, nint jmethod, params JValue[] parms)
	{
		fixed (JValue* parms2 = parms)
		{
			CallVoidMethod(jobject, jmethod, parms2);
		}
	}

	public unsafe static nint CallNonvirtualObjectMethod(nint jobject, nint jclass, nint jmethod, JValue* parms)
	{
		return JniEnvironment.InstanceMethods.CallNonvirtualObjectMethod(new JniObjectReference(jobject), new JniObjectReference(jclass), new JniMethodInfo(jmethod, isStatic: false), (JniArgumentValue*)parms).Handle;
	}

	public unsafe static nint CallNonvirtualObjectMethod(nint jobject, nint jclass, nint jmethod, params JValue[] parms)
	{
		fixed (JValue* parms2 = parms)
		{
			return CallNonvirtualObjectMethod(jobject, jclass, jmethod, parms2);
		}
	}

	public unsafe static void CallNonvirtualVoidMethod(nint jobject, nint jclass, nint jmethod, JValue* parms)
	{
		JniEnvironment.InstanceMethods.CallNonvirtualVoidMethod(new JniObjectReference(jobject), new JniObjectReference(jclass), new JniMethodInfo(jmethod, isStatic: false), (JniArgumentValue*)parms);
	}

	public unsafe static void CallNonvirtualVoidMethod(nint jobject, nint jclass, nint jmethod, params JValue[] parms)
	{
		fixed (JValue* parms2 = parms)
		{
			CallNonvirtualVoidMethod(jobject, jclass, jmethod, parms2);
		}
	}

	public static nint GetStaticFieldID(nint jclass, string name, string sig)
	{
		return JniEnvironment.StaticFields.GetStaticFieldID(new JniObjectReference(jclass), name, sig).ID;
	}

	public static nint GetStaticObjectField(nint jclass, nint jfieldID)
	{
		return JniEnvironment.StaticFields.GetStaticObjectField(new JniObjectReference(jclass), new JniFieldInfo(jfieldID, isStatic: true)).Handle;
	}

	public static nint GetObjectArrayElement(nint array, int index)
	{
		return JniEnvironment.Arrays.GetObjectArrayElement(new JniObjectReference(array), index).Handle;
	}

	public static void SetObjectArrayElement(nint array, int index, nint value)
	{
		JniEnvironment.Arrays.SetObjectArrayElement(new JniObjectReference(array), index, new JniObjectReference(value));
	}

	public static nint NewArray(byte[] array)
	{
		if (array == null)
		{
			return IntPtr.Zero;
		}
		JniObjectReference jniObjectReference = JniEnvironment.Arrays.NewByteArray(array.Length);
		CopyArray(array, jniObjectReference.Handle);
		return jniObjectReference.Handle;
	}

	public static nint NewArray(char[] array)
	{
		if (array == null)
		{
			return IntPtr.Zero;
		}
		JniObjectReference jniObjectReference = JniEnvironment.Arrays.NewCharArray(array.Length);
		CopyArray(array, jniObjectReference.Handle);
		return jniObjectReference.Handle;
	}

	public static nint NewArray(short[] array)
	{
		if (array == null)
		{
			return IntPtr.Zero;
		}
		JniObjectReference jniObjectReference = JniEnvironment.Arrays.NewShortArray(array.Length);
		CopyArray(array, jniObjectReference.Handle);
		return jniObjectReference.Handle;
	}

	public static nint NewArray(int[] array)
	{
		if (array == null)
		{
			return IntPtr.Zero;
		}
		JniObjectReference jniObjectReference = JniEnvironment.Arrays.NewIntArray(array.Length);
		CopyArray(array, jniObjectReference.Handle);
		return jniObjectReference.Handle;
	}

	public static nint NewArray(long[] array)
	{
		if (array == null)
		{
			return IntPtr.Zero;
		}
		JniObjectReference jniObjectReference = JniEnvironment.Arrays.NewLongArray(array.Length);
		CopyArray(array, jniObjectReference.Handle);
		return jniObjectReference.Handle;
	}

	public static nint NewArray(float[] array)
	{
		if (array == null)
		{
			return IntPtr.Zero;
		}
		JniObjectReference jniObjectReference = JniEnvironment.Arrays.NewFloatArray(array.Length);
		CopyArray(array, jniObjectReference.Handle);
		return jniObjectReference.Handle;
	}

	public static nint NewArray(double[] array)
	{
		if (array == null)
		{
			return IntPtr.Zero;
		}
		JniObjectReference jniObjectReference = JniEnvironment.Arrays.NewDoubleArray(array.Length);
		CopyArray(array, jniObjectReference.Handle);
		return jniObjectReference.Handle;
	}

	public unsafe static void CopyArray(nint src, byte[] dest)
	{
		if (src != IntPtr.Zero)
		{
			fixed (byte* buffer = dest)
			{
				JniEnvironment.Arrays.GetByteArrayRegion(new JniObjectReference(src), 0, dest.Length, (sbyte*)buffer);
			}
		}
	}

	public unsafe static void CopyArray(nint src, char[] dest)
	{
		if (src != IntPtr.Zero)
		{
			fixed (char* buffer = dest)
			{
				JniEnvironment.Arrays.GetCharArrayRegion(new JniObjectReference(src), 0, dest.Length, buffer);
			}
		}
	}

	public unsafe static void CopyArray(nint src, short[] dest)
	{
		if (src != IntPtr.Zero)
		{
			fixed (short* buffer = dest)
			{
				JniEnvironment.Arrays.GetShortArrayRegion(new JniObjectReference(src), 0, dest.Length, buffer);
			}
		}
	}

	public unsafe static void CopyArray(nint src, int[] dest)
	{
		if (src != IntPtr.Zero)
		{
			fixed (int* buffer = dest)
			{
				JniEnvironment.Arrays.GetIntArrayRegion(new JniObjectReference(src), 0, dest.Length, buffer);
			}
		}
	}

	public unsafe static void CopyArray(nint src, long[] dest)
	{
		if (src != IntPtr.Zero)
		{
			fixed (long* buffer = dest)
			{
				JniEnvironment.Arrays.GetLongArrayRegion(new JniObjectReference(src), 0, dest.Length, buffer);
			}
		}
	}

	public unsafe static void CopyArray(nint src, float[] dest)
	{
		if (src != IntPtr.Zero)
		{
			fixed (float* buffer = dest)
			{
				JniEnvironment.Arrays.GetFloatArrayRegion(new JniObjectReference(src), 0, dest.Length, buffer);
			}
		}
	}

	public unsafe static void CopyArray(nint src, double[] dest)
	{
		if (src != IntPtr.Zero)
		{
			fixed (double* buffer = dest)
			{
				JniEnvironment.Arrays.GetDoubleArrayRegion(new JniObjectReference(src), 0, dest.Length, buffer);
			}
		}
	}

	public unsafe static void CopyArray(byte[] src, nint dest)
	{
		if (src == null)
		{
			throw new ArgumentNullException("src");
		}
		fixed (byte* buffer = src)
		{
			JniEnvironment.Arrays.SetByteArrayRegion(new JniObjectReference(dest), 0, src.Length, (sbyte*)buffer);
		}
	}

	public unsafe static void CopyArray(char[] src, nint dest)
	{
		if (src == null)
		{
			throw new ArgumentNullException("src");
		}
		fixed (char* buffer = src)
		{
			JniEnvironment.Arrays.SetCharArrayRegion(new JniObjectReference(dest), 0, src.Length, buffer);
		}
	}

	public unsafe static void CopyArray(short[] src, nint dest)
	{
		if (src == null)
		{
			throw new ArgumentNullException("src");
		}
		fixed (short* buffer = src)
		{
			JniEnvironment.Arrays.SetShortArrayRegion(new JniObjectReference(dest), 0, src.Length, buffer);
		}
	}

	public unsafe static void CopyArray(int[] src, nint dest)
	{
		if (src == null)
		{
			throw new ArgumentNullException("src");
		}
		fixed (int* buffer = src)
		{
			JniEnvironment.Arrays.SetIntArrayRegion(new JniObjectReference(dest), 0, src.Length, buffer);
		}
	}

	public unsafe static void CopyArray(long[] src, nint dest)
	{
		if (src == null)
		{
			throw new ArgumentNullException("src");
		}
		fixed (long* buffer = src)
		{
			JniEnvironment.Arrays.SetLongArrayRegion(new JniObjectReference(dest), 0, src.Length, buffer);
		}
	}

	public unsafe static void CopyArray(float[] src, nint dest)
	{
		if (src == null)
		{
			throw new ArgumentNullException("src");
		}
		fixed (float* buffer = src)
		{
			JniEnvironment.Arrays.SetFloatArrayRegion(new JniObjectReference(dest), 0, src.Length, buffer);
		}
	}

	public unsafe static void CopyArray(double[] src, nint dest)
	{
		if (src == null)
		{
			throw new ArgumentNullException("src");
		}
		fixed (double* buffer = src)
		{
			JniEnvironment.Arrays.SetDoubleArrayRegion(new JniObjectReference(dest), 0, src.Length, buffer);
		}
	}
}
