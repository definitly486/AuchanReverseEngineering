using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Com.Scanflow.Datacapture.Utils;
using Java.Interop;
using Java.Lang;

namespace Com.Scanflow.Datacapture.Model;

[Register("com/scanflow/datacapture/model/ScanResultSuccess", DoNotGenerateAcw = true)]
public sealed class ScanResultSuccess : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/model/ScanResultSuccess", typeof(ScanResultSuccess));

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

	public unsafe BarcodeFormat BarcodeFormat
	{
		[Register("getBarcodeFormat", "()Lcom/scanflow/datacapture/utils/BarcodeFormat;", "")]
		get
		{
			return Java.Lang.Object.GetObject<BarcodeFormat>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getBarcodeFormat.()Lcom/scanflow/datacapture/utils/BarcodeFormat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe RectF BoundingBox
	{
		[Register("getBoundingBox", "()Landroid/graphics/RectF;", "")]
		get
		{
			return Java.Lang.Object.GetObject<RectF>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getBoundingBox.()Landroid/graphics/RectF;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe bool IsLongDistance
	{
		[Register("isLongDistance", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isLongDistance.()Z", this, null);
		}
	}

	public unsafe string ModelScanType
	{
		[Register("getModelScanType", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getModelScanType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe IList<PointF> Points
	{
		[Register("getPoints", "()Ljava/util/ArrayList;", "")]
		get
		{
			return JavaList<PointF>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPoints.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPoints", "(Ljava/util/ArrayList;)V", "")]
		set
		{
			nint num = JavaList<PointF>.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setPoints.(Ljava/util/ArrayList;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe string Text
	{
		[Register("getText", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal ScanResultSuccess(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)V", "")]
	public unsafe ScanResultSuccess(string p0, BarcodeFormat p1, bool p2, IList<PointF> p3, RectF p4, string p5)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(p0);
		nint num2 = JavaList<PointF>.ToLocalJniHandle(p3);
		nint num3 = JNIEnv.NewString(p5);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(p2);
			ptr[3] = new JniArgumentValue(num2);
			ptr[4] = new JniArgumentValue(p4?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(num3);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			GC.KeepAlive(p1);
			GC.KeepAlive(p3);
			GC.KeepAlive(p4);
		}
	}

	[Register("component1", "()Ljava/lang/String;", "")]
	public unsafe string Component1()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("component2", "()Lcom/scanflow/datacapture/utils/BarcodeFormat;", "")]
	public unsafe BarcodeFormat Component2()
	{
		return Java.Lang.Object.GetObject<BarcodeFormat>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Lcom/scanflow/datacapture/utils/BarcodeFormat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("component3", "()Z", "")]
	public unsafe bool Component3()
	{
		return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component3.()Z", this, null);
	}

	[Register("component4", "()Ljava/util/ArrayList;", "")]
	public unsafe IList<PointF> Component4()
	{
		return JavaList<PointF>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component4.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("component5", "()Landroid/graphics/RectF;", "")]
	public unsafe RectF Component5()
	{
		return Java.Lang.Object.GetObject<RectF>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component5.()Landroid/graphics/RectF;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("component6", "()Ljava/lang/String;", "")]
	public unsafe string Component6()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component6.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("copy", "(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)Lcom/scanflow/datacapture/model/ScanResultSuccess;", "")]
	public unsafe ScanResultSuccess Copy(string text, BarcodeFormat barcodeFormat, bool isLongDistance, IList<PointF> points, RectF boundingBox, string modelScanType)
	{
		nint num = JNIEnv.NewString(text);
		nint num2 = JavaList<PointF>.ToLocalJniHandle(points);
		nint num3 = JNIEnv.NewString(modelScanType);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(barcodeFormat?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(isLongDistance);
			ptr[3] = new JniArgumentValue(num2);
			ptr[4] = new JniArgumentValue(boundingBox?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(num3);
			return Java.Lang.Object.GetObject<ScanResultSuccess>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)Lcom/scanflow/datacapture/model/ScanResultSuccess;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			GC.KeepAlive(barcodeFormat);
			GC.KeepAlive(points);
			GC.KeepAlive(boundingBox);
		}
	}
}
