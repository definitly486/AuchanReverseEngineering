using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/LinkedHashSet", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "E" })]
public class LinkedHashSet : HashSet, ISerializable, IJavaObject, IDisposable, IJavaPeerable, ISequencedSet, ISequencedCollection, ICollection, IIterable, ISet
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/LinkedHashSet", typeof(LinkedHashSet));

	private static Delegate? cb_addFirst_AddFirst_Ljava_lang_Object__V;

	private static Delegate? cb_addLast_AddLast_Ljava_lang_Object__V;

	private static Delegate? cb_removeFirst_RemoveFirst_Ljava_lang_Object_;

	private static Delegate? cb_removeLast_RemoveLast_Ljava_lang_Object_;

	private static Delegate? cb_reversed_Reversed_Ljava_util_SequencedSet_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected LinkedHashSet(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetAddFirst_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_V(n_AddFirst_Ljava_lang_Object_);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddFirst_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinkedHashSet? linkedHashSet = Java.Lang.Object.GetObject<LinkedHashSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object e = Java.Lang.Object.GetObject<Java.Lang.Object>(native_e, JniHandleOwnership.DoNotTransfer);
			linkedHashSet.AddFirst(e);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android35.0")]
	public unsafe virtual void AddFirst(Java.Lang.Object? e)
	{
		nint num = JNIEnv.ToLocalJniHandle(e);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addFirst.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(e);
		}
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetAddLast_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_V(n_AddLast_Ljava_lang_Object_);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddLast_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinkedHashSet? linkedHashSet = Java.Lang.Object.GetObject<LinkedHashSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object e = Java.Lang.Object.GetObject<Java.Lang.Object>(native_e, JniHandleOwnership.DoNotTransfer);
			linkedHashSet.AddLast(e);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android35.0")]
	public unsafe virtual void AddLast(Java.Lang.Object? e)
	{
		nint num = JNIEnv.ToLocalJniHandle(e);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addLast.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(e);
		}
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetRemoveFirstHandler()
	{
		return new _JniMarshal_PP_L(n_RemoveFirst);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_RemoveFirst(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinkedHashSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveFirst());
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

	[SupportedOSPlatform("android35.0")]
	public unsafe virtual Java.Lang.Object? RemoveFirst()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeFirst.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetRemoveLastHandler()
	{
		return new _JniMarshal_PP_L(n_RemoveLast);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_RemoveLast(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinkedHashSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveLast());
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

	[SupportedOSPlatform("android35.0")]
	public unsafe virtual Java.Lang.Object? RemoveLast()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeLast.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetReversedHandler()
	{
		return new _JniMarshal_PP_L(n_Reversed);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Reversed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinkedHashSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reversed());
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

	[SupportedOSPlatform("android35.0")]
	public unsafe virtual ISequencedCollection? Reversed()
	{
		return Java.Lang.Object.GetObject<ISequencedSet>(_members.InstanceMethods.InvokeVirtualObjectMethod("reversed.()Ljava/util/SequencedSet;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
