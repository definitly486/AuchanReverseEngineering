using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Resource.Bitmap;

[Register("com/bumptech/glide/load/resource/bitmap/DownsampleStrategy", DoNotGenerateAcw = true)]
public abstract class DownsampleStrategy : Java.Lang.Object
{
	[Register("com/bumptech/glide/load/resource/bitmap/DownsampleStrategy$SampleSizeRounding", DoNotGenerateAcw = true)]
	public sealed class SampleSizeRounding : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/resource/bitmap/DownsampleStrategy$SampleSizeRounding", typeof(SampleSizeRounding));

		[Register("MEMORY")]
		public static SampleSizeRounding? Memory => Java.Lang.Object.GetObject<SampleSizeRounding>(_members.StaticFields.GetObjectValue("MEMORY.Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy$SampleSizeRounding;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("QUALITY")]
		public static SampleSizeRounding? Quality => Java.Lang.Object.GetObject<SampleSizeRounding>(_members.StaticFields.GetObjectValue("QUALITY.Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy$SampleSizeRounding;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal SampleSizeRounding(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy$SampleSizeRounding;", "")]
		public unsafe static SampleSizeRounding? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<SampleSizeRounding>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy$SampleSizeRounding;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy$SampleSizeRounding;", "")]
		public unsafe static SampleSizeRounding[]? Values()
		{
			return (SampleSizeRounding[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy$SampleSizeRounding;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(SampleSizeRounding));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/resource/bitmap/DownsampleStrategy", typeof(DownsampleStrategy));

	private static Delegate? cb_getSampleSizeRounding_GetSampleSizeRounding_IIII_Lcom_bumptech_glide_load_resource_bitmap_DownsampleStrategy_SampleSizeRounding_;

	private static Delegate? cb_getScaleFactor_GetScaleFactor_IIII_F;

	[Register("AT_LEAST")]
	public static DownsampleStrategy? AtLeast => Java.Lang.Object.GetObject<DownsampleStrategy>(_members.StaticFields.GetObjectValue("AT_LEAST.Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("AT_MOST")]
	public static DownsampleStrategy? AtMost => Java.Lang.Object.GetObject<DownsampleStrategy>(_members.StaticFields.GetObjectValue("AT_MOST.Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("CENTER_INSIDE")]
	public static DownsampleStrategy? CenterInside => Java.Lang.Object.GetObject<DownsampleStrategy>(_members.StaticFields.GetObjectValue("CENTER_INSIDE.Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("CENTER_OUTSIDE")]
	public static DownsampleStrategy? CenterOutside => Java.Lang.Object.GetObject<DownsampleStrategy>(_members.StaticFields.GetObjectValue("CENTER_OUTSIDE.Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("DEFAULT")]
	public static DownsampleStrategy? Default => Java.Lang.Object.GetObject<DownsampleStrategy>(_members.StaticFields.GetObjectValue("DEFAULT.Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("FIT_CENTER")]
	public static DownsampleStrategy? FitCenter => Java.Lang.Object.GetObject<DownsampleStrategy>(_members.StaticFields.GetObjectValue("FIT_CENTER.Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("NONE")]
	public static DownsampleStrategy? None => Java.Lang.Object.GetObject<DownsampleStrategy>(_members.StaticFields.GetObjectValue("NONE.Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION")]
	public static Option? Option => Java.Lang.Object.GetObject<Option>(_members.StaticFields.GetObjectValue("OPTION.Lcom/bumptech/glide/load/Option;").Handle, JniHandleOwnership.TransferLocalRef);

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

	protected DownsampleStrategy(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe DownsampleStrategy()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetSampleSizeRounding_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_L(n_GetSampleSizeRounding_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSampleSizeRounding_IIII(nint jnienv, nint native__this, int p0, int p1, int p2, int p3)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DownsampleStrategy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSampleSizeRounding(p0, p1, p2, p3));
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

	[Register("getSampleSizeRounding", "(IIII)Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy$SampleSizeRounding;", "GetGetSampleSizeRounding_IIIIHandler")]
	public abstract SampleSizeRounding? GetSampleSizeRounding(int p0, int p1, int p2, int p3);

	private static Delegate GetGetScaleFactor_IIIIHandler()
	{
		return new _JniMarshal_PPIIII_F(n_GetScaleFactor_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetScaleFactor_IIII(nint jnienv, nint native__this, int p0, int p1, int p2, int p3)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<DownsampleStrategy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetScaleFactor(p0, p1, p2, p3);
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

	[Register("getScaleFactor", "(IIII)F", "GetGetScaleFactor_IIIIHandler")]
	public abstract float GetScaleFactor(int p0, int p1, int p2, int p3);
}
