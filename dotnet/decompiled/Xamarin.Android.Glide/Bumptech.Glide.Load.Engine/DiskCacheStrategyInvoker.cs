using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Load.Engine;

[Register("com/bumptech/glide/load/engine/DiskCacheStrategy", DoNotGenerateAcw = true)]
internal class DiskCacheStrategyInvoker : DiskCacheStrategy
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/engine/DiskCacheStrategy", typeof(DiskCacheStrategyInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public DiskCacheStrategyInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("decodeCachedData", "()Z", "GetDecodeCachedDataHandler")]
	public unsafe override bool DecodeCachedData()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("decodeCachedData.()Z", this, null);
	}

	[Register("decodeCachedResource", "()Z", "GetDecodeCachedResourceHandler")]
	public unsafe override bool DecodeCachedResource()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("decodeCachedResource.()Z", this, null);
	}

	[Register("isDataCacheable", "(Lcom/bumptech/glide/load/DataSource;)Z", "GetIsDataCacheable_Lcom_bumptech_glide_load_DataSource_Handler")]
	public unsafe override bool IsDataCacheable(DataSource? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isDataCacheable.(Lcom/bumptech/glide/load/DataSource;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Register("isResourceCacheable", "(ZLcom/bumptech/glide/load/DataSource;Lcom/bumptech/glide/load/EncodeStrategy;)Z", "GetIsResourceCacheable_ZLcom_bumptech_glide_load_DataSource_Lcom_bumptech_glide_load_EncodeStrategy_Handler")]
	public unsafe override bool IsResourceCacheable(bool p0, DataSource? p1, EncodeStrategy? p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0 ? ((sbyte)1) : ((sbyte)0));
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isResourceCacheable.(ZLcom/bumptech/glide/load/DataSource;Lcom/bumptech/glide/load/EncodeStrategy;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}
}
