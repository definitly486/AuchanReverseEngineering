using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/LineStyle", DoNotGenerateAcw = true)]
public sealed class LineStyle : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/LineStyle", typeof(LineStyle));

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

	public unsafe float ArcApproximationStep
	{
		[Register("getArcApproximationStep", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getArcApproximationStep.()F", this, null);
		}
	}

	public unsafe float DashLength
	{
		[Register("getDashLength", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getDashLength.()F", this, null);
		}
	}

	public unsafe float DashOffset
	{
		[Register("getDashOffset", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getDashOffset.()F", this, null);
		}
	}

	public unsafe float GapLength
	{
		[Register("getGapLength", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getGapLength.()F", this, null);
		}
	}

	public unsafe float GradientLength
	{
		[Register("getGradientLength", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getGradientLength.()F", this, null);
		}
	}

	public unsafe bool InnerOutlineEnabled
	{
		[Register("getInnerOutlineEnabled", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getInnerOutlineEnabled.()Z", this, null);
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

	public unsafe float StrokeWidth
	{
		[Register("getStrokeWidth", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getStrokeWidth.()F", this, null);
		}
	}

	public unsafe float TurnRadius
	{
		[Register("getTurnRadius", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getTurnRadius.()F", this, null);
		}
	}

	internal LineStyle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe LineStyle()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(FFIFZFFFFF)V", "")]
	public unsafe LineStyle(float strokeWidth, float gradientLength, int outlineColor, float outlineWidth, bool innerOutlineEnabled, float turnRadius, float arcApproximationStep, float dashLength, float gapLength, float dashOffset)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[10];
			*ptr = new JniArgumentValue(strokeWidth);
			ptr[1] = new JniArgumentValue(gradientLength);
			ptr[2] = new JniArgumentValue(outlineColor);
			ptr[3] = new JniArgumentValue(outlineWidth);
			ptr[4] = new JniArgumentValue(innerOutlineEnabled);
			ptr[5] = new JniArgumentValue(turnRadius);
			ptr[6] = new JniArgumentValue(arcApproximationStep);
			ptr[7] = new JniArgumentValue(dashLength);
			ptr[8] = new JniArgumentValue(gapLength);
			ptr[9] = new JniArgumentValue(dashOffset);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(FFIFZFFFFF)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(FFIFZFFFFF)V", this, ptr);
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

	[Register("setArcApproximationStep", "(F)Lcom/yandex/mapkit/map/LineStyle;", "")]
	public unsafe LineStyle? SetArcApproximationStep(float arcApproximationStep)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(arcApproximationStep);
		return Java.Lang.Object.GetObject<LineStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setArcApproximationStep.(F)Lcom/yandex/mapkit/map/LineStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setDashLength", "(F)Lcom/yandex/mapkit/map/LineStyle;", "")]
	public unsafe LineStyle? SetDashLength(float dashLength)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(dashLength);
		return Java.Lang.Object.GetObject<LineStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDashLength.(F)Lcom/yandex/mapkit/map/LineStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setDashOffset", "(F)Lcom/yandex/mapkit/map/LineStyle;", "")]
	public unsafe LineStyle? SetDashOffset(float dashOffset)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(dashOffset);
		return Java.Lang.Object.GetObject<LineStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDashOffset.(F)Lcom/yandex/mapkit/map/LineStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setGapLength", "(F)Lcom/yandex/mapkit/map/LineStyle;", "")]
	public unsafe LineStyle? SetGapLength(float gapLength)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(gapLength);
		return Java.Lang.Object.GetObject<LineStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setGapLength.(F)Lcom/yandex/mapkit/map/LineStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setGradientLength", "(F)Lcom/yandex/mapkit/map/LineStyle;", "")]
	public unsafe LineStyle? SetGradientLength(float gradientLength)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(gradientLength);
		return Java.Lang.Object.GetObject<LineStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setGradientLength.(F)Lcom/yandex/mapkit/map/LineStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setInnerOutlineEnabled", "(Z)Lcom/yandex/mapkit/map/LineStyle;", "")]
	public unsafe LineStyle? SetInnerOutlineEnabled(bool innerOutlineEnabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(innerOutlineEnabled);
		return Java.Lang.Object.GetObject<LineStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setInnerOutlineEnabled.(Z)Lcom/yandex/mapkit/map/LineStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setOutlineColor", "(I)Lcom/yandex/mapkit/map/LineStyle;", "")]
	public unsafe LineStyle? SetOutlineColor(int outlineColor)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(outlineColor);
		return Java.Lang.Object.GetObject<LineStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOutlineColor.(I)Lcom/yandex/mapkit/map/LineStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setOutlineWidth", "(F)Lcom/yandex/mapkit/map/LineStyle;", "")]
	public unsafe LineStyle? SetOutlineWidth(float outlineWidth)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(outlineWidth);
		return Java.Lang.Object.GetObject<LineStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOutlineWidth.(F)Lcom/yandex/mapkit/map/LineStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setStrokeWidth", "(F)Lcom/yandex/mapkit/map/LineStyle;", "")]
	public unsafe LineStyle? SetStrokeWidth(float strokeWidth)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(strokeWidth);
		return Java.Lang.Object.GetObject<LineStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setStrokeWidth.(F)Lcom/yandex/mapkit/map/LineStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setTurnRadius", "(F)Lcom/yandex/mapkit/map/LineStyle;", "")]
	public unsafe LineStyle? SetTurnRadius(float turnRadius)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(turnRadius);
		return Java.Lang.Object.GetObject<LineStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTurnRadius.(F)Lcom/yandex/mapkit/map/LineStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
