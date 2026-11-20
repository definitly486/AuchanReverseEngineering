using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Nio;

namespace Xamarin.TensorFlow.Lite.Support.TensorBuffer;

[Register("org/tensorflow/lite/support/tensorbuffer/TensorBuffer", DoNotGenerateAcw = true)]
public abstract class TensorBuffer : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("org/tensorflow/lite/support/tensorbuffer/TensorBuffer", typeof(TensorBuffer));

	private static Delegate? cb_getBuffer_GetBuffer_Ljava_nio_ByteBuffer_;

	private static Delegate? cb_getDataType_GetDataType_Lorg_tensorflow_lite_DataType_;

	private static Delegate? cb_getFlatSize_GetFlatSize_I;

	private static Delegate? cb_isDynamic_IsDynamic_Z;

	private static Delegate? cb_getTypeSize_GetTypeSize_I;

	private static Delegate? cb_copyByteBufferIfReadOnly_CopyByteBufferIfReadOnly_V;

	private static Delegate? cb_getFloatArray_GetFloatArray_arrayF;

	private static Delegate? cb_getFloatValue_GetFloatValue_I_F;

	private static Delegate? cb_getIntArray_GetIntArray_arrayI;

	private static Delegate? cb_getIntValue_GetIntValue_I_I;

	private static Delegate? cb_getShape_GetShape_arrayI;

	private static Delegate? cb_loadArray_LoadArray_arrayF_V;

	private static Delegate? cb_loadArray_LoadArray_arrayFarrayI_V;

	private static Delegate? cb_loadArray_LoadArray_arrayI_V;

	private static Delegate? cb_loadArray_LoadArray_arrayIarrayI_V;

	private static Delegate? cb_loadBuffer_LoadBuffer_Ljava_nio_ByteBuffer__V;

	private static Delegate? cb_loadBuffer_LoadBuffer_Ljava_nio_ByteBuffer_arrayI_V;

	private static Delegate? cb_resize_Resize_arrayI_V;

	[Register("shape")]
	protected IList<int>? Shape
	{
		get
		{
			return global::Android.Runtime.JavaArray<int>.FromJniHandle(_members.InstanceFields.GetObjectValue("shape.[I", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = global::Android.Runtime.JavaArray<int>.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("shape.[I", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

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

	public unsafe virtual ByteBuffer? Buffer
	{
		[Register("getBuffer", "()Ljava/nio/ByteBuffer;", "GetGetBufferHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ByteBuffer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBuffer.()Ljava/nio/ByteBuffer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public abstract DataType? DataType
	{
		[Register("getDataType", "()Lorg/tensorflow/lite/DataType;", "GetGetDataTypeHandler")]
		get;
	}

	public unsafe virtual int FlatSize
	{
		[Register("getFlatSize", "()I", "GetGetFlatSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getFlatSize.()I", this, null);
		}
	}

	public unsafe virtual bool IsDynamic
	{
		[Register("isDynamic", "()Z", "GetIsDynamicHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDynamic.()Z", this, null);
		}
	}

	public abstract int TypeSize
	{
		[Register("getTypeSize", "()I", "GetGetTypeSizeHandler")]
		get;
	}

	protected TensorBuffer(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	protected unsafe TensorBuffer()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "([I)V", "")]
	protected unsafe TensorBuffer(int[]? shape)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewArray(shape);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("([I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("([I)V", this, ptr);
		}
		finally
		{
			if (shape != null)
			{
				JNIEnv.CopyArray(num, shape);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(shape);
		}
	}

	private static Delegate GetGetBufferHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBuffer);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBuffer(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Buffer);
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

	private static Delegate GetGetDataTypeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDataType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDataType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DataType);
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

	private static Delegate GetGetFlatSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetFlatSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetFlatSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlatSize;
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

	private static Delegate GetIsDynamicHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsDynamic);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDynamic(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDynamic ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetTypeSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTypeSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTypeSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TypeSize;
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

	[Register("computeFlatSize", "([I)I", "")]
	protected unsafe static int ComputeFlatSize(int[]? shape)
	{
		nint num = JNIEnv.NewArray(shape);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.StaticMethods.InvokeInt32Method("computeFlatSize.([I)I", ptr);
		}
		finally
		{
			if (shape != null)
			{
				JNIEnv.CopyArray(num, shape);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(shape);
		}
	}

	private static Delegate GetCopyByteBufferIfReadOnlyHandler()
	{
		return new global::_JniMarshal_PP_V(n_CopyByteBufferIfReadOnly);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CopyByteBufferIfReadOnly(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CopyByteBufferIfReadOnly();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("copyByteBufferIfReadOnly", "()V", "GetCopyByteBufferIfReadOnlyHandler")]
	protected unsafe virtual void CopyByteBufferIfReadOnly()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("copyByteBufferIfReadOnly.()V", this, null);
	}

	[Register("createDynamic", "(Lorg/tensorflow/lite/DataType;)Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;", "")]
	public unsafe static TensorBuffer? CreateDynamic(DataType? dataType)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(dataType?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<TensorBuffer>(_members.StaticMethods.InvokeObjectMethod("createDynamic.(Lorg/tensorflow/lite/DataType;)Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(dataType);
		}
	}

	[Register("createFixedSize", "([ILorg/tensorflow/lite/DataType;)Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;", "")]
	public unsafe static TensorBuffer? CreateFixedSize(int[]? shape, DataType? dataType)
	{
		nint num = JNIEnv.NewArray(shape);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(dataType?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<TensorBuffer>(_members.StaticMethods.InvokeObjectMethod("createFixedSize.([ILorg/tensorflow/lite/DataType;)Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (shape != null)
			{
				JNIEnv.CopyArray(num, shape);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(shape);
			GC.KeepAlive(dataType);
		}
	}

	[Register("createFrom", "(Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;Lorg/tensorflow/lite/DataType;)Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;", "")]
	public unsafe static TensorBuffer? CreateFrom(TensorBuffer? buffer, DataType? dataType)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(buffer?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dataType?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<TensorBuffer>(_members.StaticMethods.InvokeObjectMethod("createFrom.(Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;Lorg/tensorflow/lite/DataType;)Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(buffer);
			GC.KeepAlive(dataType);
		}
	}

	private static Delegate GetGetFloatArrayHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetFloatArray);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetFloatArray(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetFloatArray());
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

	[Register("getFloatArray", "()[F", "GetGetFloatArrayHandler")]
	public abstract float[]? GetFloatArray();

	private static Delegate GetGetFloatValue_IHandler()
	{
		return new global::_JniMarshal_PPI_F(n_GetFloatValue_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetFloatValue_I(nint jnienv, nint native__this, int absIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetFloatValue(absIndex);
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

	[Register("getFloatValue", "(I)F", "GetGetFloatValue_IHandler")]
	public abstract float GetFloatValue(int absIndex);

	private static Delegate GetGetIntArrayHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetIntArray);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetIntArray(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetIntArray());
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

	[Register("getIntArray", "()[I", "GetGetIntArrayHandler")]
	public abstract int[]? GetIntArray();

	private static Delegate GetGetIntValue_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_GetIntValue_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIntValue_I(nint jnienv, nint native__this, int absIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetIntValue(absIndex);
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

	[Register("getIntValue", "(I)I", "GetGetIntValue_IHandler")]
	public abstract int GetIntValue(int absIndex);

	private static Delegate GetGetShapeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetShape);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetShape(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetShape());
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

	[Register("getShape", "()[I", "GetGetShapeHandler")]
	public unsafe virtual int[]? GetShape()
	{
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getShape.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	private static Delegate GetLoadArray_arrayFHandler()
	{
		return new global::_JniMarshal_PPL_V(n_LoadArray_arrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LoadArray_arrayF(nint jnienv, nint native__this, nint native_src)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TensorBuffer? tensorBuffer = Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_src, JniHandleOwnership.DoNotTransfer, typeof(float));
			tensorBuffer.LoadArray(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_src);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("loadArray", "([F)V", "GetLoadArray_arrayFHandler")]
	public unsafe virtual void LoadArray(float[]? src)
	{
		nint num = JNIEnv.NewArray(src);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("loadArray.([F)V", this, ptr);
		}
		finally
		{
			if (src != null)
			{
				JNIEnv.CopyArray(num, src);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(src);
		}
	}

	private static Delegate GetLoadArray_arrayFarrayIHandler()
	{
		return new global::_JniMarshal_PPLL_V(n_LoadArray_arrayFarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LoadArray_arrayFarrayI(nint jnienv, nint native__this, nint native_src, nint native_shape)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TensorBuffer? tensorBuffer = Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_src, JniHandleOwnership.DoNotTransfer, typeof(float));
			int[] array2 = (int[])JNIEnv.GetArray(native_shape, JniHandleOwnership.DoNotTransfer, typeof(int));
			tensorBuffer.LoadArray(array, array2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_src);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_shape);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("loadArray", "([F[I)V", "GetLoadArray_arrayFarrayIHandler")]
	public abstract void LoadArray(float[]? src, int[]? shape);

	private static Delegate GetLoadArray_arrayIHandler()
	{
		return new global::_JniMarshal_PPL_V(n_LoadArray_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LoadArray_arrayI(nint jnienv, nint native__this, nint native_src)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TensorBuffer? tensorBuffer = Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_src, JniHandleOwnership.DoNotTransfer, typeof(int));
			tensorBuffer.LoadArray(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_src);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("loadArray", "([I)V", "GetLoadArray_arrayIHandler")]
	public unsafe virtual void LoadArray(int[]? src)
	{
		nint num = JNIEnv.NewArray(src);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("loadArray.([I)V", this, ptr);
		}
		finally
		{
			if (src != null)
			{
				JNIEnv.CopyArray(num, src);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(src);
		}
	}

	private static Delegate GetLoadArray_arrayIarrayIHandler()
	{
		return new global::_JniMarshal_PPLL_V(n_LoadArray_arrayIarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LoadArray_arrayIarrayI(nint jnienv, nint native__this, nint native_src, nint native_shape)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TensorBuffer? tensorBuffer = Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_src, JniHandleOwnership.DoNotTransfer, typeof(int));
			int[] array2 = (int[])JNIEnv.GetArray(native_shape, JniHandleOwnership.DoNotTransfer, typeof(int));
			tensorBuffer.LoadArray(array, array2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_src);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_shape);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("loadArray", "([I[I)V", "GetLoadArray_arrayIarrayIHandler")]
	public abstract void LoadArray(int[]? src, int[]? shape);

	private static Delegate GetLoadBuffer_Ljava_nio_ByteBuffer_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_LoadBuffer_Ljava_nio_ByteBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LoadBuffer_Ljava_nio_ByteBuffer_(nint jnienv, nint native__this, nint native_buffer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TensorBuffer? tensorBuffer = Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteBuffer buffer = Java.Lang.Object.GetObject<ByteBuffer>(native_buffer, JniHandleOwnership.DoNotTransfer);
			tensorBuffer.LoadBuffer(buffer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("loadBuffer", "(Ljava/nio/ByteBuffer;)V", "GetLoadBuffer_Ljava_nio_ByteBuffer_Handler")]
	public unsafe virtual void LoadBuffer(ByteBuffer? buffer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(buffer?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("loadBuffer.(Ljava/nio/ByteBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(buffer);
		}
	}

	private static Delegate GetLoadBuffer_Ljava_nio_ByteBuffer_arrayIHandler()
	{
		return new global::_JniMarshal_PPLL_V(n_LoadBuffer_Ljava_nio_ByteBuffer_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LoadBuffer_Ljava_nio_ByteBuffer_arrayI(nint jnienv, nint native__this, nint native_buffer, nint native_shape)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TensorBuffer? tensorBuffer = Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteBuffer buffer = Java.Lang.Object.GetObject<ByteBuffer>(native_buffer, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_shape, JniHandleOwnership.DoNotTransfer, typeof(int));
			tensorBuffer.LoadBuffer(buffer, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_shape);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("loadBuffer", "(Ljava/nio/ByteBuffer;[I)V", "GetLoadBuffer_Ljava_nio_ByteBuffer_arrayIHandler")]
	public unsafe virtual void LoadBuffer(ByteBuffer? buffer, int[]? shape)
	{
		nint num = JNIEnv.NewArray(shape);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(buffer?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("loadBuffer.(Ljava/nio/ByteBuffer;[I)V", this, ptr);
		}
		finally
		{
			if (shape != null)
			{
				JNIEnv.CopyArray(num, shape);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(buffer);
			GC.KeepAlive(shape);
		}
	}

	private static Delegate GetResize_arrayIHandler()
	{
		return new global::_JniMarshal_PPL_V(n_Resize_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Resize_arrayI(nint jnienv, nint native__this, nint native_shape)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TensorBuffer? tensorBuffer = Java.Lang.Object.GetObject<TensorBuffer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_shape, JniHandleOwnership.DoNotTransfer, typeof(int));
			tensorBuffer.Resize(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_shape);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("resize", "([I)V", "GetResize_arrayIHandler")]
	protected unsafe virtual void Resize(int[]? shape)
	{
		nint num = JNIEnv.NewArray(shape);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("resize.([I)V", this, ptr);
		}
		finally
		{
			if (shape != null)
			{
				JNIEnv.CopyArray(num, shape);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(shape);
		}
	}
}
