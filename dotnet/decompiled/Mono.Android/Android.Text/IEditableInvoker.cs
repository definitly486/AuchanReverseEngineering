using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/Editable", DoNotGenerateAcw = true)]
internal class IEditableInvoker : Java.Lang.Object, IEditable, IGetChars, ICharSequence, IEnumerable<char>, IEnumerable, IJavaObject, IDisposable, IJavaPeerable, ISpannable, ISpanned, IAppendable
{
	private static readonly JniPeerMembers _members_android_text_Editable = new XAPeerMembers("android/text/Editable", typeof(IEditableInvoker));

	private static readonly JniPeerMembers _members_android_text_GetChars = new XAPeerMembers("android/text/GetChars", typeof(IEditableInvoker));

	private static readonly JniPeerMembers _members_android_text_Spannable = new XAPeerMembers("android/text/Spannable", typeof(IEditableInvoker));

	private static readonly JniPeerMembers _members_android_text_Spanned = new XAPeerMembers("android/text/Spanned", typeof(IEditableInvoker));

	private static readonly JniPeerMembers _members_java_lang_Appendable = new XAPeerMembers("java/lang/Appendable", typeof(IEditableInvoker));

	private static readonly JniPeerMembers _members_java_lang_CharSequence = new XAPeerMembers("java/lang/CharSequence", typeof(IEditableInvoker));

	private static Delegate? cb_append_Append_C_Landroid_text_Editable_;

	private static Delegate? cb_append_Append_Ljava_lang_CharSequence_II_Landroid_text_Editable_;

	private static Delegate? cb_append_Append_Ljava_lang_CharSequence__Landroid_text_Editable_;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_clearSpans_ClearSpans_V;

	private static Delegate? cb_delete_Delete_II_Landroid_text_Editable_;

	private static Delegate? cb_getFilters_GetFilters_arrayLandroid_text_InputFilter_;

	private static Delegate? cb_insert_Insert_ILjava_lang_CharSequence_II_Landroid_text_Editable_;

	private static Delegate? cb_insert_Insert_ILjava_lang_CharSequence__Landroid_text_Editable_;

	private static Delegate? cb_replace_Replace_IILjava_lang_CharSequence_II_Landroid_text_Editable_;

	private static Delegate? cb_replace_Replace_IILjava_lang_CharSequence__Landroid_text_Editable_;

	private static Delegate? cb_setFilters_SetFilters_arrayLandroid_text_InputFilter__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_text_Editable;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_text_Editable.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_text_Editable.ManagedPeerType;

	public IEditableInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetAppend_CHandler()
	{
		return new _JniMarshal_PPs_L(n_Append_C);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Append_C(nint jnienv, nint native__this, ushort native_text)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEditable? editable = Java.Lang.Object.GetObject<IEditable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char text = (char)native_text;
			return JNIEnv.ToLocalJniHandle(editable.Append(text));
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

	public unsafe IAppendable? Append(char text)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((ushort)text);
		return Java.Lang.Object.GetObject<IAppendable>(_members_android_text_Editable.InstanceMethods.InvokeAbstractObjectMethod("append.(C)Landroid/text/Editable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAppend_Ljava_lang_CharSequence_IIHandler()
	{
		return new _JniMarshal_PPLII_L(n_Append_Ljava_lang_CharSequence_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Append_Ljava_lang_CharSequence_II(nint jnienv, nint native__this, nint native_text, int start, int end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEditable? editable = Java.Lang.Object.GetObject<IEditable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(editable.Append(text, start, end));
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

	public unsafe IAppendable? Append(ICharSequence? text, int start, int end)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(end);
			return Java.Lang.Object.GetObject<IAppendable>(_members_android_text_Editable.InstanceMethods.InvokeAbstractObjectMethod("append.(Ljava/lang/CharSequence;II)Landroid/text/Editable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
		}
	}

	private static Delegate GetAppend_Ljava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPL_L(n_Append_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Append_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_text)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEditable? editable = Java.Lang.Object.GetObject<IEditable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(editable.Append(text));
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

	public unsafe IAppendable? Append(ICharSequence? text)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IAppendable>(_members_android_text_Editable.InstanceMethods.InvokeAbstractObjectMethod("append.(Ljava/lang/CharSequence;)Landroid/text/Editable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
		}
	}

	private static Delegate GetClearHandler()
	{
		return new _JniMarshal_PP_V(n_Clear);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clear(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IEditable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	public unsafe void Clear()
	{
		_members_android_text_Editable.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
	}

	private static Delegate GetClearSpansHandler()
	{
		return new _JniMarshal_PP_V(n_ClearSpans);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearSpans(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IEditable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearSpans();
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

	public unsafe void ClearSpans()
	{
		_members_android_text_Editable.InstanceMethods.InvokeAbstractVoidMethod("clearSpans.()V", this, null);
	}

	private static Delegate GetDelete_IIHandler()
	{
		return new _JniMarshal_PPII_L(n_Delete_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Delete_II(nint jnienv, nint native__this, int st, int en)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEditable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Delete(st, en));
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

	public unsafe IEditable? Delete(int st, int en)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(st);
		ptr[1] = new JniArgumentValue(en);
		return Java.Lang.Object.GetObject<IEditable>(_members_android_text_Editable.InstanceMethods.InvokeAbstractObjectMethod("delete.(II)Landroid/text/Editable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetFiltersHandler()
	{
		return new _JniMarshal_PP_L(n_GetFilters);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetFilters(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IEditable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetFilters());
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

	public unsafe IInputFilter[]? GetFilters()
	{
		return (IInputFilter[])JNIEnv.GetArray(_members_android_text_Editable.InstanceMethods.InvokeAbstractObjectMethod("getFilters.()[Landroid/text/InputFilter;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(IInputFilter));
	}

	private static Delegate GetInsert_ILjava_lang_CharSequence_IIHandler()
	{
		return new _JniMarshal_PPILII_L(n_Insert_ILjava_lang_CharSequence_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Insert_ILjava_lang_CharSequence_II(nint jnienv, nint native__this, int where, nint native_text, int start, int end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEditable? editable = Java.Lang.Object.GetObject<IEditable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(editable.Insert(where, text, start, end));
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

	public unsafe IEditable? Insert(int where, ICharSequence? text, int start, int end)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(where);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(start);
			ptr[3] = new JniArgumentValue(end);
			return Java.Lang.Object.GetObject<IEditable>(_members_android_text_Editable.InstanceMethods.InvokeAbstractObjectMethod("insert.(ILjava/lang/CharSequence;II)Landroid/text/Editable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
		}
	}

	private static Delegate GetInsert_ILjava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPIL_L(n_Insert_ILjava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Insert_ILjava_lang_CharSequence_(nint jnienv, nint native__this, int where, nint native_text)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEditable? editable = Java.Lang.Object.GetObject<IEditable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(editable.Insert(where, text));
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

	public unsafe IEditable? Insert(int where, ICharSequence? text)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(where);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IEditable>(_members_android_text_Editable.InstanceMethods.InvokeAbstractObjectMethod("insert.(ILjava/lang/CharSequence;)Landroid/text/Editable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
		}
	}

	private static Delegate GetReplace_IILjava_lang_CharSequence_IIHandler()
	{
		return new _JniMarshal_PPIILII_L(n_Replace_IILjava_lang_CharSequence_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Replace_IILjava_lang_CharSequence_II(nint jnienv, nint native__this, int st, int en, nint native_source, int start, int end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEditable? editable = Java.Lang.Object.GetObject<IEditable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence source = Java.Lang.Object.GetObject<ICharSequence>(native_source, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(editable.Replace(st, en, source, start, end));
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

	public unsafe IEditable? Replace(int st, int en, ICharSequence? source, int start, int end)
	{
		nint num = CharSequence.ToLocalJniHandle(source);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(st);
			ptr[1] = new JniArgumentValue(en);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(start);
			ptr[4] = new JniArgumentValue(end);
			return Java.Lang.Object.GetObject<IEditable>(_members_android_text_Editable.InstanceMethods.InvokeAbstractObjectMethod("replace.(IILjava/lang/CharSequence;II)Landroid/text/Editable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(source);
		}
	}

	private static Delegate GetReplace_IILjava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPIIL_L(n_Replace_IILjava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Replace_IILjava_lang_CharSequence_(nint jnienv, nint native__this, int st, int en, nint native_text)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEditable? editable = Java.Lang.Object.GetObject<IEditable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(editable.Replace(st, en, text));
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

	public unsafe IEditable? Replace(int st, int en, ICharSequence? text)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(st);
			ptr[1] = new JniArgumentValue(en);
			ptr[2] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IEditable>(_members_android_text_Editable.InstanceMethods.InvokeAbstractObjectMethod("replace.(IILjava/lang/CharSequence;)Landroid/text/Editable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
		}
	}

	private static Delegate GetSetFilters_arrayLandroid_text_InputFilter_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetFilters_arrayLandroid_text_InputFilter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFilters_arrayLandroid_text_InputFilter_(nint jnienv, nint native__this, nint native_filters)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IEditable? editable = Java.Lang.Object.GetObject<IEditable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IInputFilter[] array = (IInputFilter[])JNIEnv.GetArray(native_filters, JniHandleOwnership.DoNotTransfer, typeof(IInputFilter));
			editable.SetFilters(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_filters);
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

	public unsafe void SetFilters(IInputFilter[]? filters)
	{
		nint num = JNIEnv.NewArray(filters);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_android_text_Editable.InstanceMethods.InvokeAbstractVoidMethod("setFilters.([Landroid/text/InputFilter;)V", this, ptr);
		}
		finally
		{
			if (filters != null)
			{
				JNIEnv.CopyArray(num, filters);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(filters);
		}
	}

	public unsafe void GetChars(int start, int end, char[]? dest, int destoff)
	{
		nint num = JNIEnv.NewArray(dest);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(end);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(destoff);
			_members_android_text_GetChars.InstanceMethods.InvokeAbstractVoidMethod("getChars.(II[CI)V", this, ptr);
		}
		finally
		{
			if (dest != null)
			{
				JNIEnv.CopyArray(num, dest);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(dest);
		}
	}

	public unsafe char CharAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members_java_lang_CharSequence.InstanceMethods.InvokeAbstractCharMethod("charAt.(I)C", this, ptr);
	}

	public unsafe int Length()
	{
		return _members_java_lang_CharSequence.InstanceMethods.InvokeAbstractInt32Method("length.()I", this, null);
	}

	public unsafe ICharSequence SubSequenceFormatted(int start, int end)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(end);
		return Java.Lang.Object.GetObject<ICharSequence>(_members_java_lang_CharSequence.InstanceMethods.InvokeAbstractObjectMethod("subSequence.(II)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public new unsafe string ToString()
	{
		return JNIEnv.GetString(_members_java_lang_CharSequence.InstanceMethods.InvokeAbstractObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<char> GetEnumerator()
	{
		for (int i = 0; i < Length(); i++)
		{
			yield return CharAt(i);
		}
	}

	public unsafe void RemoveSpan(Java.Lang.Object? what)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(what?.Handle ?? IntPtr.Zero);
			_members_android_text_Spannable.InstanceMethods.InvokeAbstractVoidMethod("removeSpan.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(what);
		}
	}

	public unsafe void SetSpan(Java.Lang.Object? what, int start, int end, SpanTypes flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(what?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(end);
			ptr[3] = new JniArgumentValue((int)flags);
			_members_android_text_Spannable.InstanceMethods.InvokeAbstractVoidMethod("setSpan.(Ljava/lang/Object;III)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(what);
		}
	}

	public unsafe int GetSpanEnd(Java.Lang.Object? tag)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
			return _members_android_text_Spanned.InstanceMethods.InvokeAbstractInt32Method("getSpanEnd.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tag);
		}
	}

	public unsafe SpanTypes GetSpanFlags(Java.Lang.Object? tag)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
			return (SpanTypes)_members_android_text_Spanned.InstanceMethods.InvokeAbstractInt32Method("getSpanFlags.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tag);
		}
	}

	public unsafe Java.Lang.Object[]? GetSpans(int start, int end, Class? type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(end);
			ptr[2] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			return (Java.Lang.Object[])JNIEnv.GetArray(_members_android_text_Spanned.InstanceMethods.InvokeAbstractObjectMethod("getSpans.(IILjava/lang/Class;)[Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Object));
		}
		finally
		{
			GC.KeepAlive(type);
		}
	}

	public unsafe int GetSpanStart(Java.Lang.Object? tag)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
			return _members_android_text_Spanned.InstanceMethods.InvokeAbstractInt32Method("getSpanStart.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tag);
		}
	}

	public unsafe int NextSpanTransition(int start, int limit, Class? type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(limit);
			ptr[2] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			return _members_android_text_Spanned.InstanceMethods.InvokeAbstractInt32Method("nextSpanTransition.(IILjava/lang/Class;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(type);
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
