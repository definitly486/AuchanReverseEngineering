using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/SpannableStringBuilder", DoNotGenerateAcw = true)]
public class SpannableStringBuilder : Java.Lang.Object, IEditable, IGetChars, ICharSequence, IEnumerable<char>, IEnumerable, IJavaObject, IDisposable, IJavaPeerable, ISpannable, ISpanned, IAppendable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/SpannableStringBuilder", typeof(SpannableStringBuilder));

	private static Delegate? cb_append_Append_C_Landroid_text_SpannableStringBuilder_;

	private static Delegate? cb_append_Append_Ljava_lang_CharSequence_II_Landroid_text_SpannableStringBuilder_;

	private static Delegate? cb_append_Append_Ljava_lang_CharSequence__Landroid_text_SpannableStringBuilder_;

	private static Delegate? cb_charAt_CharAt_I_C;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_clearSpans_ClearSpans_V;

	private static Delegate? cb_delete_Delete_II_Landroid_text_SpannableStringBuilder_;

	private static Delegate? cb_getChars_GetChars_IIarrayCI_V;

	private static Delegate? cb_getFilters_GetFilters_arrayLandroid_text_InputFilter_;

	private static Delegate? cb_getSpanEnd_GetSpanEnd_Ljava_lang_Object__I;

	private static Delegate? cb_getSpanFlags_GetSpanFlags_Ljava_lang_Object__I;

	private static Delegate? cb_getSpans_GetSpans_IILjava_lang_Class__arrayLjava_lang_Object_;

	private static Delegate? cb_getSpanStart_GetSpanStart_Ljava_lang_Object__I;

	private static Delegate? cb_insert_Insert_ILjava_lang_CharSequence_II_Landroid_text_SpannableStringBuilder_;

	private static Delegate? cb_insert_Insert_ILjava_lang_CharSequence__Landroid_text_SpannableStringBuilder_;

	private static Delegate? cb_length_Length_I;

	private static Delegate? cb_nextSpanTransition_NextSpanTransition_IILjava_lang_Class__I;

	private static Delegate? cb_removeSpan_RemoveSpan_Ljava_lang_Object__V;

	private static Delegate? cb_replace_Replace_IILjava_lang_CharSequence_II_Landroid_text_SpannableStringBuilder_;

	private static Delegate? cb_replace_Replace_IILjava_lang_CharSequence__Landroid_text_SpannableStringBuilder_;

	private static Delegate? cb_setFilters_SetFilters_arrayLandroid_text_InputFilter__V;

	private static Delegate? cb_setSpan_SetSpan_Ljava_lang_Object_III_V;

	private static Delegate? cb_subSequence_SubSequence_II_Ljava_lang_CharSequence_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected SpannableStringBuilder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/CharSequence;)V", "")]
	public unsafe SpannableStringBuilder(ICharSequence? text)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/CharSequence;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
		}
	}

	[Register(".ctor", "(Ljava/lang/CharSequence;)V", "")]
	public unsafe SpannableStringBuilder(string? text)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/CharSequence;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
		}
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
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char text = (char)native_text;
			return JNIEnv.ToLocalJniHandle(spannableStringBuilder.Append(text));
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

	[Register("append", "(C)Landroid/text/SpannableStringBuilder;", "GetAppend_CHandler")]
	public unsafe virtual IAppendable? Append(char text)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((ushort)text);
		return Java.Lang.Object.GetObject<IAppendable>(_members.InstanceMethods.InvokeVirtualObjectMethod("append.(C)Landroid/text/SpannableStringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(spannableStringBuilder.Append(text, start, end));
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

	[Register("append", "(Ljava/lang/CharSequence;II)Landroid/text/SpannableStringBuilder;", "GetAppend_Ljava_lang_CharSequence_IIHandler")]
	public unsafe virtual IAppendable? Append(ICharSequence? text, int start, int end)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(end);
			return Java.Lang.Object.GetObject<IAppendable>(_members.InstanceMethods.InvokeVirtualObjectMethod("append.(Ljava/lang/CharSequence;II)Landroid/text/SpannableStringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(spannableStringBuilder.Append(text));
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

	[Register("append", "(Ljava/lang/CharSequence;)Landroid/text/SpannableStringBuilder;", "GetAppend_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual IAppendable? Append(ICharSequence? text)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IAppendable>(_members.InstanceMethods.InvokeVirtualObjectMethod("append.(Ljava/lang/CharSequence;)Landroid/text/SpannableStringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
		}
	}

	private static Delegate GetCharAt_IHandler()
	{
		return new _JniMarshal_PPI_s(n_CharAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static ushort n_CharAt_I(nint jnienv, nint native__this, int where)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CharAt(where);
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

	[Register("charAt", "(I)C", "GetCharAt_IHandler")]
	public unsafe virtual char CharAt(int where)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(where);
		return _members.InstanceMethods.InvokeVirtualCharMethod("charAt.(I)C", this, ptr);
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
			Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	[Register("clear", "()V", "GetClearHandler")]
	public unsafe virtual void Clear()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clear.()V", this, null);
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
			Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearSpans();
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

	[Register("clearSpans", "()V", "GetClearSpansHandler")]
	public unsafe virtual void ClearSpans()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearSpans.()V", this, null);
	}

	private static Delegate GetDelete_IIHandler()
	{
		return new _JniMarshal_PPII_L(n_Delete_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Delete_II(nint jnienv, nint native__this, int start, int end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Delete(start, end));
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

	[Register("delete", "(II)Landroid/text/SpannableStringBuilder;", "GetDelete_IIHandler")]
	public unsafe virtual IEditable? Delete(int start, int end)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(end);
		return Java.Lang.Object.GetObject<IEditable>(_members.InstanceMethods.InvokeVirtualObjectMethod("delete.(II)Landroid/text/SpannableStringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetChars_IIarrayCIHandler()
	{
		return new _JniMarshal_PPIILI_V(n_GetChars_IIarrayCI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetChars_IIarrayCI(nint jnienv, nint native__this, int start, int end, nint native_dest, int destoff)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char[] array = (char[])JNIEnv.GetArray(native_dest, JniHandleOwnership.DoNotTransfer, typeof(char));
			spannableStringBuilder.GetChars(start, end, array, destoff);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_dest);
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

	[Register("getChars", "(II[CI)V", "GetGetChars_IIarrayCIHandler")]
	public unsafe virtual void GetChars(int start, int end, char[]? dest, int destoff)
	{
		nint num = JNIEnv.NewArray(dest);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(end);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(destoff);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getChars.(II[CI)V", this, ptr);
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
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetFilters());
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

	[Register("getFilters", "()[Landroid/text/InputFilter;", "GetGetFiltersHandler")]
	public unsafe virtual IInputFilter[]? GetFilters()
	{
		return (IInputFilter[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getFilters.()[Landroid/text/InputFilter;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(IInputFilter));
	}

	private static Delegate GetGetSpanEnd_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_I(n_GetSpanEnd_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSpanEnd_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_what)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			return spannableStringBuilder.GetSpanEnd(what);
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

	[Register("getSpanEnd", "(Ljava/lang/Object;)I", "GetGetSpanEnd_Ljava_lang_Object_Handler")]
	public unsafe virtual int GetSpanEnd(Java.Lang.Object? what)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(what?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSpanEnd.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(what);
		}
	}

	private static Delegate GetGetSpanFlags_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_I(n_GetSpanFlags_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSpanFlags_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_what)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			return (int)spannableStringBuilder.GetSpanFlags(what);
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

	[Register("getSpanFlags", "(Ljava/lang/Object;)I", "GetGetSpanFlags_Ljava_lang_Object_Handler")]
	public unsafe virtual SpanTypes GetSpanFlags(Java.Lang.Object? what)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(what?.Handle ?? IntPtr.Zero);
			return (SpanTypes)_members.InstanceMethods.InvokeVirtualInt32Method("getSpanFlags.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(what);
		}
	}

	private static Delegate GetGetSpans_IILjava_lang_Class_Handler()
	{
		return new _JniMarshal_PPIIL_L(n_GetSpans_IILjava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSpans_IILjava_lang_Class_(nint jnienv, nint native__this, int queryStart, int queryEnd, nint native_kind)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class kind = Java.Lang.Object.GetObject<Class>(native_kind, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(spannableStringBuilder.GetSpans(queryStart, queryEnd, kind));
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

	[Register("getSpans", "(IILjava/lang/Class;)[Ljava/lang/Object;", "GetGetSpans_IILjava_lang_Class_Handler")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe virtual Java.Lang.Object[]? GetSpans(int queryStart, int queryEnd, Class? kind)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(queryStart);
			ptr[1] = new JniArgumentValue(queryEnd);
			ptr[2] = new JniArgumentValue(kind?.Handle ?? IntPtr.Zero);
			return (Java.Lang.Object[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getSpans.(IILjava/lang/Class;)[Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Object));
		}
		finally
		{
			GC.KeepAlive(kind);
		}
	}

	private static Delegate GetGetSpanStart_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_I(n_GetSpanStart_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSpanStart_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_what)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			return spannableStringBuilder.GetSpanStart(what);
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

	[Register("getSpanStart", "(Ljava/lang/Object;)I", "GetGetSpanStart_Ljava_lang_Object_Handler")]
	public unsafe virtual int GetSpanStart(Java.Lang.Object? what)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(what?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSpanStart.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(what);
		}
	}

	private static Delegate GetInsert_ILjava_lang_CharSequence_IIHandler()
	{
		return new _JniMarshal_PPILII_L(n_Insert_ILjava_lang_CharSequence_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Insert_ILjava_lang_CharSequence_II(nint jnienv, nint native__this, int where, nint native_tb, int start, int end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence tb = Java.Lang.Object.GetObject<ICharSequence>(native_tb, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(spannableStringBuilder.Insert(where, tb, start, end));
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

	[Register("insert", "(ILjava/lang/CharSequence;II)Landroid/text/SpannableStringBuilder;", "GetInsert_ILjava_lang_CharSequence_IIHandler")]
	public unsafe virtual IEditable? Insert(int where, ICharSequence? tb, int start, int end)
	{
		nint num = CharSequence.ToLocalJniHandle(tb);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(where);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(start);
			ptr[3] = new JniArgumentValue(end);
			return Java.Lang.Object.GetObject<IEditable>(_members.InstanceMethods.InvokeVirtualObjectMethod("insert.(ILjava/lang/CharSequence;II)Landroid/text/SpannableStringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tb);
		}
	}

	private static Delegate GetInsert_ILjava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPIL_L(n_Insert_ILjava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Insert_ILjava_lang_CharSequence_(nint jnienv, nint native__this, int where, nint native_tb)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence tb = Java.Lang.Object.GetObject<ICharSequence>(native_tb, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(spannableStringBuilder.Insert(where, tb));
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

	[Register("insert", "(ILjava/lang/CharSequence;)Landroid/text/SpannableStringBuilder;", "GetInsert_ILjava_lang_CharSequence_Handler")]
	public unsafe virtual IEditable? Insert(int where, ICharSequence? tb)
	{
		nint num = CharSequence.ToLocalJniHandle(tb);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(where);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IEditable>(_members.InstanceMethods.InvokeVirtualObjectMethod("insert.(ILjava/lang/CharSequence;)Landroid/text/SpannableStringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tb);
		}
	}

	private static Delegate GetLengthHandler()
	{
		return new _JniMarshal_PP_I(n_Length);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Length(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Length();
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

	[Register("length", "()I", "GetLengthHandler")]
	public unsafe virtual int Length()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("length.()I", this, null);
	}

	private static Delegate GetNextSpanTransition_IILjava_lang_Class_Handler()
	{
		return new _JniMarshal_PPIIL_I(n_NextSpanTransition_IILjava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_NextSpanTransition_IILjava_lang_Class_(nint jnienv, nint native__this, int start, int limit, nint native_kind)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class kind = Java.Lang.Object.GetObject<Class>(native_kind, JniHandleOwnership.DoNotTransfer);
			return spannableStringBuilder.NextSpanTransition(start, limit, kind);
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

	[Register("nextSpanTransition", "(IILjava/lang/Class;)I", "GetNextSpanTransition_IILjava_lang_Class_Handler")]
	public unsafe virtual int NextSpanTransition(int start, int limit, Class? kind)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(limit);
			ptr[2] = new JniArgumentValue(kind?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("nextSpanTransition.(IILjava/lang/Class;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(kind);
		}
	}

	private static Delegate GetRemoveSpan_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_V(n_RemoveSpan_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveSpan_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_what)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			spannableStringBuilder.RemoveSpan(what);
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

	[Register("removeSpan", "(Ljava/lang/Object;)V", "GetRemoveSpan_Ljava_lang_Object_Handler")]
	public unsafe virtual void RemoveSpan(Java.Lang.Object? what)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(what?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeSpan.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(what);
		}
	}

	private static Delegate GetReplace_IILjava_lang_CharSequence_IIHandler()
	{
		return new _JniMarshal_PPIILII_L(n_Replace_IILjava_lang_CharSequence_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Replace_IILjava_lang_CharSequence_II(nint jnienv, nint native__this, int start, int end, nint native_tb, int tbstart, int tbend)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence tb = Java.Lang.Object.GetObject<ICharSequence>(native_tb, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(spannableStringBuilder.Replace(start, end, tb, tbstart, tbend));
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

	[Register("replace", "(IILjava/lang/CharSequence;II)Landroid/text/SpannableStringBuilder;", "GetReplace_IILjava_lang_CharSequence_IIHandler")]
	public unsafe virtual IEditable? Replace(int start, int end, ICharSequence? tb, int tbstart, int tbend)
	{
		nint num = CharSequence.ToLocalJniHandle(tb);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(end);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(tbstart);
			ptr[4] = new JniArgumentValue(tbend);
			return Java.Lang.Object.GetObject<IEditable>(_members.InstanceMethods.InvokeVirtualObjectMethod("replace.(IILjava/lang/CharSequence;II)Landroid/text/SpannableStringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tb);
		}
	}

	private static Delegate GetReplace_IILjava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPIIL_L(n_Replace_IILjava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Replace_IILjava_lang_CharSequence_(nint jnienv, nint native__this, int start, int end, nint native_tb)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence tb = Java.Lang.Object.GetObject<ICharSequence>(native_tb, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(spannableStringBuilder.Replace(start, end, tb));
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

	[Register("replace", "(IILjava/lang/CharSequence;)Landroid/text/SpannableStringBuilder;", "GetReplace_IILjava_lang_CharSequence_Handler")]
	public unsafe virtual IEditable? Replace(int start, int end, ICharSequence? tb)
	{
		nint num = CharSequence.ToLocalJniHandle(tb);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(end);
			ptr[2] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IEditable>(_members.InstanceMethods.InvokeVirtualObjectMethod("replace.(IILjava/lang/CharSequence;)Landroid/text/SpannableStringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tb);
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
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IInputFilter[] array = (IInputFilter[])JNIEnv.GetArray(native_filters, JniHandleOwnership.DoNotTransfer, typeof(IInputFilter));
			spannableStringBuilder.SetFilters(array);
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

	[Register("setFilters", "([Landroid/text/InputFilter;)V", "GetSetFilters_arrayLandroid_text_InputFilter_Handler")]
	public unsafe virtual void SetFilters(IInputFilter[]? filters)
	{
		nint num = JNIEnv.NewArray(filters);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFilters.([Landroid/text/InputFilter;)V", this, ptr);
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

	private static Delegate GetSetSpan_Ljava_lang_Object_IIIHandler()
	{
		return new _JniMarshal_PPLIII_V(n_SetSpan_Ljava_lang_Object_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSpan_Ljava_lang_Object_III(nint jnienv, nint native__this, nint native_what, int start, int end, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SpannableStringBuilder? spannableStringBuilder = Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			spannableStringBuilder.SetSpan(what, start, end, (SpanTypes)native_flags);
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

	[Register("setSpan", "(Ljava/lang/Object;III)V", "GetSetSpan_Ljava_lang_Object_IIIHandler")]
	public unsafe virtual void SetSpan(Java.Lang.Object? what, int start, int end, SpanTypes flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(what?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(end);
			ptr[3] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSpan.(Ljava/lang/Object;III)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(what);
		}
	}

	private static Delegate GetSubSequence_IIHandler()
	{
		return new _JniMarshal_PPII_L(n_SubSequence_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SubSequence_II(nint jnienv, nint native__this, int start, int end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<SpannableStringBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubSequenceFormatted(start, end));
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

	[Register("subSequence", "(II)Ljava/lang/CharSequence;", "GetSubSequence_IIHandler")]
	public unsafe virtual ICharSequence? SubSequenceFormatted(int start, int end)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(end);
		return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("subSequence.(II)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
