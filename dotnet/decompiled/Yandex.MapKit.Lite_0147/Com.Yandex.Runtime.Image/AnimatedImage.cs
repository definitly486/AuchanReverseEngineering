using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime.Image;

[Register("com/yandex/runtime/image/AnimatedImage", DoNotGenerateAcw = true)]
public class AnimatedImage : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/runtime/image/AnimatedImage", typeof(AnimatedImage));

	private static Delegate? cb_getFrames_GetFrames_Ljava_util_List_;

	private static Delegate? cb_getLoopCount_GetLoopCount_I;

	private static Delegate? cb_addFrame_AddFrame_Lcom_yandex_runtime_image_ImageProvider_J_V;

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

	public unsafe virtual IList<Frame>? Frames
	{
		[Register("getFrames", "()Ljava/util/List;", "GetGetFramesHandler")]
		get
		{
			return JavaList<Frame>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getFrames.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int LoopCount
	{
		[Register("getLoopCount", "()I", "GetGetLoopCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLoopCount.()I", this, null);
		}
	}

	protected AnimatedImage(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe AnimatedImage(int loopCount)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(loopCount);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	[Register(".ctor", "(ILjava/util/List;)V", "")]
	public unsafe AnimatedImage(int loopCount, IList<Frame>? frames)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JavaList<Frame>.ToLocalJniHandle(frames);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(loopCount);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(ILjava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(frames);
		}
	}

	private static Delegate GetGetFramesHandler()
	{
		if ((object)cb_getFrames_GetFrames_Ljava_util_List_ == null)
		{
			cb_getFrames_GetFrames_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFrames));
		}
		return cb_getFrames_GetFrames_Ljava_util_List_;
	}

	private static nint n_GetFrames(nint jnienv, nint native__this)
	{
		return JavaList<Frame>.ToLocalJniHandle(Java.Lang.Object.GetObject<AnimatedImage>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Frames);
	}

	private static Delegate GetGetLoopCountHandler()
	{
		if ((object)cb_getLoopCount_GetLoopCount_I == null)
		{
			cb_getLoopCount_GetLoopCount_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetLoopCount));
		}
		return cb_getLoopCount_GetLoopCount_I;
	}

	private static int n_GetLoopCount(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<AnimatedImage>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LoopCount;
	}

	private static Delegate GetAddFrame_Lcom_yandex_runtime_image_ImageProvider_JHandler()
	{
		if ((object)cb_addFrame_AddFrame_Lcom_yandex_runtime_image_ImageProvider_J_V == null)
		{
			cb_addFrame_AddFrame_Lcom_yandex_runtime_image_ImageProvider_J_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLJ_V(n_AddFrame_Lcom_yandex_runtime_image_ImageProvider_J));
		}
		return cb_addFrame_AddFrame_Lcom_yandex_runtime_image_ImageProvider_J_V;
	}

	private static void n_AddFrame_Lcom_yandex_runtime_image_ImageProvider_J(nint jnienv, nint native__this, nint native_image, long duration)
	{
		AnimatedImage? animatedImage = Java.Lang.Object.GetObject<AnimatedImage>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageProvider image = Java.Lang.Object.GetObject<ImageProvider>(native_image, JniHandleOwnership.DoNotTransfer);
		animatedImage.AddFrame(image, duration);
	}

	[Register("addFrame", "(Lcom/yandex/runtime/image/ImageProvider;J)V", "GetAddFrame_Lcom_yandex_runtime_image_ImageProvider_JHandler")]
	public unsafe virtual void AddFrame(ImageProvider? image, long duration)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(duration);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addFrame.(Lcom/yandex/runtime/image/ImageProvider;J)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(image);
		}
	}
}
