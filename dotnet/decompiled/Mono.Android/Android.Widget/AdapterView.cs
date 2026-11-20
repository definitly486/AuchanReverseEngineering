using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/AdapterView", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "T extends android.widget.Adapter" })]
public abstract class AdapterView : ViewGroup
{
	[Register("android/widget/AdapterView$OnItemClickListener", "", "Android.Widget.AdapterView/IOnItemClickListenerInvoker")]
	public interface IOnItemClickListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onItemClick", "(Landroid/widget/AdapterView;Landroid/view/View;IJ)V", "GetOnItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJHandler:Android.Widget.AdapterView/IOnItemClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnItemClick(AdapterView? parent, View? view, int position, long id);
	}

	[Register("android/widget/AdapterView$OnItemClickListener", DoNotGenerateAcw = true)]
	internal class IOnItemClickListenerInvoker : Java.Lang.Object, IOnItemClickListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_widget_AdapterView_OnItemClickListener = new XAPeerMembers("android/widget/AdapterView$OnItemClickListener", typeof(IOnItemClickListenerInvoker));

		private static Delegate? cb_onItemClick_OnItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJ_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_widget_AdapterView_OnItemClickListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_widget_AdapterView_OnItemClickListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_widget_AdapterView_OnItemClickListener.ManagedPeerType;

		public IOnItemClickListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJ(nint jnienv, nint native__this, nint native_parent, nint native_view, int position, long id)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnItemClickListener? onItemClickListener = Java.Lang.Object.GetObject<IOnItemClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AdapterView parent = Java.Lang.Object.GetObject<AdapterView>(native_parent, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				onItemClickListener.OnItemClick(parent, view, position, id);
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

		public unsafe void OnItemClick(AdapterView? parent, View? view, int position, long id)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(position);
				ptr[3] = new JniArgumentValue(id);
				_members_android_widget_AdapterView_OnItemClickListener.InstanceMethods.InvokeAbstractVoidMethod("onItemClick.(Landroid/widget/AdapterView;Landroid/view/View;IJ)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parent);
				GC.KeepAlive(view);
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
		private static void n_OnItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJ_mm_wrapper(nint jnienv, nint native__this, nint native_parent, nint native_view, int position, long id)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJ(jnienv, native__this, native_parent, native_view, position, id);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class ItemClickEventArgs : EventArgs
	{
		private AdapterView? parent;

		private View? view;

		private int position;

		private long id;

		public ItemClickEventArgs(AdapterView? parent, View? view, int position, long id)
		{
			this.parent = parent;
			this.view = view;
			this.position = position;
			this.id = id;
		}
	}

	[Register("mono/android/widget/AdapterView_OnItemClickListenerImplementor")]
	internal sealed class IOnItemClickListenerImplementor : Java.Lang.Object, IOnItemClickListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<ItemClickEventArgs>? Handler;

		public unsafe IOnItemClickListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnItemClick(AdapterView? parent, View? view, int position, long id)
		{
			Handler?.Invoke(sender, new ItemClickEventArgs(parent, view, position, id));
		}

		internal static bool __IsEmpty(IOnItemClickListenerImplementor value)
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

	[Register("android/widget/AdapterView$OnItemLongClickListener", "", "Android.Widget.AdapterView/IOnItemLongClickListenerInvoker")]
	public interface IOnItemLongClickListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onItemLongClick", "(Landroid/widget/AdapterView;Landroid/view/View;IJ)Z", "GetOnItemLongClick_Landroid_widget_AdapterView_Landroid_view_View_IJHandler:Android.Widget.AdapterView/IOnItemLongClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnItemLongClick(AdapterView? parent, View? view, int position, long id);
	}

	[Register("android/widget/AdapterView$OnItemLongClickListener", DoNotGenerateAcw = true)]
	internal class IOnItemLongClickListenerInvoker : Java.Lang.Object, IOnItemLongClickListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_widget_AdapterView_OnItemLongClickListener = new XAPeerMembers("android/widget/AdapterView$OnItemLongClickListener", typeof(IOnItemLongClickListenerInvoker));

		private static Delegate? cb_onItemLongClick_OnItemLongClick_Landroid_widget_AdapterView_Landroid_view_View_IJ_Z;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_widget_AdapterView_OnItemLongClickListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_widget_AdapterView_OnItemLongClickListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_widget_AdapterView_OnItemLongClickListener.ManagedPeerType;

		public IOnItemLongClickListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnItemLongClick_Landroid_widget_AdapterView_Landroid_view_View_IJ(nint jnienv, nint native__this, nint native_parent, nint native_view, int position, long id)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnItemLongClickListener? onItemLongClickListener = Java.Lang.Object.GetObject<IOnItemLongClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AdapterView parent = Java.Lang.Object.GetObject<AdapterView>(native_parent, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				return onItemLongClickListener.OnItemLongClick(parent, view, position, id) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnItemLongClick(AdapterView? parent, View? view, int position, long id)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(position);
				ptr[3] = new JniArgumentValue(id);
				return _members_android_widget_AdapterView_OnItemLongClickListener.InstanceMethods.InvokeAbstractBooleanMethod("onItemLongClick.(Landroid/widget/AdapterView;Landroid/view/View;IJ)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parent);
				GC.KeepAlive(view);
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
		private static sbyte n_OnItemLongClick_Landroid_widget_AdapterView_Landroid_view_View_IJ_mm_wrapper(nint jnienv, nint native__this, nint native_parent, nint native_view, int position, long id)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnItemLongClick_Landroid_widget_AdapterView_Landroid_view_View_IJ(jnienv, native__this, native_parent, native_view, position, id);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	public class ItemLongClickEventArgs : EventArgs
	{
		private bool handled;

		private AdapterView? parent;

		private View? view;

		private int position;

		private long id;

		public bool Handled => handled;

		public ItemLongClickEventArgs(bool handled, AdapterView? parent, View? view, int position, long id)
		{
			this.handled = handled;
			this.parent = parent;
			this.view = view;
			this.position = position;
			this.id = id;
		}
	}

	[Register("mono/android/widget/AdapterView_OnItemLongClickListenerImplementor")]
	internal sealed class IOnItemLongClickListenerImplementor : Java.Lang.Object, IOnItemLongClickListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<ItemLongClickEventArgs>? Handler;

		public unsafe IOnItemLongClickListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public bool OnItemLongClick(AdapterView? parent, View? view, int position, long id)
		{
			EventHandler<ItemLongClickEventArgs> handler = Handler;
			if (handler == null)
			{
				return false;
			}
			ItemLongClickEventArgs e = new ItemLongClickEventArgs(handled: true, parent, view, position, id);
			handler(sender, e);
			return e.Handled;
		}

		internal static bool __IsEmpty(IOnItemLongClickListenerImplementor value)
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

	[Register("android/widget/AdapterView$OnItemSelectedListener", "", "Android.Widget.AdapterView/IOnItemSelectedListenerInvoker")]
	public interface IOnItemSelectedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onItemSelected", "(Landroid/widget/AdapterView;Landroid/view/View;IJ)V", "GetOnItemSelected_Landroid_widget_AdapterView_Landroid_view_View_IJHandler:Android.Widget.AdapterView/IOnItemSelectedListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnItemSelected(AdapterView? parent, View? view, int position, long id);

		[Register("onNothingSelected", "(Landroid/widget/AdapterView;)V", "GetOnNothingSelected_Landroid_widget_AdapterView_Handler:Android.Widget.AdapterView/IOnItemSelectedListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnNothingSelected(AdapterView? parent);
	}

	[Register("android/widget/AdapterView$OnItemSelectedListener", DoNotGenerateAcw = true)]
	internal class IOnItemSelectedListenerInvoker : Java.Lang.Object, IOnItemSelectedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_widget_AdapterView_OnItemSelectedListener = new XAPeerMembers("android/widget/AdapterView$OnItemSelectedListener", typeof(IOnItemSelectedListenerInvoker));

		private static Delegate? cb_onItemSelected_OnItemSelected_Landroid_widget_AdapterView_Landroid_view_View_IJ_V;

		private static Delegate? cb_onNothingSelected_OnNothingSelected_Landroid_widget_AdapterView__V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_widget_AdapterView_OnItemSelectedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_widget_AdapterView_OnItemSelectedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_widget_AdapterView_OnItemSelectedListener.ManagedPeerType;

		public IOnItemSelectedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnItemSelected_Landroid_widget_AdapterView_Landroid_view_View_IJ(nint jnienv, nint native__this, nint native_parent, nint native_view, int position, long id)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnItemSelectedListener? onItemSelectedListener = Java.Lang.Object.GetObject<IOnItemSelectedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AdapterView parent = Java.Lang.Object.GetObject<AdapterView>(native_parent, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				onItemSelectedListener.OnItemSelected(parent, view, position, id);
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

		public unsafe void OnItemSelected(AdapterView? parent, View? view, int position, long id)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(position);
				ptr[3] = new JniArgumentValue(id);
				_members_android_widget_AdapterView_OnItemSelectedListener.InstanceMethods.InvokeAbstractVoidMethod("onItemSelected.(Landroid/widget/AdapterView;Landroid/view/View;IJ)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parent);
				GC.KeepAlive(view);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnNothingSelected_Landroid_widget_AdapterView_(nint jnienv, nint native__this, nint native_parent)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnItemSelectedListener? onItemSelectedListener = Java.Lang.Object.GetObject<IOnItemSelectedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AdapterView parent = Java.Lang.Object.GetObject<AdapterView>(native_parent, JniHandleOwnership.DoNotTransfer);
				onItemSelectedListener.OnNothingSelected(parent);
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

		public unsafe void OnNothingSelected(AdapterView? parent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				_members_android_widget_AdapterView_OnItemSelectedListener.InstanceMethods.InvokeAbstractVoidMethod("onNothingSelected.(Landroid/widget/AdapterView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parent);
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
		private static void n_OnItemSelected_Landroid_widget_AdapterView_Landroid_view_View_IJ_mm_wrapper(nint jnienv, nint native__this, nint native_parent, nint native_view, int position, long id)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnItemSelected_Landroid_widget_AdapterView_Landroid_view_View_IJ(jnienv, native__this, native_parent, native_view, position, id);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnNothingSelected_Landroid_widget_AdapterView__mm_wrapper(nint jnienv, nint native__this, nint native_parent)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnNothingSelected_Landroid_widget_AdapterView_(jnienv, native__this, native_parent);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class ItemSelectedEventArgs : EventArgs
	{
		private AdapterView? parent;

		private View? view;

		private int position;

		private long id;

		public int Position => position;

		public ItemSelectedEventArgs(AdapterView? parent, View? view, int position, long id)
		{
			this.parent = parent;
			this.view = view;
			this.position = position;
			this.id = id;
		}
	}

	public class NothingSelectedEventArgs : EventArgs
	{
		private AdapterView? parent;

		public NothingSelectedEventArgs(AdapterView? parent)
		{
			this.parent = parent;
		}
	}

	[Register("mono/android/widget/AdapterView_OnItemSelectedListenerImplementor")]
	internal sealed class IOnItemSelectedListenerImplementor : Java.Lang.Object, IOnItemSelectedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<ItemSelectedEventArgs>? OnItemSelectedHandler;

		public EventHandler<NothingSelectedEventArgs>? OnNothingSelectedHandler;

		public unsafe IOnItemSelectedListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnItemSelected(AdapterView? parent, View? view, int position, long id)
		{
			OnItemSelectedHandler?.Invoke(sender, new ItemSelectedEventArgs(parent, view, position, id));
		}

		public void OnNothingSelected(AdapterView? parent)
		{
			OnNothingSelectedHandler?.Invoke(sender, new NothingSelectedEventArgs(parent));
		}

		internal static bool __IsEmpty(IOnItemSelectedListenerImplementor value)
		{
			if (value.OnItemSelectedHandler == null)
			{
				return value.OnNothingSelectedHandler == null;
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/AdapterView", typeof(AdapterView));

	private static Delegate? cb_setAdapter_SetAdapter_Landroid_widget_Adapter__V;

	private static Delegate? cb_onLayout_OnLayout_ZIIII_V;

	private static Delegate? cb_setSelection_SetSelection_I_V;

	private WeakReference? weak_implementor___SetOnItemClickListener;

	private WeakReference? weak_implementor___SetOnItemLongClickListener;

	private WeakReference? weak_implementor___SetOnItemSelectedListener;

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

	public unsafe IOnItemClickListener? OnItemClickListener
	{
		[Register("setOnItemClickListener", "(Landroid/widget/AdapterView$OnItemClickListener;)V", "GetSetOnItemClickListener_Landroid_widget_AdapterView_OnItemClickListener_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOnItemClickListener.(Landroid/widget/AdapterView$OnItemClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe IOnItemLongClickListener? OnItemLongClickListener
	{
		[Register("setOnItemLongClickListener", "(Landroid/widget/AdapterView$OnItemLongClickListener;)V", "GetSetOnItemLongClickListener_Landroid_widget_AdapterView_OnItemLongClickListener_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOnItemLongClickListener.(Landroid/widget/AdapterView$OnItemLongClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe IOnItemSelectedListener? OnItemSelectedListener
	{
		[Register("setOnItemSelectedListener", "(Landroid/widget/AdapterView$OnItemSelectedListener;)V", "GetSetOnItemSelectedListener_Landroid_widget_AdapterView_OnItemSelectedListener_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOnItemSelectedListener.(Landroid/widget/AdapterView$OnItemSelectedListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected abstract Java.Lang.Object? RawAdapter
	{
		[Register("setAdapter", "(Landroid/widget/Adapter;)V", "GetSetAdapter_Landroid_widget_Adapter_Handler")]
		set;
	}

	public event EventHandler<ItemClickEventArgs> ItemClick
	{
		add
		{
			EventHelper.AddEventHandler(ref weak_implementor___SetOnItemClickListener, __CreateIOnItemClickListenerImplementor, delegate(IOnItemClickListener __v)
			{
				OnItemClickListener = __v;
			}, delegate(IOnItemClickListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ItemClickEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnItemClickListener, IOnItemClickListenerImplementor>(ref weak_implementor___SetOnItemClickListener, IOnItemClickListenerImplementor.__IsEmpty, delegate
			{
				OnItemClickListener = null;
			}, delegate(IOnItemClickListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ItemClickEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<ItemLongClickEventArgs> ItemLongClick
	{
		add
		{
			EventHelper.AddEventHandler(ref weak_implementor___SetOnItemLongClickListener, __CreateIOnItemLongClickListenerImplementor, delegate(IOnItemLongClickListener __v)
			{
				OnItemLongClickListener = __v;
			}, delegate(IOnItemLongClickListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ItemLongClickEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnItemLongClickListener, IOnItemLongClickListenerImplementor>(ref weak_implementor___SetOnItemLongClickListener, IOnItemLongClickListenerImplementor.__IsEmpty, delegate
			{
				OnItemLongClickListener = null;
			}, delegate(IOnItemLongClickListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ItemLongClickEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<ItemSelectedEventArgs> ItemSelected
	{
		add
		{
			EventHelper.AddEventHandler(ref weak_implementor___SetOnItemSelectedListener, __CreateIOnItemSelectedListenerImplementor, delegate(IOnItemSelectedListener __v)
			{
				OnItemSelectedListener = __v;
			}, delegate(IOnItemSelectedListenerImplementor __h)
			{
				__h.OnItemSelectedHandler = (EventHandler<ItemSelectedEventArgs>)Delegate.Combine(__h.OnItemSelectedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnItemSelectedListener, IOnItemSelectedListenerImplementor>(ref weak_implementor___SetOnItemSelectedListener, IOnItemSelectedListenerImplementor.__IsEmpty, delegate
			{
				OnItemSelectedListener = null;
			}, delegate(IOnItemSelectedListenerImplementor __h)
			{
				__h.OnItemSelectedHandler = (EventHandler<ItemSelectedEventArgs>)Delegate.Remove(__h.OnItemSelectedHandler, value);
			});
		}
	}

	protected AdapterView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe AdapterView(Context? context, IAttributeSet? attrs, int defStyleAttr)
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

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe AdapterView(Context? context, IAttributeSet? attrs)
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

	private static Delegate GetSetAdapter_Landroid_widget_Adapter_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetAdapter_Landroid_widget_Adapter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAdapter_Landroid_widget_Adapter_(nint jnienv, nint native__this, nint native_adapter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AdapterView? adapterView = Java.Lang.Object.GetObject<AdapterView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object rawAdapter = Java.Lang.Object.GetObject<Java.Lang.Object>(native_adapter, JniHandleOwnership.DoNotTransfer);
			adapterView.RawAdapter = rawAdapter;
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

	private static Delegate GetOnLayout_ZIIIIHandler()
	{
		return new _JniMarshal_PPBIIII_V(n_OnLayout_ZIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLayout_ZIIII(nint jnienv, nint native__this, sbyte native_changed, int left, int top, int right, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AdapterView? adapterView = Java.Lang.Object.GetObject<AdapterView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool changed = native_changed != 0;
			adapterView.OnLayout(changed, left, top, right, bottom);
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

	[Register("onLayout", "(ZIIII)V", "GetOnLayout_ZIIIIHandler")]
	protected unsafe override void OnLayout(bool changed, int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(changed ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(left);
		ptr[2] = new JniArgumentValue(top);
		ptr[3] = new JniArgumentValue(right);
		ptr[4] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onLayout.(ZIIII)V", this, ptr);
	}

	private static Delegate GetSetSelection_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetSelection_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSelection_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AdapterView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSelection(position);
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

	[Register("setSelection", "(I)V", "GetSetSelection_IHandler")]
	public abstract void SetSelection(int position);

	private IOnItemClickListenerImplementor __CreateIOnItemClickListenerImplementor()
	{
		return new IOnItemClickListenerImplementor(this);
	}

	private IOnItemLongClickListenerImplementor __CreateIOnItemLongClickListenerImplementor()
	{
		return new IOnItemLongClickListenerImplementor(this);
	}

	private IOnItemSelectedListenerImplementor __CreateIOnItemSelectedListenerImplementor()
	{
		return new IOnItemSelectedListenerImplementor(this);
	}
}
[Register("android/widget/AdapterView", DoNotGenerateAcw = true)]
public abstract class AdapterView<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> : AdapterView where T : IAdapter
{
	private static nint id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_;

	private static nint id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I;

	protected override Java.Lang.Object RawAdapter
	{
		set
		{
			Adapter = JavaConvert.FromJavaObject<T>(value);
		}
	}

	public abstract T Adapter
	{
		[Register("setAdapter", "(Landroid/widget/Adapter;)V", "GetSetAdapter_Landroid_widget_Adapter_Handler")]
		set;
	}

	public AdapterView(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public AdapterView(Context context, IAttributeSet attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		if (GetType() == typeof(AdapterView<T>))
		{
			if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ == IntPtr.Zero)
			{
				id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ = JNIEnv.GetMethodID(AdapterView.class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;)V");
			}
			SetHandle(JNIEnv.StartCreateInstance(AdapterView.class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, new JValue(context), new JValue(attrs)), JniHandleOwnership.TransferLocalRef);
			JNIEnv.FinishCreateInstance(base.Handle, AdapterView.class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, new JValue(context), new JValue(attrs));
		}
		else
		{
			SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;Landroid/util/AttributeSet;)V", new JValue(context), new JValue(attrs)), JniHandleOwnership.TransferLocalRef);
			JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;)V", new JValue(context), new JValue(attrs));
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public AdapterView(Context context, IAttributeSet attrs, int defStyle)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		if (GetType() == typeof(AdapterView<T>))
		{
			if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I == IntPtr.Zero)
			{
				id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I = JNIEnv.GetMethodID(AdapterView.class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V");
			}
			SetHandle(JNIEnv.StartCreateInstance(AdapterView.class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, new JValue(context), new JValue(attrs), new JValue(defStyle)), JniHandleOwnership.TransferLocalRef);
			JNIEnv.FinishCreateInstance(base.Handle, AdapterView.class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, new JValue(context), new JValue(attrs), new JValue(defStyle));
		}
		else
		{
			SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", new JValue(context), new JValue(attrs), new JValue(defStyle)), JniHandleOwnership.TransferLocalRef);
			JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", new JValue(context), new JValue(attrs), new JValue(defStyle));
		}
	}
}
