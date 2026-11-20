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

[Register("android/widget/RadioGroup", DoNotGenerateAcw = true)]
public class RadioGroup : LinearLayout
{
	[Register("android/widget/RadioGroup$OnCheckedChangeListener", "", "Android.Widget.RadioGroup/IOnCheckedChangeListenerInvoker")]
	public interface IOnCheckedChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCheckedChanged", "(Landroid/widget/RadioGroup;I)V", "GetOnCheckedChanged_Landroid_widget_RadioGroup_IHandler:Android.Widget.RadioGroup/IOnCheckedChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnCheckedChanged(RadioGroup group, int checkedId);
	}

	[Register("android/widget/RadioGroup$OnCheckedChangeListener", DoNotGenerateAcw = true)]
	internal class IOnCheckedChangeListenerInvoker : Java.Lang.Object, IOnCheckedChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_widget_RadioGroup_OnCheckedChangeListener = new XAPeerMembers("android/widget/RadioGroup$OnCheckedChangeListener", typeof(IOnCheckedChangeListenerInvoker));

		private static Delegate? cb_onCheckedChanged_OnCheckedChanged_Landroid_widget_RadioGroup_I_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_widget_RadioGroup_OnCheckedChangeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_widget_RadioGroup_OnCheckedChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_widget_RadioGroup_OnCheckedChangeListener.ManagedPeerType;

		public IOnCheckedChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnCheckedChanged_Landroid_widget_RadioGroup_I(nint jnienv, nint native__this, nint native_group, int checkedId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnCheckedChangeListener? onCheckedChangeListener = Java.Lang.Object.GetObject<IOnCheckedChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RadioGroup radioGroup = Java.Lang.Object.GetObject<RadioGroup>(native_group, JniHandleOwnership.DoNotTransfer);
				onCheckedChangeListener.OnCheckedChanged(radioGroup, checkedId);
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

		public unsafe void OnCheckedChanged(RadioGroup group, int checkedId)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(group?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(checkedId);
				_members_android_widget_RadioGroup_OnCheckedChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onCheckedChanged.(Landroid/widget/RadioGroup;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(group);
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
		private static void n_OnCheckedChanged_Landroid_widget_RadioGroup_I_mm_wrapper(nint jnienv, nint native__this, nint native_group, int checkedId)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnCheckedChanged_Landroid_widget_RadioGroup_I(jnienv, native__this, native_group, checkedId);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class CheckedChangeEventArgs : EventArgs
	{
		private int checkedId;

		public int CheckedId => checkedId;

		public CheckedChangeEventArgs(int checkedId)
		{
			this.checkedId = checkedId;
		}
	}

	[Register("mono/android/widget/RadioGroup_OnCheckedChangeListenerImplementor")]
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

		public void OnCheckedChanged(RadioGroup group, int checkedId)
		{
			Handler?.Invoke(group, new CheckedChangeEventArgs(checkedId));
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/RadioGroup", typeof(RadioGroup));

	private static Delegate? cb_check_Check_I_V;

	private static Delegate? cb_setOnCheckedChangeListener_SetOnCheckedChangeListener_Landroid_widget_RadioGroup_OnCheckedChangeListener__V;

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

	protected RadioGroup(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe RadioGroup(Context? context, IAttributeSet? attrs)
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

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe RadioGroup(Context? context)
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

	private static Delegate GetCheck_IHandler()
	{
		return new _JniMarshal_PPI_V(n_Check_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Check_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RadioGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Check(id);
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

	[Register("check", "(I)V", "GetCheck_IHandler")]
	public unsafe virtual void Check(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("check.(I)V", this, ptr);
	}

	private static Delegate GetSetOnCheckedChangeListener_Landroid_widget_RadioGroup_OnCheckedChangeListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnCheckedChangeListener_Landroid_widget_RadioGroup_OnCheckedChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnCheckedChangeListener_Landroid_widget_RadioGroup_OnCheckedChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RadioGroup? radioGroup = Java.Lang.Object.GetObject<RadioGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnCheckedChangeListener onCheckedChangeListener = Java.Lang.Object.GetObject<IOnCheckedChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			radioGroup.SetOnCheckedChangeListener(onCheckedChangeListener);
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

	[Register("setOnCheckedChangeListener", "(Landroid/widget/RadioGroup$OnCheckedChangeListener;)V", "GetSetOnCheckedChangeListener_Landroid_widget_RadioGroup_OnCheckedChangeListener_Handler")]
	public unsafe virtual void SetOnCheckedChangeListener(IOnCheckedChangeListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnCheckedChangeListener.(Landroid/widget/RadioGroup$OnCheckedChangeListener;)V", this, ptr);
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
}
