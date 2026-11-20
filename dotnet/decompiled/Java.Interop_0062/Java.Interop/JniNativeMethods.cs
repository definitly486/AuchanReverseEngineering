using System.Runtime.CompilerServices;

namespace Java.Interop;

internal static class JniNativeMethods
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint FindClass(nint env, nint classname)
	{
		return (*(JNIEnv**)env)->FindClass(env, classname);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint GetSuperclass(nint env, nint type)
	{
		return (*(JNIEnv**)env)->GetSuperclass(env, type);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static byte IsAssignableFrom(nint env, nint class1, nint class2)
	{
		return (*(JNIEnv**)env)->IsAssignableFrom(env, class1, class2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static int Throw(nint env, nint toThrow)
	{
		return (*(JNIEnv**)env)->Throw(env, toThrow);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint ExceptionOccurred(nint env)
	{
		return (*(JNIEnv**)env)->ExceptionOccurred(env);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void ExceptionClear(nint env)
	{
		(*(JNIEnv**)env)->ExceptionClear(env);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint NewGlobalRef(nint env, nint instance)
	{
		return (*(JNIEnv**)env)->NewGlobalRef(env, instance);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void DeleteGlobalRef(nint env, nint instance)
	{
		(*(JNIEnv**)env)->DeleteGlobalRef(env, instance);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void DeleteLocalRef(nint env, nint instance)
	{
		(*(JNIEnv**)env)->DeleteLocalRef(env, instance);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static byte IsSameObject(nint env, nint object1, nint object2)
	{
		return (*(JNIEnv**)env)->IsSameObject(env, object1, object2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint NewLocalRef(nint env, nint instance)
	{
		return (*(JNIEnv**)env)->NewLocalRef(env, instance);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint AllocObject(nint env, nint type)
	{
		return (*(JNIEnv**)env)->AllocObject(env, type);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint NewObjectA(nint env, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->NewObjectA(env, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint GetObjectClass(nint env, nint instance)
	{
		return (*(JNIEnv**)env)->GetObjectClass(env, instance);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static byte IsInstanceOf(nint env, nint instance, nint type)
	{
		return (*(JNIEnv**)env)->IsInstanceOf(env, instance, type);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint GetMethodID(nint env, nint type, nint name, nint signature)
	{
		return (*(JNIEnv**)env)->GetMethodID(env, type, name, signature);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint CallObjectMethod(nint env, nint instance, nint method)
	{
		return (*(JNIEnv**)env)->CallObjectMethod(env, instance, method);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint CallObjectMethodA(nint env, nint instance, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallObjectMethodA(env, instance, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static byte CallBooleanMethod(nint env, nint instance, nint method)
	{
		return (*(JNIEnv**)env)->CallBooleanMethod(env, instance, method);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static byte CallBooleanMethodA(nint env, nint instance, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallBooleanMethodA(env, instance, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static sbyte CallByteMethod(nint env, nint instance, nint method)
	{
		return (*(JNIEnv**)env)->CallByteMethod(env, instance, method);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static sbyte CallByteMethodA(nint env, nint instance, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallByteMethodA(env, instance, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static char CallCharMethod(nint env, nint instance, nint method)
	{
		return (*(JNIEnv**)env)->CallCharMethod(env, instance, method);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static char CallCharMethodA(nint env, nint instance, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallCharMethodA(env, instance, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static short CallShortMethod(nint env, nint instance, nint method)
	{
		return (*(JNIEnv**)env)->CallShortMethod(env, instance, method);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static short CallShortMethodA(nint env, nint instance, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallShortMethodA(env, instance, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static int CallIntMethod(nint env, nint instance, nint method)
	{
		return (*(JNIEnv**)env)->CallIntMethod(env, instance, method);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static int CallIntMethodA(nint env, nint instance, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallIntMethodA(env, instance, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static long CallLongMethod(nint env, nint instance, nint method)
	{
		return (*(JNIEnv**)env)->CallLongMethod(env, instance, method);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static long CallLongMethodA(nint env, nint instance, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallLongMethodA(env, instance, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static float CallFloatMethod(nint env, nint instance, nint method)
	{
		return (*(JNIEnv**)env)->CallFloatMethod(env, instance, method);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static float CallFloatMethodA(nint env, nint instance, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallFloatMethodA(env, instance, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static double CallDoubleMethod(nint env, nint instance, nint method)
	{
		return (*(JNIEnv**)env)->CallDoubleMethod(env, instance, method);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static double CallDoubleMethodA(nint env, nint instance, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallDoubleMethodA(env, instance, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void CallVoidMethod(nint env, nint instance, nint method)
	{
		(*(JNIEnv**)env)->CallVoidMethod(env, instance, method);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void CallVoidMethodA(nint env, nint instance, nint method, nint args)
	{
		(*(JNIEnv**)env)->CallVoidMethodA(env, instance, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint CallNonvirtualObjectMethodA(nint env, nint instance, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallNonvirtualObjectMethodA(env, instance, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static byte CallNonvirtualBooleanMethodA(nint env, nint instance, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallNonvirtualBooleanMethodA(env, instance, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static sbyte CallNonvirtualByteMethodA(nint env, nint instance, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallNonvirtualByteMethodA(env, instance, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static char CallNonvirtualCharMethodA(nint env, nint instance, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallNonvirtualCharMethodA(env, instance, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static short CallNonvirtualShortMethodA(nint env, nint instance, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallNonvirtualShortMethodA(env, instance, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static int CallNonvirtualIntMethodA(nint env, nint instance, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallNonvirtualIntMethodA(env, instance, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static long CallNonvirtualLongMethodA(nint env, nint instance, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallNonvirtualLongMethodA(env, instance, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static float CallNonvirtualFloatMethodA(nint env, nint instance, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallNonvirtualFloatMethodA(env, instance, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static double CallNonvirtualDoubleMethodA(nint env, nint instance, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallNonvirtualDoubleMethodA(env, instance, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void CallNonvirtualVoidMethodA(nint env, nint instance, nint type, nint method, nint args)
	{
		(*(JNIEnv**)env)->CallNonvirtualVoidMethodA(env, instance, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint GetFieldID(nint env, nint type, nint name, nint signature)
	{
		return (*(JNIEnv**)env)->GetFieldID(env, type, name, signature);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint GetObjectField(nint env, nint instance, nint field)
	{
		return (*(JNIEnv**)env)->GetObjectField(env, instance, field);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static byte GetBooleanField(nint env, nint instance, nint field)
	{
		return (*(JNIEnv**)env)->GetBooleanField(env, instance, field);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static int GetIntField(nint env, nint instance, nint field)
	{
		return (*(JNIEnv**)env)->GetIntField(env, instance, field);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static long GetLongField(nint env, nint instance, nint field)
	{
		return (*(JNIEnv**)env)->GetLongField(env, instance, field);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static float GetFloatField(nint env, nint instance, nint field)
	{
		return (*(JNIEnv**)env)->GetFloatField(env, instance, field);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetObjectField(nint env, nint instance, nint field, nint value)
	{
		(*(JNIEnv**)env)->SetObjectField(env, instance, field, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetByteField(nint env, nint instance, nint field, sbyte value)
	{
		(*(JNIEnv**)env)->SetByteField(env, instance, field, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetIntField(nint env, nint instance, nint field, int value)
	{
		(*(JNIEnv**)env)->SetIntField(env, instance, field, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetLongField(nint env, nint instance, nint field, long value)
	{
		(*(JNIEnv**)env)->SetLongField(env, instance, field, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetFloatField(nint env, nint instance, nint field, float value)
	{
		(*(JNIEnv**)env)->SetFloatField(env, instance, field, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint GetStaticMethodID(nint env, nint type, nint name, nint signature)
	{
		return (*(JNIEnv**)env)->GetStaticMethodID(env, type, name, signature);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint CallStaticObjectMethod(nint env, nint type, nint method)
	{
		return (*(JNIEnv**)env)->CallStaticObjectMethod(env, type, method);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint CallStaticObjectMethodA(nint env, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallStaticObjectMethodA(env, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static byte CallStaticBooleanMethodA(nint env, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallStaticBooleanMethodA(env, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static sbyte CallStaticByteMethodA(nint env, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallStaticByteMethodA(env, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static char CallStaticCharMethodA(nint env, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallStaticCharMethodA(env, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static short CallStaticShortMethodA(nint env, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallStaticShortMethodA(env, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static int CallStaticIntMethodA(nint env, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallStaticIntMethodA(env, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static long CallStaticLongMethodA(nint env, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallStaticLongMethodA(env, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static float CallStaticFloatMethodA(nint env, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallStaticFloatMethodA(env, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static double CallStaticDoubleMethodA(nint env, nint type, nint method, nint args)
	{
		return (*(JNIEnv**)env)->CallStaticDoubleMethodA(env, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void CallStaticVoidMethodA(nint env, nint type, nint method, nint args)
	{
		(*(JNIEnv**)env)->CallStaticVoidMethodA(env, type, method, args);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint GetStaticFieldID(nint env, nint type, nint name, nint signature)
	{
		return (*(JNIEnv**)env)->GetStaticFieldID(env, type, name, signature);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint GetStaticObjectField(nint env, nint type, nint field)
	{
		return (*(JNIEnv**)env)->GetStaticObjectField(env, type, field);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static byte GetStaticBooleanField(nint env, nint type, nint field)
	{
		return (*(JNIEnv**)env)->GetStaticBooleanField(env, type, field);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static int GetStaticIntField(nint env, nint type, nint field)
	{
		return (*(JNIEnv**)env)->GetStaticIntField(env, type, field);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static long GetStaticLongField(nint env, nint type, nint field)
	{
		return (*(JNIEnv**)env)->GetStaticLongField(env, type, field);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static float GetStaticFloatField(nint env, nint type, nint field)
	{
		return (*(JNIEnv**)env)->GetStaticFloatField(env, type, field);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetStaticObjectField(nint env, nint type, nint field, nint value)
	{
		(*(JNIEnv**)env)->SetStaticObjectField(env, type, field, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetStaticByteField(nint env, nint type, nint field, sbyte value)
	{
		(*(JNIEnv**)env)->SetStaticByteField(env, type, field, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetStaticIntField(nint env, nint type, nint field, int value)
	{
		(*(JNIEnv**)env)->SetStaticIntField(env, type, field, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetStaticLongField(nint env, nint type, nint field, long value)
	{
		(*(JNIEnv**)env)->SetStaticLongField(env, type, field, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetStaticFloatField(nint env, nint type, nint field, float value)
	{
		(*(JNIEnv**)env)->SetStaticFloatField(env, type, field, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint NewString(nint env, char* unicodeChars, int length)
	{
		return (*(JNIEnv**)env)->NewString(env, unicodeChars, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static int GetStringLength(nint env, nint stringInstance)
	{
		return (*(JNIEnv**)env)->GetStringLength(env, stringInstance);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static char* GetStringChars(nint env, nint stringInstance, bool* isCopy)
	{
		return (*(JNIEnv**)env)->GetStringChars(env, stringInstance, isCopy);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void ReleaseStringChars(nint env, nint stringInstance, char* chars)
	{
		(*(JNIEnv**)env)->ReleaseStringChars(env, stringInstance, chars);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static int GetArrayLength(nint env, nint array)
	{
		return (*(JNIEnv**)env)->GetArrayLength(env, array);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint NewObjectArray(nint env, int length, nint elementClass, nint initialElement)
	{
		return (*(JNIEnv**)env)->NewObjectArray(env, length, elementClass, initialElement);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint GetObjectArrayElement(nint env, nint array, int index)
	{
		return (*(JNIEnv**)env)->GetObjectArrayElement(env, array, index);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetObjectArrayElement(nint env, nint array, int index, nint value)
	{
		(*(JNIEnv**)env)->SetObjectArrayElement(env, array, index, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint NewBooleanArray(nint env, int length)
	{
		return (*(JNIEnv**)env)->NewBooleanArray(env, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint NewByteArray(nint env, int length)
	{
		return (*(JNIEnv**)env)->NewByteArray(env, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint NewCharArray(nint env, int length)
	{
		return (*(JNIEnv**)env)->NewCharArray(env, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint NewShortArray(nint env, int length)
	{
		return (*(JNIEnv**)env)->NewShortArray(env, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint NewIntArray(nint env, int length)
	{
		return (*(JNIEnv**)env)->NewIntArray(env, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint NewLongArray(nint env, int length)
	{
		return (*(JNIEnv**)env)->NewLongArray(env, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint NewFloatArray(nint env, int length)
	{
		return (*(JNIEnv**)env)->NewFloatArray(env, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nint NewDoubleArray(nint env, int length)
	{
		return (*(JNIEnv**)env)->NewDoubleArray(env, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static bool* GetBooleanArrayElements(nint env, nint array, bool* isCopy)
	{
		return (*(JNIEnv**)env)->GetBooleanArrayElements(env, array, isCopy);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static sbyte* GetByteArrayElements(nint env, nint array, bool* isCopy)
	{
		return (*(JNIEnv**)env)->GetByteArrayElements(env, array, isCopy);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static char* GetCharArrayElements(nint env, nint array, bool* isCopy)
	{
		return (*(JNIEnv**)env)->GetCharArrayElements(env, array, isCopy);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static short* GetShortArrayElements(nint env, nint array, bool* isCopy)
	{
		return (*(JNIEnv**)env)->GetShortArrayElements(env, array, isCopy);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static int* GetIntArrayElements(nint env, nint array, bool* isCopy)
	{
		return (*(JNIEnv**)env)->GetIntArrayElements(env, array, isCopy);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static long* GetLongArrayElements(nint env, nint array, bool* isCopy)
	{
		return (*(JNIEnv**)env)->GetLongArrayElements(env, array, isCopy);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static float* GetFloatArrayElements(nint env, nint array, bool* isCopy)
	{
		return (*(JNIEnv**)env)->GetFloatArrayElements(env, array, isCopy);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static double* GetDoubleArrayElements(nint env, nint array, bool* isCopy)
	{
		return (*(JNIEnv**)env)->GetDoubleArrayElements(env, array, isCopy);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void ReleaseBooleanArrayElements(nint env, nint array, bool* elements, int mode)
	{
		(*(JNIEnv**)env)->ReleaseBooleanArrayElements(env, array, elements, mode);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void ReleaseByteArrayElements(nint env, nint array, sbyte* elements, int mode)
	{
		(*(JNIEnv**)env)->ReleaseByteArrayElements(env, array, elements, mode);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void ReleaseCharArrayElements(nint env, nint array, char* elements, int mode)
	{
		(*(JNIEnv**)env)->ReleaseCharArrayElements(env, array, elements, mode);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void ReleaseShortArrayElements(nint env, nint array, short* elements, int mode)
	{
		(*(JNIEnv**)env)->ReleaseShortArrayElements(env, array, elements, mode);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void ReleaseIntArrayElements(nint env, nint array, int* elements, int mode)
	{
		(*(JNIEnv**)env)->ReleaseIntArrayElements(env, array, elements, mode);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void ReleaseLongArrayElements(nint env, nint array, long* elements, int mode)
	{
		(*(JNIEnv**)env)->ReleaseLongArrayElements(env, array, elements, mode);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void ReleaseFloatArrayElements(nint env, nint array, float* elements, int mode)
	{
		(*(JNIEnv**)env)->ReleaseFloatArrayElements(env, array, elements, mode);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void ReleaseDoubleArrayElements(nint env, nint array, double* elements, int mode)
	{
		(*(JNIEnv**)env)->ReleaseDoubleArrayElements(env, array, elements, mode);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void GetBooleanArrayRegion(nint env, nint array, int start, int length, bool* buffer)
	{
		(*(JNIEnv**)env)->GetBooleanArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void GetByteArrayRegion(nint env, nint array, int start, int length, sbyte* buffer)
	{
		(*(JNIEnv**)env)->GetByteArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void GetCharArrayRegion(nint env, nint array, int start, int length, char* buffer)
	{
		(*(JNIEnv**)env)->GetCharArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void GetShortArrayRegion(nint env, nint array, int start, int length, short* buffer)
	{
		(*(JNIEnv**)env)->GetShortArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void GetIntArrayRegion(nint env, nint array, int start, int length, int* buffer)
	{
		(*(JNIEnv**)env)->GetIntArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void GetLongArrayRegion(nint env, nint array, int start, int length, long* buffer)
	{
		(*(JNIEnv**)env)->GetLongArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void GetFloatArrayRegion(nint env, nint array, int start, int length, float* buffer)
	{
		(*(JNIEnv**)env)->GetFloatArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void GetDoubleArrayRegion(nint env, nint array, int start, int length, double* buffer)
	{
		(*(JNIEnv**)env)->GetDoubleArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetBooleanArrayRegion(nint env, nint array, int start, int length, bool* buffer)
	{
		(*(JNIEnv**)env)->SetBooleanArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetByteArrayRegion(nint env, nint array, int start, int length, sbyte* buffer)
	{
		(*(JNIEnv**)env)->SetByteArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetCharArrayRegion(nint env, nint array, int start, int length, char* buffer)
	{
		(*(JNIEnv**)env)->SetCharArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetShortArrayRegion(nint env, nint array, int start, int length, short* buffer)
	{
		(*(JNIEnv**)env)->SetShortArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetIntArrayRegion(nint env, nint array, int start, int length, int* buffer)
	{
		(*(JNIEnv**)env)->SetIntArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetLongArrayRegion(nint env, nint array, int start, int length, long* buffer)
	{
		(*(JNIEnv**)env)->SetLongArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetFloatArrayRegion(nint env, nint array, int start, int length, float* buffer)
	{
		(*(JNIEnv**)env)->SetFloatArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void SetDoubleArrayRegion(nint env, nint array, int start, int length, double* buffer)
	{
		(*(JNIEnv**)env)->SetDoubleArrayRegion(env, array, start, length, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static int RegisterNatives(nint env, nint type, JniNativeMethodRegistration[] methods, int numMethods)
	{
		return (*(JNIEnv**)env)->RegisterNatives(env, type, methods, numMethods);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static int UnregisterNatives(nint env, nint type)
	{
		return (*(JNIEnv**)env)->UnregisterNatives(env, type);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static int GetJavaVM(nint env, nint* vm)
	{
		return (*(JNIEnv**)env)->GetJavaVM(env, vm);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void DeleteWeakGlobalRef(nint env, nint instance)
	{
		(*(JNIEnv**)env)->DeleteWeakGlobalRef(env, instance);
	}
}
