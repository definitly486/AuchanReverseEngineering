using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Request.Transition;

[Register("com/bumptech/glide/request/transition/ViewPropertyTransition", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "R" })]
public class ViewPropertyTransition : Java.Lang.Object, ITransition, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/bumptech/glide/request/transition/ViewPropertyTransition$Animator", "", "Bumptech.Glide.Request.Transition.ViewPropertyTransition/IAnimatorInvoker")]
	public interface IAnimator : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("animate", "(Landroid/view/View;)V", "GetAnimate_Landroid_view_View_Handler:Bumptech.Glide.Request.Transition.ViewPropertyTransition/IAnimatorInvoker, Xamarin.Android.Glide")]
		void Animate(View? p0);
	}

	[Register("com/bumptech/glide/request/transition/ViewPropertyTransition$Animator", DoNotGenerateAcw = true)]
	internal class IAnimatorInvoker : Java.Lang.Object, IAnimator, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_bumptech_glide_request_transition_ViewPropertyTransition_Animator = new XAPeerMembers("com/bumptech/glide/request/transition/ViewPropertyTransition$Animator", typeof(IAnimatorInvoker));

		private static Delegate? cb_animate_Animate_Landroid_view_View__V;

		private static nint java_class_ref => _members_com_bumptech_glide_request_transition_ViewPropertyTransition_Animator.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_request_transition_ViewPropertyTransition_Animator;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_bumptech_glide_request_transition_ViewPropertyTransition_Animator.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_bumptech_glide_request_transition_ViewPropertyTransition_Animator.ManagedPeerType;

		public IAnimatorInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetAnimate_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_Animate_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Animate_Landroid_view_View_(nint jnienv, nint native__this, nint native_p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IAnimator? animator = Java.Lang.Object.GetObject<IAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View p = Java.Lang.Object.GetObject<View>(native_p0, JniHandleOwnership.DoNotTransfer);
				animator.Animate(p);
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

		public unsafe void Animate(View? p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members_com_bumptech_glide_request_transition_ViewPropertyTransition_Animator.InstanceMethods.InvokeAbstractVoidMethod("animate.(Landroid/view/View;)V", this, ptr);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/request/transition/ViewPropertyTransition", typeof(ViewPropertyTransition));

	private static Delegate? cb_transition_Transition_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_ViewAdapter__Z;

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

	protected ViewPropertyTransition(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Lcom/bumptech/glide/request/transition/ViewPropertyTransition$Animator;)V", "")]
	public unsafe ViewPropertyTransition(IAnimator? animator)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((animator == null) ? IntPtr.Zero : ((Java.Lang.Object)animator).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/bumptech/glide/request/transition/ViewPropertyTransition$Animator;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/bumptech/glide/request/transition/ViewPropertyTransition$Animator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(animator);
		}
	}

	private static Delegate GetTransition_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_ViewAdapter_Handler()
	{
		return new global::_JniMarshal_PPLL_B(n_Transition_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_ViewAdapter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Transition_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_ViewAdapter_(nint jnienv, nint native__this, nint native_current, nint native_adapter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ViewPropertyTransition? viewPropertyTransition = Java.Lang.Object.GetObject<ViewPropertyTransition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object current = Java.Lang.Object.GetObject<Java.Lang.Object>(native_current, JniHandleOwnership.DoNotTransfer);
			ITransitionViewAdapter adapter = Java.Lang.Object.GetObject<ITransitionViewAdapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
			return viewPropertyTransition.Transition(current, adapter) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("transition", "(Ljava/lang/Object;Lcom/bumptech/glide/request/transition/Transition$ViewAdapter;)Z", "GetTransition_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_ViewAdapter_Handler")]
	public unsafe virtual bool Transition(Java.Lang.Object? current, ITransitionViewAdapter? adapter)
	{
		nint num = JNIEnv.ToLocalJniHandle(current);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((adapter == null) ? IntPtr.Zero : ((Java.Lang.Object)adapter).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("transition.(Ljava/lang/Object;Lcom/bumptech/glide/request/transition/Transition$ViewAdapter;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(current);
			GC.KeepAlive(adapter);
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
