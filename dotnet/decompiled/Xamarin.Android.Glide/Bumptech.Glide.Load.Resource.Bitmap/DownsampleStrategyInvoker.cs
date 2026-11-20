using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Resource.Bitmap;

[Register("com/bumptech/glide/load/resource/bitmap/DownsampleStrategy", DoNotGenerateAcw = true)]
internal class DownsampleStrategyInvoker : DownsampleStrategy
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/resource/bitmap/DownsampleStrategy", typeof(DownsampleStrategyInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public DownsampleStrategyInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("getSampleSizeRounding", "(IIII)Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy$SampleSizeRounding;", "GetGetSampleSizeRounding_IIIIHandler")]
	public unsafe override SampleSizeRounding? GetSampleSizeRounding(int p0, int p1, int p2, int p3)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(p0);
		ptr[1] = new JniArgumentValue(p1);
		ptr[2] = new JniArgumentValue(p2);
		ptr[3] = new JniArgumentValue(p3);
		return Java.Lang.Object.GetObject<SampleSizeRounding>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSampleSizeRounding.(IIII)Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy$SampleSizeRounding;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getScaleFactor", "(IIII)F", "GetGetScaleFactor_IIIIHandler")]
	public unsafe override float GetScaleFactor(int p0, int p1, int p2, int p3)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(p0);
		ptr[1] = new JniArgumentValue(p1);
		ptr[2] = new JniArgumentValue(p2);
		ptr[3] = new JniArgumentValue(p3);
		return _members.InstanceMethods.InvokeAbstractSingleMethod("getScaleFactor.(IIII)F", this, ptr);
	}
}
