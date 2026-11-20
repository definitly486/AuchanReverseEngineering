using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/GestureDetector", DoNotGenerateAcw = true)]
public class GestureDetector : Java.Lang.Object
{
	[Register("android/view/GestureDetector$OnDoubleTapListener", "", "Android.Views.GestureDetector/IOnDoubleTapListenerInvoker")]
	public interface IOnDoubleTapListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onDoubleTap", "(Landroid/view/MotionEvent;)Z", "GetOnDoubleTap_Landroid_view_MotionEvent_Handler:Android.Views.GestureDetector/IOnDoubleTapListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnDoubleTap(MotionEvent e);

		[Register("onDoubleTapEvent", "(Landroid/view/MotionEvent;)Z", "GetOnDoubleTapEvent_Landroid_view_MotionEvent_Handler:Android.Views.GestureDetector/IOnDoubleTapListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnDoubleTapEvent(MotionEvent e);

		[Register("onSingleTapConfirmed", "(Landroid/view/MotionEvent;)Z", "GetOnSingleTapConfirmed_Landroid_view_MotionEvent_Handler:Android.Views.GestureDetector/IOnDoubleTapListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnSingleTapConfirmed(MotionEvent e);
	}

	[Register("android/view/GestureDetector$OnDoubleTapListener", DoNotGenerateAcw = true)]
	internal class IOnDoubleTapListenerInvoker : Java.Lang.Object, IOnDoubleTapListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_GestureDetector_OnDoubleTapListener = new XAPeerMembers("android/view/GestureDetector$OnDoubleTapListener", typeof(IOnDoubleTapListenerInvoker));

		private static Delegate? cb_onDoubleTap_OnDoubleTap_Landroid_view_MotionEvent__Z;

		private static Delegate? cb_onDoubleTapEvent_OnDoubleTapEvent_Landroid_view_MotionEvent__Z;

		private static Delegate? cb_onSingleTapConfirmed_OnSingleTapConfirmed_Landroid_view_MotionEvent__Z;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_GestureDetector_OnDoubleTapListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_GestureDetector_OnDoubleTapListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_GestureDetector_OnDoubleTapListener.ManagedPeerType;

		public IOnDoubleTapListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnDoubleTap_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnDoubleTapListener? onDoubleTapListener = Java.Lang.Object.GetObject<IOnDoubleTapListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return onDoubleTapListener.OnDoubleTap(e) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe bool OnDoubleTap(MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_android_view_GestureDetector_OnDoubleTapListener.InstanceMethods.InvokeAbstractBooleanMethod("onDoubleTap.(Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnDoubleTapEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnDoubleTapListener? onDoubleTapListener = Java.Lang.Object.GetObject<IOnDoubleTapListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return onDoubleTapListener.OnDoubleTapEvent(e) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe bool OnDoubleTapEvent(MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_android_view_GestureDetector_OnDoubleTapListener.InstanceMethods.InvokeAbstractBooleanMethod("onDoubleTapEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnSingleTapConfirmed_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnDoubleTapListener? onDoubleTapListener = Java.Lang.Object.GetObject<IOnDoubleTapListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return onDoubleTapListener.OnSingleTapConfirmed(e) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe bool OnSingleTapConfirmed(MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_android_view_GestureDetector_OnDoubleTapListener.InstanceMethods.InvokeAbstractBooleanMethod("onSingleTapConfirmed.(Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
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
		private static sbyte n_OnDoubleTap_Landroid_view_MotionEvent__mm_wrapper(nint jnienv, nint native__this, nint native_e)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnDoubleTap_Landroid_view_MotionEvent_(jnienv, native__this, native_e);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_OnDoubleTapEvent_Landroid_view_MotionEvent__mm_wrapper(nint jnienv, nint native__this, nint native_e)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnDoubleTapEvent_Landroid_view_MotionEvent_(jnienv, native__this, native_e);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_OnSingleTapConfirmed_Landroid_view_MotionEvent__mm_wrapper(nint jnienv, nint native__this, nint native_e)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnSingleTapConfirmed_Landroid_view_MotionEvent_(jnienv, native__this, native_e);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	[Register("android/view/GestureDetector$OnGestureListener", "", "Android.Views.GestureDetector/IOnGestureListenerInvoker")]
	public interface IOnGestureListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onDown", "(Landroid/view/MotionEvent;)Z", "GetOnDown_Landroid_view_MotionEvent_Handler:Android.Views.GestureDetector/IOnGestureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnDown(MotionEvent e);

		[Register("onFling", "(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z", "GetOnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FFHandler:Android.Views.GestureDetector/IOnGestureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnFling(MotionEvent? e1, MotionEvent e2, float velocityX, float velocityY);

		[Register("onLongPress", "(Landroid/view/MotionEvent;)V", "GetOnLongPress_Landroid_view_MotionEvent_Handler:Android.Views.GestureDetector/IOnGestureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnLongPress(MotionEvent e);

		[Register("onScroll", "(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z", "GetOnScroll_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FFHandler:Android.Views.GestureDetector/IOnGestureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnScroll(MotionEvent? e1, MotionEvent e2, float distanceX, float distanceY);

		[Register("onShowPress", "(Landroid/view/MotionEvent;)V", "GetOnShowPress_Landroid_view_MotionEvent_Handler:Android.Views.GestureDetector/IOnGestureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnShowPress(MotionEvent e);

		[Register("onSingleTapUp", "(Landroid/view/MotionEvent;)Z", "GetOnSingleTapUp_Landroid_view_MotionEvent_Handler:Android.Views.GestureDetector/IOnGestureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnSingleTapUp(MotionEvent e);
	}

	[Register("android/view/GestureDetector$OnGestureListener", DoNotGenerateAcw = true)]
	internal class IOnGestureListenerInvoker : Java.Lang.Object, IOnGestureListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_GestureDetector_OnGestureListener = new XAPeerMembers("android/view/GestureDetector$OnGestureListener", typeof(IOnGestureListenerInvoker));

		private static Delegate? cb_onDown_OnDown_Landroid_view_MotionEvent__Z;

		private static Delegate? cb_onFling_OnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF_Z;

		private static Delegate? cb_onLongPress_OnLongPress_Landroid_view_MotionEvent__V;

		private static Delegate? cb_onScroll_OnScroll_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF_Z;

		private static Delegate? cb_onShowPress_OnShowPress_Landroid_view_MotionEvent__V;

		private static Delegate? cb_onSingleTapUp_OnSingleTapUp_Landroid_view_MotionEvent__Z;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_GestureDetector_OnGestureListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_GestureDetector_OnGestureListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_GestureDetector_OnGestureListener.ManagedPeerType;

		public IOnGestureListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnDown_Landroid_view_MotionEvent_Handler()
		{
			return new _JniMarshal_PPL_B(n_OnDown_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnDown_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnGestureListener? onGestureListener = Java.Lang.Object.GetObject<IOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return onGestureListener.OnDown(e) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe bool OnDown(MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_android_view_GestureDetector_OnGestureListener.InstanceMethods.InvokeAbstractBooleanMethod("onDown.(Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetOnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FFHandler()
		{
			return new _JniMarshal_PPLLFF_B(n_OnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF(nint jnienv, nint native__this, nint native_e1, nint native_e2, float velocityX, float velocityY)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnGestureListener? onGestureListener = Java.Lang.Object.GetObject<IOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e1, JniHandleOwnership.DoNotTransfer);
				MotionEvent e2 = Java.Lang.Object.GetObject<MotionEvent>(native_e2, JniHandleOwnership.DoNotTransfer);
				return onGestureListener.OnFling(e, e2, velocityX, velocityY) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e3)
			{
				runtime.OnUserUnhandledException(ref transition, e3);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe bool OnFling(MotionEvent? e1, MotionEvent e2, float velocityX, float velocityY)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(e1?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(e2?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(velocityX);
				ptr[3] = new JniArgumentValue(velocityY);
				return _members_android_view_GestureDetector_OnGestureListener.InstanceMethods.InvokeAbstractBooleanMethod("onFling.(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e1);
				GC.KeepAlive(e2);
			}
		}

		private static Delegate GetOnLongPress_Landroid_view_MotionEvent_Handler()
		{
			return new _JniMarshal_PPL_V(n_OnLongPress_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnLongPress_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnGestureListener? onGestureListener = Java.Lang.Object.GetObject<IOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				onGestureListener.OnLongPress(e);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe void OnLongPress(MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				_members_android_view_GestureDetector_OnGestureListener.InstanceMethods.InvokeAbstractVoidMethod("onLongPress.(Landroid/view/MotionEvent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetOnScroll_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FFHandler()
		{
			return new _JniMarshal_PPLLFF_B(n_OnScroll_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnScroll_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF(nint jnienv, nint native__this, nint native_e1, nint native_e2, float distanceX, float distanceY)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnGestureListener? onGestureListener = Java.Lang.Object.GetObject<IOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e1, JniHandleOwnership.DoNotTransfer);
				MotionEvent e2 = Java.Lang.Object.GetObject<MotionEvent>(native_e2, JniHandleOwnership.DoNotTransfer);
				return onGestureListener.OnScroll(e, e2, distanceX, distanceY) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e3)
			{
				runtime.OnUserUnhandledException(ref transition, e3);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe bool OnScroll(MotionEvent? e1, MotionEvent e2, float distanceX, float distanceY)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(e1?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(e2?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(distanceX);
				ptr[3] = new JniArgumentValue(distanceY);
				return _members_android_view_GestureDetector_OnGestureListener.InstanceMethods.InvokeAbstractBooleanMethod("onScroll.(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e1);
				GC.KeepAlive(e2);
			}
		}

		private static Delegate GetOnShowPress_Landroid_view_MotionEvent_Handler()
		{
			return new _JniMarshal_PPL_V(n_OnShowPress_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnShowPress_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnGestureListener? onGestureListener = Java.Lang.Object.GetObject<IOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				onGestureListener.OnShowPress(e);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe void OnShowPress(MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				_members_android_view_GestureDetector_OnGestureListener.InstanceMethods.InvokeAbstractVoidMethod("onShowPress.(Landroid/view/MotionEvent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetOnSingleTapUp_Landroid_view_MotionEvent_Handler()
		{
			return new _JniMarshal_PPL_B(n_OnSingleTapUp_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnSingleTapUp_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnGestureListener? onGestureListener = Java.Lang.Object.GetObject<IOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return onGestureListener.OnSingleTapUp(e) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe bool OnSingleTapUp(MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_android_view_GestureDetector_OnGestureListener.InstanceMethods.InvokeAbstractBooleanMethod("onSingleTapUp.(Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
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

	[Register("android/view/GestureDetector$SimpleOnGestureListener", DoNotGenerateAcw = true)]
	public class SimpleOnGestureListener : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable, IOnDoubleTapListener, IOnGestureListener
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/GestureDetector$SimpleOnGestureListener", typeof(SimpleOnGestureListener));

		private static Delegate? cb_onDoubleTap_OnDoubleTap_Landroid_view_MotionEvent__Z;

		private static Delegate? cb_onDoubleTapEvent_OnDoubleTapEvent_Landroid_view_MotionEvent__Z;

		private static Delegate? cb_onDown_OnDown_Landroid_view_MotionEvent__Z;

		private static Delegate? cb_onFling_OnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF_Z;

		private static Delegate? cb_onLongPress_OnLongPress_Landroid_view_MotionEvent__V;

		private static Delegate? cb_onScroll_OnScroll_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF_Z;

		private static Delegate? cb_onShowPress_OnShowPress_Landroid_view_MotionEvent__V;

		private static Delegate? cb_onSingleTapConfirmed_OnSingleTapConfirmed_Landroid_view_MotionEvent__Z;

		private static Delegate? cb_onSingleTapUp_OnSingleTapUp_Landroid_view_MotionEvent__Z;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected SimpleOnGestureListener(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SimpleOnGestureListener()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnDoubleTap_Landroid_view_MotionEvent_Handler()
		{
			return new _JniMarshal_PPL_B(n_OnDoubleTap_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnDoubleTap_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				SimpleOnGestureListener? simpleOnGestureListener = Java.Lang.Object.GetObject<SimpleOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return simpleOnGestureListener.OnDoubleTap(e) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onDoubleTap", "(Landroid/view/MotionEvent;)Z", "GetOnDoubleTap_Landroid_view_MotionEvent_Handler")]
		public unsafe virtual bool OnDoubleTap(MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onDoubleTap.(Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetOnDoubleTapEvent_Landroid_view_MotionEvent_Handler()
		{
			return new _JniMarshal_PPL_B(n_OnDoubleTapEvent_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnDoubleTapEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				SimpleOnGestureListener? simpleOnGestureListener = Java.Lang.Object.GetObject<SimpleOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return simpleOnGestureListener.OnDoubleTapEvent(e) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onDoubleTapEvent", "(Landroid/view/MotionEvent;)Z", "GetOnDoubleTapEvent_Landroid_view_MotionEvent_Handler")]
		public unsafe virtual bool OnDoubleTapEvent(MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onDoubleTapEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetOnDown_Landroid_view_MotionEvent_Handler()
		{
			return new _JniMarshal_PPL_B(n_OnDown_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnDown_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				SimpleOnGestureListener? simpleOnGestureListener = Java.Lang.Object.GetObject<SimpleOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return simpleOnGestureListener.OnDown(e) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onDown", "(Landroid/view/MotionEvent;)Z", "GetOnDown_Landroid_view_MotionEvent_Handler")]
		public unsafe virtual bool OnDown(MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onDown.(Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF(nint jnienv, nint native__this, nint native_e1, nint native_e2, float velocityX, float velocityY)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				SimpleOnGestureListener? simpleOnGestureListener = Java.Lang.Object.GetObject<SimpleOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e1, JniHandleOwnership.DoNotTransfer);
				MotionEvent e2 = Java.Lang.Object.GetObject<MotionEvent>(native_e2, JniHandleOwnership.DoNotTransfer);
				return simpleOnGestureListener.OnFling(e, e2, velocityX, velocityY) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e3)
			{
				runtime.OnUserUnhandledException(ref transition, e3);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onFling", "(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z", "GetOnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FFHandler")]
		public unsafe virtual bool OnFling(MotionEvent? e1, MotionEvent e2, float velocityX, float velocityY)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(e1?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(e2?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(velocityX);
				ptr[3] = new JniArgumentValue(velocityY);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onFling.(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e1);
				GC.KeepAlive(e2);
			}
		}

		private static Delegate GetOnLongPress_Landroid_view_MotionEvent_Handler()
		{
			return new _JniMarshal_PPL_V(n_OnLongPress_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnLongPress_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				SimpleOnGestureListener? simpleOnGestureListener = Java.Lang.Object.GetObject<SimpleOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				simpleOnGestureListener.OnLongPress(e);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onLongPress", "(Landroid/view/MotionEvent;)V", "GetOnLongPress_Landroid_view_MotionEvent_Handler")]
		public unsafe virtual void OnLongPress(MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onLongPress.(Landroid/view/MotionEvent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetOnScroll_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FFHandler()
		{
			return new _JniMarshal_PPLLFF_B(n_OnScroll_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnScroll_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF(nint jnienv, nint native__this, nint native_e1, nint native_e2, float distanceX, float distanceY)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				SimpleOnGestureListener? simpleOnGestureListener = Java.Lang.Object.GetObject<SimpleOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e1, JniHandleOwnership.DoNotTransfer);
				MotionEvent e2 = Java.Lang.Object.GetObject<MotionEvent>(native_e2, JniHandleOwnership.DoNotTransfer);
				return simpleOnGestureListener.OnScroll(e, e2, distanceX, distanceY) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e3)
			{
				runtime.OnUserUnhandledException(ref transition, e3);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onScroll", "(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z", "GetOnScroll_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FFHandler")]
		public unsafe virtual bool OnScroll(MotionEvent? e1, MotionEvent e2, float distanceX, float distanceY)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(e1?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(e2?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(distanceX);
				ptr[3] = new JniArgumentValue(distanceY);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onScroll.(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e1);
				GC.KeepAlive(e2);
			}
		}

		private static Delegate GetOnShowPress_Landroid_view_MotionEvent_Handler()
		{
			return new _JniMarshal_PPL_V(n_OnShowPress_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnShowPress_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				SimpleOnGestureListener? simpleOnGestureListener = Java.Lang.Object.GetObject<SimpleOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				simpleOnGestureListener.OnShowPress(e);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onShowPress", "(Landroid/view/MotionEvent;)V", "GetOnShowPress_Landroid_view_MotionEvent_Handler")]
		public unsafe virtual void OnShowPress(MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onShowPress.(Landroid/view/MotionEvent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetOnSingleTapConfirmed_Landroid_view_MotionEvent_Handler()
		{
			return new _JniMarshal_PPL_B(n_OnSingleTapConfirmed_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnSingleTapConfirmed_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				SimpleOnGestureListener? simpleOnGestureListener = Java.Lang.Object.GetObject<SimpleOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return simpleOnGestureListener.OnSingleTapConfirmed(e) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onSingleTapConfirmed", "(Landroid/view/MotionEvent;)Z", "GetOnSingleTapConfirmed_Landroid_view_MotionEvent_Handler")]
		public unsafe virtual bool OnSingleTapConfirmed(MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onSingleTapConfirmed.(Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetOnSingleTapUp_Landroid_view_MotionEvent_Handler()
		{
			return new _JniMarshal_PPL_B(n_OnSingleTapUp_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnSingleTapUp_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				SimpleOnGestureListener? simpleOnGestureListener = Java.Lang.Object.GetObject<SimpleOnGestureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return simpleOnGestureListener.OnSingleTapUp(e) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onSingleTapUp", "(Landroid/view/MotionEvent;)Z", "GetOnSingleTapUp_Landroid_view_MotionEvent_Handler")]
		public unsafe virtual bool OnSingleTapUp(MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onSingleTapUp.(Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
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
		private static sbyte n_OnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF_mm_wrapper(nint jnienv, nint native__this, nint native_e1, nint native_e2, float velocityX, float velocityY)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF(jnienv, native__this, native_e1, native_e2, velocityX, velocityY);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/GestureDetector", typeof(GestureDetector));

	private static Delegate? cb_onTouchEvent_OnTouchEvent_Landroid_view_MotionEvent__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected GestureDetector(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/view/GestureDetector$OnGestureListener;)V", "")]
	public unsafe GestureDetector(Context? context, IOnGestureListener listener)
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
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/view/GestureDetector$OnGestureListener;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/view/GestureDetector$OnGestureListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetOnTouchEvent_Landroid_view_MotionEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_OnTouchEvent_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnTouchEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_ev)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			GestureDetector? gestureDetector = Java.Lang.Object.GetObject<GestureDetector>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_ev, JniHandleOwnership.DoNotTransfer);
			return gestureDetector.OnTouchEvent(ev) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onTouchEvent", "(Landroid/view/MotionEvent;)Z", "GetOnTouchEvent_Landroid_view_MotionEvent_Handler")]
	public unsafe virtual bool OnTouchEvent(MotionEvent ev)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ev?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onTouchEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(ev);
		}
	}
}
