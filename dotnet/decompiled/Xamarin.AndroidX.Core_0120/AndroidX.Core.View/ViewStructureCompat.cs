using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/ViewStructureCompat", DoNotGenerateAcw = true)]
public class ViewStructureCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/ViewStructureCompat", typeof(ViewStructureCompat));

	private static Delegate? cb_setClassName_SetClassName_Ljava_lang_String__V;

	private static Delegate? cb_setContentDescription_SetContentDescription_Ljava_lang_CharSequence__V;

	private static Delegate? cb_setDimens_SetDimens_IIIIII_V;

	private static Delegate? cb_setText_SetText_Ljava_lang_CharSequence__V;

	private static Delegate? cb_toViewStructure_ToViewStructure_Landroid_view_ViewStructure_;

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

	protected ViewStructureCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetSetClassName_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetClassName_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetClassName_Ljava_lang_String_(nint jnienv, nint native__this, nint native__string)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewStructureCompat? viewStructureCompat = Java.Lang.Object.GetObject<ViewStructureCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string className = JNIEnv.GetString(native__string, JniHandleOwnership.DoNotTransfer);
			viewStructureCompat.SetClassName(className);
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

	[Register("setClassName", "(Ljava/lang/String;)V", "GetSetClassName_Ljava_lang_String_Handler")]
	public unsafe virtual void SetClassName(string? @string)
	{
		nint num = JNIEnv.NewString(@string);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setClassName.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetContentDescription_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetContentDescription_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_charSequence)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewStructureCompat? viewStructureCompat = Java.Lang.Object.GetObject<ViewStructureCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence contentDescription = Java.Lang.Object.GetObject<ICharSequence>(native_charSequence, JniHandleOwnership.DoNotTransfer);
			viewStructureCompat.SetContentDescription(contentDescription);
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

	[Register("setContentDescription", "(Ljava/lang/CharSequence;)V", "GetSetContentDescription_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual void SetContentDescription(ICharSequence? charSequence)
	{
		nint num = CharSequence.ToLocalJniHandle(charSequence);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setContentDescription.(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(charSequence);
		}
	}

	public void SetContentDescription(string? charSequence)
	{
		Java.Lang.String obj = ((charSequence == null) ? null : new Java.Lang.String(charSequence));
		SetContentDescription(obj);
		obj?.Dispose();
	}

	private static Delegate GetSetDimens_IIIIIIHandler()
	{
		return new global::_JniMarshal_PPIIIIII_V(n_SetDimens_IIIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDimens_IIIIII(nint jnienv, nint native__this, int left, int top, int scrollX, int scrollY, int width, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewStructureCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDimens(left, top, scrollX, scrollY, width, height);
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

	[Register("setDimens", "(IIIIII)V", "GetSetDimens_IIIIIIHandler")]
	public unsafe virtual void SetDimens(int left, int top, int scrollX, int scrollY, int width, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(scrollX);
		ptr[3] = new JniArgumentValue(scrollY);
		ptr[4] = new JniArgumentValue(width);
		ptr[5] = new JniArgumentValue(height);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setDimens.(IIIIII)V", this, ptr);
	}

	private static Delegate GetSetText_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetText_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetText_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_charSequence)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewStructureCompat? viewStructureCompat = Java.Lang.Object.GetObject<ViewStructureCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_charSequence, JniHandleOwnership.DoNotTransfer);
			viewStructureCompat.SetText(text);
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

	[Register("setText", "(Ljava/lang/CharSequence;)V", "GetSetText_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual void SetText(ICharSequence? charSequence)
	{
		nint num = CharSequence.ToLocalJniHandle(charSequence);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setText.(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(charSequence);
		}
	}

	public void SetText(string? charSequence)
	{
		Java.Lang.String obj = ((charSequence == null) ? null : new Java.Lang.String(charSequence));
		SetText(obj);
		obj?.Dispose();
	}

	private static Delegate GetToViewStructureHandler()
	{
		return new global::_JniMarshal_PP_L(n_ToViewStructure);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToViewStructure(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ViewStructureCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToViewStructure());
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

	[Register("toViewStructure", "()Landroid/view/ViewStructure;", "GetToViewStructureHandler")]
	public unsafe virtual ViewStructure? ToViewStructure()
	{
		return Java.Lang.Object.GetObject<ViewStructure>(_members.InstanceMethods.InvokeVirtualObjectMethod("toViewStructure.()Landroid/view/ViewStructure;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("toViewStructureCompat", "(Landroid/view/ViewStructure;)Landroidx/core/view/ViewStructureCompat;", "")]
	public unsafe static ViewStructureCompat? ToViewStructureCompat(ViewStructure? contentCaptureSession)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(contentCaptureSession?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ViewStructureCompat>(_members.StaticMethods.InvokeObjectMethod("toViewStructureCompat.(Landroid/view/ViewStructure;)Landroidx/core/view/ViewStructureCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(contentCaptureSession);
		}
	}
}
