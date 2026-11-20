using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Nio;

namespace Com.Yandex.Runtime.Bindings;

[Register("com/yandex/runtime/bindings/Archive", DoNotGenerateAcw = true)]
internal class IArchiveInvoker : Java.Lang.Object, IArchive, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_runtime_bindings_Archive = new XAPeerMembers("com/yandex/runtime/bindings/Archive", typeof(IArchiveInvoker));

	private static Delegate? cb_isReader_IsReader_Z;

	private static Delegate? cb_add_Add_Landroid_graphics_PointF_Z_Landroid_graphics_PointF_;

	private static Delegate? cb_add_Add_Z_Z;

	private static Delegate? cb_add_Add_B_B;

	private static Delegate? cb_add_Add_arrayBZ_arrayB;

	private static Delegate? cb_add_Add_Lcom_yandex_runtime_TypeDictionary_ZLcom_yandex_runtime_bindings_ArchivingHandler__Lcom_yandex_runtime_TypeDictionary_;

	private static Delegate? cb_add_Add_D_D;

	private static Delegate? cb_add_Add_F_F;

	private static Delegate? cb_add_Add_I_I;

	private static Delegate? cb_add_Add_Ljava_lang_Boolean_Z_Ljava_lang_Boolean_;

	private static Delegate? cb_add_Add_Ljava_lang_Byte_Z_Ljava_lang_Byte_;

	private static Delegate? cb_add_Add_Ljava_lang_Double_Z_Ljava_lang_Double_;

	private static Delegate? cb_add_Add_Ljava_lang_Float_Z_Ljava_lang_Float_;

	private static Delegate? cb_add_Add_Ljava_lang_Integer_Z_Ljava_lang_Integer_;

	private static Delegate? cb_add_Add_Ljava_lang_Long_Z_Ljava_lang_Long_;

	private static Delegate? cb_add_Add_Ljava_lang_String_Z_Ljava_lang_String_;

	private static Delegate? cb_add_Add_Ljava_nio_ByteBuffer__Ljava_nio_ByteBuffer_;

	private static Delegate? cb_add_Add_Ljava_util_List_ZLcom_yandex_runtime_bindings_ArchivingHandler__Ljava_util_List_;

	private static Delegate? cb_add_Add_Ljava_util_Map_ZLcom_yandex_runtime_bindings_ArchivingHandler_Lcom_yandex_runtime_bindings_ArchivingHandler__Ljava_util_Map_;

	private static Delegate? cb_add_Add_J_J;

	private static Delegate? cb_add_Add_Ljava_lang_Object_Lcom_yandex_runtime_bindings_ArchivingHandler__Ljava_lang_Object_;

	private static nint java_class_ref => _members_com_yandex_runtime_bindings_Archive.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_runtime_bindings_Archive;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_runtime_bindings_Archive.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_runtime_bindings_Archive.ManagedPeerType;

	public unsafe bool IsReader => _members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractBooleanMethod("isReader.()Z", this, null);

	public IArchiveInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsReaderHandler()
	{
		if ((object)cb_isReader_IsReader_Z == null)
		{
			cb_isReader_IsReader_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsReader));
		}
		return cb_isReader_IsReader_Z;
	}

	private static bool n_IsReader(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsReader;
	}

	private static Delegate GetAdd_Landroid_graphics_PointF_ZHandler()
	{
		if ((object)cb_add_Add_Landroid_graphics_PointF_Z_Landroid_graphics_PointF_ == null)
		{
			cb_add_Add_Landroid_graphics_PointF_Z_Landroid_graphics_PointF_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZ_L(n_Add_Landroid_graphics_PointF_Z));
		}
		return cb_add_Add_Landroid_graphics_PointF_Z_Landroid_graphics_PointF_;
	}

	private static nint n_Add_Landroid_graphics_PointF_Z(nint jnienv, nint native__this, nint native_p0, bool p1)
	{
		IArchive? archive = Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		PointF p2 = Java.Lang.Object.GetObject<PointF>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(archive.Add(p2, p1));
	}

	public unsafe PointF? Add(PointF? p0, bool p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			return Java.Lang.Object.GetObject<PointF>(_members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractObjectMethod("add.(Landroid/graphics/PointF;Z)Landroid/graphics/PointF;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAdd_ZHandler()
	{
		if ((object)cb_add_Add_Z_Z == null)
		{
			cb_add_Add_Z_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_Z(n_Add_Z));
		}
		return cb_add_Add_Z_Z;
	}

	private static bool n_Add_Z(nint jnienv, nint native__this, bool p0)
	{
		return Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Add(p0);
	}

	public unsafe bool Add(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return _members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractBooleanMethod("add.(Z)Z", this, ptr);
	}

	private static Delegate GetAdd_BHandler()
	{
		if ((object)cb_add_Add_B_B == null)
		{
			cb_add_Add_B_B = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPB_B(n_Add_B));
		}
		return cb_add_Add_B_B;
	}

	private static sbyte n_Add_B(nint jnienv, nint native__this, sbyte p0)
	{
		return Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Add(p0);
	}

	public unsafe sbyte Add(sbyte p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return _members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractSByteMethod("add.(B)B", this, ptr);
	}

	private static Delegate GetAdd_arrayBZHandler()
	{
		if ((object)cb_add_Add_arrayBZ_arrayB == null)
		{
			cb_add_Add_arrayBZ_arrayB = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZ_L(n_Add_arrayBZ));
		}
		return cb_add_Add_arrayBZ_arrayB;
	}

	private static nint n_Add_arrayBZ(nint jnienv, nint native__this, nint native_p0, bool p1)
	{
		IArchive? archive = Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		byte[] array = (byte[])JNIEnv.GetArray(native_p0, JniHandleOwnership.DoNotTransfer, typeof(byte));
		nint result = JNIEnv.NewArray(archive.Add(array, p1));
		if (array != null)
		{
			JNIEnv.CopyArray(array, native_p0);
		}
		return result;
	}

	public unsafe byte[]? Add(byte[]? p0, bool p1)
	{
		nint num = JNIEnv.NewArray(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1);
			return (byte[])JNIEnv.GetArray(_members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractObjectMethod("add.([BZ)[B", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}
		finally
		{
			if (p0 != null)
			{
				JNIEnv.CopyArray(num, p0);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAdd_Lcom_yandex_runtime_TypeDictionary_ZLcom_yandex_runtime_bindings_ArchivingHandler_Handler()
	{
		if ((object)cb_add_Add_Lcom_yandex_runtime_TypeDictionary_ZLcom_yandex_runtime_bindings_ArchivingHandler__Lcom_yandex_runtime_TypeDictionary_ == null)
		{
			cb_add_Add_Lcom_yandex_runtime_TypeDictionary_ZLcom_yandex_runtime_bindings_ArchivingHandler__Lcom_yandex_runtime_TypeDictionary_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZL_L(n_Add_Lcom_yandex_runtime_TypeDictionary_ZLcom_yandex_runtime_bindings_ArchivingHandler_));
		}
		return cb_add_Add_Lcom_yandex_runtime_TypeDictionary_ZLcom_yandex_runtime_bindings_ArchivingHandler__Lcom_yandex_runtime_TypeDictionary_;
	}

	private static nint n_Add_Lcom_yandex_runtime_TypeDictionary_ZLcom_yandex_runtime_bindings_ArchivingHandler_(nint jnienv, nint native__this, nint native_p0, bool p1, nint native_p2)
	{
		IArchive? archive = Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ITypeDictionary p2 = Java.Lang.Object.GetObject<ITypeDictionary>(native_p0, JniHandleOwnership.DoNotTransfer);
		IArchivingHandler p3 = Java.Lang.Object.GetObject<IArchivingHandler>(native_p2, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(archive.Add(p2, p1, p3));
	}

	public unsafe ITypeDictionary? Add(ITypeDictionary? p0, bool p1, IArchivingHandler? p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			return Java.Lang.Object.GetObject<ITypeDictionary>(_members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractObjectMethod("add.(Lcom/yandex/runtime/TypeDictionary;ZLcom/yandex/runtime/bindings/ArchivingHandler;)Lcom/yandex/runtime/TypeDictionary;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetAdd_DHandler()
	{
		if ((object)cb_add_Add_D_D == null)
		{
			cb_add_Add_D_D = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPD_D(n_Add_D));
		}
		return cb_add_Add_D_D;
	}

	private static double n_Add_D(nint jnienv, nint native__this, double p0)
	{
		return Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Add(p0);
	}

	public unsafe double Add(double p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return _members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractDoubleMethod("add.(D)D", this, ptr);
	}

	private static Delegate GetAdd_FHandler()
	{
		if ((object)cb_add_Add_F_F == null)
		{
			cb_add_Add_F_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_F(n_Add_F));
		}
		return cb_add_Add_F_F;
	}

	private static float n_Add_F(nint jnienv, nint native__this, float p0)
	{
		return Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Add(p0);
	}

	public unsafe float Add(float p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return _members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractSingleMethod("add.(F)F", this, ptr);
	}

	private static Delegate GetAdd_IHandler()
	{
		if ((object)cb_add_Add_I_I == null)
		{
			cb_add_Add_I_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_Add_I));
		}
		return cb_add_Add_I_I;
	}

	private static int n_Add_I(nint jnienv, nint native__this, int p0)
	{
		return Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Add(p0);
	}

	public unsafe int Add(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return _members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractInt32Method("add.(I)I", this, ptr);
	}

	private static Delegate GetAdd_Ljava_lang_Boolean_ZHandler()
	{
		if ((object)cb_add_Add_Ljava_lang_Boolean_Z_Ljava_lang_Boolean_ == null)
		{
			cb_add_Add_Ljava_lang_Boolean_Z_Ljava_lang_Boolean_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZ_L(n_Add_Ljava_lang_Boolean_Z));
		}
		return cb_add_Add_Ljava_lang_Boolean_Z_Ljava_lang_Boolean_;
	}

	private static nint n_Add_Ljava_lang_Boolean_Z(nint jnienv, nint native__this, nint native_p0, bool p1)
	{
		IArchive? archive = Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Boolean p2 = Java.Lang.Object.GetObject<Java.Lang.Boolean>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(archive.Add(p2, p1));
	}

	public unsafe Java.Lang.Boolean? Add(Java.Lang.Boolean? p0, bool p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractObjectMethod("add.(Ljava/lang/Boolean;Z)Ljava/lang/Boolean;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAdd_Ljava_lang_Byte_ZHandler()
	{
		if ((object)cb_add_Add_Ljava_lang_Byte_Z_Ljava_lang_Byte_ == null)
		{
			cb_add_Add_Ljava_lang_Byte_Z_Ljava_lang_Byte_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZ_L(n_Add_Ljava_lang_Byte_Z));
		}
		return cb_add_Add_Ljava_lang_Byte_Z_Ljava_lang_Byte_;
	}

	private static nint n_Add_Ljava_lang_Byte_Z(nint jnienv, nint native__this, nint native_p0, bool p1)
	{
		IArchive? archive = Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Byte p2 = Java.Lang.Object.GetObject<Java.Lang.Byte>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(archive.Add(p2, p1));
	}

	public unsafe Java.Lang.Byte? Add(Java.Lang.Byte? p0, bool p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			return Java.Lang.Object.GetObject<Java.Lang.Byte>(_members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractObjectMethod("add.(Ljava/lang/Byte;Z)Ljava/lang/Byte;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAdd_Ljava_lang_Double_ZHandler()
	{
		if ((object)cb_add_Add_Ljava_lang_Double_Z_Ljava_lang_Double_ == null)
		{
			cb_add_Add_Ljava_lang_Double_Z_Ljava_lang_Double_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZ_L(n_Add_Ljava_lang_Double_Z));
		}
		return cb_add_Add_Ljava_lang_Double_Z_Ljava_lang_Double_;
	}

	private static nint n_Add_Ljava_lang_Double_Z(nint jnienv, nint native__this, nint native_p0, bool p1)
	{
		IArchive? archive = Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Double p2 = Java.Lang.Object.GetObject<Java.Lang.Double>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(archive.Add(p2, p1));
	}

	public unsafe Java.Lang.Double? Add(Java.Lang.Double? p0, bool p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			return Java.Lang.Object.GetObject<Java.Lang.Double>(_members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractObjectMethod("add.(Ljava/lang/Double;Z)Ljava/lang/Double;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAdd_Ljava_lang_Float_ZHandler()
	{
		if ((object)cb_add_Add_Ljava_lang_Float_Z_Ljava_lang_Float_ == null)
		{
			cb_add_Add_Ljava_lang_Float_Z_Ljava_lang_Float_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZ_L(n_Add_Ljava_lang_Float_Z));
		}
		return cb_add_Add_Ljava_lang_Float_Z_Ljava_lang_Float_;
	}

	private static nint n_Add_Ljava_lang_Float_Z(nint jnienv, nint native__this, nint native_p0, bool p1)
	{
		IArchive? archive = Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Float p2 = Java.Lang.Object.GetObject<Float>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(archive.Add(p2, p1));
	}

	public unsafe Float? Add(Float? p0, bool p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			return Java.Lang.Object.GetObject<Float>(_members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractObjectMethod("add.(Ljava/lang/Float;Z)Ljava/lang/Float;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAdd_Ljava_lang_Integer_ZHandler()
	{
		if ((object)cb_add_Add_Ljava_lang_Integer_Z_Ljava_lang_Integer_ == null)
		{
			cb_add_Add_Ljava_lang_Integer_Z_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZ_L(n_Add_Ljava_lang_Integer_Z));
		}
		return cb_add_Add_Ljava_lang_Integer_Z_Ljava_lang_Integer_;
	}

	private static nint n_Add_Ljava_lang_Integer_Z(nint jnienv, nint native__this, nint native_p0, bool p1)
	{
		IArchive? archive = Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Integer p2 = Java.Lang.Object.GetObject<Integer>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(archive.Add(p2, p1));
	}

	public unsafe Integer? Add(Integer? p0, bool p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			return Java.Lang.Object.GetObject<Integer>(_members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractObjectMethod("add.(Ljava/lang/Integer;Z)Ljava/lang/Integer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAdd_Ljava_lang_Long_ZHandler()
	{
		if ((object)cb_add_Add_Ljava_lang_Long_Z_Ljava_lang_Long_ == null)
		{
			cb_add_Add_Ljava_lang_Long_Z_Ljava_lang_Long_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZ_L(n_Add_Ljava_lang_Long_Z));
		}
		return cb_add_Add_Ljava_lang_Long_Z_Ljava_lang_Long_;
	}

	private static nint n_Add_Ljava_lang_Long_Z(nint jnienv, nint native__this, nint native_p0, bool p1)
	{
		IArchive? archive = Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Long p2 = Java.Lang.Object.GetObject<Long>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(archive.Add(p2, p1));
	}

	public unsafe Long? Add(Long? p0, bool p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			return Java.Lang.Object.GetObject<Long>(_members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractObjectMethod("add.(Ljava/lang/Long;Z)Ljava/lang/Long;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAdd_Ljava_lang_String_ZHandler()
	{
		if ((object)cb_add_Add_Ljava_lang_String_Z_Ljava_lang_String_ == null)
		{
			cb_add_Add_Ljava_lang_String_Z_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZ_L(n_Add_Ljava_lang_String_Z));
		}
		return cb_add_Add_Ljava_lang_String_Z_Ljava_lang_String_;
	}

	private static nint n_Add_Ljava_lang_String_Z(nint jnienv, nint native__this, nint native_p0, bool p1)
	{
		IArchive? archive = Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p2 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.NewString(archive.Add(p2, p1));
	}

	public unsafe string? Add(string? p0, bool p1)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1);
			return JNIEnv.GetString(_members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractObjectMethod("add.(Ljava/lang/String;Z)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetAdd_Ljava_nio_ByteBuffer_Handler()
	{
		if ((object)cb_add_Add_Ljava_nio_ByteBuffer__Ljava_nio_ByteBuffer_ == null)
		{
			cb_add_Add_Ljava_nio_ByteBuffer__Ljava_nio_ByteBuffer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Add_Ljava_nio_ByteBuffer_));
		}
		return cb_add_Add_Ljava_nio_ByteBuffer__Ljava_nio_ByteBuffer_;
	}

	private static nint n_Add_Ljava_nio_ByteBuffer_(nint jnienv, nint native__this, nint native_p0)
	{
		IArchive? archive = Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ByteBuffer p = Java.Lang.Object.GetObject<ByteBuffer>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(archive.Add(p));
	}

	public unsafe ByteBuffer? Add(ByteBuffer? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ByteBuffer>(_members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractObjectMethod("add.(Ljava/nio/ByteBuffer;)Ljava/nio/ByteBuffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAdd_Ljava_util_List_ZLcom_yandex_runtime_bindings_ArchivingHandler_Handler()
	{
		if ((object)cb_add_Add_Ljava_util_List_ZLcom_yandex_runtime_bindings_ArchivingHandler__Ljava_util_List_ == null)
		{
			cb_add_Add_Ljava_util_List_ZLcom_yandex_runtime_bindings_ArchivingHandler__Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZL_L(n_Add_Ljava_util_List_ZLcom_yandex_runtime_bindings_ArchivingHandler_));
		}
		return cb_add_Add_Ljava_util_List_ZLcom_yandex_runtime_bindings_ArchivingHandler__Ljava_util_List_;
	}

	private static nint n_Add_Ljava_util_List_ZLcom_yandex_runtime_bindings_ArchivingHandler_(nint jnienv, nint native__this, nint native_p0, bool p1, nint native_p2)
	{
		IArchive? archive = Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList p2 = JavaList.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		IArchivingHandler p3 = Java.Lang.Object.GetObject<IArchivingHandler>(native_p2, JniHandleOwnership.DoNotTransfer);
		return JavaList.ToLocalJniHandle(archive.Add(p2, p1, p3));
	}

	public unsafe IList? Add(IList? p0, bool p1, IArchivingHandler? p2)
	{
		nint num = JavaList.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			return JavaList.FromJniHandle(_members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractObjectMethod("add.(Ljava/util/List;ZLcom/yandex/runtime/bindings/ArchivingHandler;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetAdd_Ljava_util_Map_ZLcom_yandex_runtime_bindings_ArchivingHandler_Lcom_yandex_runtime_bindings_ArchivingHandler_Handler()
	{
		if ((object)cb_add_Add_Ljava_util_Map_ZLcom_yandex_runtime_bindings_ArchivingHandler_Lcom_yandex_runtime_bindings_ArchivingHandler__Ljava_util_Map_ == null)
		{
			cb_add_Add_Ljava_util_Map_ZLcom_yandex_runtime_bindings_ArchivingHandler_Lcom_yandex_runtime_bindings_ArchivingHandler__Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZLL_L(n_Add_Ljava_util_Map_ZLcom_yandex_runtime_bindings_ArchivingHandler_Lcom_yandex_runtime_bindings_ArchivingHandler_));
		}
		return cb_add_Add_Ljava_util_Map_ZLcom_yandex_runtime_bindings_ArchivingHandler_Lcom_yandex_runtime_bindings_ArchivingHandler__Ljava_util_Map_;
	}

	private static nint n_Add_Ljava_util_Map_ZLcom_yandex_runtime_bindings_ArchivingHandler_Lcom_yandex_runtime_bindings_ArchivingHandler_(nint jnienv, nint native__this, nint native_p0, bool p1, nint native_p2, nint native_p3)
	{
		IArchive? archive = Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IDictionary p2 = JavaDictionary.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		IArchivingHandler p3 = Java.Lang.Object.GetObject<IArchivingHandler>(native_p2, JniHandleOwnership.DoNotTransfer);
		IArchivingHandler p4 = Java.Lang.Object.GetObject<IArchivingHandler>(native_p3, JniHandleOwnership.DoNotTransfer);
		return JavaDictionary.ToLocalJniHandle(archive.Add(p2, p1, p3, p4));
	}

	public unsafe IDictionary? Add(IDictionary? p0, bool p1, IArchivingHandler? p2, IArchivingHandler? p3)
	{
		nint num = JavaDictionary.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			ptr[3] = new JniArgumentValue((p3 == null) ? IntPtr.Zero : ((Java.Lang.Object)p3).Handle);
			return JavaDictionary.FromJniHandle(_members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractObjectMethod("add.(Ljava/util/Map;ZLcom/yandex/runtime/bindings/ArchivingHandler;Lcom/yandex/runtime/bindings/ArchivingHandler;)Ljava/util/Map;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
			GC.KeepAlive(p2);
			GC.KeepAlive(p3);
		}
	}

	private static Delegate GetAdd_JHandler()
	{
		if ((object)cb_add_Add_J_J == null)
		{
			cb_add_Add_J_J = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPJ_J(n_Add_J));
		}
		return cb_add_Add_J_J;
	}

	private static long n_Add_J(nint jnienv, nint native__this, long p0)
	{
		return Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Add(p0);
	}

	public unsafe long Add(long p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return _members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractInt64Method("add.(J)J", this, ptr);
	}

	private static Delegate GetAdd_Ljava_lang_Object_Lcom_yandex_runtime_bindings_ArchivingHandler_Handler()
	{
		if ((object)cb_add_Add_Ljava_lang_Object_Lcom_yandex_runtime_bindings_ArchivingHandler__Ljava_lang_Object_ == null)
		{
			cb_add_Add_Ljava_lang_Object_Lcom_yandex_runtime_bindings_ArchivingHandler__Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Add_Ljava_lang_Object_Lcom_yandex_runtime_bindings_ArchivingHandler_));
		}
		return cb_add_Add_Ljava_lang_Object_Lcom_yandex_runtime_bindings_ArchivingHandler__Ljava_lang_Object_;
	}

	private static nint n_Add_Ljava_lang_Object_Lcom_yandex_runtime_bindings_ArchivingHandler_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IArchive? archive = Java.Lang.Object.GetObject<IArchive>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
		IArchivingHandler p2 = Java.Lang.Object.GetObject<IArchivingHandler>(native_p1, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(archive.Add(p, p2));
	}

	public unsafe Java.Lang.Object? Add(Java.Lang.Object? p0, IArchivingHandler? p1)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_com_yandex_runtime_bindings_Archive.InstanceMethods.InvokeAbstractObjectMethod("add.(Ljava/lang/Object;Lcom/yandex/runtime/bindings/ArchivingHandler;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}
}
