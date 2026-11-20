using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Parser;

[Register("androidx/constraintlayout/core/parser/CLContainer", DoNotGenerateAcw = true)]
public class CLContainer : CLElement
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/parser/CLContainer", typeof(CLContainer));

	private static Delegate? cb_add_Add_Landroidx_constraintlayout_core_parser_CLElement__V;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_get_Get_I_Landroidx_constraintlayout_core_parser_CLElement_;

	private static Delegate? cb_get_Get_Ljava_lang_String__Landroidx_constraintlayout_core_parser_CLElement_;

	private static Delegate? cb_getArray_GetArray_I_Landroidx_constraintlayout_core_parser_CLArray_;

	private static Delegate? cb_getArray_GetArray_Ljava_lang_String__Landroidx_constraintlayout_core_parser_CLArray_;

	private static Delegate? cb_getArrayOrCreate_GetArrayOrCreate_Ljava_lang_String__Landroidx_constraintlayout_core_parser_CLArray_;

	private static Delegate? cb_getArrayOrNull_GetArrayOrNull_Ljava_lang_String__Landroidx_constraintlayout_core_parser_CLArray_;

	private static Delegate? cb_getBoolean_GetBoolean_I_Z;

	private static Delegate? cb_getBoolean_GetBoolean_Ljava_lang_String__Z;

	private static Delegate? cb_getFloat_GetFloat_I_F;

	private static Delegate? cb_getFloat_GetFloat_Ljava_lang_String__F;

	private static Delegate? cb_getFloatOrNaN_GetFloatOrNaN_Ljava_lang_String__F;

	private static Delegate? cb_getInt_GetInt_I_I;

	private static Delegate? cb_getInt_GetInt_Ljava_lang_String__I;

	private static Delegate? cb_getObject_GetObject_I_Landroidx_constraintlayout_core_parser_CLObject_;

	private static Delegate? cb_getObject_GetObject_Ljava_lang_String__Landroidx_constraintlayout_core_parser_CLObject_;

	private static Delegate? cb_getObjectOrNull_GetObjectOrNull_Ljava_lang_String__Landroidx_constraintlayout_core_parser_CLObject_;

	private static Delegate? cb_getOrNull_GetOrNull_I_Landroidx_constraintlayout_core_parser_CLElement_;

	private static Delegate? cb_getOrNull_GetOrNull_Ljava_lang_String__Landroidx_constraintlayout_core_parser_CLElement_;

	private static Delegate? cb_getString_GetString_I_Ljava_lang_String_;

	private static Delegate? cb_getString_GetString_Ljava_lang_String__Ljava_lang_String_;

	private static Delegate? cb_getStringOrNull_GetStringOrNull_I_Ljava_lang_String_;

	private static Delegate? cb_getStringOrNull_GetStringOrNull_Ljava_lang_String__Ljava_lang_String_;

	private static Delegate? cb_has_Has_Ljava_lang_String__Z;

	private static Delegate? cb_names_Names_Ljava_util_ArrayList_;

	private static Delegate? cb_put_Put_Ljava_lang_String_Landroidx_constraintlayout_core_parser_CLElement__V;

	private static Delegate? cb_putNumber_PutNumber_Ljava_lang_String_F_V;

	private static Delegate? cb_putString_PutString_Ljava_lang_String_Ljava_lang_String__V;

	private static Delegate? cb_remove_Remove_Ljava_lang_String__V;

	private static Delegate? cb_size_Size_I;

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

	protected CLContainer(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "([C)V", "")]
	public unsafe CLContainer(char[]? content)
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

	private static Delegate GetAdd_Landroidx_constraintlayout_core_parser_CLElement_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Add_Landroidx_constraintlayout_core_parser_CLElement_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Add_Landroidx_constraintlayout_core_parser_CLElement_(nint jnienv, nint native__this, nint native_element)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CLElement element = Java.Lang.Object.GetObject<CLElement>(native_element, JniHandleOwnership.DoNotTransfer);
			cLContainer.Add(element);
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

	[Register("add", "(Landroidx/constraintlayout/core/parser/CLElement;)V", "GetAdd_Landroidx_constraintlayout_core_parser_CLElement_Handler")]
	public unsafe virtual void Add(CLElement? element)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("add.(Landroidx/constraintlayout/core/parser/CLElement;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(element);
		}
	}

	[Register("allocate", "([C)Landroidx/constraintlayout/core/parser/CLElement;", "")]
	public unsafe static CLElement? Allocate(char[]? content)
	{
		nint num = JNIEnv.NewArray(content);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<CLElement>(_members.StaticMethods.InvokeObjectMethod("allocate.([C)Landroidx/constraintlayout/core/parser/CLElement;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

	private static Delegate GetClearHandler()
	{
		return new global::_JniMarshal_PP_V(n_Clear);
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
			Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	private static Delegate GetGet_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_Get_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get(index));
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

	[Register("get", "(I)Landroidx/constraintlayout/core/parser/CLElement;", "GetGet_IHandler")]
	public unsafe virtual CLElement? Get(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<CLElement>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(I)Landroidx/constraintlayout/core/parser/CLElement;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGet_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Get_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cLContainer.Get(name));
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

	[Register("get", "(Ljava/lang/String;)Landroidx/constraintlayout/core/parser/CLElement;", "GetGet_Ljava_lang_String_Handler")]
	public unsafe virtual CLElement? Get(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<CLElement>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Ljava/lang/String;)Landroidx/constraintlayout/core/parser/CLElement;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetArray_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetArray_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetArray_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetArray(index));
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

	[Register("getArray", "(I)Landroidx/constraintlayout/core/parser/CLArray;", "GetGetArray_IHandler")]
	public unsafe virtual CLArray? GetArray(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<CLArray>(_members.InstanceMethods.InvokeVirtualObjectMethod("getArray.(I)Landroidx/constraintlayout/core/parser/CLArray;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetArray_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetArray_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetArray_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cLContainer.GetArray(name));
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

	[Register("getArray", "(Ljava/lang/String;)Landroidx/constraintlayout/core/parser/CLArray;", "GetGetArray_Ljava_lang_String_Handler")]
	public unsafe virtual CLArray? GetArray(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<CLArray>(_members.InstanceMethods.InvokeVirtualObjectMethod("getArray.(Ljava/lang/String;)Landroidx/constraintlayout/core/parser/CLArray;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetArrayOrCreate_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetArrayOrCreate_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetArrayOrCreate_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cLContainer.GetArrayOrCreate(name));
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

	[Register("getArrayOrCreate", "(Ljava/lang/String;)Landroidx/constraintlayout/core/parser/CLArray;", "GetGetArrayOrCreate_Ljava_lang_String_Handler")]
	public unsafe virtual CLArray? GetArrayOrCreate(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<CLArray>(_members.InstanceMethods.InvokeVirtualObjectMethod("getArrayOrCreate.(Ljava/lang/String;)Landroidx/constraintlayout/core/parser/CLArray;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetArrayOrNull_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetArrayOrNull_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetArrayOrNull_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cLContainer.GetArrayOrNull(name));
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

	[Register("getArrayOrNull", "(Ljava/lang/String;)Landroidx/constraintlayout/core/parser/CLArray;", "GetGetArrayOrNull_Ljava_lang_String_Handler")]
	public unsafe virtual CLArray? GetArrayOrNull(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<CLArray>(_members.InstanceMethods.InvokeVirtualObjectMethod("getArrayOrNull.(Ljava/lang/String;)Landroidx/constraintlayout/core/parser/CLArray;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetBoolean_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_GetBoolean_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetBoolean_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBoolean(index) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("getBoolean", "(I)Z", "GetGetBoolean_IHandler")]
	public unsafe virtual bool GetBoolean(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("getBoolean.(I)Z", this, ptr);
	}

	private static Delegate GetGetBoolean_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_GetBoolean_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetBoolean_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return cLContainer.GetBoolean(name) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("getBoolean", "(Ljava/lang/String;)Z", "GetGetBoolean_Ljava_lang_String_Handler")]
	public unsafe virtual bool GetBoolean(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getBoolean.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetFloat_IHandler()
	{
		return new global::_JniMarshal_PPI_F(n_GetFloat_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetFloat_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetFloat(index);
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

	[Register("getFloat", "(I)F", "GetGetFloat_IHandler")]
	public unsafe virtual float GetFloat(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getFloat.(I)F", this, ptr);
	}

	private static Delegate GetGetFloat_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_F(n_GetFloat_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetFloat_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return cLContainer.GetFloat(name);
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

	[Register("getFloat", "(Ljava/lang/String;)F", "GetGetFloat_Ljava_lang_String_Handler")]
	public unsafe virtual float GetFloat(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getFloat.(Ljava/lang/String;)F", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetFloatOrNaN_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_F(n_GetFloatOrNaN_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetFloatOrNaN_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return cLContainer.GetFloatOrNaN(name);
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

	[Register("getFloatOrNaN", "(Ljava/lang/String;)F", "GetGetFloatOrNaN_Ljava_lang_String_Handler")]
	public unsafe virtual float GetFloatOrNaN(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getFloatOrNaN.(Ljava/lang/String;)F", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetInt_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_GetInt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInt_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetInt(index);
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

	[Register("getInt", "(I)I", "GetGetInt_IHandler")]
	public unsafe virtual int GetInt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getInt.(I)I", this, ptr);
	}

	private static Delegate GetGetInt_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetInt_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInt_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return cLContainer.GetInt(name);
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

	[Register("getInt", "(Ljava/lang/String;)I", "GetGetInt_Ljava_lang_String_Handler")]
	public unsafe virtual int GetInt(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInt.(Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetObject_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetObject_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetObject_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetObject(index));
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

	[Register("getObject", "(I)Landroidx/constraintlayout/core/parser/CLObject;", "GetGetObject_IHandler")]
	public unsafe virtual CLObject? GetObject(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<CLObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("getObject.(I)Landroidx/constraintlayout/core/parser/CLObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetObject_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetObject_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetObject_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cLContainer.GetObject(name));
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

	[Register("getObject", "(Ljava/lang/String;)Landroidx/constraintlayout/core/parser/CLObject;", "GetGetObject_Ljava_lang_String_Handler")]
	public unsafe virtual CLObject? GetObject(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<CLObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("getObject.(Ljava/lang/String;)Landroidx/constraintlayout/core/parser/CLObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetObjectOrNull_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetObjectOrNull_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetObjectOrNull_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cLContainer.GetObjectOrNull(name));
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

	[Register("getObjectOrNull", "(Ljava/lang/String;)Landroidx/constraintlayout/core/parser/CLObject;", "GetGetObjectOrNull_Ljava_lang_String_Handler")]
	public unsafe virtual CLObject? GetObjectOrNull(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<CLObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("getObjectOrNull.(Ljava/lang/String;)Landroidx/constraintlayout/core/parser/CLObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetOrNull_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetOrNull_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetOrNull_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetOrNull(index));
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

	[Register("getOrNull", "(I)Landroidx/constraintlayout/core/parser/CLElement;", "GetGetOrNull_IHandler")]
	public unsafe virtual CLElement? GetOrNull(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<CLElement>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrNull.(I)Landroidx/constraintlayout/core/parser/CLElement;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetOrNull_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetOrNull_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetOrNull_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cLContainer.GetOrNull(name));
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

	[Register("getOrNull", "(Ljava/lang/String;)Landroidx/constraintlayout/core/parser/CLElement;", "GetGetOrNull_Ljava_lang_String_Handler")]
	public unsafe virtual CLElement? GetOrNull(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<CLElement>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrNull.(Ljava/lang/String;)Landroidx/constraintlayout/core/parser/CLElement;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetString_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetString_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetString_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetString(index));
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

	[Register("getString", "(I)Ljava/lang/String;", "GetGetString_IHandler")]
	public unsafe virtual string? GetString(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getString.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetString_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetString_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetString_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(cLContainer.GetString(name));
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

	[Register("getString", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetString_Ljava_lang_String_Handler")]
	public unsafe virtual string? GetString(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getString.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetStringOrNull_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetStringOrNull_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStringOrNull_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetStringOrNull(index));
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

	[Register("getStringOrNull", "(I)Ljava/lang/String;", "GetGetStringOrNull_IHandler")]
	public unsafe virtual string? GetStringOrNull(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getStringOrNull.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetStringOrNull_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetStringOrNull_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStringOrNull_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(cLContainer.GetStringOrNull(name));
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

	[Register("getStringOrNull", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetStringOrNull_Ljava_lang_String_Handler")]
	public unsafe virtual string? GetStringOrNull(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getStringOrNull.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetHas_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_Has_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Has_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return cLContainer.Has(name) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("has", "(Ljava/lang/String;)Z", "GetHas_Ljava_lang_String_Handler")]
	public unsafe virtual bool Has(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("has.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetNamesHandler()
	{
		return new global::_JniMarshal_PP_L(n_Names);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Names(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Names());
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

	[Register("names", "()Ljava/util/ArrayList;", "GetNamesHandler")]
	public unsafe virtual IList<string>? Names()
	{
		return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("names.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetPut_Ljava_lang_String_Landroidx_constraintlayout_core_parser_CLElement_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_Put_Ljava_lang_String_Landroidx_constraintlayout_core_parser_CLElement_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Put_Ljava_lang_String_Landroidx_constraintlayout_core_parser_CLElement_(nint jnienv, nint native__this, nint native_name, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			CLElement value = Java.Lang.Object.GetObject<CLElement>(native_value, JniHandleOwnership.DoNotTransfer);
			cLContainer.Put(name, value);
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

	[Register("put", "(Ljava/lang/String;Landroidx/constraintlayout/core/parser/CLElement;)V", "GetPut_Ljava_lang_String_Landroidx_constraintlayout_core_parser_CLElement_Handler")]
	public unsafe virtual void Put(string? name, CLElement? value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("put.(Ljava/lang/String;Landroidx/constraintlayout/core/parser/CLElement;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetPutNumber_Ljava_lang_String_FHandler()
	{
		return new global::_JniMarshal_PPLF_V(n_PutNumber_Ljava_lang_String_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PutNumber_Ljava_lang_String_F(nint jnienv, nint native__this, nint native_name, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			cLContainer.PutNumber(name, value);
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

	[Register("putNumber", "(Ljava/lang/String;F)V", "GetPutNumber_Ljava_lang_String_FHandler")]
	public unsafe virtual void PutNumber(string? name, float value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("putNumber.(Ljava/lang/String;F)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetPutString_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_PutString_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PutString_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			cLContainer.PutString(name, value);
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

	[Register("putString", "(Ljava/lang/String;Ljava/lang/String;)V", "GetPutString_Ljava_lang_String_Ljava_lang_String_Handler")]
	public unsafe virtual void PutString(string? name, string? value)
	{
		nint num = JNIEnv.NewString(name);
		nint num2 = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("putString.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetRemove_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Remove_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Remove_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CLContainer? cLContainer = Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			cLContainer.Remove(name);
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

	[Register("remove", "(Ljava/lang/String;)V", "GetRemove_Ljava_lang_String_Handler")]
	public unsafe virtual void Remove(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("remove.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_Size);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Size(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CLContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
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

	[Register("size", "()I", "GetSizeHandler")]
	public unsafe virtual int Size()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("size.()I", this, null);
	}
}
