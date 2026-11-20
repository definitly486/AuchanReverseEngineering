using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Text;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Core.Text;

[Register("androidx/core/text/PrecomputedTextCompat", DoNotGenerateAcw = true)]
public class PrecomputedTextCompat : Java.Lang.Object, ISpannable, ISpanned, ICharSequence, IEnumerable<char>, IEnumerable, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/core/text/PrecomputedTextCompat$Params", DoNotGenerateAcw = true)]
	public sealed class Params : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/text/PrecomputedTextCompat$Params", typeof(Params));

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

		public unsafe int BreakStrategy
		{
			[Register("getBreakStrategy", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getBreakStrategy.()I", this, null);
			}
		}

		public unsafe int HyphenationFrequency
		{
			[Register("getHyphenationFrequency", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getHyphenationFrequency.()I", this, null);
			}
		}

		public unsafe ITextDirectionHeuristic? TextDirection
		{
			[Register("getTextDirection", "()Landroid/text/TextDirectionHeuristic;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ITextDirectionHeuristic>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTextDirection.()Landroid/text/TextDirectionHeuristic;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe TextPaint? TextPaint
		{
			[Register("getTextPaint", "()Landroid/text/TextPaint;", "")]
			get
			{
				return Java.Lang.Object.GetObject<TextPaint>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTextPaint.()Landroid/text/TextPaint;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Params(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("equalsWithoutTextDirection", "(Landroidx/core/text/PrecomputedTextCompat$Params;)Z", "")]
		public unsafe bool EqualsWithoutTextDirection(Params? other)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("equalsWithoutTextDirection.(Landroidx/core/text/PrecomputedTextCompat$Params;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(other);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/text/PrecomputedTextCompat", typeof(PrecomputedTextCompat));

	private static Delegate? cb_getParagraphCount_GetParagraphCount_I;

	private static Delegate? cb_charAt_CharAt_I_C;

	private static Delegate? cb_getParagraphEnd_GetParagraphEnd_I_I;

	private static Delegate? cb_getParagraphStart_GetParagraphStart_I_I;

	private static Delegate? cb_getParams_GetParams_Landroidx_core_text_PrecomputedTextCompat_Params_;

	private static Delegate? cb_getSpanEnd_GetSpanEnd_Ljava_lang_Object__I;

	private static Delegate? cb_getSpanFlags_GetSpanFlags_Ljava_lang_Object__I;

	private static Delegate? cb_getSpanStart_GetSpanStart_Ljava_lang_Object__I;

	private static Delegate? cb_getSpans_GetSpans_IILjava_lang_Class__arrayLjava_lang_Object_;

	private static Delegate? cb_length_Length_I;

	private static Delegate? cb_nextSpanTransition_NextSpanTransition_IILjava_lang_Class__I;

	private static Delegate? cb_removeSpan_RemoveSpan_Ljava_lang_Object__V;

	private static Delegate? cb_setSpan_SetSpan_Ljava_lang_Object_III_V;

	private static Delegate? cb_subSequence_SubSequence_II_Ljava_lang_CharSequence_;

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

	public unsafe virtual int ParagraphCount
	{
		[Register("getParagraphCount", "()I", "GetGetParagraphCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getParagraphCount.()I", this, null);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<char> GetEnumerator()
	{
		throw new NotImplementedException();
	}

	protected PrecomputedTextCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetParagraphCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetParagraphCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetParagraphCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<PrecomputedTextCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ParagraphCount;
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

	private static Delegate GetCharAt_IHandler()
	{
		return new global::_JniMarshal_PPI_s(n_CharAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static ushort n_CharAt_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<PrecomputedTextCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CharAt(index);
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
	public unsafe virtual char CharAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members.InstanceMethods.InvokeVirtualCharMethod("charAt.(I)C", this, ptr);
	}

	[Register("create", "(Ljava/lang/CharSequence;Landroidx/core/text/PrecomputedTextCompat$Params;)Landroidx/core/text/PrecomputedTextCompat;", "")]
	public unsafe static PrecomputedTextCompat? Create(ICharSequence? text, Params? @params)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<PrecomputedTextCompat>(_members.StaticMethods.InvokeObjectMethod("create.(Ljava/lang/CharSequence;Landroidx/core/text/PrecomputedTextCompat$Params;)Landroidx/core/text/PrecomputedTextCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
			GC.KeepAlive(@params);
		}
	}

	public static PrecomputedTextCompat? Create(string? text, Params? @params)
	{
		Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
		PrecomputedTextCompat? result = Create(obj, @params);
		obj?.Dispose();
		return result;
	}

	private static Delegate GetGetParagraphEnd_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_GetParagraphEnd_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetParagraphEnd_I(nint jnienv, nint native__this, int paraIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<PrecomputedTextCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetParagraphEnd(paraIndex);
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

	[Register("getParagraphEnd", "(I)I", "GetGetParagraphEnd_IHandler")]
	public unsafe virtual int GetParagraphEnd(int paraIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(paraIndex);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getParagraphEnd.(I)I", this, ptr);
	}

	private static Delegate GetGetParagraphStart_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_GetParagraphStart_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetParagraphStart_I(nint jnienv, nint native__this, int paraIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<PrecomputedTextCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetParagraphStart(paraIndex);
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

	[Register("getParagraphStart", "(I)I", "GetGetParagraphStart_IHandler")]
	public unsafe virtual int GetParagraphStart(int paraIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(paraIndex);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getParagraphStart.(I)I", this, ptr);
	}

	private static Delegate GetGetParamsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetParams);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetParams(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PrecomputedTextCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetParams());
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

	[Register("getParams", "()Landroidx/core/text/PrecomputedTextCompat$Params;", "GetGetParamsHandler")]
	public unsafe virtual Params? GetParams()
	{
		return Java.Lang.Object.GetObject<Params>(_members.InstanceMethods.InvokeVirtualObjectMethod("getParams.()Landroidx/core/text/PrecomputedTextCompat$Params;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetSpanEnd_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetSpanEnd_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSpanEnd_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PrecomputedTextCompat? precomputedTextCompat = Java.Lang.Object.GetObject<PrecomputedTextCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object tag = Java.Lang.Object.GetObject<Java.Lang.Object>(native_tag, JniHandleOwnership.DoNotTransfer);
			return precomputedTextCompat.GetSpanEnd(tag);
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
	public unsafe virtual int GetSpanEnd(Java.Lang.Object? tag)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSpanEnd.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tag);
		}
	}

	private static Delegate GetGetSpanFlags_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetSpanFlags_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSpanFlags_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PrecomputedTextCompat? precomputedTextCompat = Java.Lang.Object.GetObject<PrecomputedTextCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object tag = Java.Lang.Object.GetObject<Java.Lang.Object>(native_tag, JniHandleOwnership.DoNotTransfer);
			return (int)precomputedTextCompat.GetSpanFlags(tag);
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
	public unsafe virtual SpanTypes GetSpanFlags(Java.Lang.Object? tag)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
			return (SpanTypes)_members.InstanceMethods.InvokeVirtualInt32Method("getSpanFlags.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tag);
		}
	}

	private static Delegate GetGetSpanStart_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetSpanStart_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSpanStart_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PrecomputedTextCompat? precomputedTextCompat = Java.Lang.Object.GetObject<PrecomputedTextCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object tag = Java.Lang.Object.GetObject<Java.Lang.Object>(native_tag, JniHandleOwnership.DoNotTransfer);
			return precomputedTextCompat.GetSpanStart(tag);
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
	public unsafe virtual int GetSpanStart(Java.Lang.Object? tag)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSpanStart.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tag);
		}
	}

	private static Delegate GetGetSpans_IILjava_lang_Class_Handler()
	{
		return new global::_JniMarshal_PPIIL_L(n_GetSpans_IILjava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSpans_IILjava_lang_Class_(nint jnienv, nint native__this, int start, int end, nint native_type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PrecomputedTextCompat? precomputedTextCompat = Java.Lang.Object.GetObject<PrecomputedTextCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class type = Java.Lang.Object.GetObject<Class>(native_type, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(precomputedTextCompat.GetSpans(start, end, type));
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
	public unsafe virtual Java.Lang.Object[]? GetSpans(int start, int end, Class? type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(end);
			ptr[2] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			return (Java.Lang.Object[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getSpans.(IILjava/lang/Class;)[Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Object));
		}
		finally
		{
			GC.KeepAlive(type);
		}
	}

	[Register("getTextFuture", "(Ljava/lang/CharSequence;Landroidx/core/text/PrecomputedTextCompat$Params;Ljava/util/concurrent/Executor;)Ljava/util/concurrent/Future;", "")]
	public unsafe static IFuture? GetTextFuture(ICharSequence? charSequence, Params? @params, IExecutor? executor)
	{
		nint num = CharSequence.ToLocalJniHandle(charSequence);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			return Java.Lang.Object.GetObject<IFuture>(_members.StaticMethods.InvokeObjectMethod("getTextFuture.(Ljava/lang/CharSequence;Landroidx/core/text/PrecomputedTextCompat$Params;Ljava/util/concurrent/Executor;)Ljava/util/concurrent/Future;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(charSequence);
			GC.KeepAlive(@params);
			GC.KeepAlive(executor);
		}
	}

	public static IFuture? GetTextFuture(string? charSequence, Params? @params, IExecutor? executor)
	{
		Java.Lang.String obj = ((charSequence == null) ? null : new Java.Lang.String(charSequence));
		IFuture? textFuture = GetTextFuture(obj, @params, executor);
		obj?.Dispose();
		return textFuture;
	}

	private static Delegate GetLengthHandler()
	{
		return new global::_JniMarshal_PP_I(n_Length);
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
			return Java.Lang.Object.GetObject<PrecomputedTextCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Length();
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
		return new global::_JniMarshal_PPIIL_I(n_NextSpanTransition_IILjava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_NextSpanTransition_IILjava_lang_Class_(nint jnienv, nint native__this, int start, int limit, nint native_type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PrecomputedTextCompat? precomputedTextCompat = Java.Lang.Object.GetObject<PrecomputedTextCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class type = Java.Lang.Object.GetObject<Class>(native_type, JniHandleOwnership.DoNotTransfer);
			return precomputedTextCompat.NextSpanTransition(start, limit, type);
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
	public unsafe virtual int NextSpanTransition(int start, int limit, Class? type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(limit);
			ptr[2] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("nextSpanTransition.(IILjava/lang/Class;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(type);
		}
	}

	private static Delegate GetRemoveSpan_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveSpan_Ljava_lang_Object_);
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
			PrecomputedTextCompat? precomputedTextCompat = Java.Lang.Object.GetObject<PrecomputedTextCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			precomputedTextCompat.RemoveSpan(what);
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

	private static Delegate GetSetSpan_Ljava_lang_Object_IIIHandler()
	{
		return new global::_JniMarshal_PPLIII_V(n_SetSpan_Ljava_lang_Object_III);
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
			PrecomputedTextCompat? precomputedTextCompat = Java.Lang.Object.GetObject<PrecomputedTextCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object what = Java.Lang.Object.GetObject<Java.Lang.Object>(native_what, JniHandleOwnership.DoNotTransfer);
			precomputedTextCompat.SetSpan(what, start, end, (SpanTypes)native_flags);
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
		return new global::_JniMarshal_PPII_L(n_SubSequence_II);
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
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<PrecomputedTextCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubSequenceFormatted(start, end));
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

	public string? SubSequence(int start, int end)
	{
		return SubSequenceFormatted(start, end)?.ToString();
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
