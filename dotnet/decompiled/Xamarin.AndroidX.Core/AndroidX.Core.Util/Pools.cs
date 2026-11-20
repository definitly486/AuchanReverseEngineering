using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Util;

[Register("androidx/core/util/Pools", DoNotGenerateAcw = true)]
public sealed class Pools : Java.Lang.Object
{
	[Register("androidx/core/util/Pools$Pool", "", "AndroidX.Core.Util.Pools/IPoolInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IPool : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("acquire", "()Ljava/lang/Object;", "GetAcquireHandler:AndroidX.Core.Util.Pools/IPoolInvoker, Xamarin.AndroidX.Core")]
		Java.Lang.Object? Acquire();

		[Register("release", "(Ljava/lang/Object;)Z", "GetRelease_Ljava_lang_Object_Handler:AndroidX.Core.Util.Pools/IPoolInvoker, Xamarin.AndroidX.Core")]
		bool Release(Java.Lang.Object instance);
	}

	[Register("androidx/core/util/Pools$Pool", DoNotGenerateAcw = true)]
	internal class IPoolInvoker : Java.Lang.Object, IPool, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_core_util_Pools_Pool = new XAPeerMembers("androidx/core/util/Pools$Pool", typeof(IPoolInvoker));

		private static Delegate? cb_acquire_Acquire_Ljava_lang_Object_;

		private static Delegate? cb_release_Release_Ljava_lang_Object__Z;

		private static nint java_class_ref => _members_androidx_core_util_Pools_Pool.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_core_util_Pools_Pool;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_core_util_Pools_Pool.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_core_util_Pools_Pool.ManagedPeerType;

		public IPoolInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetAcquireHandler()
		{
			return new global::_JniMarshal_PP_L(n_Acquire);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Acquire(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Acquire());
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

		public unsafe Java.Lang.Object? Acquire()
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_androidx_core_util_Pools_Pool.InstanceMethods.InvokeAbstractObjectMethod("acquire.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRelease_Ljava_lang_Object_Handler()
		{
			return new global::_JniMarshal_PPL_B(n_Release_Ljava_lang_Object_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_Release_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_instance)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IPool? pool = Java.Lang.Object.GetObject<IPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object instance = Java.Lang.Object.GetObject<Java.Lang.Object>(native_instance, JniHandleOwnership.DoNotTransfer);
				return pool.Release(instance) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool Release(Java.Lang.Object instance)
		{
			nint num = JNIEnv.ToLocalJniHandle(instance);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return _members_androidx_core_util_Pools_Pool.InstanceMethods.InvokeAbstractBooleanMethod("release.(Ljava/lang/Object;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(instance);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/util/Pools", typeof(Pools));

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

	internal Pools(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
