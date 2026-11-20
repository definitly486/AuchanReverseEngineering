using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/ViewStub", DoNotGenerateAcw = true)]
public sealed class ViewStub : View
{
	[Register("android/view/ViewStub$OnInflateListener", "", "Android.Views.ViewStub/IOnInflateListenerInvoker")]
	public interface IOnInflateListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onInflate", "(Landroid/view/ViewStub;Landroid/view/View;)V", "GetOnInflate_Landroid_view_ViewStub_Landroid_view_View_Handler:Android.Views.ViewStub/IOnInflateListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnInflate(ViewStub? stub, View? inflated);
	}

	[Register("android/view/ViewStub$OnInflateListener", DoNotGenerateAcw = true)]
	internal class IOnInflateListenerInvoker : Java.Lang.Object, IOnInflateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_ViewStub_OnInflateListener = new XAPeerMembers("android/view/ViewStub$OnInflateListener", typeof(IOnInflateListenerInvoker));

		private static Delegate? cb_onInflate_OnInflate_Landroid_view_ViewStub_Landroid_view_View__V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_ViewStub_OnInflateListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_ViewStub_OnInflateListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_ViewStub_OnInflateListener.ManagedPeerType;

		public IOnInflateListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnInflate_Landroid_view_ViewStub_Landroid_view_View_(nint jnienv, nint native__this, nint native_stub, nint native_inflated)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnInflateListener? onInflateListener = Java.Lang.Object.GetObject<IOnInflateListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewStub stub = Java.Lang.Object.GetObject<ViewStub>(native_stub, JniHandleOwnership.DoNotTransfer);
				View inflated = Java.Lang.Object.GetObject<View>(native_inflated, JniHandleOwnership.DoNotTransfer);
				onInflateListener.OnInflate(stub, inflated);
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

		public unsafe void OnInflate(ViewStub? stub, View? inflated)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(stub?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(inflated?.Handle ?? IntPtr.Zero);
				_members_android_view_ViewStub_OnInflateListener.InstanceMethods.InvokeAbstractVoidMethod("onInflate.(Landroid/view/ViewStub;Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(stub);
				GC.KeepAlive(inflated);
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
		private static void n_OnInflate_Landroid_view_ViewStub_Landroid_view_View__mm_wrapper(nint jnienv, nint native__this, nint native_stub, nint native_inflated)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnInflate_Landroid_view_ViewStub_Landroid_view_View_(jnienv, native__this, native_stub, native_inflated);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class InflateEventArgs : EventArgs
	{
		private View? inflated;

		public View? Inflated => inflated;

		public InflateEventArgs(View? inflated)
		{
			this.inflated = inflated;
		}
	}

	[Register("mono/android/view/ViewStub_OnInflateListenerImplementor")]
	internal sealed class IOnInflateListenerImplementor : Java.Lang.Object, IOnInflateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public EventHandler<InflateEventArgs>? Handler;

		public unsafe IOnInflateListenerImplementor()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		public void OnInflate(ViewStub? stub, View? inflated)
		{
			Handler?.Invoke(stub, new InflateEventArgs(inflated));
		}

		internal static bool __IsEmpty(IOnInflateListenerImplementor value)
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ViewStub", typeof(ViewStub));

	private WeakReference? weak_implementor_SetOnInflateListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public event EventHandler<InflateEventArgs> InflateEvent
	{
		add
		{
			EventHelper.AddEventHandler<IOnInflateListener, IOnInflateListenerImplementor>(ref weak_implementor_SetOnInflateListener, __CreateIOnInflateListenerImplementor, SetOnInflateListener, delegate(IOnInflateListenerImplementor __h)
			{
				__h.Handler = (EventHandler<InflateEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnInflateListener, IOnInflateListenerImplementor>(ref weak_implementor_SetOnInflateListener, IOnInflateListenerImplementor.__IsEmpty, delegate
			{
				SetOnInflateListener(null);
			}, delegate(IOnInflateListenerImplementor __h)
			{
				__h.Handler = (EventHandler<InflateEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	internal ViewStub(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe ViewStub(Context? context, IAttributeSet? attrs, int defStyleAttr)
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

	public unsafe ViewStub(Context? context, IAttributeSet? attrs)
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

	public unsafe void SetOnInflateListener(IOnInflateListener? inflateListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((inflateListener == null) ? IntPtr.Zero : ((Java.Lang.Object)inflateListener).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setOnInflateListener.(Landroid/view/ViewStub$OnInflateListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(inflateListener);
		}
	}

	private IOnInflateListenerImplementor __CreateIOnInflateListenerImplementor()
	{
		return new IOnInflateListenerImplementor();
	}
}
