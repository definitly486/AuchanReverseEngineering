using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Request.Target;

[Obsolete("This class is obsoleted in this android platform")]
[Register("com/bumptech/glide/request/target/ViewTarget", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "T extends android.view.View", "Z" })]
public abstract class ViewTarget : BaseTarget
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/request/target/ViewTarget", typeof(ViewTarget));

	private static Delegate? cb_getView_GetView_Landroid_view_View_;

	private static Delegate? cb_getSize_GetSize_Lcom_bumptech_glide_request_target_SizeReadyCallback__V;

	private static Delegate? cb_removeCallback_RemoveCallback_Lcom_bumptech_glide_request_target_SizeReadyCallback__V;

	[Register("view")]
	protected View? _view
	{
		get
		{
			return Java.Lang.Object.GetObject<View>(_members.InstanceFields.GetObjectValue("view.Landroid/view/View;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("view.Landroid/view/View;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual View View
	{
		[Register("getView", "()Landroid/view/View;", "GetGetViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ViewTarget(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/view/View;)V", "")]
	public unsafe ViewTarget(Java.Lang.Object view)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.ToLocalJniHandle(view);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/View;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
		}
	}

	[Register(".ctor", "(Landroid/view/View;Z)V", "")]
	[Obsolete("deprecated")]
	public unsafe ViewTarget(Java.Lang.Object view, bool waitForLayout)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.ToLocalJniHandle(view);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(waitForLayout ? ((sbyte)1) : ((sbyte)0));
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/View;Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/view/View;Z)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetGetViewHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ViewTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).View);
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

	[Register("clearOnDetach", "()Lcom/bumptech/glide/request/target/ViewTarget;", "")]
	public unsafe ViewTarget ClearOnDetach()
	{
		return Java.Lang.Object.GetObject<ViewTarget>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("clearOnDetach.()Lcom/bumptech/glide/request/target/ViewTarget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetSize_Lcom_bumptech_glide_request_target_SizeReadyCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_GetSize_Lcom_bumptech_glide_request_target_SizeReadyCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetSize_Lcom_bumptech_glide_request_target_SizeReadyCallback_(nint jnienv, nint native__this, nint native_cb)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewTarget? viewTarget = Java.Lang.Object.GetObject<ViewTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISizeReadyCallback p = Java.Lang.Object.GetObject<ISizeReadyCallback>(native_cb, JniHandleOwnership.DoNotTransfer);
			viewTarget.GetSize(p);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getSize", "(Lcom/bumptech/glide/request/target/SizeReadyCallback;)V", "GetGetSize_Lcom_bumptech_glide_request_target_SizeReadyCallback_Handler")]
	public unsafe override void GetSize(ISizeReadyCallback cb)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((cb == null) ? IntPtr.Zero : ((Java.Lang.Object)cb).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getSize.(Lcom/bumptech/glide/request/target/SizeReadyCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cb);
		}
	}

	private static Delegate GetRemoveCallback_Lcom_bumptech_glide_request_target_SizeReadyCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveCallback_Lcom_bumptech_glide_request_target_SizeReadyCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveCallback_Lcom_bumptech_glide_request_target_SizeReadyCallback_(nint jnienv, nint native__this, nint native_cb)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewTarget? viewTarget = Java.Lang.Object.GetObject<ViewTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISizeReadyCallback p = Java.Lang.Object.GetObject<ISizeReadyCallback>(native_cb, JniHandleOwnership.DoNotTransfer);
			viewTarget.RemoveCallback(p);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("removeCallback", "(Lcom/bumptech/glide/request/target/SizeReadyCallback;)V", "GetRemoveCallback_Lcom_bumptech_glide_request_target_SizeReadyCallback_Handler")]
	public unsafe override void RemoveCallback(ISizeReadyCallback cb)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((cb == null) ? IntPtr.Zero : ((Java.Lang.Object)cb).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeCallback.(Lcom/bumptech/glide/request/target/SizeReadyCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cb);
		}
	}

	[Obsolete("deprecated")]
	[Register("setTagId", "(I)V", "")]
	public unsafe static void SetTagId(int tagId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(tagId);
		_members.StaticMethods.InvokeVoidMethod("setTagId.(I)V", ptr);
	}

	[Register("waitForLayout", "()Lcom/bumptech/glide/request/target/ViewTarget;", "")]
	public unsafe ViewTarget WaitForLayout()
	{
		return Java.Lang.Object.GetObject<ViewTarget>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("waitForLayout.()Lcom/bumptech/glide/request/target/ViewTarget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
