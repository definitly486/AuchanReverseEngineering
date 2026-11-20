using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Text.Method;

[Register("android/text/method/BaseKeyListener", DoNotGenerateAcw = true)]
public abstract class BaseKeyListener : MetaKeyKeyListener, IKeyListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/method/BaseKeyListener", typeof(BaseKeyListener));

	private static Delegate? cb_onKeyOther_OnKeyOther_Landroid_view_View_Landroid_text_Editable_Landroid_view_KeyEvent__Z;

	private static Delegate? cb_getInputType_GetInputType_I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public abstract InputTypes InputType
	{
		[Register("getInputType", "()I", "GetGetInputTypeHandler")]
		get;
	}

	protected BaseKeyListener(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetOnKeyOther_Landroid_view_View_Landroid_text_Editable_Landroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPLLL_B(n_OnKeyOther_Landroid_view_View_Landroid_text_Editable_Landroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKeyOther_Landroid_view_View_Landroid_text_Editable_Landroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_view, nint native_content, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseKeyListener? baseKeyListener = Java.Lang.Object.GetObject<BaseKeyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			IEditable content = Java.Lang.Object.GetObject<IEditable>(native_content, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return baseKeyListener.OnKeyOther(view, content, e) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onKeyOther", "(Landroid/view/View;Landroid/text/Editable;Landroid/view/KeyEvent;)Z", "GetOnKeyOther_Landroid_view_View_Landroid_text_Editable_Landroid_view_KeyEvent_Handler")]
	public unsafe virtual bool OnKeyOther(View? view, IEditable? content, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((content == null) ? IntPtr.Zero : ((Java.Lang.Object)content).Handle);
			ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onKeyOther.(Landroid/view/View;Landroid/text/Editable;Landroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(content);
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetGetInputTypeHandler()
	{
		return new _JniMarshal_PP_I(n_GetInputType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInputType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<BaseKeyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputType;
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
