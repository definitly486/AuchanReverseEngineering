using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Shape;

[Register("com/google/android/material/shape/CornerSize", DoNotGenerateAcw = true)]
internal class ICornerSizeInvoker : Java.Lang.Object, ICornerSize, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_google_android_material_shape_CornerSize = new XAPeerMembers("com/google/android/material/shape/CornerSize", typeof(ICornerSizeInvoker));

	private static Delegate? cb_getCornerSize_GetCornerSize_Landroid_graphics_RectF__F;

	private static nint java_class_ref => _members_com_google_android_material_shape_CornerSize.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_shape_CornerSize;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_google_android_material_shape_CornerSize.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_google_android_material_shape_CornerSize.ManagedPeerType;

	public ICornerSizeInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetCornerSize_Landroid_graphics_RectF_Handler()
	{
		return new global::_JniMarshal_PPL_F(n_GetCornerSize_Landroid_graphics_RectF_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetCornerSize_Landroid_graphics_RectF_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			ICornerSize? cornerSize = Java.Lang.Object.GetObject<ICornerSize>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RectF p = Java.Lang.Object.GetObject<RectF>(native_p0, JniHandleOwnership.DoNotTransfer);
			return cornerSize.GetCornerSize(p);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe float GetCornerSize(RectF p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return _members_com_google_android_material_shape_CornerSize.InstanceMethods.InvokeAbstractSingleMethod("getCornerSize.(Landroid/graphics/RectF;)F", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
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
