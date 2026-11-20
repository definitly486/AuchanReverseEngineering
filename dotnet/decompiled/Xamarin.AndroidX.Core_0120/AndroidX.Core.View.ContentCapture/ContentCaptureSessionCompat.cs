using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Android.Views.Autofill;
using Android.Views.ContentCaptures;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View.ContentCapture;

[Register("androidx/core/view/contentcapture/ContentCaptureSessionCompat", DoNotGenerateAcw = true)]
public class ContentCaptureSessionCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/contentcapture/ContentCaptureSessionCompat", typeof(ContentCaptureSessionCompat));

	private static Delegate? cb_newAutofillId_NewAutofillId_J_Landroid_view_autofill_AutofillId_;

	private static Delegate? cb_newVirtualViewStructure_NewVirtualViewStructure_Landroid_view_autofill_AutofillId_J_Landroidx_core_view_ViewStructureCompat_;

	private static Delegate? cb_notifyViewTextChanged_NotifyViewTextChanged_Landroid_view_autofill_AutofillId_Ljava_lang_CharSequence__V;

	private static Delegate? cb_notifyViewsAppeared_NotifyViewsAppeared_Ljava_util_List__V;

	private static Delegate? cb_notifyViewsDisappeared_NotifyViewsDisappeared_arrayJ_V;

	private static Delegate? cb_toContentCaptureSession_ToContentCaptureSession_Landroid_view_contentcapture_ContentCaptureSession_;

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

	protected ContentCaptureSessionCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetNewAutofillId_JHandler()
	{
		return new global::_JniMarshal_PPJ_L(n_NewAutofillId_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_NewAutofillId_J(nint jnienv, nint native__this, long virtualChildId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContentCaptureSessionCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NewAutofillId(virtualChildId));
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

	[Register("newAutofillId", "(J)Landroid/view/autofill/AutofillId;", "GetNewAutofillId_JHandler")]
	public unsafe virtual AutofillId? NewAutofillId(long virtualChildId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(virtualChildId);
		return Java.Lang.Object.GetObject<AutofillId>(_members.InstanceMethods.InvokeVirtualObjectMethod("newAutofillId.(J)Landroid/view/autofill/AutofillId;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetNewVirtualViewStructure_Landroid_view_autofill_AutofillId_JHandler()
	{
		return new global::_JniMarshal_PPLJ_L(n_NewVirtualViewStructure_Landroid_view_autofill_AutofillId_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_NewVirtualViewStructure_Landroid_view_autofill_AutofillId_J(nint jnienv, nint native__this, nint native_parentId, long virtualId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ContentCaptureSessionCompat? contentCaptureSessionCompat = Java.Lang.Object.GetObject<ContentCaptureSessionCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AutofillId parentId = Java.Lang.Object.GetObject<AutofillId>(native_parentId, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(contentCaptureSessionCompat.NewVirtualViewStructure(parentId, virtualId));
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

	[Register("newVirtualViewStructure", "(Landroid/view/autofill/AutofillId;J)Landroidx/core/view/ViewStructureCompat;", "GetNewVirtualViewStructure_Landroid_view_autofill_AutofillId_JHandler")]
	public unsafe virtual ViewStructureCompat? NewVirtualViewStructure(AutofillId? parentId, long virtualId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(parentId?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(virtualId);
			return Java.Lang.Object.GetObject<ViewStructureCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("newVirtualViewStructure.(Landroid/view/autofill/AutofillId;J)Landroidx/core/view/ViewStructureCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(parentId);
		}
	}

	private static Delegate GetNotifyViewTextChanged_Landroid_view_autofill_AutofillId_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_NotifyViewTextChanged_Landroid_view_autofill_AutofillId_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_NotifyViewTextChanged_Landroid_view_autofill_AutofillId_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_id, nint native_text)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ContentCaptureSessionCompat? contentCaptureSessionCompat = Java.Lang.Object.GetObject<ContentCaptureSessionCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AutofillId id = Java.Lang.Object.GetObject<AutofillId>(native_id, JniHandleOwnership.DoNotTransfer);
			ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			contentCaptureSessionCompat.NotifyViewTextChanged(id, text);
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

	[Register("notifyViewTextChanged", "(Landroid/view/autofill/AutofillId;Ljava/lang/CharSequence;)V", "GetNotifyViewTextChanged_Landroid_view_autofill_AutofillId_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual void NotifyViewTextChanged(AutofillId? id, ICharSequence? text)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("notifyViewTextChanged.(Landroid/view/autofill/AutofillId;Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(id);
			GC.KeepAlive(text);
		}
	}

	public void NotifyViewTextChanged(AutofillId? id, string? text)
	{
		Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
		NotifyViewTextChanged(id, obj);
		obj?.Dispose();
	}

	private static Delegate GetNotifyViewsAppeared_Ljava_util_List_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_NotifyViewsAppeared_Ljava_util_List_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_NotifyViewsAppeared_Ljava_util_List_(nint jnienv, nint native__this, nint native_appearedNodes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ContentCaptureSessionCompat? contentCaptureSessionCompat = Java.Lang.Object.GetObject<ContentCaptureSessionCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<ViewStructure> appearedNodes = JavaList<ViewStructure>.FromJniHandle(native_appearedNodes, JniHandleOwnership.DoNotTransfer);
			contentCaptureSessionCompat.NotifyViewsAppeared(appearedNodes);
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

	[Register("notifyViewsAppeared", "(Ljava/util/List;)V", "GetNotifyViewsAppeared_Ljava_util_List_Handler")]
	public unsafe virtual void NotifyViewsAppeared(IList<ViewStructure>? appearedNodes)
	{
		nint num = JavaList<ViewStructure>.ToLocalJniHandle(appearedNodes);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("notifyViewsAppeared.(Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(appearedNodes);
		}
	}

	private static Delegate GetNotifyViewsDisappeared_arrayJHandler()
	{
		return new global::_JniMarshal_PPL_V(n_NotifyViewsDisappeared_arrayJ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_NotifyViewsDisappeared_arrayJ(nint jnienv, nint native__this, nint native_virtualIds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ContentCaptureSessionCompat? contentCaptureSessionCompat = Java.Lang.Object.GetObject<ContentCaptureSessionCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			long[] array = (long[])JNIEnv.GetArray(native_virtualIds, JniHandleOwnership.DoNotTransfer, typeof(long));
			contentCaptureSessionCompat.NotifyViewsDisappeared(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_virtualIds);
			}
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

	[Register("notifyViewsDisappeared", "([J)V", "GetNotifyViewsDisappeared_arrayJHandler")]
	public unsafe virtual void NotifyViewsDisappeared(long[]? virtualIds)
	{
		nint num = JNIEnv.NewArray(virtualIds);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("notifyViewsDisappeared.([J)V", this, ptr);
		}
		finally
		{
			if (virtualIds != null)
			{
				JNIEnv.CopyArray(num, virtualIds);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(virtualIds);
		}
	}

	private static Delegate GetToContentCaptureSessionHandler()
	{
		return new global::_JniMarshal_PP_L(n_ToContentCaptureSession);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToContentCaptureSession(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContentCaptureSessionCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToContentCaptureSession());
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

	[Register("toContentCaptureSession", "()Landroid/view/contentcapture/ContentCaptureSession;", "GetToContentCaptureSessionHandler")]
	public unsafe virtual ContentCaptureSession? ToContentCaptureSession()
	{
		return Java.Lang.Object.GetObject<ContentCaptureSession>(_members.InstanceMethods.InvokeVirtualObjectMethod("toContentCaptureSession.()Landroid/view/contentcapture/ContentCaptureSession;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("toContentCaptureSessionCompat", "(Landroid/view/contentcapture/ContentCaptureSession;Landroid/view/View;)Landroidx/core/view/contentcapture/ContentCaptureSessionCompat;", "")]
	public unsafe static ContentCaptureSessionCompat? ToContentCaptureSessionCompat(ContentCaptureSession? contentCaptureSession, Android.Views.View? host)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(contentCaptureSession?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(host?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ContentCaptureSessionCompat>(_members.StaticMethods.InvokeObjectMethod("toContentCaptureSessionCompat.(Landroid/view/contentcapture/ContentCaptureSession;Landroid/view/View;)Landroidx/core/view/contentcapture/ContentCaptureSessionCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(contentCaptureSession);
			GC.KeepAlive(host);
		}
	}
}
