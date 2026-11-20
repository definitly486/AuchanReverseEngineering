using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace AndroidX.ConstraintLayout.Core.Parser;

[Register("androidx/constraintlayout/core/parser/CLObject", DoNotGenerateAcw = true)]
public class CLObject : CLContainer, IIterable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/parser/CLObject", typeof(CLObject));

	private static Delegate? cb_iterator_Iterator_Ljava_util_Iterator_;

	private static Delegate? cb_toFormattedJSON_ToFormattedJSON_Ljava_lang_String_;

	private static Delegate? cb_toFormattedJSON_ToFormattedJSON_II_Ljava_lang_String_;

	private static Delegate? cb_toJSON_ToJSON_Ljava_lang_String_;

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

	protected CLObject(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "([C)V", "")]
	public unsafe CLObject(char[]? content)
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

	[Register("allocate", "([C)Landroidx/constraintlayout/core/parser/CLObject;", "")]
	public new unsafe static CLObject? Allocate(char[]? content)
	{
		nint num = JNIEnv.NewArray(content);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<CLObject>(_members.StaticMethods.InvokeObjectMethod("allocate.([C)Landroidx/constraintlayout/core/parser/CLObject;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

	private static Delegate GetIteratorHandler()
	{
		return new global::_JniMarshal_PP_L(n_Iterator);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Iterator(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CLObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Iterator());
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

	[Register("iterator", "()Ljava/util/Iterator;", "GetIteratorHandler")]
	public unsafe virtual IIterator? Iterator()
	{
		return Java.Lang.Object.GetObject<IIterator>(_members.InstanceMethods.InvokeVirtualObjectMethod("iterator.()Ljava/util/Iterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetToFormattedJSONHandler()
	{
		return new global::_JniMarshal_PP_L(n_ToFormattedJSON);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToFormattedJSON(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CLObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToFormattedJSON());
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

	[Register("toFormattedJSON", "()Ljava/lang/String;", "GetToFormattedJSONHandler")]
	public unsafe virtual string? ToFormattedJSON()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("toFormattedJSON.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CLObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToFormattedJSON(indent, forceIndent));
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
	public new unsafe virtual string? ToFormattedJSON(int indent, int forceIndent)
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CLObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToJSON());
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
	public new unsafe virtual string? ToJSON()
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
