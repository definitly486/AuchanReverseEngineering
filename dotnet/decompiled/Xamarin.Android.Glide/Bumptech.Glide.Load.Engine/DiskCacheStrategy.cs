using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine;

[Register("com/bumptech/glide/load/engine/DiskCacheStrategy", DoNotGenerateAcw = true)]
public abstract class DiskCacheStrategy : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/engine/DiskCacheStrategy", typeof(DiskCacheStrategy));

	private static Delegate? cb_decodeCachedData_DecodeCachedData_Z;

	private static Delegate? cb_decodeCachedResource_DecodeCachedResource_Z;

	private static Delegate? cb_isDataCacheable_IsDataCacheable_Lcom_bumptech_glide_load_DataSource__Z;

	private static Delegate? cb_isResourceCacheable_IsResourceCacheable_ZLcom_bumptech_glide_load_DataSource_Lcom_bumptech_glide_load_EncodeStrategy__Z;

	[Register("ALL")]
	public static DiskCacheStrategy? All => Java.Lang.Object.GetObject<DiskCacheStrategy>(_members.StaticFields.GetObjectValue("ALL.Lcom/bumptech/glide/load/engine/DiskCacheStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("AUTOMATIC")]
	public static DiskCacheStrategy? Automatic => Java.Lang.Object.GetObject<DiskCacheStrategy>(_members.StaticFields.GetObjectValue("AUTOMATIC.Lcom/bumptech/glide/load/engine/DiskCacheStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("DATA")]
	public static DiskCacheStrategy? Data => Java.Lang.Object.GetObject<DiskCacheStrategy>(_members.StaticFields.GetObjectValue("DATA.Lcom/bumptech/glide/load/engine/DiskCacheStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("NONE")]
	public static DiskCacheStrategy? None => Java.Lang.Object.GetObject<DiskCacheStrategy>(_members.StaticFields.GetObjectValue("NONE.Lcom/bumptech/glide/load/engine/DiskCacheStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("RESOURCE")]
	public static DiskCacheStrategy? Resource => Java.Lang.Object.GetObject<DiskCacheStrategy>(_members.StaticFields.GetObjectValue("RESOURCE.Lcom/bumptech/glide/load/engine/DiskCacheStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

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

	protected DiskCacheStrategy(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe DiskCacheStrategy()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetDecodeCachedDataHandler()
	{
		return new global::_JniMarshal_PP_B(n_DecodeCachedData);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DecodeCachedData(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<DiskCacheStrategy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DecodeCachedData() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("decodeCachedData", "()Z", "GetDecodeCachedDataHandler")]
	public abstract bool DecodeCachedData();

	private static Delegate GetDecodeCachedResourceHandler()
	{
		return new global::_JniMarshal_PP_B(n_DecodeCachedResource);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DecodeCachedResource(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<DiskCacheStrategy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DecodeCachedResource() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("decodeCachedResource", "()Z", "GetDecodeCachedResourceHandler")]
	public abstract bool DecodeCachedResource();

	private static Delegate GetIsDataCacheable_Lcom_bumptech_glide_load_DataSource_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_IsDataCacheable_Lcom_bumptech_glide_load_DataSource_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDataCacheable_Lcom_bumptech_glide_load_DataSource_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DiskCacheStrategy? diskCacheStrategy = Java.Lang.Object.GetObject<DiskCacheStrategy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DataSource p = Java.Lang.Object.GetObject<DataSource>(native_p0, JniHandleOwnership.DoNotTransfer);
			return diskCacheStrategy.IsDataCacheable(p) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isDataCacheable", "(Lcom/bumptech/glide/load/DataSource;)Z", "GetIsDataCacheable_Lcom_bumptech_glide_load_DataSource_Handler")]
	public abstract bool IsDataCacheable(DataSource? p0);

	private static Delegate GetIsResourceCacheable_ZLcom_bumptech_glide_load_DataSource_Lcom_bumptech_glide_load_EncodeStrategy_Handler()
	{
		return new _JniMarshal_PPBLL_B(n_IsResourceCacheable_ZLcom_bumptech_glide_load_DataSource_Lcom_bumptech_glide_load_EncodeStrategy_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsResourceCacheable_ZLcom_bumptech_glide_load_DataSource_Lcom_bumptech_glide_load_EncodeStrategy_(nint jnienv, nint native__this, sbyte native_p0, nint native_p1, nint native_p2)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DiskCacheStrategy? diskCacheStrategy = Java.Lang.Object.GetObject<DiskCacheStrategy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool p = native_p0 != 0;
			DataSource p2 = Java.Lang.Object.GetObject<DataSource>(native_p1, JniHandleOwnership.DoNotTransfer);
			EncodeStrategy p3 = Java.Lang.Object.GetObject<EncodeStrategy>(native_p2, JniHandleOwnership.DoNotTransfer);
			return diskCacheStrategy.IsResourceCacheable(p, p2, p3) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isResourceCacheable", "(ZLcom/bumptech/glide/load/DataSource;Lcom/bumptech/glide/load/EncodeStrategy;)Z", "GetIsResourceCacheable_ZLcom_bumptech_glide_load_DataSource_Lcom_bumptech_glide_load_EncodeStrategy_Handler")]
	public abstract bool IsResourceCacheable(bool p0, DataSource? p1, EncodeStrategy? p2);
}
