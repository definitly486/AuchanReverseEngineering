using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/FragmentContainer", DoNotGenerateAcw = true)]
public abstract class FragmentContainer : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentContainer", typeof(FragmentContainer));

	private static Delegate? cb_instantiate_Instantiate_Landroid_content_Context_Ljava_lang_String_Landroid_os_Bundle__Landroidx_fragment_app_Fragment_;

	private static Delegate? cb_onFindViewById_OnFindViewById_I_Landroid_view_View_;

	private static Delegate? cb_onHasView_OnHasView_Z;

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

	protected FragmentContainer(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe FragmentContainer()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Obsolete]
	private static Delegate GetInstantiate_Landroid_content_Context_Ljava_lang_String_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPLLL_L(n_Instantiate_Landroid_content_Context_Ljava_lang_String_Landroid_os_Bundle_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Instantiate_Landroid_content_Context_Ljava_lang_String_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_context, nint native_className, nint native_arguments)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentContainer? fragmentContainer = Java.Lang.Object.GetObject<FragmentContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			string className = JNIEnv.GetString(native_className, JniHandleOwnership.DoNotTransfer);
			Bundle arguments = Java.Lang.Object.GetObject<Bundle>(native_arguments, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentContainer.Instantiate(context, className, arguments));
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

	[Obsolete("deprecated")]
	[Register("instantiate", "(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;)Landroidx/fragment/app/Fragment;", "GetInstantiate_Landroid_content_Context_Ljava_lang_String_Landroid_os_Bundle_Handler")]
	public unsafe virtual Fragment Instantiate(Context context, string className, Bundle? arguments)
	{
		nint num = JNIEnv.NewString(className);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(arguments?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeVirtualObjectMethod("instantiate.(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;)Landroidx/fragment/app/Fragment;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
			GC.KeepAlive(arguments);
		}
	}

	private static Delegate GetOnFindViewById_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_OnFindViewById_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnFindViewById_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnFindViewById(id));
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

	[Register("onFindViewById", "(I)Landroid/view/View;", "GetOnFindViewById_IHandler")]
	public abstract View? OnFindViewById(int id);

	private static Delegate GetOnHasViewHandler()
	{
		return new global::_JniMarshal_PP_B(n_OnHasView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnHasView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FragmentContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnHasView() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onHasView", "()Z", "GetOnHasViewHandler")]
	public abstract bool OnHasView();
}
