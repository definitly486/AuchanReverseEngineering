using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine.Prefill;

[Register("com/bumptech/glide/load/engine/prefill/PreFillType", DoNotGenerateAcw = true)]
public sealed class PreFillType : Java.Lang.Object
{
	[Register("com/bumptech/glide/load/engine/prefill/PreFillType$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/engine/prefill/PreFillType$Builder", typeof(Builder));

		private static Delegate? cb_setConfig_SetConfig_Landroid_graphics_Bitmap_Config__Lcom_bumptech_glide_load_engine_prefill_PreFillType_Builder_;

		private static Delegate? cb_setWeight_SetWeight_I_Lcom_bumptech_glide_load_engine_prefill_PreFillType_Builder_;

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

		[Register(".ctor", "(I)V", "")]
		public unsafe Builder(int size)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(size);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}

		[Register(".ctor", "(II)V", "")]
		public unsafe Builder(int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(width);
				ptr[1] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
			}
		}

		private static Delegate GetSetConfig_Landroid_graphics_Bitmap_Config_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetConfig_Landroid_graphics_Bitmap_Config_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetConfig_Landroid_graphics_Bitmap_Config_(nint jnienv, nint native__this, nint native_config)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Bitmap.Config config = Java.Lang.Object.GetObject<Bitmap.Config>(native_config, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetConfig(config));
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

		[Register("setConfig", "(Landroid/graphics/Bitmap$Config;)Lcom/bumptech/glide/load/engine/prefill/PreFillType$Builder;", "GetSetConfig_Landroid_graphics_Bitmap_Config_Handler")]
		public unsafe virtual Builder? SetConfig(Bitmap.Config? config)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setConfig.(Landroid/graphics/Bitmap$Config;)Lcom/bumptech/glide/load/engine/prefill/PreFillType$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(config);
			}
		}

		private static Delegate GetSetWeight_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetWeight_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetWeight_I(nint jnienv, nint native__this, int weight)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetWeight(weight));
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

		[Register("setWeight", "(I)Lcom/bumptech/glide/load/engine/prefill/PreFillType$Builder;", "GetSetWeight_IHandler")]
		public unsafe virtual Builder? SetWeight(int weight)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(weight);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setWeight.(I)Lcom/bumptech/glide/load/engine/prefill/PreFillType$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/engine/prefill/PreFillType", typeof(PreFillType));

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

	internal PreFillType(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
