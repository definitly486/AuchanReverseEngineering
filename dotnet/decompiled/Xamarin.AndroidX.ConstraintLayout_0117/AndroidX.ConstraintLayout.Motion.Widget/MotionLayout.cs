using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.ConstraintLayout.Widget;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Motion.Widget;

[Register("androidx/constraintlayout/motion/widget/MotionLayout", DoNotGenerateAcw = true)]
public class MotionLayout : AndroidX.ConstraintLayout.Widget.ConstraintLayout, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/constraintlayout/motion/widget/MotionLayout$MotionTracker", "", "AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker")]
	protected internal interface IMotionTracker : IJavaObject, IDisposable, IJavaPeerable
	{
		float XVelocity
		{
			[Register("getXVelocity", "()F", "GetGetXVelocityHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
			get;
		}

		float YVelocity
		{
			[Register("getYVelocity", "()F", "GetGetYVelocityHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
			get;
		}

		[Register("addMovement", "(Landroid/view/MotionEvent;)V", "GetAddMovement_Landroid_view_MotionEvent_Handler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
		void AddMovement(MotionEvent? p0);

		[Register("clear", "()V", "GetClearHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
		void Clear();

		[Register("computeCurrentVelocity", "(I)V", "GetComputeCurrentVelocity_IHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
		void ComputeCurrentVelocity(int p0);

		[Register("computeCurrentVelocity", "(IF)V", "GetComputeCurrentVelocity_IFHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
		void ComputeCurrentVelocity(int p0, float p1);

		[Register("getXVelocity", "(I)F", "GetGetXVelocity_IHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
		float GetXVelocity(int p0);

		[Register("getYVelocity", "(I)F", "GetGetYVelocity_IHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
		float GetYVelocity(int p0);

		[Register("recycle", "()V", "GetRecycleHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
		void Recycle();
	}

	[Register("androidx/constraintlayout/motion/widget/MotionLayout$MotionTracker", DoNotGenerateAcw = true)]
	internal class IMotionTrackerInvoker : Java.Lang.Object, IMotionTracker, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_constraintlayout_motion_widget_MotionLayout_MotionTracker = new XAPeerMembers("androidx/constraintlayout/motion/widget/MotionLayout$MotionTracker", typeof(IMotionTrackerInvoker));

		private static Delegate? cb_getXVelocity_GetXVelocity_F;

		private static Delegate? cb_getYVelocity_GetYVelocity_F;

		private static Delegate? cb_addMovement_AddMovement_Landroid_view_MotionEvent__V;

		private static Delegate? cb_clear_Clear_V;

		private static Delegate? cb_computeCurrentVelocity_ComputeCurrentVelocity_I_V;

		private static Delegate? cb_computeCurrentVelocity_ComputeCurrentVelocity_IF_V;

		private static Delegate? cb_getXVelocity_GetXVelocity_I_F;

		private static Delegate? cb_getYVelocity_GetYVelocity_I_F;

		private static Delegate? cb_recycle_Recycle_V;

		private static nint java_class_ref => _members_androidx_constraintlayout_motion_widget_MotionLayout_MotionTracker.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_constraintlayout_motion_widget_MotionLayout_MotionTracker;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_constraintlayout_motion_widget_MotionLayout_MotionTracker.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_constraintlayout_motion_widget_MotionLayout_MotionTracker.ManagedPeerType;

		public unsafe float XVelocity => _members_androidx_constraintlayout_motion_widget_MotionLayout_MotionTracker.InstanceMethods.InvokeAbstractSingleMethod("getXVelocity.()F", this, null);

		public unsafe float YVelocity => _members_androidx_constraintlayout_motion_widget_MotionLayout_MotionTracker.InstanceMethods.InvokeAbstractSingleMethod("getYVelocity.()F", this, null);

		public IMotionTrackerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetGetXVelocityHandler()
		{
			return new global::_JniMarshal_PP_F(n_GetXVelocity);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static float n_GetXVelocity(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0f;
			}
			try
			{
				return Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).XVelocity;
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0f;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		private static Delegate GetGetYVelocityHandler()
		{
			return new global::_JniMarshal_PP_F(n_GetYVelocity);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static float n_GetYVelocity(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0f;
			}
			try
			{
				return Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).YVelocity;
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0f;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		private static Delegate GetAddMovement_Landroid_view_MotionEvent_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_AddMovement_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_AddMovement_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IMotionTracker? motionTracker = Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent p = Java.Lang.Object.GetObject<MotionEvent>(native_p0, JniHandleOwnership.DoNotTransfer);
				motionTracker.AddMovement(p);
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

		public unsafe void AddMovement(MotionEvent? p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members_androidx_constraintlayout_motion_widget_MotionLayout_MotionTracker.InstanceMethods.InvokeAbstractVoidMethod("addMovement.(Landroid/view/MotionEvent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetClearHandler()
		{
			return new global::_JniMarshal_PP_V(n_Clear);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Clear(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

		public unsafe void Clear()
		{
			_members_androidx_constraintlayout_motion_widget_MotionLayout_MotionTracker.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
		}

		private static Delegate GetComputeCurrentVelocity_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_ComputeCurrentVelocity_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_ComputeCurrentVelocity_I(nint jnienv, nint native__this, int p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeCurrentVelocity(p0);
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

		public unsafe void ComputeCurrentVelocity(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			_members_androidx_constraintlayout_motion_widget_MotionLayout_MotionTracker.InstanceMethods.InvokeAbstractVoidMethod("computeCurrentVelocity.(I)V", this, ptr);
		}

		private static Delegate GetComputeCurrentVelocity_IFHandler()
		{
			return new global::_JniMarshal_PPIF_V(n_ComputeCurrentVelocity_IF);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_ComputeCurrentVelocity_IF(nint jnienv, nint native__this, int p0, float p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeCurrentVelocity(p0, p1);
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

		public unsafe void ComputeCurrentVelocity(int p0, float p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			_members_androidx_constraintlayout_motion_widget_MotionLayout_MotionTracker.InstanceMethods.InvokeAbstractVoidMethod("computeCurrentVelocity.(IF)V", this, ptr);
		}

		private static Delegate GetGetXVelocity_IHandler()
		{
			return new global::_JniMarshal_PPI_F(n_GetXVelocity_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static float n_GetXVelocity_I(nint jnienv, nint native__this, int p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0f;
			}
			try
			{
				return Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetXVelocity(p0);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0f;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe float GetXVelocity(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return _members_androidx_constraintlayout_motion_widget_MotionLayout_MotionTracker.InstanceMethods.InvokeAbstractSingleMethod("getXVelocity.(I)F", this, ptr);
		}

		private static Delegate GetGetYVelocity_IHandler()
		{
			return new global::_JniMarshal_PPI_F(n_GetYVelocity_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static float n_GetYVelocity_I(nint jnienv, nint native__this, int p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0f;
			}
			try
			{
				return Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetYVelocity(p0);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0f;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe float GetYVelocity(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return _members_androidx_constraintlayout_motion_widget_MotionLayout_MotionTracker.InstanceMethods.InvokeAbstractSingleMethod("getYVelocity.(I)F", this, ptr);
		}

		private static Delegate GetRecycleHandler()
		{
			return new global::_JniMarshal_PP_V(n_Recycle);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Recycle(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Recycle();
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

		public unsafe void Recycle()
		{
			_members_androidx_constraintlayout_motion_widget_MotionLayout_MotionTracker.InstanceMethods.InvokeAbstractVoidMethod("recycle.()V", this, null);
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

	[Register("androidx/constraintlayout/motion/widget/MotionLayout$TransitionListener", "", "AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/ITransitionListenerInvoker")]
	public interface ITransitionListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onTransitionChange", "(Landroidx/constraintlayout/motion/widget/MotionLayout;IIF)V", "GetOnTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIFHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/ITransitionListenerInvoker, Xamarin.AndroidX.ConstraintLayout")]
		void OnTransitionChange(MotionLayout? motionLayout, int startId, int endId, float progress);

		[Register("onTransitionCompleted", "(Landroidx/constraintlayout/motion/widget/MotionLayout;I)V", "GetOnTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_IHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/ITransitionListenerInvoker, Xamarin.AndroidX.ConstraintLayout")]
		void OnTransitionCompleted(MotionLayout? motionLayout, int currentId);

		[Register("onTransitionStarted", "(Landroidx/constraintlayout/motion/widget/MotionLayout;II)V", "GetOnTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_IIHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/ITransitionListenerInvoker, Xamarin.AndroidX.ConstraintLayout")]
		void OnTransitionStarted(MotionLayout? motionLayout, int startId, int endId);

		[Register("onTransitionTrigger", "(Landroidx/constraintlayout/motion/widget/MotionLayout;IZF)V", "GetOnTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZFHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/ITransitionListenerInvoker, Xamarin.AndroidX.ConstraintLayout")]
		void OnTransitionTrigger(MotionLayout? motionLayout, int triggerId, bool positive, float progress);
	}

	[Register("androidx/constraintlayout/motion/widget/MotionLayout$TransitionListener", DoNotGenerateAcw = true)]
	internal class ITransitionListenerInvoker : Java.Lang.Object, ITransitionListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_constraintlayout_motion_widget_MotionLayout_TransitionListener = new XAPeerMembers("androidx/constraintlayout/motion/widget/MotionLayout$TransitionListener", typeof(ITransitionListenerInvoker));

		private static Delegate? cb_onTransitionChange_OnTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIF_V;

		private static Delegate? cb_onTransitionCompleted_OnTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_I_V;

		private static Delegate? cb_onTransitionStarted_OnTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_II_V;

		private static Delegate? cb_onTransitionTrigger_OnTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZF_V;

		private static nint java_class_ref => _members_androidx_constraintlayout_motion_widget_MotionLayout_TransitionListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_constraintlayout_motion_widget_MotionLayout_TransitionListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_constraintlayout_motion_widget_MotionLayout_TransitionListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_constraintlayout_motion_widget_MotionLayout_TransitionListener.ManagedPeerType;

		public ITransitionListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIF(nint jnienv, nint native__this, nint native_motionLayout, int startId, int endId, float progress)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ITransitionListener? transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(native_motionLayout, JniHandleOwnership.DoNotTransfer);
				transitionListener.OnTransitionChange(motionLayout, startId, endId, progress);
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

		public unsafe void OnTransitionChange(MotionLayout? motionLayout, int startId, int endId, float progress)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(motionLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(startId);
				ptr[2] = new JniArgumentValue(endId);
				ptr[3] = new JniArgumentValue(progress);
				_members_androidx_constraintlayout_motion_widget_MotionLayout_TransitionListener.InstanceMethods.InvokeAbstractVoidMethod("onTransitionChange.(Landroidx/constraintlayout/motion/widget/MotionLayout;IIF)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(motionLayout);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_I(nint jnienv, nint native__this, nint native_motionLayout, int currentId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ITransitionListener? transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(native_motionLayout, JniHandleOwnership.DoNotTransfer);
				transitionListener.OnTransitionCompleted(motionLayout, currentId);
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

		public unsafe void OnTransitionCompleted(MotionLayout? motionLayout, int currentId)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(motionLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(currentId);
				_members_androidx_constraintlayout_motion_widget_MotionLayout_TransitionListener.InstanceMethods.InvokeAbstractVoidMethod("onTransitionCompleted.(Landroidx/constraintlayout/motion/widget/MotionLayout;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(motionLayout);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_II(nint jnienv, nint native__this, nint native_motionLayout, int startId, int endId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ITransitionListener? transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(native_motionLayout, JniHandleOwnership.DoNotTransfer);
				transitionListener.OnTransitionStarted(motionLayout, startId, endId);
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

		public unsafe void OnTransitionStarted(MotionLayout? motionLayout, int startId, int endId)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(motionLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(startId);
				ptr[2] = new JniArgumentValue(endId);
				_members_androidx_constraintlayout_motion_widget_MotionLayout_TransitionListener.InstanceMethods.InvokeAbstractVoidMethod("onTransitionStarted.(Landroidx/constraintlayout/motion/widget/MotionLayout;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(motionLayout);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZF(nint jnienv, nint native__this, nint native_motionLayout, int triggerId, sbyte native_positive, float progress)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ITransitionListener? transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(native_motionLayout, JniHandleOwnership.DoNotTransfer);
				bool positive = native_positive != 0;
				transitionListener.OnTransitionTrigger(motionLayout, triggerId, positive, progress);
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

		public unsafe void OnTransitionTrigger(MotionLayout? motionLayout, int triggerId, bool positive, float progress)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(motionLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(triggerId);
				ptr[2] = new JniArgumentValue(positive ? ((sbyte)1) : ((sbyte)0));
				ptr[3] = new JniArgumentValue(progress);
				_members_androidx_constraintlayout_motion_widget_MotionLayout_TransitionListener.InstanceMethods.InvokeAbstractVoidMethod("onTransitionTrigger.(Landroidx/constraintlayout/motion/widget/MotionLayout;IZF)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(motionLayout);
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

		[UnmanagedCallersOnly]
		private static void n_OnTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIF_mm_wrapper(nint jnienv, nint native__this, nint native_motionLayout, int startId, int endId, float progress)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIF(jnienv, native__this, native_motionLayout, startId, endId, progress);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_I_mm_wrapper(nint jnienv, nint native__this, nint native_motionLayout, int currentId)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_I(jnienv, native__this, native_motionLayout, currentId);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_II_mm_wrapper(nint jnienv, nint native__this, nint native_motionLayout, int startId, int endId)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_II(jnienv, native__this, native_motionLayout, startId, endId);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZF_mm_wrapper(nint jnienv, nint native__this, nint native_motionLayout, int triggerId, sbyte native_positive, float progress)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZF(jnienv, native__this, native_motionLayout, triggerId, native_positive, progress);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class TransitionChangeEventArgs : EventArgs
	{
		private MotionLayout? motionLayout;

		private int startId;

		private int endId;

		private float progress;

		public TransitionChangeEventArgs(MotionLayout? motionLayout, int startId, int endId, float progress)
		{
			this.motionLayout = motionLayout;
			this.startId = startId;
			this.endId = endId;
			this.progress = progress;
		}
	}

	public class TransitionCompletedEventArgs : EventArgs
	{
		private MotionLayout? motionLayout;

		private int currentId;

		public TransitionCompletedEventArgs(MotionLayout? motionLayout, int currentId)
		{
			this.motionLayout = motionLayout;
			this.currentId = currentId;
		}
	}

	public class TransitionStartedEventArgs : EventArgs
	{
		private MotionLayout? motionLayout;

		private int startId;

		private int endId;

		public TransitionStartedEventArgs(MotionLayout? motionLayout, int startId, int endId)
		{
			this.motionLayout = motionLayout;
			this.startId = startId;
			this.endId = endId;
		}
	}

	public class TransitionTriggerEventArgs : EventArgs
	{
		private MotionLayout? motionLayout;

		private int triggerId;

		private bool positive;

		private float progress;

		public TransitionTriggerEventArgs(MotionLayout? motionLayout, int triggerId, bool positive, float progress)
		{
			this.motionLayout = motionLayout;
			this.triggerId = triggerId;
			this.positive = positive;
			this.progress = progress;
		}
	}

	[Register("mono/androidx/constraintlayout/motion/widget/MotionLayout_TransitionListenerImplementor")]
	internal sealed class ITransitionListenerImplementor : Java.Lang.Object, ITransitionListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<TransitionChangeEventArgs>? OnTransitionChangeHandler;

		public EventHandler<TransitionCompletedEventArgs>? OnTransitionCompletedHandler;

		public EventHandler<TransitionStartedEventArgs>? OnTransitionStartedHandler;

		public EventHandler<TransitionTriggerEventArgs>? OnTransitionTriggerHandler;

		public unsafe ITransitionListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnTransitionChange(MotionLayout? motionLayout, int startId, int endId, float progress)
		{
			OnTransitionChangeHandler?.Invoke(sender, new TransitionChangeEventArgs(motionLayout, startId, endId, progress));
		}

		public void OnTransitionCompleted(MotionLayout? motionLayout, int currentId)
		{
			OnTransitionCompletedHandler?.Invoke(sender, new TransitionCompletedEventArgs(motionLayout, currentId));
		}

		public void OnTransitionStarted(MotionLayout? motionLayout, int startId, int endId)
		{
			OnTransitionStartedHandler?.Invoke(sender, new TransitionStartedEventArgs(motionLayout, startId, endId));
		}

		public void OnTransitionTrigger(MotionLayout? motionLayout, int triggerId, bool positive, float progress)
		{
			OnTransitionTriggerHandler?.Invoke(sender, new TransitionTriggerEventArgs(motionLayout, triggerId, positive, progress));
		}

		internal static bool __IsEmpty(ITransitionListenerImplementor value)
		{
			if (value.OnTransitionChangeHandler == null && value.OnTransitionCompletedHandler == null && value.OnTransitionStartedHandler == null)
			{
				return value.OnTransitionTriggerHandler == null;
			}
			return false;
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/MotionLayout", typeof(MotionLayout));

	private static Delegate? cb_getCurrentState_GetCurrentState_I;

	private static Delegate? cb_getDefinedTransitions_GetDefinedTransitions_Ljava_util_ArrayList_;

	private static Delegate? cb_isDelayedApplicationOfInitialState_IsDelayedApplicationOfInitialState_Z;

	private static Delegate? cb_setDelayedApplicationOfInitialState_SetDelayedApplicationOfInitialState_Z_V;

	private static Delegate? cb_getDesignTool_GetDesignTool_Landroidx_constraintlayout_motion_widget_DesignTool_;

	private static Delegate? cb_getEndState_GetEndState_I;

	private static Delegate? cb_isInteractionEnabled_IsInteractionEnabled_Z;

	private static Delegate? cb_setInteractionEnabled_SetInteractionEnabled_Z_V;

	private static Delegate? cb_isInRotation_IsInRotation_Z;

	private static Delegate? cb_getNanoTime_GetNanoTime_J;

	private static Delegate? cb_getProgress_GetProgress_F;

	private static Delegate? cb_setProgress_SetProgress_F_V;

	private static Delegate? cb_getScene_GetScene_Landroidx_constraintlayout_motion_widget_MotionScene_;

	private static Delegate? cb_setScene_SetScene_Landroidx_constraintlayout_motion_widget_MotionScene__V;

	private static Delegate? cb_getStartState_GetStartState_I;

	private static Delegate? cb_getTargetPosition_GetTargetPosition_F;

	private static Delegate? cb_getTransitionState_GetTransitionState_Landroid_os_Bundle_;

	private static Delegate? cb_setTransitionState_SetTransitionState_Landroid_os_Bundle__V;

	private static Delegate? cb_getTransitionTimeMs_GetTransitionTimeMs_J;

	private static Delegate? cb_getVelocity_GetVelocity_F;

	private static Delegate? cb_applyViewTransition_ApplyViewTransition_ILandroidx_constraintlayout_motion_widget_MotionController__Z;

	private static Delegate? cb_cloneConstraintSet_CloneConstraintSet_I_Landroidx_constraintlayout_widget_ConstraintSet_;

	private static Delegate? cb_enableTransition_EnableTransition_IZ_V;

	private static Delegate? cb_enableViewTransition_EnableViewTransition_IZ_V;

	private static Delegate? cb_fireTransitionCompleted_FireTransitionCompleted_V;

	private static Delegate? cb_fireTrigger_FireTrigger_IZF_V;

	private static Delegate? cb_getConstraintSet_GetConstraintSet_I_Landroidx_constraintlayout_widget_ConstraintSet_;

	private static Delegate? cb_getConstraintSetIds_GetConstraintSetIds_arrayI;

	private static Delegate? cb_getMatchingConstraintSetIds_GetMatchingConstraintSetIds_arrayLjava_lang_String__arrayI;

	private static Delegate? cb_getTransition_GetTransition_I_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_;

	private static Delegate? cb_getViewVelocity_GetViewVelocity_Landroid_view_View_FFarrayFI_V;

	private static Delegate? cb_isViewTransitionEnabled_IsViewTransitionEnabled_I_Z;

	private static Delegate? cb_jumpToState_JumpToState_I_V;

	private static Delegate? cb_obtainVelocityTracker_ObtainVelocityTracker_Landroidx_constraintlayout_motion_widget_MotionLayout_MotionTracker_;

	private static Delegate? cb_onNestedPreScroll_OnNestedPreScroll_Landroid_view_View_IIarrayII_V;

	private static Delegate? cb_onNestedScroll_OnNestedScroll_Landroid_view_View_IIIII_V;

	private static Delegate? cb_onNestedScroll_OnNestedScroll_Landroid_view_View_IIIIIarrayI_V;

	private static Delegate? cb_onNestedScrollAccepted_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II_V;

	private static Delegate? cb_onStartNestedScroll_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_II_Z;

	private static Delegate? cb_onStopNestedScroll_OnStopNestedScroll_Landroid_view_View_I_V;

	private static Delegate? cb_rebuildMotion_RebuildMotion_V;

	private static Delegate? cb_rebuildScene_RebuildScene_V;

	private static Delegate? cb_removeTransitionListener_RemoveTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener__Z;

	private static Delegate? cb_rotateTo_RotateTo_II_V;

	private static Delegate? cb_scheduleTransitionTo_ScheduleTransitionTo_I_V;

	private static Delegate? cb_setDebugMode_SetDebugMode_I_V;

	private static Delegate? cb_setInterpolatedProgress_SetInterpolatedProgress_F_V;

	private static Delegate? cb_setOnHide_SetOnHide_F_V;

	private static Delegate? cb_setOnShow_SetOnShow_F_V;

	private static Delegate? cb_setProgress_SetProgress_FF_V;

	private static Delegate? cb_setTransition_SetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition__V;

	private static Delegate? cb_setTransition_SetTransition_I_V;

	private static Delegate? cb_setTransition_SetTransition_II_V;

	private static Delegate? cb_setTransitionDuration_SetTransitionDuration_I_V;

	private static Delegate? cb_setTransitionListener_SetTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener__V;

	private static Delegate? cb_touchAnimateTo_TouchAnimateTo_IFF_V;

	private static Delegate? cb_touchSpringTo_TouchSpringTo_FF_V;

	private static Delegate? cb_transitionToEnd_TransitionToEnd_V;

	private static Delegate? cb_transitionToEnd_TransitionToEnd_Ljava_lang_Runnable__V;

	private static Delegate? cb_transitionToStart_TransitionToStart_V;

	private static Delegate? cb_transitionToStart_TransitionToStart_Ljava_lang_Runnable__V;

	private static Delegate? cb_transitionToState_TransitionToState_I_V;

	private static Delegate? cb_transitionToState_TransitionToState_II_V;

	private static Delegate? cb_transitionToState_TransitionToState_III_V;

	private static Delegate? cb_transitionToState_TransitionToState_IIII_V;

	private static Delegate? cb_updateState_UpdateState_V;

	private static Delegate? cb_updateState_UpdateState_ILandroidx_constraintlayout_widget_ConstraintSet__V;

	private static Delegate? cb_updateStateAnimate_UpdateStateAnimate_ILandroidx_constraintlayout_widget_ConstraintSet_I_V;

	private static Delegate? cb_viewTransition_ViewTransition_IarrayLandroid_view_View__V;

	private WeakReference? weak_implementor_SetTransitionListener;

	[Register("mMeasureDuringTransition")]
	protected bool MMeasureDuringTransition
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("mMeasureDuringTransition.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mMeasureDuringTransition.Z", this, value ? ((sbyte)1) : ((sbyte)0));
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

	public unsafe virtual int CurrentState
	{
		[Register("getCurrentState", "()I", "GetGetCurrentStateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCurrentState.()I", this, null);
		}
	}

	public unsafe virtual IList<MotionScene.Transition>? DefinedTransitions
	{
		[Register("getDefinedTransitions", "()Ljava/util/ArrayList;", "GetGetDefinedTransitionsHandler")]
		get
		{
			return JavaList<MotionScene.Transition>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefinedTransitions.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool DelayedApplicationOfInitialState
	{
		[Register("isDelayedApplicationOfInitialState", "()Z", "GetIsDelayedApplicationOfInitialStateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDelayedApplicationOfInitialState.()Z", this, null);
		}
		[Register("setDelayedApplicationOfInitialState", "(Z)V", "GetSetDelayedApplicationOfInitialState_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDelayedApplicationOfInitialState.(Z)V", this, ptr);
		}
	}

	public unsafe virtual DesignTool? DesignTool
	{
		[Register("getDesignTool", "()Landroidx/constraintlayout/motion/widget/DesignTool;", "GetGetDesignToolHandler")]
		get
		{
			return Java.Lang.Object.GetObject<DesignTool>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDesignTool.()Landroidx/constraintlayout/motion/widget/DesignTool;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int EndState
	{
		[Register("getEndState", "()I", "GetGetEndStateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getEndState.()I", this, null);
		}
	}

	public unsafe virtual bool InteractionEnabled
	{
		[Register("isInteractionEnabled", "()Z", "GetIsInteractionEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInteractionEnabled.()Z", this, null);
		}
		[Register("setInteractionEnabled", "(Z)V", "GetSetInteractionEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInteractionEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool IsInRotation
	{
		[Register("isInRotation", "()Z", "GetIsInRotationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInRotation.()Z", this, null);
		}
	}

	protected unsafe virtual long NanoTime
	{
		[Register("getNanoTime", "()J", "GetGetNanoTimeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getNanoTime.()J", this, null);
		}
	}

	public unsafe virtual float Progress
	{
		[Register("getProgress", "()F", "GetGetProgressHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getProgress.()F", this, null);
		}
		[Register("setProgress", "(F)V", "GetSetProgress_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setProgress.(F)V", this, ptr);
		}
	}

	public unsafe virtual MotionScene? Scene
	{
		[Register("getScene", "()Landroidx/constraintlayout/motion/widget/MotionScene;", "GetGetSceneHandler")]
		get
		{
			return Java.Lang.Object.GetObject<MotionScene>(_members.InstanceMethods.InvokeVirtualObjectMethod("getScene.()Landroidx/constraintlayout/motion/widget/MotionScene;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setScene", "(Landroidx/constraintlayout/motion/widget/MotionScene;)V", "GetSetScene_Landroidx_constraintlayout_motion_widget_MotionScene_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setScene.(Landroidx/constraintlayout/motion/widget/MotionScene;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int StartState
	{
		[Register("getStartState", "()I", "GetGetStartStateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getStartState.()I", this, null);
		}
	}

	public unsafe virtual float TargetPosition
	{
		[Register("getTargetPosition", "()F", "GetGetTargetPositionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getTargetPosition.()F", this, null);
		}
	}

	public unsafe virtual Bundle? TransitionState
	{
		[Register("getTransitionState", "()Landroid/os/Bundle;", "GetGetTransitionStateHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTransitionState.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTransitionState", "(Landroid/os/Bundle;)V", "GetSetTransitionState_Landroid_os_Bundle_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTransitionState.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual long TransitionTimeMs
	{
		[Register("getTransitionTimeMs", "()J", "GetGetTransitionTimeMsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getTransitionTimeMs.()J", this, null);
		}
	}

	public unsafe virtual float Velocity
	{
		[Register("getVelocity", "()F", "GetGetVelocityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getVelocity.()F", this, null);
		}
	}

	public event EventHandler<TransitionChangeEventArgs> TransitionChange
	{
		add
		{
			EventHelper.AddEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, __CreateITransitionListenerImplementor, SetTransitionListener, delegate(ITransitionListenerImplementor __h)
			{
				__h.OnTransitionChangeHandler = (EventHandler<TransitionChangeEventArgs>)Delegate.Combine(__h.OnTransitionChangeHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, ITransitionListenerImplementor.__IsEmpty, delegate
			{
				SetTransitionListener(null);
			}, delegate(ITransitionListenerImplementor __h)
			{
				__h.OnTransitionChangeHandler = (EventHandler<TransitionChangeEventArgs>)Delegate.Remove(__h.OnTransitionChangeHandler, value);
			});
		}
	}

	public event EventHandler<TransitionCompletedEventArgs> TransitionCompleted
	{
		add
		{
			EventHelper.AddEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, __CreateITransitionListenerImplementor, SetTransitionListener, delegate(ITransitionListenerImplementor __h)
			{
				__h.OnTransitionCompletedHandler = (EventHandler<TransitionCompletedEventArgs>)Delegate.Combine(__h.OnTransitionCompletedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, ITransitionListenerImplementor.__IsEmpty, delegate
			{
				SetTransitionListener(null);
			}, delegate(ITransitionListenerImplementor __h)
			{
				__h.OnTransitionCompletedHandler = (EventHandler<TransitionCompletedEventArgs>)Delegate.Remove(__h.OnTransitionCompletedHandler, value);
			});
		}
	}

	public event EventHandler<TransitionStartedEventArgs> TransitionStarted
	{
		add
		{
			EventHelper.AddEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, __CreateITransitionListenerImplementor, SetTransitionListener, delegate(ITransitionListenerImplementor __h)
			{
				__h.OnTransitionStartedHandler = (EventHandler<TransitionStartedEventArgs>)Delegate.Combine(__h.OnTransitionStartedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, ITransitionListenerImplementor.__IsEmpty, delegate
			{
				SetTransitionListener(null);
			}, delegate(ITransitionListenerImplementor __h)
			{
				__h.OnTransitionStartedHandler = (EventHandler<TransitionStartedEventArgs>)Delegate.Remove(__h.OnTransitionStartedHandler, value);
			});
		}
	}

	public event EventHandler<TransitionTriggerEventArgs> TransitionTrigger
	{
		add
		{
			EventHelper.AddEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, __CreateITransitionListenerImplementor, SetTransitionListener, delegate(ITransitionListenerImplementor __h)
			{
				__h.OnTransitionTriggerHandler = (EventHandler<TransitionTriggerEventArgs>)Delegate.Combine(__h.OnTransitionTriggerHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, ITransitionListenerImplementor.__IsEmpty, delegate
			{
				SetTransitionListener(null);
			}, delegate(ITransitionListenerImplementor __h)
			{
				__h.OnTransitionTriggerHandler = (EventHandler<TransitionTriggerEventArgs>)Delegate.Remove(__h.OnTransitionTriggerHandler, value);
			});
		}
	}

	public virtual void OnNestedScrollAccepted(View child, View target, int axes, int type)
	{
		OnNestedScrollAccepted(child, target, (ScrollAxis)axes, type);
	}

	public virtual bool OnStartNestedScroll(View child, View target, int axes, int type)
	{
		return OnStartNestedScroll(child, target, (ScrollAxis)axes, type);
	}

	protected MotionLayout(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe MotionLayout(Context context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe MotionLayout(Context context, IAttributeSet? attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe MotionLayout(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	private static Delegate GetGetCurrentStateHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetCurrentState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCurrentState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentState;
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

	private static Delegate GetGetDefinedTransitionsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDefinedTransitions);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDefinedTransitions(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<MotionScene.Transition>.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefinedTransitions);
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

	private static Delegate GetIsDelayedApplicationOfInitialStateHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsDelayedApplicationOfInitialState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDelayedApplicationOfInitialState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DelayedApplicationOfInitialState ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetDelayedApplicationOfInitialState_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetDelayedApplicationOfInitialState_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDelayedApplicationOfInitialState_Z(nint jnienv, nint native__this, sbyte native_delayedApply)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool delayedApplicationOfInitialState = native_delayedApply != 0;
			motionLayout.DelayedApplicationOfInitialState = delayedApplicationOfInitialState;
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

	private static Delegate GetGetDesignToolHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDesignTool);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDesignTool(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DesignTool);
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

	private static Delegate GetGetEndStateHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetEndState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetEndState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndState;
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

	private static Delegate GetIsInteractionEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsInteractionEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsInteractionEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InteractionEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetInteractionEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetInteractionEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInteractionEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool interactionEnabled = native_enabled != 0;
			motionLayout.InteractionEnabled = interactionEnabled;
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

	private static Delegate GetIsInRotationHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsInRotation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsInRotation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsInRotation ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetNanoTimeHandler()
	{
		return new global::_JniMarshal_PP_J(n_GetNanoTime);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetNanoTime(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NanoTime;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetProgressHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetProgress);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetProgress(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Progress;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetProgress_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetProgress_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProgress_F(nint jnienv, nint native__this, float pos)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Progress = pos;
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

	private static Delegate GetGetSceneHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetScene);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetScene(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Scene);
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

	private static Delegate GetSetScene_Landroidx_constraintlayout_motion_widget_MotionScene_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetScene_Landroidx_constraintlayout_motion_widget_MotionScene_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetScene_Landroidx_constraintlayout_motion_widget_MotionScene_(nint jnienv, nint native__this, nint native_scene)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionScene scene = Java.Lang.Object.GetObject<MotionScene>(native_scene, JniHandleOwnership.DoNotTransfer);
			motionLayout.Scene = scene;
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

	private static Delegate GetGetStartStateHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetStartState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetStartState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartState;
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

	private static Delegate GetGetTargetPositionHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetTargetPosition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetTargetPosition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetPosition;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTransitionStateHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTransitionState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTransitionState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionState);
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

	private static Delegate GetSetTransitionState_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTransitionState_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTransitionState_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_bundle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle transitionState = Java.Lang.Object.GetObject<Bundle>(native_bundle, JniHandleOwnership.DoNotTransfer);
			motionLayout.TransitionState = transitionState;
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

	private static Delegate GetGetTransitionTimeMsHandler()
	{
		return new global::_JniMarshal_PP_J(n_GetTransitionTimeMs);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetTransitionTimeMs(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionTimeMs;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetVelocityHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetVelocity);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetVelocity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Velocity;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetApplyViewTransition_ILandroidx_constraintlayout_motion_widget_MotionController_Handler()
	{
		return new global::_JniMarshal_PPIL_B(n_ApplyViewTransition_ILandroidx_constraintlayout_motion_widget_MotionController_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ApplyViewTransition_ILandroidx_constraintlayout_motion_widget_MotionController_(nint jnienv, nint native__this, int viewTransitionId, nint native_motionController)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionController motionController = Java.Lang.Object.GetObject<MotionController>(native_motionController, JniHandleOwnership.DoNotTransfer);
			return motionLayout.ApplyViewTransition(viewTransitionId, motionController) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("applyViewTransition", "(ILandroidx/constraintlayout/motion/widget/MotionController;)Z", "GetApplyViewTransition_ILandroidx_constraintlayout_motion_widget_MotionController_Handler")]
	public unsafe virtual bool ApplyViewTransition(int viewTransitionId, MotionController? motionController)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewTransitionId);
			ptr[1] = new JniArgumentValue(motionController?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("applyViewTransition.(ILandroidx/constraintlayout/motion/widget/MotionController;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(motionController);
		}
	}

	private static Delegate GetCloneConstraintSet_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_CloneConstraintSet_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CloneConstraintSet_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CloneConstraintSet(id));
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

	[Register("cloneConstraintSet", "(I)Landroidx/constraintlayout/widget/ConstraintSet;", "GetCloneConstraintSet_IHandler")]
	public unsafe virtual ConstraintSet? CloneConstraintSet(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<ConstraintSet>(_members.InstanceMethods.InvokeVirtualObjectMethod("cloneConstraintSet.(I)Landroidx/constraintlayout/widget/ConstraintSet;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetEnableTransition_IZHandler()
	{
		return new global::_JniMarshal_PPIB_V(n_EnableTransition_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_EnableTransition_IZ(nint jnienv, nint native__this, int transitionID, sbyte native_enable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool enable = native_enable != 0;
			motionLayout.EnableTransition(transitionID, enable);
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

	[Register("enableTransition", "(IZ)V", "GetEnableTransition_IZHandler")]
	public unsafe virtual void EnableTransition(int transitionID, bool enable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(transitionID);
		ptr[1] = new JniArgumentValue(enable ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("enableTransition.(IZ)V", this, ptr);
	}

	private static Delegate GetEnableViewTransition_IZHandler()
	{
		return new global::_JniMarshal_PPIB_V(n_EnableViewTransition_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_EnableViewTransition_IZ(nint jnienv, nint native__this, int viewTransitionId, sbyte native_enable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool enable = native_enable != 0;
			motionLayout.EnableViewTransition(viewTransitionId, enable);
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

	[Register("enableViewTransition", "(IZ)V", "GetEnableViewTransition_IZHandler")]
	public unsafe virtual void EnableViewTransition(int viewTransitionId, bool enable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewTransitionId);
		ptr[1] = new JniArgumentValue(enable ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("enableViewTransition.(IZ)V", this, ptr);
	}

	private static Delegate GetFireTransitionCompletedHandler()
	{
		return new global::_JniMarshal_PP_V(n_FireTransitionCompleted);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_FireTransitionCompleted(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FireTransitionCompleted();
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

	[Register("fireTransitionCompleted", "()V", "GetFireTransitionCompletedHandler")]
	protected unsafe virtual void FireTransitionCompleted()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("fireTransitionCompleted.()V", this, null);
	}

	private static Delegate GetFireTrigger_IZFHandler()
	{
		return new _JniMarshal_PPIBF_V(n_FireTrigger_IZF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_FireTrigger_IZF(nint jnienv, nint native__this, int triggerId, sbyte native_positive, float progress)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool positive = native_positive != 0;
			motionLayout.FireTrigger(triggerId, positive, progress);
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

	[Register("fireTrigger", "(IZF)V", "GetFireTrigger_IZFHandler")]
	public unsafe virtual void FireTrigger(int triggerId, bool positive, float progress)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(triggerId);
		ptr[1] = new JniArgumentValue(positive ? ((sbyte)1) : ((sbyte)0));
		ptr[2] = new JniArgumentValue(progress);
		_members.InstanceMethods.InvokeVirtualVoidMethod("fireTrigger.(IZF)V", this, ptr);
	}

	private static Delegate GetGetConstraintSet_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetConstraintSet_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetConstraintSet_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetConstraintSet(id));
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

	[Register("getConstraintSet", "(I)Landroidx/constraintlayout/widget/ConstraintSet;", "GetGetConstraintSet_IHandler")]
	public unsafe virtual ConstraintSet? GetConstraintSet(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<ConstraintSet>(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraintSet.(I)Landroidx/constraintlayout/widget/ConstraintSet;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetConstraintSetIdsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetConstraintSetIds);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetConstraintSetIds(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetConstraintSetIds());
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

	[Register("getConstraintSetIds", "()[I", "GetGetConstraintSetIdsHandler")]
	public unsafe virtual int[]? GetConstraintSetIds()
	{
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraintSetIds.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	private static Delegate GetGetMatchingConstraintSetIds_arrayLjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetMatchingConstraintSetIds_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMatchingConstraintSetIds_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_types)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_types, JniHandleOwnership.DoNotTransfer, typeof(string));
			nint result = JNIEnv.NewArray(motionLayout.GetMatchingConstraintSetIds(array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_types);
			}
			return result;
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

	[Register("getMatchingConstraintSetIds", "([Ljava/lang/String;)[I", "GetGetMatchingConstraintSetIds_arrayLjava_lang_String_Handler")]
	public unsafe virtual int[]? GetMatchingConstraintSetIds(params string[]? types)
	{
		nint num = JNIEnv.NewArray(types);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getMatchingConstraintSetIds.([Ljava/lang/String;)[I", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}
		finally
		{
			if (types != null)
			{
				JNIEnv.CopyArray(num, types);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(types);
		}
	}

	private static Delegate GetGetTransition_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetTransition_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTransition_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTransition(id));
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

	[Register("getTransition", "(I)Landroidx/constraintlayout/motion/widget/MotionScene$Transition;", "GetGetTransition_IHandler")]
	public unsafe virtual MotionScene.Transition? GetTransition(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<MotionScene.Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTransition.(I)Landroidx/constraintlayout/motion/widget/MotionScene$Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetViewVelocity_Landroid_view_View_FFarrayFIHandler()
	{
		return new _JniMarshal_PPLFFLI_V(n_GetViewVelocity_Landroid_view_View_FFarrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetViewVelocity_Landroid_view_View_FFarrayFI(nint jnienv, nint native__this, nint native_view, float posOnViewX, float posOnViewY, nint native_returnVelocity, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_returnVelocity, JniHandleOwnership.DoNotTransfer, typeof(float));
			motionLayout.GetViewVelocity(view, posOnViewX, posOnViewY, array, type);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_returnVelocity);
			}
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

	[Register("getViewVelocity", "(Landroid/view/View;FF[FI)V", "GetGetViewVelocity_Landroid_view_View_FFarrayFIHandler")]
	public unsafe virtual void GetViewVelocity(View? view, float posOnViewX, float posOnViewY, float[]? returnVelocity, int type)
	{
		nint num = JNIEnv.NewArray(returnVelocity);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(posOnViewX);
			ptr[2] = new JniArgumentValue(posOnViewY);
			ptr[3] = new JniArgumentValue(num);
			ptr[4] = new JniArgumentValue(type);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getViewVelocity.(Landroid/view/View;FF[FI)V", this, ptr);
		}
		finally
		{
			if (returnVelocity != null)
			{
				JNIEnv.CopyArray(num, returnVelocity);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(returnVelocity);
		}
	}

	private static Delegate GetIsViewTransitionEnabled_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_IsViewTransitionEnabled_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsViewTransitionEnabled_I(nint jnienv, nint native__this, int viewTransitionId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsViewTransitionEnabled(viewTransitionId) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isViewTransitionEnabled", "(I)Z", "GetIsViewTransitionEnabled_IHandler")]
	public unsafe virtual bool IsViewTransitionEnabled(int viewTransitionId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(viewTransitionId);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("isViewTransitionEnabled.(I)Z", this, ptr);
	}

	private static Delegate GetJumpToState_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_JumpToState_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_JumpToState_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).JumpToState(id);
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

	[Register("jumpToState", "(I)V", "GetJumpToState_IHandler")]
	public unsafe virtual void JumpToState(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("jumpToState.(I)V", this, ptr);
	}

	private static Delegate GetObtainVelocityTrackerHandler()
	{
		return new global::_JniMarshal_PP_L(n_ObtainVelocityTracker);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ObtainVelocityTracker(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ObtainVelocityTracker());
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

	[Register("obtainVelocityTracker", "()Landroidx/constraintlayout/motion/widget/MotionLayout$MotionTracker;", "GetObtainVelocityTrackerHandler")]
	protected unsafe virtual IMotionTracker? ObtainVelocityTracker()
	{
		return Java.Lang.Object.GetObject<IMotionTracker>(_members.InstanceMethods.InvokeVirtualObjectMethod("obtainVelocityTracker.()Landroidx/constraintlayout/motion/widget/MotionLayout$MotionTracker;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnNestedPreScroll_Landroid_view_View_IIarrayIIHandler()
	{
		return new _JniMarshal_PPLIILI_V(n_OnNestedPreScroll_Landroid_view_View_IIarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNestedPreScroll_Landroid_view_View_IIarrayII(nint jnienv, nint native__this, nint native_target, int dx, int dy, nint native_consumed, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			motionLayout.OnNestedPreScroll(target, dx, dy, array, type);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_consumed);
			}
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

	[Register("onNestedPreScroll", "(Landroid/view/View;II[II)V", "GetOnNestedPreScroll_Landroid_view_View_IIarrayIIHandler")]
	public unsafe virtual void OnNestedPreScroll(View target, int dx, int dy, int[] consumed, int type)
	{
		nint num = JNIEnv.NewArray(consumed);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dx);
			ptr[2] = new JniArgumentValue(dy);
			ptr[3] = new JniArgumentValue(num);
			ptr[4] = new JniArgumentValue(type);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedPreScroll.(Landroid/view/View;II[II)V", this, ptr);
		}
		finally
		{
			if (consumed != null)
			{
				JNIEnv.CopyArray(num, consumed);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(target);
			GC.KeepAlive(consumed);
		}
	}

	private static Delegate GetOnNestedScroll_Landroid_view_View_IIIIIHandler()
	{
		return new _JniMarshal_PPLIIIII_V(n_OnNestedScroll_Landroid_view_View_IIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNestedScroll_Landroid_view_View_IIIII(nint jnienv, nint native__this, nint native_target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			motionLayout.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type);
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

	[Register("onNestedScroll", "(Landroid/view/View;IIIII)V", "GetOnNestedScroll_Landroid_view_View_IIIIIHandler")]
	public unsafe virtual void OnNestedScroll(View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dxConsumed);
			ptr[2] = new JniArgumentValue(dyConsumed);
			ptr[3] = new JniArgumentValue(dxUnconsumed);
			ptr[4] = new JniArgumentValue(dyUnconsumed);
			ptr[5] = new JniArgumentValue(type);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScroll.(Landroid/view/View;IIIII)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetOnNestedScroll_Landroid_view_View_IIIIIarrayIHandler()
	{
		return new _JniMarshal_PPLIIIIIL_V(n_OnNestedScroll_Landroid_view_View_IIIIIarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNestedScroll_Landroid_view_View_IIIIIarrayI(nint jnienv, nint native__this, nint native_target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type, nint native_consumed)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			motionLayout.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_consumed);
			}
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

	[Register("onNestedScroll", "(Landroid/view/View;IIIII[I)V", "GetOnNestedScroll_Landroid_view_View_IIIIIarrayIHandler")]
	public unsafe virtual void OnNestedScroll(View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type, int[]? consumed)
	{
		nint num = JNIEnv.NewArray(consumed);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dxConsumed);
			ptr[2] = new JniArgumentValue(dyConsumed);
			ptr[3] = new JniArgumentValue(dxUnconsumed);
			ptr[4] = new JniArgumentValue(dyUnconsumed);
			ptr[5] = new JniArgumentValue(type);
			ptr[6] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScroll.(Landroid/view/View;IIIII[I)V", this, ptr);
		}
		finally
		{
			if (consumed != null)
			{
				JNIEnv.CopyArray(num, consumed);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(target);
			GC.KeepAlive(consumed);
		}
	}

	private static Delegate GetOnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_IIHandler()
	{
		return new global::_JniMarshal_PPLLII_V(n_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II(nint jnienv, nint native__this, nint native_child, nint native_target, int native_axes, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			motionLayout.OnNestedScrollAccepted(child, target, (ScrollAxis)native_axes, type);
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

	[Register("onNestedScrollAccepted", "(Landroid/view/View;Landroid/view/View;II)V", "GetOnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_IIHandler")]
	public unsafe virtual void OnNestedScrollAccepted(View child, View target, ScrollAxis axes, int type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((int)axes);
			ptr[3] = new JniArgumentValue(type);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScrollAccepted.(Landroid/view/View;Landroid/view/View;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetOnStartNestedScroll_Landroid_view_View_Landroid_view_View_IIHandler()
	{
		return new _JniMarshal_PPLLII_B(n_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_II(nint jnienv, nint native__this, nint native_child, nint native_target, int native_axes, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return motionLayout.OnStartNestedScroll(child, target, (ScrollAxis)native_axes, type) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onStartNestedScroll", "(Landroid/view/View;Landroid/view/View;II)Z", "GetOnStartNestedScroll_Landroid_view_View_Landroid_view_View_IIHandler")]
	public unsafe virtual bool OnStartNestedScroll(View child, View target, ScrollAxis axes, int type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((int)axes);
			ptr[3] = new JniArgumentValue(type);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStartNestedScroll.(Landroid/view/View;Landroid/view/View;II)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetOnStopNestedScroll_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_OnStopNestedScroll_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStopNestedScroll_Landroid_view_View_I(nint jnienv, nint native__this, nint native_target, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			motionLayout.OnStopNestedScroll(target, type);
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

	[Register("onStopNestedScroll", "(Landroid/view/View;I)V", "GetOnStopNestedScroll_Landroid_view_View_IHandler")]
	public unsafe virtual void OnStopNestedScroll(View target, int type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(type);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStopNestedScroll.(Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
		}
	}

	[Obsolete]
	private static Delegate GetRebuildMotionHandler()
	{
		return new global::_JniMarshal_PP_V(n_RebuildMotion);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RebuildMotion(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RebuildMotion();
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

	[Obsolete("deprecated")]
	[Register("rebuildMotion", "()V", "GetRebuildMotionHandler")]
	public unsafe virtual void RebuildMotion()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("rebuildMotion.()V", this, null);
	}

	private static Delegate GetRebuildSceneHandler()
	{
		return new global::_JniMarshal_PP_V(n_RebuildScene);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RebuildScene(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RebuildScene();
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

	[Register("rebuildScene", "()V", "GetRebuildSceneHandler")]
	public unsafe virtual void RebuildScene()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("rebuildScene.()V", this, null);
	}

	private static Delegate GetRemoveTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_RemoveTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RemoveTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITransitionListener listener = Java.Lang.Object.GetObject<ITransitionListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			return motionLayout.RemoveTransitionListener(listener) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("removeTransitionListener", "(Landroidx/constraintlayout/motion/widget/MotionLayout$TransitionListener;)Z", "GetRemoveTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_Handler")]
	public unsafe virtual bool RemoveTransitionListener(ITransitionListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("removeTransitionListener.(Landroidx/constraintlayout/motion/widget/MotionLayout$TransitionListener;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRotateTo_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_RotateTo_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RotateTo_II(nint jnienv, nint native__this, int id, int duration)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotateTo(id, duration);
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

	[Register("rotateTo", "(II)V", "GetRotateTo_IIHandler")]
	public unsafe virtual void RotateTo(int id, int duration)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(duration);
		_members.InstanceMethods.InvokeVirtualVoidMethod("rotateTo.(II)V", this, ptr);
	}

	private static Delegate GetScheduleTransitionTo_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_ScheduleTransitionTo_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ScheduleTransitionTo_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScheduleTransitionTo(id);
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

	[Register("scheduleTransitionTo", "(I)V", "GetScheduleTransitionTo_IHandler")]
	public unsafe virtual void ScheduleTransitionTo(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("scheduleTransitionTo.(I)V", this, ptr);
	}

	private static Delegate GetSetDebugMode_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetDebugMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDebugMode_I(nint jnienv, nint native__this, int debugMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDebugMode(debugMode);
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

	[Register("setDebugMode", "(I)V", "GetSetDebugMode_IHandler")]
	public unsafe virtual void SetDebugMode(int debugMode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(debugMode);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setDebugMode.(I)V", this, ptr);
	}

	private static Delegate GetSetInterpolatedProgress_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetInterpolatedProgress_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInterpolatedProgress_F(nint jnienv, nint native__this, float pos)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetInterpolatedProgress(pos);
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

	[Register("setInterpolatedProgress", "(F)V", "GetSetInterpolatedProgress_FHandler")]
	public unsafe virtual void SetInterpolatedProgress(float pos)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(pos);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setInterpolatedProgress.(F)V", this, ptr);
	}

	private static Delegate GetSetOnHide_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetOnHide_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnHide_F(nint jnienv, nint native__this, float progress)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOnHide(progress);
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

	[Register("setOnHide", "(F)V", "GetSetOnHide_FHandler")]
	public unsafe virtual void SetOnHide(float progress)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(progress);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnHide.(F)V", this, ptr);
	}

	private static Delegate GetSetOnShow_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetOnShow_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnShow_F(nint jnienv, nint native__this, float progress)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOnShow(progress);
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

	[Register("setOnShow", "(F)V", "GetSetOnShow_FHandler")]
	public unsafe virtual void SetOnShow(float progress)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(progress);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnShow.(F)V", this, ptr);
	}

	private static Delegate GetSetProgress_FFHandler()
	{
		return new global::_JniMarshal_PPFF_V(n_SetProgress_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProgress_FF(nint jnienv, nint native__this, float pos, float velocity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetProgress(pos, velocity);
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

	[Register("setProgress", "(FF)V", "GetSetProgress_FFHandler")]
	public unsafe virtual void SetProgress(float pos, float velocity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(pos);
		ptr[1] = new JniArgumentValue(velocity);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setProgress.(FF)V", this, ptr);
	}

	private static Delegate GetSetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_(nint jnienv, nint native__this, nint native_transition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionScene.Transition transition2 = Java.Lang.Object.GetObject<MotionScene.Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
			motionLayout.SetTransition(transition2);
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

	[Register("setTransition", "(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", "GetSetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler")]
	protected unsafe virtual void SetTransition(MotionScene.Transition? transition)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTransition.(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(transition);
		}
	}

	private static Delegate GetSetTransition_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTransition_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTransition_I(nint jnienv, nint native__this, int transitionId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransition(transitionId);
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

	[Register("setTransition", "(I)V", "GetSetTransition_IHandler")]
	public unsafe virtual void SetTransition(int transitionId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(transitionId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTransition.(I)V", this, ptr);
	}

	private static Delegate GetSetTransition_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetTransition_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTransition_II(nint jnienv, nint native__this, int beginId, int endId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransition(beginId, endId);
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

	[Register("setTransition", "(II)V", "GetSetTransition_IIHandler")]
	public unsafe virtual void SetTransition(int beginId, int endId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(beginId);
		ptr[1] = new JniArgumentValue(endId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTransition.(II)V", this, ptr);
	}

	private static Delegate GetSetTransitionDuration_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTransitionDuration_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTransitionDuration_I(nint jnienv, nint native__this, int milliseconds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransitionDuration(milliseconds);
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

	[Register("setTransitionDuration", "(I)V", "GetSetTransitionDuration_IHandler")]
	public unsafe virtual void SetTransitionDuration(int milliseconds)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(milliseconds);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTransitionDuration.(I)V", this, ptr);
	}

	private static Delegate GetSetTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITransitionListener transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			motionLayout.SetTransitionListener(transitionListener);
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

	[Register("setTransitionListener", "(Landroidx/constraintlayout/motion/widget/MotionLayout$TransitionListener;)V", "GetSetTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_Handler")]
	public unsafe virtual void SetTransitionListener(ITransitionListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTransitionListener.(Landroidx/constraintlayout/motion/widget/MotionLayout$TransitionListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetTouchAnimateTo_IFFHandler()
	{
		return new _JniMarshal_PPIFF_V(n_TouchAnimateTo_IFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_TouchAnimateTo_IFF(nint jnienv, nint native__this, int touchUpMode, float position, float currentVelocity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TouchAnimateTo(touchUpMode, position, currentVelocity);
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

	[Register("touchAnimateTo", "(IFF)V", "GetTouchAnimateTo_IFFHandler")]
	public unsafe virtual void TouchAnimateTo(int touchUpMode, float position, float currentVelocity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(touchUpMode);
		ptr[1] = new JniArgumentValue(position);
		ptr[2] = new JniArgumentValue(currentVelocity);
		_members.InstanceMethods.InvokeVirtualVoidMethod("touchAnimateTo.(IFF)V", this, ptr);
	}

	private static Delegate GetTouchSpringTo_FFHandler()
	{
		return new global::_JniMarshal_PPFF_V(n_TouchSpringTo_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_TouchSpringTo_FF(nint jnienv, nint native__this, float position, float currentVelocity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TouchSpringTo(position, currentVelocity);
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

	[Register("touchSpringTo", "(FF)V", "GetTouchSpringTo_FFHandler")]
	public unsafe virtual void TouchSpringTo(float position, float currentVelocity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(position);
		ptr[1] = new JniArgumentValue(currentVelocity);
		_members.InstanceMethods.InvokeVirtualVoidMethod("touchSpringTo.(FF)V", this, ptr);
	}

	private static Delegate GetTransitionToEndHandler()
	{
		return new global::_JniMarshal_PP_V(n_TransitionToEnd);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_TransitionToEnd(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionToEnd();
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

	[Register("transitionToEnd", "()V", "GetTransitionToEndHandler")]
	public unsafe virtual void TransitionToEnd()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("transitionToEnd.()V", this, null);
	}

	private static Delegate GetTransitionToEnd_Ljava_lang_Runnable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_TransitionToEnd_Ljava_lang_Runnable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_TransitionToEnd_Ljava_lang_Runnable_(nint jnienv, nint native__this, nint native_onComplete)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable onComplete = Java.Lang.Object.GetObject<IRunnable>(native_onComplete, JniHandleOwnership.DoNotTransfer);
			motionLayout.TransitionToEnd(onComplete);
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

	[Register("transitionToEnd", "(Ljava/lang/Runnable;)V", "GetTransitionToEnd_Ljava_lang_Runnable_Handler")]
	public unsafe virtual void TransitionToEnd(IRunnable? onComplete)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((onComplete == null) ? IntPtr.Zero : ((Java.Lang.Object)onComplete).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("transitionToEnd.(Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(onComplete);
		}
	}

	private static Delegate GetTransitionToStartHandler()
	{
		return new global::_JniMarshal_PP_V(n_TransitionToStart);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_TransitionToStart(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionToStart();
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

	[Register("transitionToStart", "()V", "GetTransitionToStartHandler")]
	public unsafe virtual void TransitionToStart()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("transitionToStart.()V", this, null);
	}

	private static Delegate GetTransitionToStart_Ljava_lang_Runnable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_TransitionToStart_Ljava_lang_Runnable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_TransitionToStart_Ljava_lang_Runnable_(nint jnienv, nint native__this, nint native_onComplete)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable onComplete = Java.Lang.Object.GetObject<IRunnable>(native_onComplete, JniHandleOwnership.DoNotTransfer);
			motionLayout.TransitionToStart(onComplete);
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

	[Register("transitionToStart", "(Ljava/lang/Runnable;)V", "GetTransitionToStart_Ljava_lang_Runnable_Handler")]
	public unsafe virtual void TransitionToStart(IRunnable? onComplete)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((onComplete == null) ? IntPtr.Zero : ((Java.Lang.Object)onComplete).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("transitionToStart.(Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(onComplete);
		}
	}

	private static Delegate GetTransitionToState_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_TransitionToState_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_TransitionToState_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionToState(id);
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

	[Register("transitionToState", "(I)V", "GetTransitionToState_IHandler")]
	public unsafe virtual void TransitionToState(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("transitionToState.(I)V", this, ptr);
	}

	private static Delegate GetTransitionToState_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_TransitionToState_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_TransitionToState_II(nint jnienv, nint native__this, int id, int duration)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionToState(id, duration);
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

	[Register("transitionToState", "(II)V", "GetTransitionToState_IIHandler")]
	public unsafe virtual void TransitionToState(int id, int duration)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(duration);
		_members.InstanceMethods.InvokeVirtualVoidMethod("transitionToState.(II)V", this, ptr);
	}

	private static Delegate GetTransitionToState_IIIHandler()
	{
		return new global::_JniMarshal_PPIII_V(n_TransitionToState_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_TransitionToState_III(nint jnienv, nint native__this, int id, int screenWidth, int screenHeight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionToState(id, screenWidth, screenHeight);
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

	[Register("transitionToState", "(III)V", "GetTransitionToState_IIIHandler")]
	public unsafe virtual void TransitionToState(int id, int screenWidth, int screenHeight)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(screenWidth);
		ptr[2] = new JniArgumentValue(screenHeight);
		_members.InstanceMethods.InvokeVirtualVoidMethod("transitionToState.(III)V", this, ptr);
	}

	private static Delegate GetTransitionToState_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_V(n_TransitionToState_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_TransitionToState_IIII(nint jnienv, nint native__this, int id, int screenWidth, int screenHeight, int duration)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionToState(id, screenWidth, screenHeight, duration);
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

	[Register("transitionToState", "(IIII)V", "GetTransitionToState_IIIIHandler")]
	public unsafe virtual void TransitionToState(int id, int screenWidth, int screenHeight, int duration)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(screenWidth);
		ptr[2] = new JniArgumentValue(screenHeight);
		ptr[3] = new JniArgumentValue(duration);
		_members.InstanceMethods.InvokeVirtualVoidMethod("transitionToState.(IIII)V", this, ptr);
	}

	private static Delegate GetUpdateStateHandler()
	{
		return new global::_JniMarshal_PP_V(n_UpdateState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UpdateState();
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

	[Register("updateState", "()V", "GetUpdateStateHandler")]
	public unsafe virtual void UpdateState()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("updateState.()V", this, null);
	}

	private static Delegate GetUpdateState_ILandroidx_constraintlayout_widget_ConstraintSet_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_UpdateState_ILandroidx_constraintlayout_widget_ConstraintSet_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateState_ILandroidx_constraintlayout_widget_ConstraintSet_(nint jnienv, nint native__this, int stateId, nint native_set)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintSet set = Java.Lang.Object.GetObject<ConstraintSet>(native_set, JniHandleOwnership.DoNotTransfer);
			motionLayout.UpdateState(stateId, set);
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

	[Register("updateState", "(ILandroidx/constraintlayout/widget/ConstraintSet;)V", "GetUpdateState_ILandroidx_constraintlayout_widget_ConstraintSet_Handler")]
	public unsafe virtual void UpdateState(int stateId, ConstraintSet? set)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(stateId);
			ptr[1] = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateState.(ILandroidx/constraintlayout/widget/ConstraintSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(set);
		}
	}

	private static Delegate GetUpdateStateAnimate_ILandroidx_constraintlayout_widget_ConstraintSet_IHandler()
	{
		return new global::_JniMarshal_PPILI_V(n_UpdateStateAnimate_ILandroidx_constraintlayout_widget_ConstraintSet_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateStateAnimate_ILandroidx_constraintlayout_widget_ConstraintSet_I(nint jnienv, nint native__this, int stateId, nint native_set, int duration)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintSet set = Java.Lang.Object.GetObject<ConstraintSet>(native_set, JniHandleOwnership.DoNotTransfer);
			motionLayout.UpdateStateAnimate(stateId, set, duration);
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

	[Register("updateStateAnimate", "(ILandroidx/constraintlayout/widget/ConstraintSet;I)V", "GetUpdateStateAnimate_ILandroidx_constraintlayout_widget_ConstraintSet_IHandler")]
	public unsafe virtual void UpdateStateAnimate(int stateId, ConstraintSet? set, int duration)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(stateId);
			ptr[1] = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(duration);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateStateAnimate.(ILandroidx/constraintlayout/widget/ConstraintSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(set);
		}
	}

	private static Delegate GetViewTransition_IarrayLandroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_ViewTransition_IarrayLandroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ViewTransition_IarrayLandroid_view_View_(nint jnienv, nint native__this, int viewTransitionId, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionLayout? motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View[] array = (View[])JNIEnv.GetArray(native_view, JniHandleOwnership.DoNotTransfer, typeof(View));
			motionLayout.ViewTransition(viewTransitionId, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_view);
			}
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

	[Register("viewTransition", "(I[Landroid/view/View;)V", "GetViewTransition_IarrayLandroid_view_View_Handler")]
	public unsafe virtual void ViewTransition(int viewTransitionId, params View[]? view)
	{
		nint num = JNIEnv.NewArray(view);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewTransitionId);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("viewTransition.(I[Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			if (view != null)
			{
				JNIEnv.CopyArray(num, view);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(view);
		}
	}

	private ITransitionListenerImplementor __CreateITransitionListenerImplementor()
	{
		return new ITransitionListenerImplementor(this);
	}
}
