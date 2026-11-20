using System;
using Android.Runtime;
using Google.Common.Util.Concurrent;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Processing;

[Register("androidx/camera/core/processing/SurfaceProcessorInternal", "", "AndroidX.Camera.Core.Processing.ISurfaceProcessorInternalInvoker")]
public interface ISurfaceProcessorInternal : ISurfaceProcessor, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/processing/SurfaceProcessorInternal", typeof(ISurfaceProcessorInternal), isInterface: true);

	private static Delegate? cb_snapshot_II;

	[Register("release", "()V", "GetReleaseHandler:AndroidX.Camera.Core.Processing.ISurfaceProcessorInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	void Release();

	private static Delegate GetSnapshot_IIHandler()
	{
		if ((object)cb_snapshot_II == null)
		{
			cb_snapshot_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_L(n_Snapshot_II));
		}
		return cb_snapshot_II;
	}

	private static nint n_Snapshot_II(nint jnienv, nint native__this, int jpegQuality, int rotationDegrees)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISurfaceProcessorInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Snapshot(jpegQuality, rotationDegrees));
	}

	[Register("snapshot", "(II)Lcom/google/common/util/concurrent/ListenableFuture;", "GetSnapshot_IIHandler:AndroidX.Camera.Core.Processing.ISurfaceProcessorInternal, Xamarin.AndroidX.Camera.Core")]
	unsafe IListenableFuture Snapshot(int jpegQuality, int rotationDegrees)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(jpegQuality);
		ptr[1] = new JniArgumentValue(rotationDegrees);
		return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeVirtualObjectMethod("snapshot.(II)Lcom/google/common/util/concurrent/ListenableFuture;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
