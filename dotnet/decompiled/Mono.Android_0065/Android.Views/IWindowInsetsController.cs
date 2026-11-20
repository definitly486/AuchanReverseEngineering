using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.OS;
using Android.Runtime;
using Android.Views.Animations;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/WindowInsetsController", "", "Android.Views.IWindowInsetsControllerInvoker", ApiSince = 30)]
public interface IWindowInsetsController : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("android/view/WindowInsetsController$OnControllableInsetsChangedListener", "", "Android.Views.IWindowInsetsController/IOnControllableInsetsChangedListenerInvoker", ApiSince = 30)]
	public interface IOnControllableInsetsChangedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[SupportedOSPlatform("android30.0")]
		[Register("onControllableInsetsChanged", "(Landroid/view/WindowInsetsController;I)V", "GetOnControllableInsetsChanged_Landroid_view_WindowInsetsController_IHandler:Android.Views.IWindowInsetsController/IOnControllableInsetsChangedListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 30)]
		void OnControllableInsetsChanged(IWindowInsetsController controller, int typeMask);
	}

	[Register("android/view/WindowInsetsController$OnControllableInsetsChangedListener", DoNotGenerateAcw = true, ApiSince = 30)]
	internal class IOnControllableInsetsChangedListenerInvoker : Java.Lang.Object, IOnControllableInsetsChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_WindowInsetsController_OnControllableInsetsChangedListener = new XAPeerMembers("android/view/WindowInsetsController$OnControllableInsetsChangedListener", typeof(IOnControllableInsetsChangedListenerInvoker));

		private static Delegate? cb_onControllableInsetsChanged_OnControllableInsetsChanged_Landroid_view_WindowInsetsController_I_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_WindowInsetsController_OnControllableInsetsChangedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_WindowInsetsController_OnControllableInsetsChangedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_WindowInsetsController_OnControllableInsetsChangedListener.ManagedPeerType;

		public IOnControllableInsetsChangedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[SupportedOSPlatform("android30.0")]
		private static Delegate GetOnControllableInsetsChanged_Landroid_view_WindowInsetsController_IHandler()
		{
			return new _JniMarshal_PPLI_V(n_OnControllableInsetsChanged_Landroid_view_WindowInsetsController_I);
		}

		[SupportedOSPlatform("android30.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnControllableInsetsChanged_Landroid_view_WindowInsetsController_I(nint jnienv, nint native__this, nint native_controller, int typeMask)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnControllableInsetsChangedListener? onControllableInsetsChangedListener = Java.Lang.Object.GetObject<IOnControllableInsetsChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IWindowInsetsController controller = Java.Lang.Object.GetObject<IWindowInsetsController>(native_controller, JniHandleOwnership.DoNotTransfer);
				onControllableInsetsChangedListener.OnControllableInsetsChanged(controller, typeMask);
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

		[SupportedOSPlatform("android30.0")]
		public unsafe void OnControllableInsetsChanged(IWindowInsetsController controller, int typeMask)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((controller == null) ? IntPtr.Zero : ((Java.Lang.Object)controller).Handle);
				ptr[1] = new JniArgumentValue(typeMask);
				_members_android_view_WindowInsetsController_OnControllableInsetsChangedListener.InstanceMethods.InvokeAbstractVoidMethod("onControllableInsetsChanged.(Landroid/view/WindowInsetsController;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(controller);
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

	int SystemBarsAppearance
	{
		[SupportedOSPlatform("android30.0")]
		get;
	}

	int SystemBarsBehavior
	{
		[SupportedOSPlatform("android30.0")]
		get;
		[SupportedOSPlatform("android30.0")]
		set;
	}

	[SupportedOSPlatform("android30.0")]
	void AddOnControllableInsetsChangedListener(IOnControllableInsetsChangedListener listener);

	[SupportedOSPlatform("android30.0")]
	void ControlWindowInsetsAnimation(int types, long durationMillis, IInterpolator? interpolator, CancellationSignal? cancellationSignal, IWindowInsetsAnimationControlListener listener);

	[SupportedOSPlatform("android30.0")]
	void Hide(int types);

	[SupportedOSPlatform("android30.0")]
	void RemoveOnControllableInsetsChangedListener(IOnControllableInsetsChangedListener listener);

	[SupportedOSPlatform("android30.0")]
	void SetSystemBarsAppearance([IntDef(Flag = true, Type = "Android.Views.IWindowInsetsController", Fields = new string[] { "AppearanceLightStatusBars", "AppearanceLightNavigationBars", "AppearanceTransparentCaptionBarBackground", "AppearanceLightCaptionBars" })] int appearance, [IntDef(Flag = true, Type = "Android.Views.IWindowInsetsController", Fields = new string[] { "AppearanceLightStatusBars", "AppearanceLightNavigationBars", "AppearanceTransparentCaptionBarBackground", "AppearanceLightCaptionBars" })] int mask);

	[SupportedOSPlatform("android30.0")]
	void Show(int types);
}
