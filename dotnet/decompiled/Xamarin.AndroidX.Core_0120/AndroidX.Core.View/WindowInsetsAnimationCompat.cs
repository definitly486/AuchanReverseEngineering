using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using AndroidX.Core.Graphics;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/WindowInsetsAnimationCompat", DoNotGenerateAcw = true)]
public sealed class WindowInsetsAnimationCompat : Java.Lang.Object
{
	[Register("androidx/core/view/WindowInsetsAnimationCompat$BoundsCompat", DoNotGenerateAcw = true)]
	public sealed class BoundsCompat : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/WindowInsetsAnimationCompat$BoundsCompat", typeof(BoundsCompat));

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

		public unsafe Insets? LowerBound
		{
			[Register("getLowerBound", "()Landroidx/core/graphics/Insets;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Insets>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLowerBound.()Landroidx/core/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Insets? UpperBound
		{
			[Register("getUpperBound", "()Landroidx/core/graphics/Insets;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Insets>(_members.InstanceMethods.InvokeAbstractObjectMethod("getUpperBound.()Landroidx/core/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal BoundsCompat(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/core/graphics/Insets;Landroidx/core/graphics/Insets;)V", "")]
		public unsafe BoundsCompat(Insets? lowerBound, Insets? upperBound)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(lowerBound?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(upperBound?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/core/graphics/Insets;Landroidx/core/graphics/Insets;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/core/graphics/Insets;Landroidx/core/graphics/Insets;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(lowerBound);
				GC.KeepAlive(upperBound);
			}
		}

		[Register("inset", "(Landroidx/core/graphics/Insets;)Landroidx/core/view/WindowInsetsAnimationCompat$BoundsCompat;", "")]
		public unsafe BoundsCompat? Inset(Insets? insets)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<BoundsCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("inset.(Landroidx/core/graphics/Insets;)Landroidx/core/view/WindowInsetsAnimationCompat$BoundsCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(insets);
			}
		}

		[Register("toBounds", "()Landroid/view/WindowInsetsAnimation$Bounds;", "")]
		public unsafe WindowInsetsAnimation.Bounds? ToBounds()
		{
			return Java.Lang.Object.GetObject<WindowInsetsAnimation.Bounds>(_members.InstanceMethods.InvokeAbstractObjectMethod("toBounds.()Landroid/view/WindowInsetsAnimation$Bounds;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("toBoundsCompat", "(Landroid/view/WindowInsetsAnimation$Bounds;)Landroidx/core/view/WindowInsetsAnimationCompat$BoundsCompat;", "")]
		public unsafe static BoundsCompat? ToBoundsCompat(WindowInsetsAnimation.Bounds? bounds)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bounds?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<BoundsCompat>(_members.StaticMethods.InvokeObjectMethod("toBoundsCompat.(Landroid/view/WindowInsetsAnimation$Bounds;)Landroidx/core/view/WindowInsetsAnimationCompat$BoundsCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(bounds);
			}
		}
	}

	[Register("androidx/core/view/WindowInsetsAnimationCompat$Callback", DoNotGenerateAcw = true)]
	public abstract class Callback : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/WindowInsetsAnimationCompat$Callback", typeof(Callback));

		private static Delegate? cb_onEnd_OnEnd_Landroidx_core_view_WindowInsetsAnimationCompat__V;

		private static Delegate? cb_onPrepare_OnPrepare_Landroidx_core_view_WindowInsetsAnimationCompat__V;

		private static Delegate? cb_onProgress_OnProgress_Landroidx_core_view_WindowInsetsCompat_Ljava_util_List__Landroidx_core_view_WindowInsetsCompat_;

		private static Delegate? cb_onStart_OnStart_Landroidx_core_view_WindowInsetsAnimationCompat_Landroidx_core_view_WindowInsetsAnimationCompat_BoundsCompat__Landroidx_core_view_WindowInsetsAnimationCompat_BoundsCompat_;

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

		public unsafe int DispatchMode
		{
			[Register("getDispatchMode", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getDispatchMode.()I", this, null);
			}
		}

		protected Callback(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(I)V", "")]
		public unsafe Callback(int dispatchMode)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(dispatchMode);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}

		private static Delegate GetOnEnd_Landroidx_core_view_WindowInsetsAnimationCompat_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnEnd_Landroidx_core_view_WindowInsetsAnimationCompat_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnEnd_Landroidx_core_view_WindowInsetsAnimationCompat_(nint jnienv, nint native__this, nint native_animation)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Callback? callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				WindowInsetsAnimationCompat animation = Java.Lang.Object.GetObject<WindowInsetsAnimationCompat>(native_animation, JniHandleOwnership.DoNotTransfer);
				callback.OnEnd(animation);
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

		[Register("onEnd", "(Landroidx/core/view/WindowInsetsAnimationCompat;)V", "GetOnEnd_Landroidx_core_view_WindowInsetsAnimationCompat_Handler")]
		public unsafe virtual void OnEnd(WindowInsetsAnimationCompat? animation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(animation?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onEnd.(Landroidx/core/view/WindowInsetsAnimationCompat;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(animation);
			}
		}

		private static Delegate GetOnPrepare_Landroidx_core_view_WindowInsetsAnimationCompat_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnPrepare_Landroidx_core_view_WindowInsetsAnimationCompat_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnPrepare_Landroidx_core_view_WindowInsetsAnimationCompat_(nint jnienv, nint native__this, nint native_animation)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Callback? callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				WindowInsetsAnimationCompat animation = Java.Lang.Object.GetObject<WindowInsetsAnimationCompat>(native_animation, JniHandleOwnership.DoNotTransfer);
				callback.OnPrepare(animation);
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

		[Register("onPrepare", "(Landroidx/core/view/WindowInsetsAnimationCompat;)V", "GetOnPrepare_Landroidx_core_view_WindowInsetsAnimationCompat_Handler")]
		public unsafe virtual void OnPrepare(WindowInsetsAnimationCompat? animation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(animation?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onPrepare.(Landroidx/core/view/WindowInsetsAnimationCompat;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(animation);
			}
		}

		private static Delegate GetOnProgress_Landroidx_core_view_WindowInsetsCompat_Ljava_util_List_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_OnProgress_Landroidx_core_view_WindowInsetsCompat_Ljava_util_List_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_OnProgress_Landroidx_core_view_WindowInsetsCompat_Ljava_util_List_(nint jnienv, nint native__this, nint native_insets, nint native_runningAnimations)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Callback? callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				WindowInsetsCompat insets = Java.Lang.Object.GetObject<WindowInsetsCompat>(native_insets, JniHandleOwnership.DoNotTransfer);
				IList<WindowInsetsAnimationCompat> runningAnimations = JavaList<WindowInsetsAnimationCompat>.FromJniHandle(native_runningAnimations, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(callback.OnProgress(insets, runningAnimations));
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

		[Register("onProgress", "(Landroidx/core/view/WindowInsetsCompat;Ljava/util/List;)Landroidx/core/view/WindowInsetsCompat;", "GetOnProgress_Landroidx_core_view_WindowInsetsCompat_Ljava_util_List_Handler")]
		public abstract WindowInsetsCompat? OnProgress(WindowInsetsCompat? insets, IList<WindowInsetsAnimationCompat>? runningAnimations);

		private static Delegate GetOnStart_Landroidx_core_view_WindowInsetsAnimationCompat_Landroidx_core_view_WindowInsetsAnimationCompat_BoundsCompat_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_OnStart_Landroidx_core_view_WindowInsetsAnimationCompat_Landroidx_core_view_WindowInsetsAnimationCompat_BoundsCompat_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_OnStart_Landroidx_core_view_WindowInsetsAnimationCompat_Landroidx_core_view_WindowInsetsAnimationCompat_BoundsCompat_(nint jnienv, nint native__this, nint native_animation, nint native_bounds)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Callback? callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				WindowInsetsAnimationCompat animation = Java.Lang.Object.GetObject<WindowInsetsAnimationCompat>(native_animation, JniHandleOwnership.DoNotTransfer);
				BoundsCompat bounds = Java.Lang.Object.GetObject<BoundsCompat>(native_bounds, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(callback.OnStart(animation, bounds));
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

		[Register("onStart", "(Landroidx/core/view/WindowInsetsAnimationCompat;Landroidx/core/view/WindowInsetsAnimationCompat$BoundsCompat;)Landroidx/core/view/WindowInsetsAnimationCompat$BoundsCompat;", "GetOnStart_Landroidx_core_view_WindowInsetsAnimationCompat_Landroidx_core_view_WindowInsetsAnimationCompat_BoundsCompat_Handler")]
		public unsafe virtual BoundsCompat? OnStart(WindowInsetsAnimationCompat? animation, BoundsCompat? bounds)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(animation?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(bounds?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<BoundsCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("onStart.(Landroidx/core/view/WindowInsetsAnimationCompat;Landroidx/core/view/WindowInsetsAnimationCompat$BoundsCompat;)Landroidx/core/view/WindowInsetsAnimationCompat$BoundsCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(animation);
				GC.KeepAlive(bounds);
			}
		}
	}

	[Register("androidx/core/view/WindowInsetsAnimationCompat$Callback", DoNotGenerateAcw = true)]
	internal class CallbackInvoker : Callback
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/WindowInsetsAnimationCompat$Callback", typeof(CallbackInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public CallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onProgress", "(Landroidx/core/view/WindowInsetsCompat;Ljava/util/List;)Landroidx/core/view/WindowInsetsCompat;", "GetOnProgress_Landroidx_core_view_WindowInsetsCompat_Ljava_util_List_Handler")]
		public unsafe override WindowInsetsCompat? OnProgress(WindowInsetsCompat? insets, IList<WindowInsetsAnimationCompat>? runningAnimations)
		{
			nint num = JavaList<WindowInsetsAnimationCompat>.ToLocalJniHandle(runningAnimations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("onProgress.(Landroidx/core/view/WindowInsetsCompat;Ljava/util/List;)Landroidx/core/view/WindowInsetsCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(insets);
				GC.KeepAlive(runningAnimations);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/WindowInsetsAnimationCompat", typeof(WindowInsetsAnimationCompat));

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

	public unsafe float Alpha
	{
		[Register("getAlpha", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getAlpha.()F", this, null);
		}
		[Register("setAlpha", "(F)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setAlpha.(F)V", this, ptr);
		}
	}

	public unsafe long DurationMillis
	{
		[Register("getDurationMillis", "()J", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("getDurationMillis.()J", this, null);
		}
	}

	public unsafe float Fraction
	{
		[Register("getFraction", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getFraction.()F", this, null);
		}
		[Register("setFraction", "(F)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setFraction.(F)V", this, ptr);
		}
	}

	public unsafe float InterpolatedFraction
	{
		[Register("getInterpolatedFraction", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getInterpolatedFraction.()F", this, null);
		}
	}

	public unsafe IInterpolator? Interpolator
	{
		[Register("getInterpolator", "()Landroid/view/animation/Interpolator;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IInterpolator>(_members.InstanceMethods.InvokeAbstractObjectMethod("getInterpolator.()Landroid/view/animation/Interpolator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int TypeMask
	{
		[Register("getTypeMask", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getTypeMask.()I", this, null);
		}
	}

	internal WindowInsetsAnimationCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(ILandroid/view/animation/Interpolator;J)V", "")]
	public unsafe WindowInsetsAnimationCompat(int typeMask, IInterpolator? interpolator, long durationMillis)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(typeMask);
			ptr[1] = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
			ptr[2] = new JniArgumentValue(durationMillis);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(ILandroid/view/animation/Interpolator;J)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(ILandroid/view/animation/Interpolator;J)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(interpolator);
		}
	}
}
