using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/ActionMode", DoNotGenerateAcw = true)]
public abstract class ActionMode : Java.Lang.Object
{
	[Register("android/view/ActionMode$Callback", "", "Android.Views.ActionMode/ICallbackInvoker")]
	public interface ICallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onActionItemClicked", "(Landroid/view/ActionMode;Landroid/view/MenuItem;)Z", "GetOnActionItemClicked_Landroid_view_ActionMode_Landroid_view_MenuItem_Handler:Android.Views.ActionMode/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnActionItemClicked(ActionMode? mode, IMenuItem? item);

		[Register("onCreateActionMode", "(Landroid/view/ActionMode;Landroid/view/Menu;)Z", "GetOnCreateActionMode_Landroid_view_ActionMode_Landroid_view_Menu_Handler:Android.Views.ActionMode/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnCreateActionMode(ActionMode? mode, IMenu? menu);

		[Register("onDestroyActionMode", "(Landroid/view/ActionMode;)V", "GetOnDestroyActionMode_Landroid_view_ActionMode_Handler:Android.Views.ActionMode/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnDestroyActionMode(ActionMode? mode);

		[Register("onPrepareActionMode", "(Landroid/view/ActionMode;Landroid/view/Menu;)Z", "GetOnPrepareActionMode_Landroid_view_ActionMode_Landroid_view_Menu_Handler:Android.Views.ActionMode/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnPrepareActionMode(ActionMode? mode, IMenu? menu);
	}

	[Register("android/view/ActionMode$Callback", DoNotGenerateAcw = true)]
	internal class ICallbackInvoker : Java.Lang.Object, ICallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_ActionMode_Callback = new XAPeerMembers("android/view/ActionMode$Callback", typeof(ICallbackInvoker));

		private static Delegate? cb_onActionItemClicked_OnActionItemClicked_Landroid_view_ActionMode_Landroid_view_MenuItem__Z;

		private static Delegate? cb_onCreateActionMode_OnCreateActionMode_Landroid_view_ActionMode_Landroid_view_Menu__Z;

		private static Delegate? cb_onDestroyActionMode_OnDestroyActionMode_Landroid_view_ActionMode__V;

		private static Delegate? cb_onPrepareActionMode_OnPrepareActionMode_Landroid_view_ActionMode_Landroid_view_Menu__Z;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_ActionMode_Callback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_ActionMode_Callback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_ActionMode_Callback.ManagedPeerType;

		public ICallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnActionItemClicked_Landroid_view_ActionMode_Landroid_view_MenuItem_Handler()
		{
			return new _JniMarshal_PPLL_B(n_OnActionItemClicked_Landroid_view_ActionMode_Landroid_view_MenuItem_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnActionItemClicked_Landroid_view_ActionMode_Landroid_view_MenuItem_(nint jnienv, nint native__this, nint native_mode, nint native_item)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
				IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
				return callback.OnActionItemClicked(mode, item) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnActionItemClicked(ActionMode? mode, IMenuItem? item)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
				return _members_android_view_ActionMode_Callback.InstanceMethods.InvokeAbstractBooleanMethod("onActionItemClicked.(Landroid/view/ActionMode;Landroid/view/MenuItem;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(mode);
				GC.KeepAlive(item);
			}
		}

		private static Delegate GetOnCreateActionMode_Landroid_view_ActionMode_Landroid_view_Menu_Handler()
		{
			return new _JniMarshal_PPLL_B(n_OnCreateActionMode_Landroid_view_ActionMode_Landroid_view_Menu_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnCreateActionMode_Landroid_view_ActionMode_Landroid_view_Menu_(nint jnienv, nint native__this, nint native_mode, nint native_menu)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
				IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
				return callback.OnCreateActionMode(mode, menu) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnCreateActionMode(ActionMode? mode, IMenu? menu)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
				return _members_android_view_ActionMode_Callback.InstanceMethods.InvokeAbstractBooleanMethod("onCreateActionMode.(Landroid/view/ActionMode;Landroid/view/Menu;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(mode);
				GC.KeepAlive(menu);
			}
		}

		private static Delegate GetOnDestroyActionMode_Landroid_view_ActionMode_Handler()
		{
			return new _JniMarshal_PPL_V(n_OnDestroyActionMode_Landroid_view_ActionMode_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDestroyActionMode_Landroid_view_ActionMode_(nint jnienv, nint native__this, nint native_mode)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
				callback.OnDestroyActionMode(mode);
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

		public unsafe void OnDestroyActionMode(ActionMode? mode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				_members_android_view_ActionMode_Callback.InstanceMethods.InvokeAbstractVoidMethod("onDestroyActionMode.(Landroid/view/ActionMode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(mode);
			}
		}

		private static Delegate GetOnPrepareActionMode_Landroid_view_ActionMode_Landroid_view_Menu_Handler()
		{
			return new _JniMarshal_PPLL_B(n_OnPrepareActionMode_Landroid_view_ActionMode_Landroid_view_Menu_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnPrepareActionMode_Landroid_view_ActionMode_Landroid_view_Menu_(nint jnienv, nint native__this, nint native_mode, nint native_menu)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
				IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
				return callback.OnPrepareActionMode(mode, menu) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnPrepareActionMode(ActionMode? mode, IMenu? menu)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
				return _members_android_view_ActionMode_Callback.InstanceMethods.InvokeAbstractBooleanMethod("onPrepareActionMode.(Landroid/view/ActionMode;Landroid/view/Menu;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(mode);
				GC.KeepAlive(menu);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ActionMode", typeof(ActionMode));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ActionMode(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
