using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/ModelStyle", DoNotGenerateAcw = true)]
public sealed class ModelStyle : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/yandex/mapkit/map/ModelStyle$RenderMode", DoNotGenerateAcw = true)]
	public sealed class RenderMode : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/ModelStyle$RenderMode", typeof(RenderMode));

		[Register("BUILDING")]
		public static RenderMode? Building => Java.Lang.Object.GetObject<RenderMode>(_members.StaticFields.GetObjectValue("BUILDING.Lcom/yandex/mapkit/map/ModelStyle$RenderMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("USER_MODEL")]
		public static RenderMode? UserModel => Java.Lang.Object.GetObject<RenderMode>(_members.StaticFields.GetObjectValue("USER_MODEL.Lcom/yandex/mapkit/map/ModelStyle$RenderMode;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal RenderMode(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/map/ModelStyle$RenderMode;", "")]
		public unsafe static RenderMode? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<RenderMode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/map/ModelStyle$RenderMode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Lcom/yandex/mapkit/map/ModelStyle$RenderMode;", "")]
		public unsafe static RenderMode[]? Values()
		{
			return (RenderMode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/map/ModelStyle$RenderMode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(RenderMode));
		}
	}

	[Register("com/yandex/mapkit/map/ModelStyle$UnitType", DoNotGenerateAcw = true)]
	public sealed class UnitType : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/ModelStyle$UnitType", typeof(UnitType));

		[Register("METER")]
		public static UnitType? Meter => Java.Lang.Object.GetObject<UnitType>(_members.StaticFields.GetObjectValue("METER.Lcom/yandex/mapkit/map/ModelStyle$UnitType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NORMALIZED")]
		[Obsolete("deprecated")]
		public static UnitType? Normalized => Java.Lang.Object.GetObject<UnitType>(_members.StaticFields.GetObjectValue("NORMALIZED.Lcom/yandex/mapkit/map/ModelStyle$UnitType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNIT")]
		public static UnitType? Unit => Java.Lang.Object.GetObject<UnitType>(_members.StaticFields.GetObjectValue("UNIT.Lcom/yandex/mapkit/map/ModelStyle$UnitType;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal UnitType(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/map/ModelStyle$UnitType;", "")]
		public unsafe static UnitType? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<UnitType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/map/ModelStyle$UnitType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Lcom/yandex/mapkit/map/ModelStyle$UnitType;", "")]
		public unsafe static UnitType[]? Values()
		{
			return (UnitType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/map/ModelStyle$UnitType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(UnitType));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/ModelStyle", typeof(ModelStyle));

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

	public unsafe float Scale
	{
		[Register("getScale", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getScale.()F", this, null);
		}
	}

	public unsafe string? VariantName
	{
		[Register("getVariantName", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getVariantName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal ModelStyle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ModelStyle()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(FLcom/yandex/mapkit/map/ModelStyle$UnitType;Lcom/yandex/mapkit/map/ModelStyle$RenderMode;Ljava/lang/String;)V", "")]
	public unsafe ModelStyle(float scale, UnitType unitType, RenderMode renderMode, string? variantName)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(variantName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(scale);
			ptr[1] = new JniArgumentValue(unitType?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(renderMode?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(FLcom/yandex/mapkit/map/ModelStyle$UnitType;Lcom/yandex/mapkit/map/ModelStyle$RenderMode;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(FLcom/yandex/mapkit/map/ModelStyle$UnitType;Lcom/yandex/mapkit/map/ModelStyle$RenderMode;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(unitType);
			GC.KeepAlive(renderMode);
		}
	}

	[Register("getRenderMode", "()Lcom/yandex/mapkit/map/ModelStyle$RenderMode;", "")]
	public unsafe RenderMode GetRenderMode()
	{
		return Java.Lang.Object.GetObject<RenderMode>(_members.InstanceMethods.InvokeAbstractObjectMethod("getRenderMode.()Lcom/yandex/mapkit/map/ModelStyle$RenderMode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getUnitType", "()Lcom/yandex/mapkit/map/ModelStyle$UnitType;", "")]
	public unsafe UnitType GetUnitType()
	{
		return Java.Lang.Object.GetObject<UnitType>(_members.InstanceMethods.InvokeAbstractObjectMethod("getUnitType.()Lcom/yandex/mapkit/map/ModelStyle$UnitType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	[Register("setRenderMode", "(Lcom/yandex/mapkit/map/ModelStyle$RenderMode;)Lcom/yandex/mapkit/map/ModelStyle;", "")]
	public unsafe ModelStyle? SetRenderMode(RenderMode renderMode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(renderMode?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ModelStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setRenderMode.(Lcom/yandex/mapkit/map/ModelStyle$RenderMode;)Lcom/yandex/mapkit/map/ModelStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(renderMode);
		}
	}

	[Register("setScale", "(F)Lcom/yandex/mapkit/map/ModelStyle;", "")]
	public unsafe ModelStyle? SetScale(float scale)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(scale);
		return Java.Lang.Object.GetObject<ModelStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setScale.(F)Lcom/yandex/mapkit/map/ModelStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setUnitType", "(Lcom/yandex/mapkit/map/ModelStyle$UnitType;)Lcom/yandex/mapkit/map/ModelStyle;", "")]
	public unsafe ModelStyle? SetUnitType(UnitType unitType)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(unitType?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ModelStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setUnitType.(Lcom/yandex/mapkit/map/ModelStyle$UnitType;)Lcom/yandex/mapkit/map/ModelStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(unitType);
		}
	}

	[Register("setVariantName", "(Ljava/lang/String;)Lcom/yandex/mapkit/map/ModelStyle;", "")]
	public unsafe ModelStyle? SetVariantName(string? variantName)
	{
		nint num = JNIEnv.NewString(variantName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ModelStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setVariantName.(Ljava/lang/String;)Lcom/yandex/mapkit/map/ModelStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
