using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/LayerOptions", DoNotGenerateAcw = true)]
public sealed class LayerOptions : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/layers/LayerOptions", typeof(LayerOptions));

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

	public unsafe bool Active
	{
		[Register("getActive", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getActive.()Z", this, null);
		}
	}

	public unsafe bool AnimateOnActivation
	{
		[Register("getAnimateOnActivation", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getAnimateOnActivation.()Z", this, null);
		}
	}

	public unsafe bool Cacheable
	{
		[Register("getCacheable", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getCacheable.()Z", this, null);
		}
	}

	public unsafe bool NightModeAvailable
	{
		[Register("getNightModeAvailable", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getNightModeAvailable.()Z", this, null);
		}
	}

	public unsafe OverzoomMode OverzoomMode
	{
		[Register("getOverzoomMode", "()Lcom/yandex/mapkit/layers/OverzoomMode;", "")]
		get
		{
			return Java.Lang.Object.GetObject<OverzoomMode>(_members.InstanceMethods.InvokeAbstractObjectMethod("getOverzoomMode.()Lcom/yandex/mapkit/layers/OverzoomMode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe long TileAppearingAnimationDuration
	{
		[Register("getTileAppearingAnimationDuration", "()J", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("getTileAppearingAnimationDuration.()J", this, null);
		}
	}

	public unsafe bool Transparent
	{
		[Register("getTransparent", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getTransparent.()Z", this, null);
		}
	}

	public unsafe bool VersionSupport
	{
		[Register("getVersionSupport", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getVersionSupport.()Z", this, null);
		}
	}

	internal LayerOptions(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe LayerOptions()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(ZZZZJLcom/yandex/mapkit/layers/OverzoomMode;ZZ)V", "")]
	public unsafe LayerOptions(bool active, bool nightModeAvailable, bool cacheable, bool animateOnActivation, long tileAppearingAnimationDuration, OverzoomMode overzoomMode, bool transparent, bool versionSupport)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(active);
			ptr[1] = new JniArgumentValue(nightModeAvailable);
			ptr[2] = new JniArgumentValue(cacheable);
			ptr[3] = new JniArgumentValue(animateOnActivation);
			ptr[4] = new JniArgumentValue(tileAppearingAnimationDuration);
			ptr[5] = new JniArgumentValue(overzoomMode?.Handle ?? IntPtr.Zero);
			ptr[6] = new JniArgumentValue(transparent);
			ptr[7] = new JniArgumentValue(versionSupport);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(ZZZZJLcom/yandex/mapkit/layers/OverzoomMode;ZZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(ZZZZJLcom/yandex/mapkit/layers/OverzoomMode;ZZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(overzoomMode);
		}
	}

	[Register("serialize", "(Lcom/yandex/runtime/bindings/Archive;)V", "")]
	public unsafe void Serialize(IArchive? archive)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((archive == null) ? IntPtr.Zero : ((Java.Lang.Object)archive).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("serialize.(Lcom/yandex/runtime/bindings/Archive;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(archive);
		}
	}

	[Register("setActive", "(Z)Lcom/yandex/mapkit/layers/LayerOptions;", "")]
	public unsafe LayerOptions? SetActive(bool active)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(active);
		return Java.Lang.Object.GetObject<LayerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActive.(Z)Lcom/yandex/mapkit/layers/LayerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setAnimateOnActivation", "(Z)Lcom/yandex/mapkit/layers/LayerOptions;", "")]
	public unsafe LayerOptions? SetAnimateOnActivation(bool animateOnActivation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(animateOnActivation);
		return Java.Lang.Object.GetObject<LayerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAnimateOnActivation.(Z)Lcom/yandex/mapkit/layers/LayerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setCacheable", "(Z)Lcom/yandex/mapkit/layers/LayerOptions;", "")]
	public unsafe LayerOptions? SetCacheable(bool cacheable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(cacheable);
		return Java.Lang.Object.GetObject<LayerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCacheable.(Z)Lcom/yandex/mapkit/layers/LayerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setNightModeAvailable", "(Z)Lcom/yandex/mapkit/layers/LayerOptions;", "")]
	public unsafe LayerOptions? SetNightModeAvailable(bool nightModeAvailable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(nightModeAvailable);
		return Java.Lang.Object.GetObject<LayerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("setNightModeAvailable.(Z)Lcom/yandex/mapkit/layers/LayerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setOverzoomMode", "(Lcom/yandex/mapkit/layers/OverzoomMode;)Lcom/yandex/mapkit/layers/LayerOptions;", "")]
	public unsafe LayerOptions? SetOverzoomMode(OverzoomMode overzoomMode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(overzoomMode?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LayerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOverzoomMode.(Lcom/yandex/mapkit/layers/OverzoomMode;)Lcom/yandex/mapkit/layers/LayerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(overzoomMode);
		}
	}

	[Register("setTileAppearingAnimationDuration", "(J)Lcom/yandex/mapkit/layers/LayerOptions;", "")]
	public unsafe LayerOptions? SetTileAppearingAnimationDuration(long tileAppearingAnimationDuration)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(tileAppearingAnimationDuration);
		return Java.Lang.Object.GetObject<LayerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTileAppearingAnimationDuration.(J)Lcom/yandex/mapkit/layers/LayerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setTransparent", "(Z)Lcom/yandex/mapkit/layers/LayerOptions;", "")]
	public unsafe LayerOptions? SetTransparent(bool transparent)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(transparent);
		return Java.Lang.Object.GetObject<LayerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTransparent.(Z)Lcom/yandex/mapkit/layers/LayerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setVersionSupport", "(Z)Lcom/yandex/mapkit/layers/LayerOptions;", "")]
	public unsafe LayerOptions? SetVersionSupport(bool versionSupport)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(versionSupport);
		return Java.Lang.Object.GetObject<LayerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("setVersionSupport.(Z)Lcom/yandex/mapkit/layers/LayerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
