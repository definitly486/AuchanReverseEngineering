using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang.Reflect;

namespace Java.Lang;

[Register("java/lang/Class", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "T" })]
public sealed class Class : Object, ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
	public static readonly nint Object;

	public static readonly nint String;

	public static readonly nint CharSequence;

	internal static readonly nint CharSequence_toString;

	private static readonly JniPeerMembers _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe ClassLoader? ClassLoader
	{
		[Register("getClassLoader", "()Ljava/lang/ClassLoader;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ClassLoader>(_members.InstanceMethods.InvokeAbstractObjectMethod("getClassLoader.()Ljava/lang/ClassLoader;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe string Name
	{
		[Register("getName", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	static Class()
	{
		_members = new XAPeerMembers("java/lang/Class", typeof(Class));
		Object = JNIEnv.FindClass("java/lang/Object");
		String = JNIEnv.FindClass("java/lang/String");
		CharSequence = JNIEnv.FindClass("java/lang/CharSequence");
		CharSequence_toString = JNIEnv.GetMethodID(CharSequence, "toString", "()Ljava/lang/String;");
	}

	public static Class FromType(Type type)
	{
		if (!typeof(IJavaObject).IsAssignableFrom(type))
		{
			throw new ArgumentException("type", "Type is not derived from a java type.");
		}
		return Java.Lang.Object.GetObject<Class>(JNIEnv.FindClass(type), JniHandleOwnership.TransferGlobalRef);
	}

	internal Class(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("getDeclaredField", "(Ljava/lang/String;)Ljava/lang/reflect/Field;", "")]
	public unsafe Field GetDeclaredField(string name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Field>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDeclaredField.(Ljava/lang/String;)Ljava/lang/reflect/Field;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("getDeclaredMethod", "(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;", "")]
	public unsafe Method GetDeclaredMethod(string name, params Class[]? parameterTypes)
	{
		nint num = JNIEnv.NewString(name);
		nint num2 = JNIEnv.NewArray(parameterTypes);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<Method>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDeclaredMethod.(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (parameterTypes != null)
			{
				JNIEnv.CopyArray(num2, parameterTypes);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(parameterTypes);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
