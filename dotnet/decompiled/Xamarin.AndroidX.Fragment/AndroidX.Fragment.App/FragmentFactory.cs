using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/FragmentFactory", DoNotGenerateAcw = true)]
public class FragmentFactory : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentFactory", typeof(FragmentFactory));

	private static Delegate? cb_instantiate_Instantiate_Ljava_lang_ClassLoader_Ljava_lang_String__Landroidx_fragment_app_Fragment_;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected FragmentFactory(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe FragmentFactory()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Instantiate_Ljava_lang_ClassLoader_Ljava_lang_String_(nint jnienv, nint native__this, nint native_classLoader, nint native_className)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentFactory? fragmentFactory = Java.Lang.Object.GetObject<FragmentFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ClassLoader classLoader = Java.Lang.Object.GetObject<ClassLoader>(native_classLoader, JniHandleOwnership.DoNotTransfer);
			string className = JNIEnv.GetString(native_className, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentFactory.Instantiate(classLoader, className));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("instantiate", "(Ljava/lang/ClassLoader;Ljava/lang/String;)Landroidx/fragment/app/Fragment;", "GetInstantiate_Ljava_lang_ClassLoader_Ljava_lang_String_Handler")]
	public unsafe virtual Fragment Instantiate(ClassLoader classLoader, string className)
	{
		nint num = JNIEnv.NewString(className);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(classLoader?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeVirtualObjectMethod("instantiate.(Ljava/lang/ClassLoader;Ljava/lang/String;)Landroidx/fragment/app/Fragment;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(classLoader);
		}
	}

	[Register("loadFragmentClass", "(Ljava/lang/ClassLoader;Ljava/lang/String;)Ljava/lang/Class;", "")]
	public unsafe static Class LoadFragmentClass(ClassLoader classLoader, string className)
	{
		nint num = JNIEnv.NewString(className);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(classLoader?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Class>(_members.StaticMethods.InvokeObjectMethod("loadFragmentClass.(Ljava/lang/ClassLoader;Ljava/lang/String;)Ljava/lang/Class;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(classLoader);
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_Instantiate_Ljava_lang_ClassLoader_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_classLoader, nint native_className)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_Instantiate_Ljava_lang_ClassLoader_Ljava_lang_String_(jnienv, native__this, native_classLoader, native_className);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
