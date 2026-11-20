using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Parser;

[Register("androidx/constraintlayout/core/parser/CLElement", DoNotGenerateAcw = true)]
public class CLElement : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/parser/CLElement", typeof(CLElement));

	private static Delegate? cb_getContainer_GetContainer_Landroidx_constraintlayout_core_parser_CLElement_;

	private static Delegate? cb_getDebugName_GetDebugName_Ljava_lang_String_;

	private static Delegate? cb_getEnd_GetEnd_J;

	private static Delegate? cb_setEnd_SetEnd_J_V;

	private static Delegate? cb_getFloat_GetFloat_F;

	private static Delegate? cb_hasContent_HasContent_Z;

	private static Delegate? cb_getInt_GetInt_I;

	private static Delegate? cb_isDone_IsDone_Z;

	private static Delegate? cb_isStarted_IsStarted_Z;

	private static Delegate? cb_getLine_GetLine_I;

	private static Delegate? cb_setLine_SetLine_I_V;

	private static Delegate? cb_getStart_GetStart_J;

	private static Delegate? cb_setStart_SetStart_J_V;

	private static Delegate? cb_getStrClass_GetStrClass_Ljava_lang_String_;

	private static Delegate? cb_addIndent_AddIndent_Ljava_lang_StringBuilder_I_V;

	private static Delegate? cb_clone_Clone_Landroidx_constraintlayout_core_parser_CLElement_;

	private static Delegate? cb_content_Content_Ljava_lang_String_;

	private static Delegate? cb_notStarted_NotStarted_Z;

	private static Delegate? cb_setContainer_SetContainer_Landroidx_constraintlayout_core_parser_CLContainer__V;

	private static Delegate? cb_toFormattedJSON_ToFormattedJSON_II_Ljava_lang_String_;

	private static Delegate? cb_toJSON_ToJSON_Ljava_lang_String_;

	[Register("mContainer")]
	protected CLContainer? MContainer
	{
		get
		{
			return Java.Lang.Object.GetObject<CLContainer>(_members.InstanceFields.GetObjectValue("mContainer.Landroidx/constraintlayout/core/parser/CLContainer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mContainer.Landroidx/constraintlayout/core/parser/CLContainer;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mEnd")]
	protected long MEnd
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("mEnd.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mEnd.J", this, value);
		}
	}

	[Register("mStart")]
	protected long MStart
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("mStart.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mStart.J", this, value);
		}
	}

	[Register("sBaseIndent")]
	protected static int SBaseIndent
	{
		get
		{
			return _members.StaticFields.GetInt32Value("sBaseIndent.I");
		}
		set
		{
			_members.StaticFields.SetValue("sBaseIndent.I", value);
		}
	}

	[Register("sMaxLine")]
	protected static int SMaxLine
	{
		get
		{
			return _members.StaticFields.GetInt32Value("sMaxLine.I");
		}
		set
		{
			_members.StaticFields.SetValue("sMaxLine.I", value);
		}
	}

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

	public unsafe virtual CLElement? Container
	{
		[Register("getContainer", "()Landroidx/constraintlayout/core/parser/CLElement;", "GetGetContainerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<CLElement>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContainer.()Landroidx/constraintlayout/core/parser/CLElement;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected unsafe virtual string? DebugName
	{
		[Register("getDebugName", "()Ljava/lang/String;", "GetGetDebugNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getDebugName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual long End
	{
		[Register("getEnd", "()J", "GetGetEndHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getEnd.()J", this, null);
		}
		[Register("setEnd", "(J)V", "GetSetEnd_JHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEnd.(J)V", this, ptr);
		}
	}

	public unsafe virtual float Float
	{
		[Register("getFloat", "()F", "GetGetFloatHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getFloat.()F", this, null);
		}
	}

	public unsafe virtual bool HasContent
	{
		[Register("hasContent", "()Z", "GetHasContentHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasContent.()Z", this, null);
		}
	}

	public unsafe virtual int Int
	{
		[Register("getInt", "()I", "GetGetIntHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInt.()I", this, null);
		}
	}

	public unsafe virtual bool IsDone
	{
		[Register("isDone", "()Z", "GetIsDoneHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDone.()Z", this, null);
		}
	}

	public unsafe virtual bool IsStarted
	{
		[Register("isStarted", "()Z", "GetIsStartedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isStarted.()Z", this, null);
		}
	}

	public unsafe virtual int Line
	{
		[Register("getLine", "()I", "GetGetLineHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLine.()I", this, null);
		}
		[Register("setLine", "(I)V", "GetSetLine_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLine.(I)V", this, ptr);
		}
	}

	public unsafe virtual long Start
	{
		[Register("getStart", "()J", "GetGetStartHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getStart.()J", this, null);
		}
		[Register("setStart", "(J)V", "GetSetStart_JHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStart.(J)V", this, ptr);
		}
	}

	protected unsafe virtual string? StrClass
	{
		[Register("getStrClass", "()Ljava/lang/String;", "GetGetStrClassHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getStrClass.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected CLElement(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "([C)V", "")]
	public unsafe CLElement(char[]? content)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewArray(content);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("([C)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("([C)V", this, ptr);
		}
		finally
		{
			if (content != null)
			{
				JNIEnv.CopyArray(num, content);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(content);
		}
	}

	private static Delegate GetGetContainerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetContainer);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContainer(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Container);
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

	private static Delegate GetGetDebugNameHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDebugName);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDebugName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DebugName);
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

	private static Delegate GetGetEndHandler()
	{
		return new global::_JniMarshal_PP_J(n_GetEnd);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetEnd(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).End;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetEnd_JHandler()
	{
		return new global::_JniMarshal_PPJ_V(n_SetEnd_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEnd_J(nint jnienv, nint native__this, long end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).End = end;
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

	private static Delegate GetGetFloatHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetFloat);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetFloat(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Float;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetHasContentHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasContent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasContent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasContent ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetIntHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetInt);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInt(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Int;
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

	private static Delegate GetIsDoneHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsDone);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDone(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDone ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsStartedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsStarted);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsStarted(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsStarted ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetLineHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLine);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLine(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Line;
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

	private static Delegate GetSetLine_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetLine_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLine_I(nint jnienv, nint native__this, int line)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Line = line;
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

	private static Delegate GetGetStartHandler()
	{
		return new global::_JniMarshal_PP_J(n_GetStart);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetStart(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Start;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetStart_JHandler()
	{
		return new global::_JniMarshal_PPJ_V(n_SetStart_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStart_J(nint jnienv, nint native__this, long start)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Start = start;
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

	private static Delegate GetGetStrClassHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStrClass);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStrClass(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrClass);
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

	private static Delegate GetAddIndent_Ljava_lang_StringBuilder_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_AddIndent_Ljava_lang_StringBuilder_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddIndent_Ljava_lang_StringBuilder_I(nint jnienv, nint native__this, nint native_builder, int indent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CLElement? cLElement = Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			StringBuilder builder = Java.Lang.Object.GetObject<StringBuilder>(native_builder, JniHandleOwnership.DoNotTransfer);
			cLElement.AddIndent(builder, indent);
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

	[Register("addIndent", "(Ljava/lang/StringBuilder;I)V", "GetAddIndent_Ljava_lang_StringBuilder_IHandler")]
	protected unsafe virtual void AddIndent(StringBuilder? builder, int indent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(indent);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addIndent.(Ljava/lang/StringBuilder;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(builder);
		}
	}

	private static Delegate GetCloneHandler()
	{
		return new global::_JniMarshal_PP_L(n_Clone);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Clone(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
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

	[Register("clone", "()Landroidx/constraintlayout/core/parser/CLElement;", "GetCloneHandler")]
	public new unsafe virtual CLElement Clone()
	{
		return Java.Lang.Object.GetObject<CLElement>(_members.InstanceMethods.InvokeVirtualObjectMethod("clone.()Landroidx/constraintlayout/core/parser/CLElement;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetContentHandler()
	{
		return new global::_JniMarshal_PP_L(n_Content);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Content(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Content());
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

	[Register("content", "()Ljava/lang/String;", "GetContentHandler")]
	public unsafe virtual string? Content()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("content.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetNotStartedHandler()
	{
		return new global::_JniMarshal_PP_B(n_NotStarted);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_NotStarted(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NotStarted() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("notStarted", "()Z", "GetNotStartedHandler")]
	public unsafe virtual bool NotStarted()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("notStarted.()Z", this, null);
	}

	private static Delegate GetSetContainer_Landroidx_constraintlayout_core_parser_CLContainer_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetContainer_Landroidx_constraintlayout_core_parser_CLContainer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContainer_Landroidx_constraintlayout_core_parser_CLContainer_(nint jnienv, nint native__this, nint native_element)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CLElement? cLElement = Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CLContainer container = Java.Lang.Object.GetObject<CLContainer>(native_element, JniHandleOwnership.DoNotTransfer);
			cLElement.SetContainer(container);
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

	[Register("setContainer", "(Landroidx/constraintlayout/core/parser/CLContainer;)V", "GetSetContainer_Landroidx_constraintlayout_core_parser_CLContainer_Handler")]
	public unsafe virtual void SetContainer(CLContainer? element)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setContainer.(Landroidx/constraintlayout/core/parser/CLContainer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(element);
		}
	}

	private static Delegate GetToFormattedJSON_IIHandler()
	{
		return new global::_JniMarshal_PPII_L(n_ToFormattedJSON_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToFormattedJSON_II(nint jnienv, nint native__this, int indent, int forceIndent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToFormattedJSON(indent, forceIndent));
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

	[Register("toFormattedJSON", "(II)Ljava/lang/String;", "GetToFormattedJSON_IIHandler")]
	protected unsafe virtual string? ToFormattedJSON(int indent, int forceIndent)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(indent);
		ptr[1] = new JniArgumentValue(forceIndent);
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("toFormattedJSON.(II)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetToJSONHandler()
	{
		return new global::_JniMarshal_PP_L(n_ToJSON);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToJSON(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CLElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToJSON());
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

	[Register("toJSON", "()Ljava/lang/String;", "GetToJSONHandler")]
	protected unsafe virtual string? ToJSON()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSON.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
