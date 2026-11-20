using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/SequencedCollection", "", "Java.Util.ISequencedCollectionInvoker", ApiSince = 35)]
[JavaTypeParameters(new string[] { "E" })]
public interface ISequencedCollection : ICollection, IIterable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/SequencedCollection", typeof(ISequencedCollection), isInterface: true);

	private static Delegate? cb_addFirst_AddFirst_Ljava_lang_Object__V;

	private static Delegate? cb_addLast_AddLast_Ljava_lang_Object__V;

	private static Delegate? cb_getFirst_GetFirst_Ljava_lang_Object_;

	private static Delegate? cb_getLast_GetLast_Ljava_lang_Object_;

	private static Delegate? cb_removeFirst_RemoveFirst_Ljava_lang_Object_;

	private static Delegate? cb_removeLast_RemoveLast_Ljava_lang_Object_;

	[SupportedOSPlatform("android35.0")]
	[Register("reversed", "()Ljava/util/SequencedCollection;", "GetReversedHandler:Java.Util.ISequencedCollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	ISequencedCollection? Reversed();

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
			ISequencedCollection? sequencedCollection = Java.Lang.Object.GetObject<ISequencedCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object e = Java.Lang.Object.GetObject<Java.Lang.Object>(native_e, JniHandleOwnership.DoNotTransfer);
			sequencedCollection.AddFirst(e);
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
	[Register("addFirst", "(Ljava/lang/Object;)V", "GetAddFirst_Ljava_lang_Object_Handler:Java.Util.ISequencedCollection, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	unsafe void AddFirst(Java.Lang.Object? e)
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
			ISequencedCollection? sequencedCollection = Java.Lang.Object.GetObject<ISequencedCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object e = Java.Lang.Object.GetObject<Java.Lang.Object>(native_e, JniHandleOwnership.DoNotTransfer);
			sequencedCollection.AddLast(e);
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
	[Register("addLast", "(Ljava/lang/Object;)V", "GetAddLast_Ljava_lang_Object_Handler:Java.Util.ISequencedCollection, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	unsafe void AddLast(Java.Lang.Object? e)
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
	private static Delegate GetGetFirstHandler()
	{
		return new _JniMarshal_PP_L(n_GetFirst);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetFirst(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISequencedCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetFirst());
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
	[Register("getFirst", "()Ljava/lang/Object;", "GetGetFirstHandler:Java.Util.ISequencedCollection, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	unsafe Java.Lang.Object? GetFirst()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFirst.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetGetLastHandler()
	{
		return new _JniMarshal_PP_L(n_GetLast);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLast(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISequencedCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLast());
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
	[Register("getLast", "()Ljava/lang/Object;", "GetGetLastHandler:Java.Util.ISequencedCollection, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	unsafe Java.Lang.Object? GetLast()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLast.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISequencedCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveFirst());
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
	[Register("removeFirst", "()Ljava/lang/Object;", "GetRemoveFirstHandler:Java.Util.ISequencedCollection, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	unsafe Java.Lang.Object? RemoveFirst()
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISequencedCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveLast());
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
	[Register("removeLast", "()Ljava/lang/Object;", "GetRemoveLastHandler:Java.Util.ISequencedCollection, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	unsafe Java.Lang.Object? RemoveLast()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeLast.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
