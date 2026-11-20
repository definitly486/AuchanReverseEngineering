using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Xamarin.TensorFlow.Lite.Support.TensorBuffer;

[Register("org/tensorflow/lite/support/tensorbuffer/TensorBuffer", DoNotGenerateAcw = true)]
internal class TensorBufferInvoker : TensorBuffer
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("org/tensorflow/lite/support/tensorbuffer/TensorBuffer", typeof(TensorBufferInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override DataType? DataType
	{
		[Register("getDataType", "()Lorg/tensorflow/lite/DataType;", "GetGetDataTypeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<DataType>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDataType.()Lorg/tensorflow/lite/DataType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override int TypeSize
	{
		[Register("getTypeSize", "()I", "GetGetTypeSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getTypeSize.()I", this, null);
		}
	}

	public TensorBufferInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("getFloatArray", "()[F", "GetGetFloatArrayHandler")]
	public unsafe override float[]? GetFloatArray()
	{
		return (float[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getFloatArray.()[F", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(float));
	}

	[Register("getFloatValue", "(I)F", "GetGetFloatValue_IHandler")]
	public unsafe override float GetFloatValue(int absIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(absIndex);
		return _members.InstanceMethods.InvokeAbstractSingleMethod("getFloatValue.(I)F", this, ptr);
	}

	[Register("getIntArray", "()[I", "GetGetIntArrayHandler")]
	public unsafe override int[]? GetIntArray()
	{
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getIntArray.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	[Register("getIntValue", "(I)I", "GetGetIntValue_IHandler")]
	public unsafe override int GetIntValue(int absIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(absIndex);
		return _members.InstanceMethods.InvokeAbstractInt32Method("getIntValue.(I)I", this, ptr);
	}

	[Register("loadArray", "([F[I)V", "GetLoadArray_arrayFarrayIHandler")]
	public unsafe override void LoadArray(float[]? src, int[]? shape)
	{
		nint num = JNIEnv.NewArray(src);
		nint num2 = JNIEnv.NewArray(shape);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeAbstractVoidMethod("loadArray.([F[I)V", this, ptr);
		}
		finally
		{
			if (src != null)
			{
				JNIEnv.CopyArray(num, src);
				JNIEnv.DeleteLocalRef(num);
			}
			if (shape != null)
			{
				JNIEnv.CopyArray(num2, shape);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(src);
			GC.KeepAlive(shape);
		}
	}

	[Register("loadArray", "([I[I)V", "GetLoadArray_arrayIarrayIHandler")]
	public unsafe override void LoadArray(int[]? src, int[]? shape)
	{
		nint num = JNIEnv.NewArray(src);
		nint num2 = JNIEnv.NewArray(shape);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeAbstractVoidMethod("loadArray.([I[I)V", this, ptr);
		}
		finally
		{
			if (src != null)
			{
				JNIEnv.CopyArray(num, src);
				JNIEnv.DeleteLocalRef(num);
			}
			if (shape != null)
			{
				JNIEnv.CopyArray(num2, shape);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(src);
			GC.KeepAlive(shape);
		}
	}
}
