using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/CompoundButton", DoNotGenerateAcw = true)]
public abstract class CompoundButton : Button, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("android/widget/CompoundButton$OnCheckedChangeListener", "", "Android.Widget.CompoundButton/IOnCheckedChangeListenerInvoker")]
	public interface IOnCheckedChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCheckedChanged", "(Landroid/widget/CompoundButton;Z)V", "GetOnCheckedChanged_Landroid_widget_CompoundButton_ZHandler:Android.Widget.CompoundButton/IOnCheckedChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnCheckedChanged(CompoundButton buttonView, bool isChecked);
	}

	[Register("android/widget/CompoundButton$OnCheckedChangeListener", DoNotGenerateAcw = true)]
	internal class IOnCheckedChangeListenerInvoker : Java.Lang.Object, IOnCheckedChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_widget_CompoundButton_OnCheckedChangeListener = new XAPeerMembers("android/widget/CompoundButton$OnCheckedChangeListener", typeof(IOnCheckedChangeListenerInvoker));

		private static Delegate? cb_onCheckedChanged_OnCheckedChanged_Landroid_widget_CompoundButton_Z_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_widget_CompoundButton_OnCheckedChangeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_widget_CompoundButton_OnCheckedChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_widget_CompoundButton_OnCheckedChangeListener.ManagedPeerType;

		public IOnCheckedChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnCheckedChanged_Landroid_widget_CompoundButton_Z(nint jnienv, nint native__this, nint native_buttonView, sbyte native_isChecked)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnCheckedChangeListener? onCheckedChangeListener = Java.Lang.Object.GetObject<IOnCheckedChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CompoundButton buttonView = Java.Lang.Object.GetObject<CompoundButton>(native_buttonView, JniHandleOwnership.DoNotTransfer);
				bool isChecked = native_isChecked != 0;
				onCheckedChangeListener.OnCheckedChanged(buttonView, isChecked);
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

		public unsafe void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(buttonView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(isChecked ? ((sbyte)1) : ((sbyte)0));
				_members_android_widget_CompoundButton_OnCheckedChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onCheckedChanged.(Landroid/widget/CompoundButton;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(buttonView);
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
		private static void n_OnCheckedChanged_Landroid_widget_CompoundButton_Z_mm_wrapper(nint jnienv, nint native__this, nint native_buttonView, sbyte native_isChecked)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnCheckedChanged_Landroid_widget_CompoundButton_Z(jnienv, native__this, native_buttonView, native_isChecked);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class CheckedChangeEventArgs : EventArgs
	{
		private bool isChecked;

		public bool IsChecked => isChecked;

		public CheckedChangeEventArgs(bool isChecked)
		{
			this.isChecked = isChecked;
		}
	}

	[Register("mono/android/widget/CompoundButton_OnCheckedChangeListenerImplementor")]
	internal sealed class IOnCheckedChangeListenerImplementor : Java.Lang.Object, IOnCheckedChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public EventHandler<CheckedChangeEventArgs>? Handler;

		public unsafe IOnCheckedChangeListenerImplementor()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
		{
			Handler?.Invoke(buttonView, new CheckedChangeEventArgs(isChecked));
		}

		internal static bool __IsEmpty(IOnCheckedChangeListenerImplementor value)
		{
			return value.Handler == null;
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/CompoundButton", typeof(CompoundButton));

	private static Delegate? cb_isChecked_IsChecked_Z;

	private static Delegate? cb_setChecked_SetChecked_Z_V;

	private static Delegate? cb_setButtonDrawable_SetButtonDrawable_I_V;

	private static Delegate? cb_setOnCheckedChangeListener_SetOnCheckedChangeListener_Landroid_widget_CompoundButton_OnCheckedChangeListener__V;

	private WeakReference? weak_implementor_SetOnCheckedChangeListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual bool Checked
	{
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isChecked.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setChecked.(Z)V", this, ptr);
		}
	}

	public event EventHandler<CheckedChangeEventArgs> CheckedChange
	{
		add
		{
			EventHelper.AddEventHandler<IOnCheckedChangeListener, IOnCheckedChangeListenerImplementor>(ref weak_implementor_SetOnCheckedChangeListener, __CreateIOnCheckedChangeListenerImplementor, SetOnCheckedChangeListener, delegate(IOnCheckedChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<CheckedChangeEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnCheckedChangeListener, IOnCheckedChangeListenerImplementor>(ref weak_implementor_SetOnCheckedChangeListener, IOnCheckedChangeListenerImplementor.__IsEmpty, delegate
			{
				SetOnCheckedChangeListener(null);
			}, delegate(IOnCheckedChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<CheckedChangeEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected CompoundButton(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe CompoundButton(Context? context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(defStyleRes);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	public unsafe CompoundButton(Context? context, IAttributeSet? attrs, int defStyleAttr)
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

	public unsafe CompoundButton(Context? context, IAttributeSet? attrs)
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

	public unsafe CompoundButton(Context? context)
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

	private static Delegate GetIsCheckedHandler()
	{
		return new _JniMarshal_PP_B(n_IsChecked);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsChecked(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CompoundButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Checked ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetChecked_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetChecked_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetChecked_Z(nint jnienv, nint native__this, sbyte native__checked)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CompoundButton? compoundButton = Java.Lang.Object.GetObject<CompoundButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool flag = native__checked != 0;
			compoundButton.Checked = flag;
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

	private static Delegate GetSetButtonDrawable_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetButtonDrawable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetButtonDrawable_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<CompoundButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetButtonDrawable(resId);
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

	public unsafe virtual void SetButtonDrawable(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setButtonDrawable.(I)V", this, ptr);
	}

	private static Delegate GetSetOnCheckedChangeListener_Landroid_widget_CompoundButton_OnCheckedChangeListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnCheckedChangeListener_Landroid_widget_CompoundButton_OnCheckedChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnCheckedChangeListener_Landroid_widget_CompoundButton_OnCheckedChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CompoundButton? compoundButton = Java.Lang.Object.GetObject<CompoundButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnCheckedChangeListener onCheckedChangeListener = Java.Lang.Object.GetObject<IOnCheckedChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			compoundButton.SetOnCheckedChangeListener(onCheckedChangeListener);
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

	public unsafe virtual void SetOnCheckedChangeListener(IOnCheckedChangeListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnCheckedChangeListener.(Landroid/widget/CompoundButton$OnCheckedChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private IOnCheckedChangeListenerImplementor __CreateIOnCheckedChangeListenerImplementor()
	{
		return new IOnCheckedChangeListenerImplementor();
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
