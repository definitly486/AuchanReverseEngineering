using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/LayoutInflater", DoNotGenerateAcw = true)]
public abstract class LayoutInflater : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/LayoutInflater", typeof(LayoutInflater));

	private static Delegate? cb_inflate_Inflate_ILandroid_view_ViewGroup_Z_Landroid_view_View_;

	private static Delegate? cb_inflate_Inflate_ILandroid_view_ViewGroup__Landroid_view_View_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public static LayoutInflater? FromContext(Context context)
	{
		return context.GetSystemService("layout_inflater") as LayoutInflater;
	}

	protected LayoutInflater(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("from", "(Landroid/content/Context;)Landroid/view/LayoutInflater;", "")]
	public unsafe static LayoutInflater? From(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LayoutInflater>(_members.StaticMethods.InvokeObjectMethod("from.(Landroid/content/Context;)Landroid/view/LayoutInflater;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetInflate_ILandroid_view_ViewGroup_ZHandler()
	{
		return new _JniMarshal_PPILB_L(n_Inflate_ILandroid_view_ViewGroup_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Inflate_ILandroid_view_ViewGroup_Z(nint jnienv, nint native__this, int resource, nint native_root, sbyte native_attachToRoot)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LayoutInflater? layoutInflater = Java.Lang.Object.GetObject<LayoutInflater>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup root = Java.Lang.Object.GetObject<ViewGroup>(native_root, JniHandleOwnership.DoNotTransfer);
			bool attachToRoot = native_attachToRoot != 0;
			return JNIEnv.ToLocalJniHandle(layoutInflater.Inflate(resource, root, attachToRoot));
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

	[Register("inflate", "(ILandroid/view/ViewGroup;Z)Landroid/view/View;", "GetInflate_ILandroid_view_ViewGroup_ZHandler")]
	public unsafe virtual View? Inflate(int resource, ViewGroup? root, bool attachToRoot)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(resource);
			ptr[1] = new JniArgumentValue(root?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(attachToRoot ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("inflate.(ILandroid/view/ViewGroup;Z)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(root);
		}
	}

	private static Delegate GetInflate_ILandroid_view_ViewGroup_Handler()
	{
		return new _JniMarshal_PPIL_L(n_Inflate_ILandroid_view_ViewGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Inflate_ILandroid_view_ViewGroup_(nint jnienv, nint native__this, int resource, nint native_root)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LayoutInflater? layoutInflater = Java.Lang.Object.GetObject<LayoutInflater>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup root = Java.Lang.Object.GetObject<ViewGroup>(native_root, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(layoutInflater.Inflate(resource, root));
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

	[Register("inflate", "(ILandroid/view/ViewGroup;)Landroid/view/View;", "GetInflate_ILandroid_view_ViewGroup_Handler")]
	public unsafe virtual View? Inflate(int resource, ViewGroup? root)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(resource);
			ptr[1] = new JniArgumentValue(root?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("inflate.(ILandroid/view/ViewGroup;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(root);
		}
	}
}
