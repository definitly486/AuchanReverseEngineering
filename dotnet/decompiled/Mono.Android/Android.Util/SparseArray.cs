using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Util;

[Register("android/util/SparseArray", DoNotGenerateAcw = true)]
public class SparseArray<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] E> : SparseArray
{
	private static nint id_get_I;

	private static nint id_put_ILjava_lang_Object_;

	private static nint id_valueAt_I;

	[Register("get", "(I)Ljava/lang/Object;", "")]
	public virtual E Get(int key)
	{
		if (id_get_I == IntPtr.Zero)
		{
			id_get_I = JNIEnv.GetMethodID(SparseArray.class_ref, "get", "(I)Ljava/lang/Object;");
		}
		return JavaConvert.FromJniHandle<E>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, SparseArray.class_ref, id_get_I, new JValue(key)), JniHandleOwnership.TransferLocalRef);
	}

	[Register("put", "(ILjava/lang/Object;)V", "")]
	public virtual void Put(int key, E value)
	{
		if (id_put_ILjava_lang_Object_ == IntPtr.Zero)
		{
			id_put_ILjava_lang_Object_ = JNIEnv.GetMethodID(SparseArray.class_ref, "put", "(ILjava/lang/Object;)V");
		}
		JavaConvert.WithLocalJniHandle(value, delegate(nint lref)
		{
			JNIEnv.CallNonvirtualVoidMethod(base.Handle, SparseArray.class_ref, id_put_ILjava_lang_Object_, new JValue(key), new JValue(lref));
			return IntPtr.Zero;
		});
	}

	[Register("valueAt", "(I)Ljava/lang/Object;", "")]
	public virtual E ValueAt(int index)
	{
		if (id_valueAt_I == IntPtr.Zero)
		{
			id_valueAt_I = JNIEnv.GetMethodID(SparseArray.class_ref, "valueAt", "(I)Ljava/lang/Object;");
		}
		return JavaConvert.FromJniHandle<E>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, SparseArray.class_ref, id_valueAt_I, new JValue(index)), JniHandleOwnership.TransferLocalRef);
	}
}
[Register("android/util/SparseArray", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "E" })]
public class SparseArray : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/util/SparseArray", typeof(SparseArray));

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_remove_Remove_I_V;

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

	protected SparseArray(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe SparseArray()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
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
			Java.Lang.Object.GetObject<SparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	private static Delegate GetRemove_IHandler()
	{
		return new _JniMarshal_PPI_V(n_Remove_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Remove_I(nint jnienv, nint native__this, int key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove(key);
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

	[Register("remove", "(I)V", "GetRemove_IHandler")]
	public unsafe virtual void Remove(int key)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(key);
		_members.InstanceMethods.InvokeVirtualVoidMethod("remove.(I)V", this, ptr);
	}

	private static Delegate GetSizeHandler()
	{
		return new _JniMarshal_PP_I(n_Size);
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
			return Java.Lang.Object.GetObject<SparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
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
