using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Widget;

[Register("androidx/constraintlayout/widget/SharedValues", DoNotGenerateAcw = true)]
public class SharedValues : Java.Lang.Object
{
	[Register("androidx/constraintlayout/widget/SharedValues$SharedValuesListener", "", "AndroidX.ConstraintLayout.Widget.SharedValues/ISharedValuesListenerInvoker")]
	public interface ISharedValuesListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onNewValue", "(III)V", "GetOnNewValue_IIIHandler:AndroidX.ConstraintLayout.Widget.SharedValues/ISharedValuesListenerInvoker, Xamarin.AndroidX.ConstraintLayout")]
		void OnNewValue(int p0, int p1, int p2);
	}

	[Register("androidx/constraintlayout/widget/SharedValues$SharedValuesListener", DoNotGenerateAcw = true)]
	internal class ISharedValuesListenerInvoker : Java.Lang.Object, ISharedValuesListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_constraintlayout_widget_SharedValues_SharedValuesListener = new XAPeerMembers("androidx/constraintlayout/widget/SharedValues$SharedValuesListener", typeof(ISharedValuesListenerInvoker));

		private static Delegate? cb_onNewValue_OnNewValue_III_V;

		private static nint java_class_ref => _members_androidx_constraintlayout_widget_SharedValues_SharedValuesListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_constraintlayout_widget_SharedValues_SharedValuesListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_constraintlayout_widget_SharedValues_SharedValuesListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_constraintlayout_widget_SharedValues_SharedValuesListener.ManagedPeerType;

		public ISharedValuesListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnNewValue_IIIHandler()
		{
			return new global::_JniMarshal_PPIII_V(n_OnNewValue_III);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnNewValue_III(nint jnienv, nint native__this, int p0, int p1, int p2)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<ISharedValuesListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnNewValue(p0, p1, p2);
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

		public unsafe void OnNewValue(int p0, int p1, int p2)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue(p2);
			_members_androidx_constraintlayout_widget_SharedValues_SharedValuesListener.InstanceMethods.InvokeAbstractVoidMethod("onNewValue.(III)V", this, ptr);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/SharedValues", typeof(SharedValues));

	private static Delegate? cb_addListener_AddListener_ILandroidx_constraintlayout_widget_SharedValues_SharedValuesListener__V;

	private static Delegate? cb_clearListeners_ClearListeners_V;

	private static Delegate? cb_fireNewValue_FireNewValue_II_V;

	private static Delegate? cb_getValue_GetValue_I_I;

	private static Delegate? cb_removeListener_RemoveListener_Landroidx_constraintlayout_widget_SharedValues_SharedValuesListener__V;

	private static Delegate? cb_removeListener_RemoveListener_ILandroidx_constraintlayout_widget_SharedValues_SharedValuesListener__V;

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

	protected SharedValues(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe SharedValues()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetAddListener_ILandroidx_constraintlayout_widget_SharedValues_SharedValuesListener_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_AddListener_ILandroidx_constraintlayout_widget_SharedValues_SharedValuesListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddListener_ILandroidx_constraintlayout_widget_SharedValues_SharedValuesListener_(nint jnienv, nint native__this, int key, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SharedValues? sharedValues = Java.Lang.Object.GetObject<SharedValues>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISharedValuesListener listener = Java.Lang.Object.GetObject<ISharedValuesListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			sharedValues.AddListener(key, listener);
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

	[Register("addListener", "(ILandroidx/constraintlayout/widget/SharedValues$SharedValuesListener;)V", "GetAddListener_ILandroidx_constraintlayout_widget_SharedValues_SharedValuesListener_Handler")]
	public unsafe virtual void AddListener(int key, ISharedValuesListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addListener.(ILandroidx/constraintlayout/widget/SharedValues$SharedValuesListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetClearListenersHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearListeners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearListeners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SharedValues>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearListeners();
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

	[Register("clearListeners", "()V", "GetClearListenersHandler")]
	public unsafe virtual void ClearListeners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearListeners.()V", this, null);
	}

	private static Delegate GetFireNewValue_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_FireNewValue_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_FireNewValue_II(nint jnienv, nint native__this, int key, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SharedValues>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FireNewValue(key, value);
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

	[Register("fireNewValue", "(II)V", "GetFireNewValue_IIHandler")]
	public unsafe virtual void FireNewValue(int key, int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(key);
		ptr[1] = new JniArgumentValue(value);
		_members.InstanceMethods.InvokeVirtualVoidMethod("fireNewValue.(II)V", this, ptr);
	}

	private static Delegate GetGetValue_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_GetValue_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetValue_I(nint jnienv, nint native__this, int key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SharedValues>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetValue(key);
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

	[Register("getValue", "(I)I", "GetGetValue_IHandler")]
	public unsafe virtual int GetValue(int key)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(key);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getValue.(I)I", this, ptr);
	}

	private static Delegate GetRemoveListener_Landroidx_constraintlayout_widget_SharedValues_SharedValuesListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveListener_Landroidx_constraintlayout_widget_SharedValues_SharedValuesListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveListener_Landroidx_constraintlayout_widget_SharedValues_SharedValuesListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SharedValues? sharedValues = Java.Lang.Object.GetObject<SharedValues>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISharedValuesListener listener = Java.Lang.Object.GetObject<ISharedValuesListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			sharedValues.RemoveListener(listener);
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

	[Register("removeListener", "(Landroidx/constraintlayout/widget/SharedValues$SharedValuesListener;)V", "GetRemoveListener_Landroidx_constraintlayout_widget_SharedValues_SharedValuesListener_Handler")]
	public unsafe virtual void RemoveListener(ISharedValuesListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeListener.(Landroidx/constraintlayout/widget/SharedValues$SharedValuesListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveListener_ILandroidx_constraintlayout_widget_SharedValues_SharedValuesListener_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_RemoveListener_ILandroidx_constraintlayout_widget_SharedValues_SharedValuesListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveListener_ILandroidx_constraintlayout_widget_SharedValues_SharedValuesListener_(nint jnienv, nint native__this, int key, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SharedValues? sharedValues = Java.Lang.Object.GetObject<SharedValues>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISharedValuesListener listener = Java.Lang.Object.GetObject<ISharedValuesListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			sharedValues.RemoveListener(key, listener);
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

	[Register("removeListener", "(ILandroidx/constraintlayout/widget/SharedValues$SharedValuesListener;)V", "GetRemoveListener_ILandroidx_constraintlayout_widget_SharedValues_SharedValuesListener_Handler")]
	public unsafe virtual void RemoveListener(int key, ISharedValuesListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeListener.(ILandroidx/constraintlayout/widget/SharedValues$SharedValuesListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}
}
