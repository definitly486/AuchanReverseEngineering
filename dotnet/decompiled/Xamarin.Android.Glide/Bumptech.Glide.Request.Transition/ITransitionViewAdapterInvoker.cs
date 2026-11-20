using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Request.Transition;

[Register("com/bumptech/glide/request/transition/Transition$ViewAdapter", DoNotGenerateAcw = true)]
internal class ITransitionViewAdapterInvoker : Java.Lang.Object, ITransitionViewAdapter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_request_transition_Transition_ViewAdapter = new XAPeerMembers("com/bumptech/glide/request/transition/Transition$ViewAdapter", typeof(ITransitionViewAdapterInvoker));

	private static Delegate? cb_getCurrentDrawable_GetCurrentDrawable_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_getView_GetView_Landroid_view_View_;

	private static Delegate? cb_setDrawable_SetDrawable_Landroid_graphics_drawable_Drawable__V;

	private static nint java_class_ref => _members_com_bumptech_glide_request_transition_Transition_ViewAdapter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_request_transition_Transition_ViewAdapter;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_request_transition_Transition_ViewAdapter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_request_transition_Transition_ViewAdapter.ManagedPeerType;

	public unsafe Drawable? CurrentDrawable => Java.Lang.Object.GetObject<Drawable>(_members_com_bumptech_glide_request_transition_Transition_ViewAdapter.InstanceMethods.InvokeAbstractObjectMethod("getCurrentDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe View? View => Java.Lang.Object.GetObject<View>(_members_com_bumptech_glide_request_transition_Transition_ViewAdapter.InstanceMethods.InvokeAbstractObjectMethod("getView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public ITransitionViewAdapterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetCurrentDrawableHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCurrentDrawable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCurrentDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ITransitionViewAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentDrawable);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ITransitionViewAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).View);
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

	private static Delegate GetSetDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ITransitionViewAdapter? transitionViewAdapter = Java.Lang.Object.GetObject<ITransitionViewAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable drawable = Java.Lang.Object.GetObject<Drawable>(native_p0, JniHandleOwnership.DoNotTransfer);
			transitionViewAdapter.SetDrawable(drawable);
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

	public unsafe void SetDrawable(Drawable? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_bumptech_glide_request_transition_Transition_ViewAdapter.InstanceMethods.InvokeAbstractVoidMethod("setDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
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
