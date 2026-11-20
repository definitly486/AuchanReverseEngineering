using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Core.Util;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine;

[Register("com/bumptech/glide/load/engine/LoadPath", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "Data", "ResourceType", "Transcode" })]
public class LoadPath : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/engine/LoadPath", typeof(LoadPath));

	private static Delegate? cb_getDataClass_GetDataClass_Ljava_lang_Class_;

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

	public unsafe virtual Class? DataClass
	{
		[Register("getDataClass", "()Ljava/lang/Class;", "GetGetDataClassHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Class>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDataClass.()Ljava/lang/Class;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected LoadPath(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/Class;Ljava/util/List;Landroidx/core/util/Pools$Pool;)V", "")]
	public unsafe LoadPath(Class? dataClass, Class? resourceClass, Class? transcodeClass, IList? decodePaths, Pools.IPool? listPool)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JavaList.ToLocalJniHandle(decodePaths);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(dataClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(transcodeClass?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(num);
			ptr[4] = new JniArgumentValue((listPool == null) ? IntPtr.Zero : ((Java.Lang.Object)listPool).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/Class;Ljava/util/List;Landroidx/core/util/Pools$Pool;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/Class;Ljava/util/List;Landroidx/core/util/Pools$Pool;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(dataClass);
			GC.KeepAlive(resourceClass);
			GC.KeepAlive(transcodeClass);
			GC.KeepAlive(decodePaths);
			GC.KeepAlive(listPool);
		}
	}

	private static Delegate GetGetDataClassHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDataClass);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDataClass(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LoadPath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DataClass);
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
}
