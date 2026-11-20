using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Internal;

[Register("androidx/camera/core/internal/TargetConfig$Builder", DoNotGenerateAcw = true)]
internal class ITargetConfigBuilderInvoker : Java.Lang.Object, ITargetConfigBuilder, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/internal/TargetConfig$Builder", typeof(ITargetConfigBuilderInvoker));

	private nint class_ref;

	private static Delegate? cb_setTargetClass_Ljava_lang_Class_;

	private nint id_setTargetClass_Ljava_lang_Class_;

	private static Delegate? cb_setTargetName_Ljava_lang_String_;

	private nint id_setTargetName_Ljava_lang_String_;

	private static nint java_class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => class_ref;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public static ITargetConfigBuilder? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ITargetConfigBuilder>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.internal.TargetConfig.Builder'.");
		}
		return handle;
	}

	protected override void Dispose(bool disposing)
	{
		if (class_ref != IntPtr.Zero)
		{
			JNIEnv.DeleteGlobalRef(class_ref);
		}
		class_ref = IntPtr.Zero;
		base.Dispose(disposing);
	}

	public ITargetConfigBuilderInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetSetTargetClass_Ljava_lang_Class_Handler()
	{
		if ((object)cb_setTargetClass_Ljava_lang_Class_ == null)
		{
			cb_setTargetClass_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetTargetClass_Ljava_lang_Class_));
		}
		return cb_setTargetClass_Ljava_lang_Class_;
	}

	private static nint n_SetTargetClass_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_p0)
	{
		ITargetConfigBuilder? targetConfigBuilder = Java.Lang.Object.GetObject<ITargetConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Class targetClass = Java.Lang.Object.GetObject<Class>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(targetConfigBuilder.SetTargetClass(targetClass));
	}

	public unsafe Java.Lang.Object SetTargetClass(Class p0)
	{
		if (id_setTargetClass_Ljava_lang_Class_ == IntPtr.Zero)
		{
			id_setTargetClass_Ljava_lang_Class_ = JNIEnv.GetMethodID(class_ref, "setTargetClass", "(Ljava/lang/Class;)Ljava/lang/Object;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_setTargetClass_Ljava_lang_Class_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetTargetName_Ljava_lang_String_Handler()
	{
		if ((object)cb_setTargetName_Ljava_lang_String_ == null)
		{
			cb_setTargetName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetTargetName_Ljava_lang_String_));
		}
		return cb_setTargetName_Ljava_lang_String_;
	}

	private static nint n_SetTargetName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		ITargetConfigBuilder? targetConfigBuilder = Java.Lang.Object.GetObject<ITargetConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string targetName = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(targetConfigBuilder.SetTargetName(targetName));
	}

	public unsafe Java.Lang.Object SetTargetName(string p0)
	{
		if (id_setTargetName_Ljava_lang_String_ == IntPtr.Zero)
		{
			id_setTargetName_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "setTargetName", "(Ljava/lang/String;)Ljava/lang/Object;");
		}
		nint num = JNIEnv.NewString(p0);
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(num);
		Java.Lang.Object? result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_setTargetName_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
		JNIEnv.DeleteLocalRef(num);
		return result;
	}
}
