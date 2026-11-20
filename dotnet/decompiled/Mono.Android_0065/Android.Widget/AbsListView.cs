using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/AbsListView", DoNotGenerateAcw = true)]
public abstract class AbsListView : AdapterView<IListAdapter>, ITextWatcher, INoCopySpan, IJavaObject, IDisposable, IJavaPeerable, ViewTreeObserver.IOnGlobalLayoutListener
{
	private static Delegate? cb_setAdapter_Landroid_widget_Adapter_;

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/AbsListView", typeof(AbsListView));

	private static Delegate? cb_afterTextChanged_AfterTextChanged_Landroid_text_Editable__V;

	private static Delegate? cb_beforeTextChanged_BeforeTextChanged_Ljava_lang_CharSequence_III_V;

	private static Delegate? cb_onGlobalLayout_OnGlobalLayout_V;

	private static Delegate? cb_onRestoreInstanceState_OnRestoreInstanceState_Landroid_os_Parcelable__V;

	private static Delegate? cb_onSaveInstanceState_OnSaveInstanceState_Landroid_os_Parcelable_;

	private static Delegate? cb_onTextChanged_OnTextChanged_Ljava_lang_CharSequence_III_V;

	public abstract override IListAdapter? Adapter { set; }

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	private static Delegate GetSetAdapter_Landroid_widget_ListAdapter_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetAdapter_Landroid_widget_ListAdapter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAdapter_Landroid_widget_ListAdapter_(nint jnienv, nint native__this, nint native_adapter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AbsListView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Adapter = JavaConvert.FromJniHandle<IListAdapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
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

	protected AbsListView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe AbsListView(Context? context, IAttributeSet? attrs, int defStyleAttr)
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

	public unsafe AbsListView(Context? context, IAttributeSet? attrs)
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

	private static Delegate GetAfterTextChanged_Landroid_text_Editable_Handler()
	{
		return new _JniMarshal_PPL_V(n_AfterTextChanged_Landroid_text_Editable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AfterTextChanged_Landroid_text_Editable_(nint jnienv, nint native__this, nint native_s)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AbsListView? absListView = Java.Lang.Object.GetObject<AbsListView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IEditable s = Java.Lang.Object.GetObject<IEditable>(native_s, JniHandleOwnership.DoNotTransfer);
			absListView.AfterTextChanged(s);
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

	public unsafe virtual void AfterTextChanged(IEditable? s)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((s == null) ? IntPtr.Zero : ((Java.Lang.Object)s).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("afterTextChanged.(Landroid/text/Editable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(s);
		}
	}

	private static Delegate GetBeforeTextChanged_Ljava_lang_CharSequence_IIIHandler()
	{
		return new _JniMarshal_PPLIII_V(n_BeforeTextChanged_Ljava_lang_CharSequence_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_BeforeTextChanged_Ljava_lang_CharSequence_III(nint jnienv, nint native__this, nint native_s, int start, int count, int after)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AbsListView? absListView = Java.Lang.Object.GetObject<AbsListView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence s = Java.Lang.Object.GetObject<ICharSequence>(native_s, JniHandleOwnership.DoNotTransfer);
			absListView.BeforeTextChanged(s, start, count, after);
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

	public unsafe virtual void BeforeTextChanged(ICharSequence? s, int start, int count, int after)
	{
		nint num = CharSequence.ToLocalJniHandle(s);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(count);
			ptr[3] = new JniArgumentValue(after);
			_members.InstanceMethods.InvokeVirtualVoidMethod("beforeTextChanged.(Ljava/lang/CharSequence;III)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(s);
		}
	}

	private static Delegate GetOnGlobalLayoutHandler()
	{
		return new _JniMarshal_PP_V(n_OnGlobalLayout);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnGlobalLayout(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AbsListView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnGlobalLayout();
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

	public unsafe virtual void OnGlobalLayout()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onGlobalLayout.()V", this, null);
	}

	private static Delegate GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler()
	{
		return new _JniMarshal_PPL_V(n_OnRestoreInstanceState_Landroid_os_Parcelable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnRestoreInstanceState_Landroid_os_Parcelable_(nint jnienv, nint native__this, nint native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AbsListView? absListView = Java.Lang.Object.GetObject<AbsListView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
			absListView.OnRestoreInstanceState(state);
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

	public new unsafe virtual void OnRestoreInstanceState(IParcelable? state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((state == null) ? IntPtr.Zero : ((Java.Lang.Object)state).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onRestoreInstanceState.(Landroid/os/Parcelable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetOnSaveInstanceStateHandler()
	{
		return new _JniMarshal_PP_L(n_OnSaveInstanceState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnSaveInstanceState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AbsListView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSaveInstanceState());
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

	public new unsafe virtual IParcelable? OnSaveInstanceState()
	{
		return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSaveInstanceState.()Landroid/os/Parcelable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnTextChanged_Ljava_lang_CharSequence_IIIHandler()
	{
		return new _JniMarshal_PPLIII_V(n_OnTextChanged_Ljava_lang_CharSequence_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnTextChanged_Ljava_lang_CharSequence_III(nint jnienv, nint native__this, nint native_s, int start, int before, int count)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AbsListView? absListView = Java.Lang.Object.GetObject<AbsListView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence s = Java.Lang.Object.GetObject<ICharSequence>(native_s, JniHandleOwnership.DoNotTransfer);
			absListView.OnTextChanged(s, start, before, count);
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

	public unsafe virtual void OnTextChanged(ICharSequence? s, int start, int before, int count)
	{
		nint num = CharSequence.ToLocalJniHandle(s);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(before);
			ptr[3] = new JniArgumentValue(count);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onTextChanged.(Ljava/lang/CharSequence;III)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(s);
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
