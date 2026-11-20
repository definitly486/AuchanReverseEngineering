using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Java.Interop;

public static class JniEnvironment
{
	public static class Arrays
	{
		public static int GetArrayLength(JniObjectReference array)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			return JniNativeMethods.GetArrayLength(EnvironmentPointer, array.Handle);
		}

		public static JniObjectReference NewObjectArray(int length, JniObjectReference elementClass, JniObjectReference initialElement)
		{
			if (!elementClass.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "elementClass");
			}
			nint environmentPointer = EnvironmentPointer;
			nint num = JniNativeMethods.NewObjectArray(environmentPointer, length, elementClass.Handle, initialElement.Handle);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public static JniObjectReference GetObjectArrayElement(JniObjectReference array, int index)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			nint objectArrayElement = JniNativeMethods.GetObjectArrayElement(environmentPointer, array.Handle, index);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			LogCreateLocalRef(objectArrayElement);
			return new JniObjectReference(objectArrayElement, JniObjectReferenceType.Local);
		}

		public static void SetObjectArrayElement(JniObjectReference array, int index, JniObjectReference value)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.SetObjectArrayElement(environmentPointer, array.Handle, index, value.Handle);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public static JniObjectReference NewBooleanArray(int length)
		{
			nint num = JniNativeMethods.NewBooleanArray(EnvironmentPointer, length);
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public static JniObjectReference NewByteArray(int length)
		{
			nint num = JniNativeMethods.NewByteArray(EnvironmentPointer, length);
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public static JniObjectReference NewCharArray(int length)
		{
			nint num = JniNativeMethods.NewCharArray(EnvironmentPointer, length);
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public static JniObjectReference NewShortArray(int length)
		{
			nint num = JniNativeMethods.NewShortArray(EnvironmentPointer, length);
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public static JniObjectReference NewIntArray(int length)
		{
			nint num = JniNativeMethods.NewIntArray(EnvironmentPointer, length);
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public static JniObjectReference NewLongArray(int length)
		{
			nint num = JniNativeMethods.NewLongArray(EnvironmentPointer, length);
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public static JniObjectReference NewFloatArray(int length)
		{
			nint num = JniNativeMethods.NewFloatArray(EnvironmentPointer, length);
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public static JniObjectReference NewDoubleArray(int length)
		{
			nint num = JniNativeMethods.NewDoubleArray(EnvironmentPointer, length);
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public unsafe static bool* GetBooleanArrayElements(JniObjectReference array, bool* isCopy)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			return JniNativeMethods.GetBooleanArrayElements(EnvironmentPointer, array.Handle, isCopy);
		}

		public unsafe static sbyte* GetByteArrayElements(JniObjectReference array, bool* isCopy)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			return JniNativeMethods.GetByteArrayElements(EnvironmentPointer, array.Handle, isCopy);
		}

		public unsafe static char* GetCharArrayElements(JniObjectReference array, bool* isCopy)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			return JniNativeMethods.GetCharArrayElements(EnvironmentPointer, array.Handle, isCopy);
		}

		public unsafe static short* GetShortArrayElements(JniObjectReference array, bool* isCopy)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			return JniNativeMethods.GetShortArrayElements(EnvironmentPointer, array.Handle, isCopy);
		}

		public unsafe static int* GetIntArrayElements(JniObjectReference array, bool* isCopy)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			return JniNativeMethods.GetIntArrayElements(EnvironmentPointer, array.Handle, isCopy);
		}

		public unsafe static long* GetLongArrayElements(JniObjectReference array, bool* isCopy)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			return JniNativeMethods.GetLongArrayElements(EnvironmentPointer, array.Handle, isCopy);
		}

		public unsafe static float* GetFloatArrayElements(JniObjectReference array, bool* isCopy)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			return JniNativeMethods.GetFloatArrayElements(EnvironmentPointer, array.Handle, isCopy);
		}

		public unsafe static double* GetDoubleArrayElements(JniObjectReference array, bool* isCopy)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			return JniNativeMethods.GetDoubleArrayElements(EnvironmentPointer, array.Handle, isCopy);
		}

		public unsafe static void ReleaseBooleanArrayElements(JniObjectReference array, bool* elements, JniReleaseArrayElementsMode mode)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			JniNativeMethods.ReleaseBooleanArrayElements(EnvironmentPointer, array.Handle, elements, (int)mode);
		}

		public unsafe static void ReleaseByteArrayElements(JniObjectReference array, sbyte* elements, JniReleaseArrayElementsMode mode)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			JniNativeMethods.ReleaseByteArrayElements(EnvironmentPointer, array.Handle, elements, (int)mode);
		}

		public unsafe static void ReleaseCharArrayElements(JniObjectReference array, char* elements, JniReleaseArrayElementsMode mode)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			JniNativeMethods.ReleaseCharArrayElements(EnvironmentPointer, array.Handle, elements, (int)mode);
		}

		public unsafe static void ReleaseShortArrayElements(JniObjectReference array, short* elements, JniReleaseArrayElementsMode mode)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			JniNativeMethods.ReleaseShortArrayElements(EnvironmentPointer, array.Handle, elements, (int)mode);
		}

		public unsafe static void ReleaseIntArrayElements(JniObjectReference array, int* elements, JniReleaseArrayElementsMode mode)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			JniNativeMethods.ReleaseIntArrayElements(EnvironmentPointer, array.Handle, elements, (int)mode);
		}

		public unsafe static void ReleaseLongArrayElements(JniObjectReference array, long* elements, JniReleaseArrayElementsMode mode)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			JniNativeMethods.ReleaseLongArrayElements(EnvironmentPointer, array.Handle, elements, (int)mode);
		}

		public unsafe static void ReleaseFloatArrayElements(JniObjectReference array, float* elements, JniReleaseArrayElementsMode mode)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			JniNativeMethods.ReleaseFloatArrayElements(EnvironmentPointer, array.Handle, elements, (int)mode);
		}

		public unsafe static void ReleaseDoubleArrayElements(JniObjectReference array, double* elements, JniReleaseArrayElementsMode mode)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			JniNativeMethods.ReleaseDoubleArrayElements(EnvironmentPointer, array.Handle, elements, (int)mode);
		}

		public unsafe static void GetBooleanArrayRegion(JniObjectReference array, int start, int length, bool* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.GetBooleanArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void GetByteArrayRegion(JniObjectReference array, int start, int length, sbyte* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.GetByteArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void GetCharArrayRegion(JniObjectReference array, int start, int length, char* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.GetCharArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void GetShortArrayRegion(JniObjectReference array, int start, int length, short* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.GetShortArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void GetIntArrayRegion(JniObjectReference array, int start, int length, int* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.GetIntArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void GetLongArrayRegion(JniObjectReference array, int start, int length, long* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.GetLongArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void GetFloatArrayRegion(JniObjectReference array, int start, int length, float* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.GetFloatArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void GetDoubleArrayRegion(JniObjectReference array, int start, int length, double* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.GetDoubleArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void SetBooleanArrayRegion(JniObjectReference array, int start, int length, bool* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.SetBooleanArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void SetByteArrayRegion(JniObjectReference array, int start, int length, sbyte* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.SetByteArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void SetCharArrayRegion(JniObjectReference array, int start, int length, char* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.SetCharArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void SetShortArrayRegion(JniObjectReference array, int start, int length, short* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.SetShortArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void SetIntArrayRegion(JniObjectReference array, int start, int length, int* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.SetIntArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void SetLongArrayRegion(JniObjectReference array, int start, int length, long* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.SetLongArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void SetFloatArrayRegion(JniObjectReference array, int start, int length, float* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.SetFloatArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void SetDoubleArrayRegion(JniObjectReference array, int start, int length, double* buffer)
		{
			if (!array.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "array");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.SetDoubleArrayRegion(environmentPointer, array.Handle, start, length, buffer);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}
	}

	public static class References
	{
		internal unsafe static int GetJavaVM(nint jnienv, out nint vm)
		{
			nint num = default(nint);
			int javaVM = JniNativeMethods.GetJavaVM(jnienv, &num);
			vm = num;
			return javaVM;
		}

		internal static void RawDeleteLocalRef(nint env, nint localRef)
		{
			JniNativeMethods.DeleteLocalRef(env, localRef);
		}

		public static int GetIdentityHashCode(JniObjectReference value)
		{
			return JniSystem.IdentityHashCode(value);
		}

		internal static JniObjectReference NewGlobalRef(JniObjectReference instance)
		{
			return new JniObjectReference(JniNativeMethods.NewGlobalRef(EnvironmentPointer, instance.Handle), JniObjectReferenceType.Global);
		}

		internal static void DeleteGlobalRef(nint instance)
		{
			JniNativeMethods.DeleteGlobalRef(EnvironmentPointer, instance);
		}

		internal static void DeleteLocalRef(nint instance)
		{
			JniNativeMethods.DeleteLocalRef(EnvironmentPointer, instance);
		}

		internal static JniObjectReference NewLocalRef(JniObjectReference instance)
		{
			return new JniObjectReference(JniNativeMethods.NewLocalRef(EnvironmentPointer, instance.Handle), JniObjectReferenceType.Local);
		}

		internal static void DeleteWeakGlobalRef(nint instance)
		{
			JniNativeMethods.DeleteWeakGlobalRef(EnvironmentPointer, instance);
		}
	}

	public static class Exceptions
	{
		public static void Throw(JniObjectReference toThrow)
		{
			if (!toThrow.IsValid)
			{
				throw new ArgumentException("toThrow");
			}
			int num = _Throw(toThrow);
			if (num != 0)
			{
				throw new InvalidOperationException($"Could not raise an exception; JNIEnv::Throw() returned {num}.");
			}
		}

		public static void Throw(Exception e)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			JavaException ex = e as JavaException;
			if (ex == null)
			{
				ex = new JavaProxyThrowable(e);
			}
			Throw(ex.PeerReference);
		}

		internal static int _Throw(JniObjectReference toThrow)
		{
			if (!toThrow.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "toThrow");
			}
			return JniNativeMethods.Throw(EnvironmentPointer, toThrow.Handle);
		}

		public static void ExceptionClear()
		{
			JniNativeMethods.ExceptionClear(EnvironmentPointer);
		}
	}

	public static class Object
	{
		private static JniMethodInfo Object_toString;

		static Object()
		{
			using JniType jniType = new JniType("java/lang/Object");
			Object_toString = jniType.GetInstanceMethod("toString", "()Ljava/lang/String;");
		}

		public unsafe static JniObjectReference NewObject(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			WithinNewObjectScope = true;
			try
			{
				return _NewObject(type, method, args);
			}
			finally
			{
				WithinNewObjectScope = false;
			}
		}

		public static JniObjectReference ToString(JniObjectReference value)
		{
			return InstanceMethods.CallObjectMethod(value, Object_toString);
		}

		public static JniObjectReference AllocObject(JniObjectReference type)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			nint environmentPointer = EnvironmentPointer;
			nint num = JniNativeMethods.AllocObject(environmentPointer, type.Handle);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		internal unsafe static JniObjectReference _NewObject(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			nint num = JniNativeMethods.NewObjectA(environmentPointer, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}
	}

	public static class Strings
	{
		public unsafe static JniObjectReference NewString(string? value)
		{
			if (value == null)
			{
				return default(JniObjectReference);
			}
			fixed (char* unicodeChars = value)
			{
				return NewString(unicodeChars, value.Length);
			}
		}

		public static string? ToString(nint reference)
		{
			return ToString(new JniObjectReference(reference));
		}

		internal static string? ToString(ref JniObjectReference reference, JniObjectReferenceOptions transfer, Type targetType)
		{
			return ToString(ref reference, transfer);
		}

		public static string? ToString(JniObjectReference value)
		{
			return ToString(ref value, JniObjectReferenceOptions.Copy);
		}

		public unsafe static string? ToString(ref JniObjectReference value, JniObjectReferenceOptions transfer)
		{
			if (!value.IsValid)
			{
				return null;
			}
			int stringLength = GetStringLength(value);
			char* stringChars = GetStringChars(value, null);
			try
			{
				return new string(stringChars, 0, stringLength);
			}
			finally
			{
				ReleaseStringChars(value, stringChars);
				JniObjectReference.Dispose(ref value, transfer);
			}
		}

		public unsafe static JniObjectReference NewString(char* unicodeChars, int length)
		{
			nint environmentPointer = EnvironmentPointer;
			nint num = JniNativeMethods.NewString(environmentPointer, unicodeChars, length);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public static int GetStringLength(JniObjectReference stringInstance)
		{
			if (!stringInstance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "stringInstance");
			}
			return JniNativeMethods.GetStringLength(EnvironmentPointer, stringInstance.Handle);
		}

		public unsafe static char* GetStringChars(JniObjectReference stringInstance, bool* isCopy)
		{
			if (!stringInstance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "stringInstance");
			}
			return JniNativeMethods.GetStringChars(EnvironmentPointer, stringInstance.Handle, isCopy);
		}

		public unsafe static void ReleaseStringChars(JniObjectReference stringInstance, char* chars)
		{
			if (!stringInstance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "stringInstance");
			}
			JniNativeMethods.ReleaseStringChars(EnvironmentPointer, stringInstance.Handle, chars);
		}
	}

	public static class Types
	{
		private static readonly KeyValuePair<string, string>[] BuiltinMappings;

		private static readonly JniMethodInfo Class_getName;

		private static readonly JniMethodInfo Class_forName;

		private static readonly JniObjectReference Class_reference;

		static Types()
		{
			BuiltinMappings = new KeyValuePair<string, string>[9]
			{
				new KeyValuePair<string, string>("byte", "B"),
				new KeyValuePair<string, string>("boolean", "Z"),
				new KeyValuePair<string, string>("char", "C"),
				new KeyValuePair<string, string>("double", "D"),
				new KeyValuePair<string, string>("float", "F"),
				new KeyValuePair<string, string>("int", "I"),
				new KeyValuePair<string, string>("long", "J"),
				new KeyValuePair<string, string>("short", "S"),
				new KeyValuePair<string, string>("void", "V")
			};
			using JniType jniType = new JniType("java/lang/Class");
			Class_reference = jniType.PeerReference.NewGlobalRef();
			Class_getName = jniType.GetInstanceMethod("getName", "()Ljava/lang/String;");
			Class_forName = jniType.GetStaticMethod("forName", "(Ljava/lang/String;ZLjava/lang/ClassLoader;)Ljava/lang/Class;");
		}

		public static JniObjectReference FindClass(string classname)
		{
			return TryFindClass(classname, throwOnError: true);
		}

		private unsafe static JniObjectReference TryFindClass(string classname, bool throwOnError)
		{
			if (classname == null)
			{
				throw new ArgumentNullException("classname");
			}
			if (classname.Length == 0)
			{
				throw new ArgumentException("'classname' cannot be a zero-length string.", "classname");
			}
			JniEnvironmentInfo currentInfo = CurrentInfo;
			if (TryRawFindClass(currentInfo.EnvironmentPointer, classname, out var klass, out var thrown))
			{
				JniObjectReference jniObjectReference = new JniObjectReference(klass, JniObjectReferenceType.Local);
				LogCreateLocalRef(jniObjectReference);
				return jniObjectReference;
			}
			RawExceptionClear(currentInfo.EnvironmentPointer);
			JniObjectReference reference = new JniObjectReference(thrown, JniObjectReferenceType.Local);
			LogCreateLocalRef(reference);
			Exception exceptionForThrowable = currentInfo.Runtime.GetExceptionForThrowable(ref reference, JniObjectReferenceOptions.CopyAndDispose);
			if (Class_forName.IsValid)
			{
				JniObjectReference reference2 = currentInfo.ToJavaName(classname);
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(reference2);
				ptr[1] = new JniArgumentValue(value: true);
				ptr[2] = new JniArgumentValue(currentInfo.Runtime.ClassLoader);
				klass = RawCallStaticObjectMethodA(currentInfo.EnvironmentPointer, out thrown, Class_reference.Handle, Class_forName.ID, (nint)ptr);
				JniObjectReference.Dispose(ref reference2);
				if (thrown == IntPtr.Zero)
				{
					(exceptionForThrowable as IJavaPeerable)?.Dispose();
					JniObjectReference jniObjectReference2 = new JniObjectReference(klass, JniObjectReferenceType.Local);
					LogCreateLocalRef(jniObjectReference2);
					return jniObjectReference2;
				}
				RawExceptionClear(currentInfo.EnvironmentPointer);
				if (exceptionForThrowable != null)
				{
					References.RawDeleteLocalRef(currentInfo.EnvironmentPointer, thrown);
				}
				else
				{
					JniObjectReference reference3 = new JniObjectReference(thrown, JniObjectReferenceType.Local);
					LogCreateLocalRef(reference3);
					exceptionForThrowable = currentInfo.Runtime.GetExceptionForThrowable(ref reference3, JniObjectReferenceOptions.CopyAndDispose);
				}
			}
			if (!throwOnError)
			{
				(exceptionForThrowable as IJavaPeerable)?.Dispose();
				return default(JniObjectReference);
			}
			throw exceptionForThrowable;
		}

		private static bool TryRawFindClass(nint env, string classname, out nint klass, out nint thrown)
		{
			nint num = Marshal.StringToCoTaskMemUTF8(classname);
			klass = JniNativeMethods.FindClass(env, num);
			thrown = JniNativeMethods.ExceptionOccurred(env);
			Marshal.ZeroFreeCoTaskMemUTF8(num);
			if (thrown == IntPtr.Zero)
			{
				return true;
			}
			return false;
		}

		private static void RawExceptionClear(nint env)
		{
			JniNativeMethods.ExceptionClear(env);
		}

		private static nint RawCallStaticObjectMethodA(nint env, out nint thrown, nint clazz, nint jmethodID, nint args)
		{
			nint result = JniNativeMethods.CallStaticObjectMethodA(env, clazz, jmethodID, args);
			thrown = JniNativeMethods.ExceptionOccurred(env);
			return result;
		}

		public static bool TryFindClass(string classname, out JniObjectReference instance)
		{
			if (classname == null)
			{
				throw new ArgumentNullException("classname");
			}
			if (classname.Length == 0)
			{
				throw new ArgumentException("'classname' cannot be a zero-length string.", "classname");
			}
			instance = TryFindClass(classname, throwOnError: false);
			return instance.IsValid;
		}

		public static string? GetJniTypeNameFromInstance(JniObjectReference instance)
		{
			if (!instance.IsValid)
			{
				return null;
			}
			JniObjectReference reference = GetObjectClass(instance);
			try
			{
				return GetJniTypeNameFromClass(reference);
			}
			finally
			{
				JniObjectReference.Dispose(ref reference, JniObjectReferenceOptions.CopyAndDispose);
			}
		}

		public static string? GetJniTypeNameFromClass(JniObjectReference type)
		{
			if (!type.IsValid)
			{
				return null;
			}
			JniObjectReference value = InstanceMethods.CallObjectMethod(type, Class_getName);
			return JavaClassToJniType(Strings.ToString(ref value, JniObjectReferenceOptions.CopyAndDispose));
		}

		private static string JavaClassToJniType(string value)
		{
			for (int i = 0; i < BuiltinMappings.Length; i++)
			{
				if (value == BuiltinMappings[i].Key)
				{
					return BuiltinMappings[i].Value;
				}
			}
			return value.Replace('.', '/');
		}

		public static void RegisterNatives(JniObjectReference type, JniNativeMethodRegistration[] methods, int numMethods)
		{
			if (numMethods < 0 || numMethods > ((methods != null) ? methods.Length : 0))
			{
				throw new ArgumentOutOfRangeException("numMethods", numMethods, $"`numMethods` must be between 0 and `methods.Length` ({((methods != null) ? methods.Length : 0)})!");
			}
			int num = _RegisterNatives(type, methods ?? Array.Empty<JniNativeMethodRegistration>(), numMethods);
			if (num != 0)
			{
				throw new InvalidOperationException($"Could not register native methods for class '{GetJniTypeNameFromClass(type)}'; JNIEnv::RegisterNatives() returned {num}.");
			}
		}

		public static void UnregisterNatives(JniObjectReference type)
		{
			int num = _UnregisterNatives(type);
			if (num != 0)
			{
				throw new InvalidOperationException($"Could not unregister native methods for class '{GetJniTypeNameFromClass(type)}'; JNIEnv::UnregisterNatives() returned {num}.");
			}
		}

		public static JniObjectReference GetSuperclass(JniObjectReference type)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			nint superclass = JniNativeMethods.GetSuperclass(EnvironmentPointer, type.Handle);
			LogCreateLocalRef(superclass);
			return new JniObjectReference(superclass, JniObjectReferenceType.Local);
		}

		public static bool IsAssignableFrom(JniObjectReference class1, JniObjectReference class2)
		{
			if (!class1.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "class1");
			}
			if (!class2.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "class2");
			}
			return JniNativeMethods.IsAssignableFrom(EnvironmentPointer, class1.Handle, class2.Handle) != 0;
		}

		public static bool IsSameObject(JniObjectReference object1, JniObjectReference object2)
		{
			return JniNativeMethods.IsSameObject(EnvironmentPointer, object1.Handle, object2.Handle) != 0;
		}

		public static JniObjectReference GetObjectClass(JniObjectReference instance)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			nint objectClass = JniNativeMethods.GetObjectClass(EnvironmentPointer, instance.Handle);
			LogCreateLocalRef(objectClass);
			return new JniObjectReference(objectClass, JniObjectReferenceType.Local);
		}

		public static bool IsInstanceOf(JniObjectReference instance, JniObjectReference type)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			return JniNativeMethods.IsInstanceOf(EnvironmentPointer, instance.Handle, type.Handle) != 0;
		}

		internal static int _RegisterNatives(JniObjectReference type, JniNativeMethodRegistration[] methods, int numMethods)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			nint environmentPointer = EnvironmentPointer;
			int result = JniNativeMethods.RegisterNatives(environmentPointer, type.Handle, methods, numMethods);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		internal static int _UnregisterNatives(JniObjectReference type)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			return JniNativeMethods.UnregisterNatives(EnvironmentPointer, type.Handle);
		}
	}

	public static class InstanceFields
	{
		public static JniFieldInfo GetFieldID(JniObjectReference type, string name, string signature)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (signature == null)
			{
				throw new ArgumentNullException("signature");
			}
			nint num = Marshal.StringToCoTaskMemUTF8(name);
			nint num2 = Marshal.StringToCoTaskMemUTF8(signature);
			nint environmentPointer = EnvironmentPointer;
			nint fieldID = JniNativeMethods.GetFieldID(environmentPointer, type.Handle, num, num2);
			nint thrown = JniNativeMethods.ExceptionOccurred(environmentPointer);
			Marshal.ZeroFreeCoTaskMemUTF8(num);
			Marshal.ZeroFreeCoTaskMemUTF8(num2);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			if (fieldID == IntPtr.Zero)
			{
				throw new InvalidOperationException("Should not be reached; `GetFieldID` should have thrown!");
			}
			return new JniFieldInfo(name, signature, fieldID, isStatic: false);
		}

		public static JniObjectReference GetObjectField(JniObjectReference instance, JniFieldInfo field)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			nint objectField = JniNativeMethods.GetObjectField(EnvironmentPointer, instance.Handle, field.ID);
			LogCreateLocalRef(objectField);
			return new JniObjectReference(objectField, JniObjectReferenceType.Local);
		}

		public static bool GetBooleanField(JniObjectReference instance, JniFieldInfo field)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			return JniNativeMethods.GetBooleanField(EnvironmentPointer, instance.Handle, field.ID) != 0;
		}

		public static int GetIntField(JniObjectReference instance, JniFieldInfo field)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			return JniNativeMethods.GetIntField(EnvironmentPointer, instance.Handle, field.ID);
		}

		public static long GetLongField(JniObjectReference instance, JniFieldInfo field)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			return JniNativeMethods.GetLongField(EnvironmentPointer, instance.Handle, field.ID);
		}

		public static float GetFloatField(JniObjectReference instance, JniFieldInfo field)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			return JniNativeMethods.GetFloatField(EnvironmentPointer, instance.Handle, field.ID);
		}

		public static void SetObjectField(JniObjectReference instance, JniFieldInfo field, JniObjectReference value)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			JniNativeMethods.SetObjectField(EnvironmentPointer, instance.Handle, field.ID, value.Handle);
		}

		public static void SetByteField(JniObjectReference instance, JniFieldInfo field, sbyte value)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			JniNativeMethods.SetByteField(EnvironmentPointer, instance.Handle, field.ID, value);
		}

		public static void SetIntField(JniObjectReference instance, JniFieldInfo field, int value)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			JniNativeMethods.SetIntField(EnvironmentPointer, instance.Handle, field.ID, value);
		}

		public static void SetLongField(JniObjectReference instance, JniFieldInfo field, long value)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			JniNativeMethods.SetLongField(EnvironmentPointer, instance.Handle, field.ID, value);
		}

		public static void SetFloatField(JniObjectReference instance, JniFieldInfo field, float value)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			JniNativeMethods.SetFloatField(EnvironmentPointer, instance.Handle, field.ID, value);
		}
	}

	public static class InstanceMethods
	{
		public static JniMethodInfo GetMethodID(JniObjectReference type, string name, string signature)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (signature == null)
			{
				throw new ArgumentNullException("signature");
			}
			nint num = Marshal.StringToCoTaskMemUTF8(name);
			nint num2 = Marshal.StringToCoTaskMemUTF8(signature);
			nint environmentPointer = EnvironmentPointer;
			nint methodID = JniNativeMethods.GetMethodID(environmentPointer, type.Handle, num, num2);
			nint thrown = JniNativeMethods.ExceptionOccurred(environmentPointer);
			Marshal.ZeroFreeCoTaskMemUTF8(num);
			Marshal.ZeroFreeCoTaskMemUTF8(num2);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			if (methodID == IntPtr.Zero)
			{
				throw new InvalidOperationException("Should not be reached; `GetMethodID` should have thrown!");
			}
			return new JniMethodInfo(name, signature, methodID, isStatic: false);
		}

		public static JniObjectReference CallObjectMethod(JniObjectReference instance, JniMethodInfo method)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			nint num = JniNativeMethods.CallObjectMethod(environmentPointer, instance.Handle, method.ID);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public unsafe static JniObjectReference CallObjectMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			nint num = JniNativeMethods.CallObjectMethodA(environmentPointer, instance.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public static bool CallBooleanMethod(JniObjectReference instance, JniMethodInfo method)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			byte b = JniNativeMethods.CallBooleanMethod(environmentPointer, instance.Handle, method.ID);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return b != 0;
		}

		public unsafe static bool CallBooleanMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			byte b = JniNativeMethods.CallBooleanMethodA(environmentPointer, instance.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return b != 0;
		}

		public static sbyte CallByteMethod(JniObjectReference instance, JniMethodInfo method)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			sbyte result = JniNativeMethods.CallByteMethod(environmentPointer, instance.Handle, method.ID);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static sbyte CallByteMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			sbyte result = JniNativeMethods.CallByteMethodA(environmentPointer, instance.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public static char CallCharMethod(JniObjectReference instance, JniMethodInfo method)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			char result = JniNativeMethods.CallCharMethod(environmentPointer, instance.Handle, method.ID);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static char CallCharMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			char result = JniNativeMethods.CallCharMethodA(environmentPointer, instance.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public static short CallShortMethod(JniObjectReference instance, JniMethodInfo method)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			short result = JniNativeMethods.CallShortMethod(environmentPointer, instance.Handle, method.ID);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static short CallShortMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			short result = JniNativeMethods.CallShortMethodA(environmentPointer, instance.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public static int CallIntMethod(JniObjectReference instance, JniMethodInfo method)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			int result = JniNativeMethods.CallIntMethod(environmentPointer, instance.Handle, method.ID);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static int CallIntMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			int result = JniNativeMethods.CallIntMethodA(environmentPointer, instance.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public static long CallLongMethod(JniObjectReference instance, JniMethodInfo method)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			long result = JniNativeMethods.CallLongMethod(environmentPointer, instance.Handle, method.ID);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static long CallLongMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			long result = JniNativeMethods.CallLongMethodA(environmentPointer, instance.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public static float CallFloatMethod(JniObjectReference instance, JniMethodInfo method)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			float result = JniNativeMethods.CallFloatMethod(environmentPointer, instance.Handle, method.ID);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static float CallFloatMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			float result = JniNativeMethods.CallFloatMethodA(environmentPointer, instance.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public static double CallDoubleMethod(JniObjectReference instance, JniMethodInfo method)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			double result = JniNativeMethods.CallDoubleMethod(environmentPointer, instance.Handle, method.ID);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static double CallDoubleMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			double result = JniNativeMethods.CallDoubleMethodA(environmentPointer, instance.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public static void CallVoidMethod(JniObjectReference instance, JniMethodInfo method)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.CallVoidMethod(environmentPointer, instance.Handle, method.ID);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static void CallVoidMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.CallVoidMethodA(environmentPointer, instance.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}

		public unsafe static JniObjectReference CallNonvirtualObjectMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			nint num = JniNativeMethods.CallNonvirtualObjectMethodA(environmentPointer, instance.Handle, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public unsafe static bool CallNonvirtualBooleanMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			byte b = JniNativeMethods.CallNonvirtualBooleanMethodA(environmentPointer, instance.Handle, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return b != 0;
		}

		public unsafe static sbyte CallNonvirtualByteMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			sbyte result = JniNativeMethods.CallNonvirtualByteMethodA(environmentPointer, instance.Handle, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static char CallNonvirtualCharMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			char result = JniNativeMethods.CallNonvirtualCharMethodA(environmentPointer, instance.Handle, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static short CallNonvirtualShortMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			short result = JniNativeMethods.CallNonvirtualShortMethodA(environmentPointer, instance.Handle, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static int CallNonvirtualIntMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			int result = JniNativeMethods.CallNonvirtualIntMethodA(environmentPointer, instance.Handle, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static long CallNonvirtualLongMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			long result = JniNativeMethods.CallNonvirtualLongMethodA(environmentPointer, instance.Handle, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static float CallNonvirtualFloatMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			float result = JniNativeMethods.CallNonvirtualFloatMethodA(environmentPointer, instance.Handle, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static double CallNonvirtualDoubleMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			double result = JniNativeMethods.CallNonvirtualDoubleMethodA(environmentPointer, instance.Handle, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static void CallNonvirtualVoidMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!instance.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "instance");
			}
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.CallNonvirtualVoidMethodA(environmentPointer, instance.Handle, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}
	}

	public static class StaticFields
	{
		public static JniFieldInfo GetStaticFieldID(JniObjectReference type, string name, string signature)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (signature == null)
			{
				throw new ArgumentNullException("signature");
			}
			nint num = Marshal.StringToCoTaskMemUTF8(name);
			nint num2 = Marshal.StringToCoTaskMemUTF8(signature);
			nint environmentPointer = EnvironmentPointer;
			nint staticFieldID = JniNativeMethods.GetStaticFieldID(environmentPointer, type.Handle, num, num2);
			nint thrown = JniNativeMethods.ExceptionOccurred(environmentPointer);
			Marshal.ZeroFreeCoTaskMemUTF8(num);
			Marshal.ZeroFreeCoTaskMemUTF8(num2);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			if (staticFieldID == IntPtr.Zero)
			{
				throw new InvalidOperationException("Should not be reached; `GetStaticFieldID` should have thrown!");
			}
			return new JniFieldInfo(name, signature, staticFieldID, isStatic: true);
		}

		public static JniObjectReference GetStaticObjectField(JniObjectReference type, JniFieldInfo field)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			nint staticObjectField = JniNativeMethods.GetStaticObjectField(EnvironmentPointer, type.Handle, field.ID);
			LogCreateLocalRef(staticObjectField);
			return new JniObjectReference(staticObjectField, JniObjectReferenceType.Local);
		}

		public static bool GetStaticBooleanField(JniObjectReference type, JniFieldInfo field)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			return JniNativeMethods.GetStaticBooleanField(EnvironmentPointer, type.Handle, field.ID) != 0;
		}

		public static int GetStaticIntField(JniObjectReference type, JniFieldInfo field)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			return JniNativeMethods.GetStaticIntField(EnvironmentPointer, type.Handle, field.ID);
		}

		public static long GetStaticLongField(JniObjectReference type, JniFieldInfo field)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			return JniNativeMethods.GetStaticLongField(EnvironmentPointer, type.Handle, field.ID);
		}

		public static float GetStaticFloatField(JniObjectReference type, JniFieldInfo field)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			return JniNativeMethods.GetStaticFloatField(EnvironmentPointer, type.Handle, field.ID);
		}

		public static void SetStaticObjectField(JniObjectReference type, JniFieldInfo field, JniObjectReference value)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			JniNativeMethods.SetStaticObjectField(EnvironmentPointer, type.Handle, field.ID, value.Handle);
		}

		public static void SetStaticByteField(JniObjectReference type, JniFieldInfo field, sbyte value)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			JniNativeMethods.SetStaticByteField(EnvironmentPointer, type.Handle, field.ID, value);
		}

		public static void SetStaticIntField(JniObjectReference type, JniFieldInfo field, int value)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			JniNativeMethods.SetStaticIntField(EnvironmentPointer, type.Handle, field.ID, value);
		}

		public static void SetStaticLongField(JniObjectReference type, JniFieldInfo field, long value)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			JniNativeMethods.SetStaticLongField(EnvironmentPointer, type.Handle, field.ID, value);
		}

		public static void SetStaticFloatField(JniObjectReference type, JniFieldInfo field, float value)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (!field.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "field");
			}
			JniNativeMethods.SetStaticFloatField(EnvironmentPointer, type.Handle, field.ID, value);
		}
	}

	public static class StaticMethods
	{
		public static JniMethodInfo GetStaticMethodID(JniObjectReference type, string name, string signature)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (signature == null)
			{
				throw new ArgumentNullException("signature");
			}
			nint num = Marshal.StringToCoTaskMemUTF8(name);
			nint num2 = Marshal.StringToCoTaskMemUTF8(signature);
			nint environmentPointer = EnvironmentPointer;
			nint staticMethodID = JniNativeMethods.GetStaticMethodID(environmentPointer, type.Handle, num, num2);
			nint thrown = JniNativeMethods.ExceptionOccurred(environmentPointer);
			Marshal.ZeroFreeCoTaskMemUTF8(num);
			Marshal.ZeroFreeCoTaskMemUTF8(num2);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			if (staticMethodID == IntPtr.Zero)
			{
				throw new InvalidOperationException("Should not be reached; `GetStaticMethodID` should have thrown!");
			}
			return new JniMethodInfo(name, signature, staticMethodID, isStatic: true);
		}

		public static JniObjectReference CallStaticObjectMethod(JniObjectReference type, JniMethodInfo method)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			nint num = JniNativeMethods.CallStaticObjectMethod(environmentPointer, type.Handle, method.ID);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public unsafe static JniObjectReference CallStaticObjectMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			nint num = JniNativeMethods.CallStaticObjectMethodA(environmentPointer, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			LogCreateLocalRef(num);
			return new JniObjectReference(num, JniObjectReferenceType.Local);
		}

		public unsafe static bool CallStaticBooleanMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			byte b = JniNativeMethods.CallStaticBooleanMethodA(environmentPointer, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return b != 0;
		}

		public unsafe static sbyte CallStaticByteMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			sbyte result = JniNativeMethods.CallStaticByteMethodA(environmentPointer, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static char CallStaticCharMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			char result = JniNativeMethods.CallStaticCharMethodA(environmentPointer, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static short CallStaticShortMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			short result = JniNativeMethods.CallStaticShortMethodA(environmentPointer, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static int CallStaticIntMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			int result = JniNativeMethods.CallStaticIntMethodA(environmentPointer, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static long CallStaticLongMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			long result = JniNativeMethods.CallStaticLongMethodA(environmentPointer, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static float CallStaticFloatMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			float result = JniNativeMethods.CallStaticFloatMethodA(environmentPointer, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static double CallStaticDoubleMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			double result = JniNativeMethods.CallStaticDoubleMethodA(environmentPointer, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
			return result;
		}

		public unsafe static void CallStaticVoidMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
		{
			if (!type.IsValid)
			{
				throw new ArgumentException("Handle must be valid.", "type");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!method.IsValid)
			{
				throw new ArgumentException("Handle value is not valid.", "method");
			}
			nint environmentPointer = EnvironmentPointer;
			JniNativeMethods.CallStaticVoidMethodA(environmentPointer, type.Handle, method.ID, (nint)args);
			Exception exceptionForLastThrowable = GetExceptionForLastThrowable(JniNativeMethods.ExceptionOccurred(environmentPointer));
			if (exceptionForLastThrowable != null)
			{
				ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
			}
		}
	}

	internal static readonly ThreadLocal<JniEnvironmentInfo> Info = new ThreadLocal<JniEnvironmentInfo>(() => new JniEnvironmentInfo(), trackAllValues: true);

	internal static JniEnvironmentInfo CurrentInfo
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			JniEnvironmentInfo value = Info.Value;
			if (!value.IsValid)
			{
				throw new NotSupportedException("JNI Environment Information has been invalidated on this thread.");
			}
			return value;
		}
	}

	public static JniRuntime Runtime
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return CurrentInfo.Runtime;
		}
	}

	public static nint EnvironmentPointer
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return CurrentInfo.EnvironmentPointer;
		}
	}

	public static bool WithinNewObjectScope
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return CurrentInfo.WithinNewObjectScope;
		}
		internal set
		{
			CurrentInfo.WithinNewObjectScope = value;
		}
	}

	public static bool BeginMarshalMethod(nint jnienv, out JniTransition transition, [NotNullWhen(true)] out JniRuntime? runtime)
	{
		runtime = null;
		Exception ex = null;
		try
		{
			runtime = Info.Value?.Runtime;
		}
		catch (Exception ex2)
		{
			ex = ex2;
		}
		if (runtime == null || ex != null)
		{
			transition = default(JniTransition);
			runtime = null;
			Console.Error.WriteLine("JNI Environment Information is not available on this thread.");
			if (ex != null)
			{
				Console.Error.WriteLine(ex);
			}
			return false;
		}
		try
		{
			runtime.OnEnterMarshalMethod();
			transition = new JniTransition(jnienv);
		}
		catch (Exception value)
		{
			runtime = null;
			transition = default(JniTransition);
			Console.Error.WriteLine($"OnEnterMarshalMethod failed: {value}");
			return false;
		}
		return true;
	}

	public static void EndMarshalMethod(ref JniTransition transition)
	{
		transition.Dispose();
	}

	internal static void SetEnvironmentPointer(nint environmentPointer)
	{
		CurrentInfo.EnvironmentPointer = environmentPointer;
	}

	internal static void SetEnvironmentInfo(JniEnvironmentInfo info)
	{
		Info.Value = info;
	}

	internal static Exception? GetExceptionForLastThrowable(nint thrown)
	{
		if (thrown == IntPtr.Zero)
		{
			return null;
		}
		JniObjectReference reference = new JniObjectReference(thrown, JniObjectReferenceType.Local);
		Exceptions.ExceptionClear();
		LogCreateLocalRef(reference);
		return Runtime.GetExceptionForThrowable(ref reference, JniObjectReferenceOptions.CopyAndDispose);
	}

	internal static Exception CreateObjectDisposedException(IJavaPeerable value)
	{
		return new ObjectDisposedException(value.GetType().FullName, $"Cannot access disposed object with JniIdentityHashCode={value.JniIdentityHashCode}.");
	}

	internal static void LogCreateLocalRef(JniObjectReference value)
	{
		if (value.IsValid)
		{
			Runtime.ObjectReferenceManager.CreatedLocalReference(CurrentInfo, value);
		}
	}

	internal static void LogCreateLocalRef(nint value)
	{
		if (value != IntPtr.Zero)
		{
			LogCreateLocalRef(new JniObjectReference(value, JniObjectReferenceType.Local));
		}
	}
}
