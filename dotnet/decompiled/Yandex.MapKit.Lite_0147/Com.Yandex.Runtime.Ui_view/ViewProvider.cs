using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime.Ui_view;

[Register("com/yandex/runtime/ui_view/ViewProvider", DoNotGenerateAcw = true)]
public class ViewProvider : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/runtime/ui_view/ViewProvider", typeof(ViewProvider));

	private static Delegate? cb_getId_GetId_Ljava_lang_String_;

	private static Delegate? cb_isCacheable_IsCacheable_Z;

	private static Delegate? cb_snapshot_Snapshot_V;

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

	public unsafe virtual string? Id
	{
		[Register("getId", "()Ljava/lang/String;", "GetGetIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsCacheable
	{
		[Register("isCacheable", "()Z", "GetIsCacheableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCacheable.()Z", this, null);
		}
	}

	protected ViewProvider(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/view/View;)V", "")]
	public unsafe ViewProvider(Android.Views.View? view)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/View;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register(".ctor", "(Landroid/view/View;Z)V", "")]
	public unsafe ViewProvider(Android.Views.View? view, bool cacheable)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(cacheable);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/View;Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/view/View;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetGetIdHandler()
	{
		if ((object)cb_getId_GetId_Ljava_lang_String_ == null)
		{
			cb_getId_GetId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetId));
		}
		return cb_getId_GetId_Ljava_lang_String_;
	}

	private static nint n_GetId(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ViewProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id);
	}

	private static Delegate GetIsCacheableHandler()
	{
		if ((object)cb_isCacheable_IsCacheable_Z == null)
		{
			cb_isCacheable_IsCacheable_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsCacheable));
		}
		return cb_isCacheable_IsCacheable_Z;
	}

	private static bool n_IsCacheable(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ViewProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCacheable;
	}

	private static Delegate GetSnapshotHandler()
	{
		if ((object)cb_snapshot_Snapshot_V == null)
		{
			cb_snapshot_Snapshot_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Snapshot));
		}
		return cb_snapshot_Snapshot_V;
	}

	private static void n_Snapshot(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ViewProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Snapshot();
	}

	[Register("snapshot", "()V", "GetSnapshotHandler")]
	public unsafe virtual void Snapshot()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("snapshot.()V", this, null);
	}
}
