namespace Java.Interop;

internal struct JNIEnv
{
	private nint reserved0;

	private nint reserved1;

	private nint reserved2;

	private nint reserved3;

	public unsafe delegate* unmanaged<nint, int> GetVersion;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, int, nint> DefineClass;

	public unsafe delegate* unmanaged<nint, nint, nint> FindClass;

	public unsafe delegate* unmanaged<nint, nint, nint> FromReflectedMethod;

	public unsafe delegate* unmanaged<nint, nint, nint> FromReflectedField;

	public unsafe delegate* unmanaged<nint, nint, nint, byte, nint> ToReflectedMethod;

	public unsafe delegate* unmanaged<nint, nint, nint> GetSuperclass;

	public unsafe delegate* unmanaged<nint, nint, nint, byte> IsAssignableFrom;

	public unsafe delegate* unmanaged<nint, nint, nint, byte, nint> ToReflectedField;

	public unsafe delegate* unmanaged<nint, nint, int> Throw;

	public unsafe delegate* unmanaged<nint, nint, nint, int> ThrowNew;

	public unsafe delegate* unmanaged<nint, nint> ExceptionOccurred;

	public unsafe delegate* unmanaged<nint, void> ExceptionDescribe;

	public unsafe delegate* unmanaged<nint, void> ExceptionClear;

	public unsafe delegate* unmanaged<nint, nint, void> FatalError;

	public unsafe delegate* unmanaged<nint, int, int> PushLocalFrame;

	public unsafe delegate* unmanaged<nint, nint, nint> PopLocalFrame;

	public unsafe delegate* unmanaged<nint, nint, nint> NewGlobalRef;

	public unsafe delegate* unmanaged<nint, nint, void> DeleteGlobalRef;

	public unsafe delegate* unmanaged<nint, nint, void> DeleteLocalRef;

	public unsafe delegate* unmanaged<nint, nint, nint, byte> IsSameObject;

	public unsafe delegate* unmanaged<nint, nint, nint> NewLocalRef;

	public unsafe delegate* unmanaged<nint, int, int> EnsureLocalCapacity;

	public unsafe delegate* unmanaged<nint, nint, nint> AllocObject;

	public unsafe delegate* unmanaged<nint, nint, nint, nint> NewObject;

	public nint NewObjectV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint> NewObjectA;

	public unsafe delegate* unmanaged<nint, nint, nint> GetObjectClass;

	public unsafe delegate* unmanaged<nint, nint, nint, byte> IsInstanceOf;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint> GetMethodID;

	public unsafe delegate* unmanaged<nint, nint, nint, nint> CallObjectMethod;

	public nint CallObjectMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint> CallObjectMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, byte> CallBooleanMethod;

	public nint CallBooleanMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, byte> CallBooleanMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, sbyte> CallByteMethod;

	public nint CallByteMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, sbyte> CallByteMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, char> CallCharMethod;

	public nint CallCharMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, char> CallCharMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, short> CallShortMethod;

	public nint CallShortMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, short> CallShortMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, int> CallIntMethod;

	public nint CallIntMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, int> CallIntMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, long> CallLongMethod;

	public nint CallLongMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, long> CallLongMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, float> CallFloatMethod;

	public nint CallFloatMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, float> CallFloatMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, double> CallDoubleMethod;

	public nint CallDoubleMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, double> CallDoubleMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, void> CallVoidMethod;

	public nint CallVoidMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, void> CallVoidMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint> CallNonvirtualObjectMethod;

	public nint CallNonvirtualObjectMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint, nint> CallNonvirtualObjectMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, byte> CallNonvirtualBooleanMethod;

	public nint CallNonvirtualBooleanMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint, byte> CallNonvirtualBooleanMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, sbyte> CallNonvirtualByteMethod;

	public nint CallNonvirtualByteMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint, sbyte> CallNonvirtualByteMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, char> CallNonvirtualCharMethod;

	public nint CallNonvirtualCharMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint, char> CallNonvirtualCharMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, short> CallNonvirtualShortMethod;

	public nint CallNonvirtualShortMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint, short> CallNonvirtualShortMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, int> CallNonvirtualIntMethod;

	public nint CallNonvirtualIntMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint, int> CallNonvirtualIntMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, long> CallNonvirtualLongMethod;

	public nint CallNonvirtualLongMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint, long> CallNonvirtualLongMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, float> CallNonvirtualFloatMethod;

	public nint CallNonvirtualFloatMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint, float> CallNonvirtualFloatMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, double> CallNonvirtualDoubleMethod;

	public nint CallNonvirtualDoubleMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint, double> CallNonvirtualDoubleMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, void> CallNonvirtualVoidMethod;

	public nint CallNonvirtualVoidMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint, void> CallNonvirtualVoidMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint> GetFieldID;

	public unsafe delegate* unmanaged<nint, nint, nint, nint> GetObjectField;

	public unsafe delegate* unmanaged<nint, nint, nint, byte> GetBooleanField;

	public unsafe delegate* unmanaged<nint, nint, nint, sbyte> GetByteField;

	public unsafe delegate* unmanaged<nint, nint, nint, char> GetCharField;

	public unsafe delegate* unmanaged<nint, nint, nint, short> GetShortField;

	public unsafe delegate* unmanaged<nint, nint, nint, int> GetIntField;

	public unsafe delegate* unmanaged<nint, nint, nint, long> GetLongField;

	public unsafe delegate* unmanaged<nint, nint, nint, float> GetFloatField;

	public unsafe delegate* unmanaged<nint, nint, nint, double> GetDoubleField;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, void> SetObjectField;

	public unsafe delegate* unmanaged<nint, nint, nint, byte, void> SetBooleanField;

	public unsafe delegate* unmanaged<nint, nint, nint, sbyte, void> SetByteField;

	public unsafe delegate* unmanaged<nint, nint, nint, char, void> SetCharField;

	public unsafe delegate* unmanaged<nint, nint, nint, short, void> SetShortField;

	public unsafe delegate* unmanaged<nint, nint, nint, int, void> SetIntField;

	public unsafe delegate* unmanaged<nint, nint, nint, long, void> SetLongField;

	public unsafe delegate* unmanaged<nint, nint, nint, float, void> SetFloatField;

	public unsafe delegate* unmanaged<nint, nint, nint, double, void> SetDoubleField;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint> GetStaticMethodID;

	public unsafe delegate* unmanaged<nint, nint, nint, nint> CallStaticObjectMethod;

	public nint CallStaticObjectMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint> CallStaticObjectMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, byte> CallStaticBooleanMethod;

	public nint CallStaticBooleanMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, byte> CallStaticBooleanMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, sbyte> CallStaticByteMethod;

	public nint CallStaticByteMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, sbyte> CallStaticByteMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, char> CallStaticCharMethod;

	public nint CallStaticCharMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, char> CallStaticCharMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, short> CallStaticShortMethod;

	public nint CallStaticShortMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, short> CallStaticShortMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, int> CallStaticIntMethod;

	public nint CallStaticIntMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, int> CallStaticIntMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, long> CallStaticLongMethod;

	public nint CallStaticLongMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, long> CallStaticLongMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, float> CallStaticFloatMethod;

	public nint CallStaticFloatMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, float> CallStaticFloatMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, double> CallStaticDoubleMethod;

	public nint CallStaticDoubleMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, double> CallStaticDoubleMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, void> CallStaticVoidMethod;

	public nint CallStaticVoidMethodV;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, void> CallStaticVoidMethodA;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, nint> GetStaticFieldID;

	public unsafe delegate* unmanaged<nint, nint, nint, nint> GetStaticObjectField;

	public unsafe delegate* unmanaged<nint, nint, nint, byte> GetStaticBooleanField;

	public unsafe delegate* unmanaged<nint, nint, nint, sbyte> GetStaticByteField;

	public unsafe delegate* unmanaged<nint, nint, nint, char> GetStaticCharField;

	public unsafe delegate* unmanaged<nint, nint, nint, short> GetStaticShortField;

	public unsafe delegate* unmanaged<nint, nint, nint, int> GetStaticIntField;

	public unsafe delegate* unmanaged<nint, nint, nint, long> GetStaticLongField;

	public unsafe delegate* unmanaged<nint, nint, nint, float> GetStaticFloatField;

	public unsafe delegate* unmanaged<nint, nint, nint, double> GetStaticDoubleField;

	public unsafe delegate* unmanaged<nint, nint, nint, nint, void> SetStaticObjectField;

	public unsafe delegate* unmanaged<nint, nint, nint, byte, void> SetStaticBooleanField;

	public unsafe delegate* unmanaged<nint, nint, nint, sbyte, void> SetStaticByteField;

	public unsafe delegate* unmanaged<nint, nint, nint, char, void> SetStaticCharField;

	public unsafe delegate* unmanaged<nint, nint, nint, short, void> SetStaticShortField;

	public unsafe delegate* unmanaged<nint, nint, nint, int, void> SetStaticIntField;

	public unsafe delegate* unmanaged<nint, nint, nint, long, void> SetStaticLongField;

	public unsafe delegate* unmanaged<nint, nint, nint, float, void> SetStaticFloatField;

	public unsafe delegate* unmanaged<nint, nint, nint, double, void> SetStaticDoubleField;

	public unsafe delegate* unmanaged<nint, char*, int, nint> NewString;

	public unsafe delegate* unmanaged<nint, nint, int> GetStringLength;

	public unsafe delegate* unmanaged<nint, nint, bool*, char*> GetStringChars;

	public unsafe delegate* unmanaged<nint, nint, char*, void> ReleaseStringChars;

	public unsafe delegate* unmanaged<nint, nint, nint> NewStringUTF;

	public unsafe delegate* unmanaged<nint, nint, int> GetStringUTFLength;

	public unsafe delegate* unmanaged<nint, nint, bool*, nint> GetStringUTFChars;

	public unsafe delegate* unmanaged<nint, nint, nint, void> ReleaseStringUTFChars;

	public unsafe delegate* unmanaged<nint, nint, int> GetArrayLength;

	public unsafe delegate* unmanaged<nint, int, nint, nint, nint> NewObjectArray;

	public unsafe delegate* unmanaged<nint, nint, int, nint> GetObjectArrayElement;

	public unsafe delegate* unmanaged<nint, nint, int, nint, void> SetObjectArrayElement;

	public unsafe delegate* unmanaged<nint, int, nint> NewBooleanArray;

	public unsafe delegate* unmanaged<nint, int, nint> NewByteArray;

	public unsafe delegate* unmanaged<nint, int, nint> NewCharArray;

	public unsafe delegate* unmanaged<nint, int, nint> NewShortArray;

	public unsafe delegate* unmanaged<nint, int, nint> NewIntArray;

	public unsafe delegate* unmanaged<nint, int, nint> NewLongArray;

	public unsafe delegate* unmanaged<nint, int, nint> NewFloatArray;

	public unsafe delegate* unmanaged<nint, int, nint> NewDoubleArray;

	public unsafe delegate* unmanaged<nint, nint, bool*, bool*> GetBooleanArrayElements;

	public unsafe delegate* unmanaged<nint, nint, bool*, sbyte*> GetByteArrayElements;

	public unsafe delegate* unmanaged<nint, nint, bool*, char*> GetCharArrayElements;

	public unsafe delegate* unmanaged<nint, nint, bool*, short*> GetShortArrayElements;

	public unsafe delegate* unmanaged<nint, nint, bool*, int*> GetIntArrayElements;

	public unsafe delegate* unmanaged<nint, nint, bool*, long*> GetLongArrayElements;

	public unsafe delegate* unmanaged<nint, nint, bool*, float*> GetFloatArrayElements;

	public unsafe delegate* unmanaged<nint, nint, bool*, double*> GetDoubleArrayElements;

	public unsafe delegate* unmanaged<nint, nint, bool*, int, void> ReleaseBooleanArrayElements;

	public unsafe delegate* unmanaged<nint, nint, sbyte*, int, void> ReleaseByteArrayElements;

	public unsafe delegate* unmanaged<nint, nint, char*, int, void> ReleaseCharArrayElements;

	public unsafe delegate* unmanaged<nint, nint, short*, int, void> ReleaseShortArrayElements;

	public unsafe delegate* unmanaged<nint, nint, int*, int, void> ReleaseIntArrayElements;

	public unsafe delegate* unmanaged<nint, nint, long*, int, void> ReleaseLongArrayElements;

	public unsafe delegate* unmanaged<nint, nint, float*, int, void> ReleaseFloatArrayElements;

	public unsafe delegate* unmanaged<nint, nint, double*, int, void> ReleaseDoubleArrayElements;

	public unsafe delegate* unmanaged<nint, nint, int, int, bool*, void> GetBooleanArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, sbyte*, void> GetByteArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, char*, void> GetCharArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, short*, void> GetShortArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, int*, void> GetIntArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, long*, void> GetLongArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, float*, void> GetFloatArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, double*, void> GetDoubleArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, bool*, void> SetBooleanArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, sbyte*, void> SetByteArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, char*, void> SetCharArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, short*, void> SetShortArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, int*, void> SetIntArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, long*, void> SetLongArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, float*, void> SetFloatArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, double*, void> SetDoubleArrayRegion;

	public unsafe delegate* unmanaged<nint, nint, JniNativeMethodRegistration[], int, int> RegisterNatives;

	public unsafe delegate* unmanaged<nint, nint, int> UnregisterNatives;

	public unsafe delegate* unmanaged<nint, nint, int> MonitorEnter;

	public unsafe delegate* unmanaged<nint, nint, int> MonitorExit;

	public unsafe delegate* unmanaged<nint, nint*, int> GetJavaVM;

	public unsafe delegate* unmanaged<nint, nint, int, int, char*, void> GetStringRegion;

	public unsafe delegate* unmanaged<nint, nint, int, int, nint, void> GetStringUTFRegion;

	public unsafe delegate* unmanaged<nint, nint, bool*, nint> GetPrimitiveArrayCritical;

	public unsafe delegate* unmanaged<nint, nint, nint, int, void> ReleasePrimitiveArrayCritical;

	public unsafe delegate* unmanaged<nint, nint, bool*, nint> GetStringCritical;

	public unsafe delegate* unmanaged<nint, nint, nint, void> ReleaseStringCritical;

	public unsafe delegate* unmanaged<nint, nint, nint> NewWeakGlobalRef;

	public unsafe delegate* unmanaged<nint, nint, void> DeleteWeakGlobalRef;

	public unsafe delegate* unmanaged<nint, byte> ExceptionCheck;

	public unsafe delegate* unmanaged<nint, nint, long, nint> NewDirectByteBuffer;

	public unsafe delegate* unmanaged<nint, nint, nint> GetDirectBufferAddress;

	public unsafe delegate* unmanaged<nint, nint, long> GetDirectBufferCapacity;

	public unsafe delegate* unmanaged<nint, nint, JniObjectReferenceType> GetObjectRefType;
}
