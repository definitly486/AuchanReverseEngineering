using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/TextStyle", DoNotGenerateAcw = true)]
public sealed class TextStyle : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/yandex/mapkit/map/TextStyle$Placement", DoNotGenerateAcw = true)]
	public sealed class Placement : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/TextStyle$Placement", typeof(Placement));

		[Register("BOTTOM")]
		public static Placement? Bottom => Java.Lang.Object.GetObject<Placement>(_members.StaticFields.GetObjectValue("BOTTOM.Lcom/yandex/mapkit/map/TextStyle$Placement;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("BOTTOM_LEFT")]
		public static Placement? BottomLeft => Java.Lang.Object.GetObject<Placement>(_members.StaticFields.GetObjectValue("BOTTOM_LEFT.Lcom/yandex/mapkit/map/TextStyle$Placement;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("BOTTOM_RIGHT")]
		public static Placement? BottomRight => Java.Lang.Object.GetObject<Placement>(_members.StaticFields.GetObjectValue("BOTTOM_RIGHT.Lcom/yandex/mapkit/map/TextStyle$Placement;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CENTER")]
		public static Placement? Center => Java.Lang.Object.GetObject<Placement>(_members.StaticFields.GetObjectValue("CENTER.Lcom/yandex/mapkit/map/TextStyle$Placement;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LEFT")]
		public static Placement? Left => Java.Lang.Object.GetObject<Placement>(_members.StaticFields.GetObjectValue("LEFT.Lcom/yandex/mapkit/map/TextStyle$Placement;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RIGHT")]
		public static Placement? Right => Java.Lang.Object.GetObject<Placement>(_members.StaticFields.GetObjectValue("RIGHT.Lcom/yandex/mapkit/map/TextStyle$Placement;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TOP")]
		public static Placement? Top => Java.Lang.Object.GetObject<Placement>(_members.StaticFields.GetObjectValue("TOP.Lcom/yandex/mapkit/map/TextStyle$Placement;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TOP_LEFT")]
		public static Placement? TopLeft => Java.Lang.Object.GetObject<Placement>(_members.StaticFields.GetObjectValue("TOP_LEFT.Lcom/yandex/mapkit/map/TextStyle$Placement;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TOP_RIGHT")]
		public static Placement? TopRight => Java.Lang.Object.GetObject<Placement>(_members.StaticFields.GetObjectValue("TOP_RIGHT.Lcom/yandex/mapkit/map/TextStyle$Placement;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal Placement(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/map/TextStyle$Placement;", "")]
		public unsafe static Placement? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Placement>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/map/TextStyle$Placement;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Lcom/yandex/mapkit/map/TextStyle$Placement;", "")]
		public unsafe static Placement[]? Values()
		{
			return (Placement[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/map/TextStyle$Placement;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Placement));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/TextStyle", typeof(TextStyle));

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

	public unsafe int Color
	{
		[Register("getColor", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getColor.()I", this, null);
		}
	}

	public unsafe float Offset
	{
		[Register("getOffset", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getOffset.()F", this, null);
		}
	}

	public unsafe bool OffsetFromIcon
	{
		[Register("getOffsetFromIcon", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getOffsetFromIcon.()Z", this, null);
		}
	}

	public unsafe int OutlineColor
	{
		[Register("getOutlineColor", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getOutlineColor.()I", this, null);
		}
	}

	public unsafe float OutlineWidth
	{
		[Register("getOutlineWidth", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getOutlineWidth.()F", this, null);
		}
	}

	public unsafe float Size
	{
		[Register("getSize", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getSize.()F", this, null);
		}
	}

	public unsafe bool TextOptional
	{
		[Register("getTextOptional", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getTextOptional.()Z", this, null);
		}
	}

	internal TextStyle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe TextStyle()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(FIFILcom/yandex/mapkit/map/TextStyle$Placement;FZZ)V", "")]
	public unsafe TextStyle(float size, int color, float outlineWidth, int outlineColor, Placement placement, float offset, bool offsetFromIcon, bool textOptional)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(size);
			ptr[1] = new JniArgumentValue(color);
			ptr[2] = new JniArgumentValue(outlineWidth);
			ptr[3] = new JniArgumentValue(outlineColor);
			ptr[4] = new JniArgumentValue(placement?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(offset);
			ptr[6] = new JniArgumentValue(offsetFromIcon);
			ptr[7] = new JniArgumentValue(textOptional);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(FIFILcom/yandex/mapkit/map/TextStyle$Placement;FZZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(FIFILcom/yandex/mapkit/map/TextStyle$Placement;FZZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(placement);
		}
	}

	[Register("getPlacement", "()Lcom/yandex/mapkit/map/TextStyle$Placement;", "")]
	public unsafe Placement GetPlacement()
	{
		return Java.Lang.Object.GetObject<Placement>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPlacement.()Lcom/yandex/mapkit/map/TextStyle$Placement;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	[Register("setColor", "(I)Lcom/yandex/mapkit/map/TextStyle;", "")]
	public unsafe TextStyle? SetColor(int color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color);
		return Java.Lang.Object.GetObject<TextStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setColor.(I)Lcom/yandex/mapkit/map/TextStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setOffset", "(F)Lcom/yandex/mapkit/map/TextStyle;", "")]
	public unsafe TextStyle? SetOffset(float offset)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(offset);
		return Java.Lang.Object.GetObject<TextStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOffset.(F)Lcom/yandex/mapkit/map/TextStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setOffsetFromIcon", "(Z)Lcom/yandex/mapkit/map/TextStyle;", "")]
	public unsafe TextStyle? SetOffsetFromIcon(bool offsetFromIcon)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(offsetFromIcon);
		return Java.Lang.Object.GetObject<TextStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOffsetFromIcon.(Z)Lcom/yandex/mapkit/map/TextStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setOutlineColor", "(I)Lcom/yandex/mapkit/map/TextStyle;", "")]
	public unsafe TextStyle? SetOutlineColor(int outlineColor)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(outlineColor);
		return Java.Lang.Object.GetObject<TextStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOutlineColor.(I)Lcom/yandex/mapkit/map/TextStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setOutlineWidth", "(F)Lcom/yandex/mapkit/map/TextStyle;", "")]
	public unsafe TextStyle? SetOutlineWidth(float outlineWidth)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(outlineWidth);
		return Java.Lang.Object.GetObject<TextStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOutlineWidth.(F)Lcom/yandex/mapkit/map/TextStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setPlacement", "(Lcom/yandex/mapkit/map/TextStyle$Placement;)Lcom/yandex/mapkit/map/TextStyle;", "")]
	public unsafe TextStyle? SetPlacement(Placement placement)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(placement?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<TextStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPlacement.(Lcom/yandex/mapkit/map/TextStyle$Placement;)Lcom/yandex/mapkit/map/TextStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(placement);
		}
	}

	[Register("setSize", "(F)Lcom/yandex/mapkit/map/TextStyle;", "")]
	public unsafe TextStyle? SetSize(float size)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(size);
		return Java.Lang.Object.GetObject<TextStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSize.(F)Lcom/yandex/mapkit/map/TextStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setTextOptional", "(Z)Lcom/yandex/mapkit/map/TextStyle;", "")]
	public unsafe TextStyle? SetTextOptional(bool textOptional)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(textOptional);
		return Java.Lang.Object.GetObject<TextStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTextOptional.(Z)Lcom/yandex/mapkit/map/TextStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
