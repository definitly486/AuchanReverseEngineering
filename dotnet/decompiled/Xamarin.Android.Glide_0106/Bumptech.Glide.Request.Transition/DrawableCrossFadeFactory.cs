using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Bumptech.Glide.Load;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Request.Transition;

[Register("com/bumptech/glide/request/transition/DrawableCrossFadeFactory", DoNotGenerateAcw = true)]
public class DrawableCrossFadeFactory : Java.Lang.Object, ITransitionFactory, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/bumptech/glide/request/transition/DrawableCrossFadeFactory$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/request/transition/DrawableCrossFadeFactory$Builder", typeof(Builder));

		private static Delegate? cb_build_Build_Lcom_bumptech_glide_request_transition_DrawableCrossFadeFactory_;

		private static Delegate? cb_setCrossFadeEnabled_SetCrossFadeEnabled_Z_Lcom_bumptech_glide_request_transition_DrawableCrossFadeFactory_Builder_;

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

		protected Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Builder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(I)V", "")]
		public unsafe Builder(int durationMillis)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(durationMillis);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}

		private static Delegate GetBuildHandler()
		{
			return new global::_JniMarshal_PP_L(n_Build);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Build(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
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

		[Register("build", "()Lcom/bumptech/glide/request/transition/DrawableCrossFadeFactory;", "GetBuildHandler")]
		public unsafe virtual DrawableCrossFadeFactory? Build()
		{
			return Java.Lang.Object.GetObject<DrawableCrossFadeFactory>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/bumptech/glide/request/transition/DrawableCrossFadeFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetCrossFadeEnabled_ZHandler()
		{
			return new global::_JniMarshal_PPB_L(n_SetCrossFadeEnabled_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetCrossFadeEnabled_Z(nint jnienv, nint native__this, sbyte native_isCrossFadeEnabled)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool crossFadeEnabled = native_isCrossFadeEnabled != 0;
				return JNIEnv.ToLocalJniHandle(builder.SetCrossFadeEnabled(crossFadeEnabled));
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

		[Register("setCrossFadeEnabled", "(Z)Lcom/bumptech/glide/request/transition/DrawableCrossFadeFactory$Builder;", "GetSetCrossFadeEnabled_ZHandler")]
		public unsafe virtual Builder? SetCrossFadeEnabled(bool isCrossFadeEnabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(isCrossFadeEnabled ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCrossFadeEnabled.(Z)Lcom/bumptech/glide/request/transition/DrawableCrossFadeFactory$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/request/transition/DrawableCrossFadeFactory", typeof(DrawableCrossFadeFactory));

	private static Delegate? cb_build_Build_Lcom_bumptech_glide_load_DataSource_Z_Lcom_bumptech_glide_request_transition_Transition_;

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

	protected DrawableCrossFadeFactory(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(IZ)V", "")]
	protected unsafe DrawableCrossFadeFactory(int duration, bool isCrossFadeEnabled)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(duration);
			ptr[1] = new JniArgumentValue(isCrossFadeEnabled ? ((sbyte)1) : ((sbyte)0));
			SetHandle(_members.InstanceMethods.StartCreateInstance("(IZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(IZ)V", this, ptr);
		}
	}

	private static Delegate GetBuild_Lcom_bumptech_glide_load_DataSource_ZHandler()
	{
		return new global::_JniMarshal_PPLB_L(n_Build_Lcom_bumptech_glide_load_DataSource_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Build_Lcom_bumptech_glide_load_DataSource_Z(nint jnienv, nint native__this, nint native_dataSource, sbyte native_isFirstResource)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DrawableCrossFadeFactory? drawableCrossFadeFactory = Java.Lang.Object.GetObject<DrawableCrossFadeFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DataSource dataSource = Java.Lang.Object.GetObject<DataSource>(native_dataSource, JniHandleOwnership.DoNotTransfer);
			bool isFirstResource = native_isFirstResource != 0;
			return JNIEnv.ToLocalJniHandle(drawableCrossFadeFactory.Build(dataSource, isFirstResource));
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

	[Register("build", "(Lcom/bumptech/glide/load/DataSource;Z)Lcom/bumptech/glide/request/transition/Transition;", "GetBuild_Lcom_bumptech_glide_load_DataSource_ZHandler")]
	public unsafe virtual ITransition? Build(DataSource? dataSource, bool isFirstResource)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dataSource?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(isFirstResource ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<ITransition>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.(Lcom/bumptech/glide/load/DataSource;Z)Lcom/bumptech/glide/request/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(dataSource);
		}
	}

	ITransition? ITransitionFactory.Build(DataSource? p0, bool p1)
	{
		return JavaObjectExtensions.JavaCast<ITransition>(Build(p0, p1));
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
