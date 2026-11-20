using System;
using System.Collections;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Nio;

namespace Com.Yandex.Runtime.Bindings;

[Register("com/yandex/runtime/bindings/Archive", "", "Com.Yandex.Runtime.Bindings.IArchiveInvoker")]
public interface IArchive : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsReader
	{
		[Register("isReader", "()Z", "GetIsReaderHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("add", "(Landroid/graphics/PointF;Z)Landroid/graphics/PointF;", "GetAdd_Landroid_graphics_PointF_ZHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	PointF? Add(PointF? p0, bool p1);

	[Register("add", "(Z)Z", "GetAdd_ZHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	bool Add(bool p0);

	[Register("add", "(B)B", "GetAdd_BHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	sbyte Add(sbyte p0);

	[Register("add", "([BZ)[B", "GetAdd_arrayBZHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	byte[]? Add(byte[]? p0, bool p1);

	[Register("add", "(Lcom/yandex/runtime/TypeDictionary;ZLcom/yandex/runtime/bindings/ArchivingHandler;)Lcom/yandex/runtime/TypeDictionary;", "GetAdd_Lcom_yandex_runtime_TypeDictionary_ZLcom_yandex_runtime_bindings_ArchivingHandler_Handler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	[JavaTypeParameters(new string[] { "T" })]
	ITypeDictionary? Add(ITypeDictionary? p0, bool p1, IArchivingHandler? p2);

	[Register("add", "(D)D", "GetAdd_DHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	double Add(double p0);

	[Register("add", "(F)F", "GetAdd_FHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	float Add(float p0);

	[Register("add", "(I)I", "GetAdd_IHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	int Add(int p0);

	[Register("add", "(Ljava/lang/Boolean;Z)Ljava/lang/Boolean;", "GetAdd_Ljava_lang_Boolean_ZHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	Java.Lang.Boolean? Add(Java.Lang.Boolean? p0, bool p1);

	[Register("add", "(Ljava/lang/Byte;Z)Ljava/lang/Byte;", "GetAdd_Ljava_lang_Byte_ZHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	Java.Lang.Byte? Add(Java.Lang.Byte? p0, bool p1);

	[Register("add", "(Ljava/lang/Double;Z)Ljava/lang/Double;", "GetAdd_Ljava_lang_Double_ZHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	Java.Lang.Double? Add(Java.Lang.Double? p0, bool p1);

	[Register("add", "(Ljava/lang/Float;Z)Ljava/lang/Float;", "GetAdd_Ljava_lang_Float_ZHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	Float? Add(Float? p0, bool p1);

	[Register("add", "(Ljava/lang/Integer;Z)Ljava/lang/Integer;", "GetAdd_Ljava_lang_Integer_ZHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	Integer? Add(Integer? p0, bool p1);

	[Register("add", "(Ljava/lang/Long;Z)Ljava/lang/Long;", "GetAdd_Ljava_lang_Long_ZHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	Long? Add(Long? p0, bool p1);

	[Register("add", "(Ljava/lang/String;Z)Ljava/lang/String;", "GetAdd_Ljava_lang_String_ZHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	string? Add(string? p0, bool p1);

	[Register("add", "(Ljava/nio/ByteBuffer;)Ljava/nio/ByteBuffer;", "GetAdd_Ljava_nio_ByteBuffer_Handler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	ByteBuffer? Add(ByteBuffer? p0);

	[Register("add", "(Ljava/util/List;ZLcom/yandex/runtime/bindings/ArchivingHandler;)Ljava/util/List;", "GetAdd_Ljava_util_List_ZLcom_yandex_runtime_bindings_ArchivingHandler_Handler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	[JavaTypeParameters(new string[] { "T" })]
	IList? Add(IList? p0, bool p1, IArchivingHandler? p2);

	[Register("add", "(Ljava/util/Map;ZLcom/yandex/runtime/bindings/ArchivingHandler;Lcom/yandex/runtime/bindings/ArchivingHandler;)Ljava/util/Map;", "GetAdd_Ljava_util_Map_ZLcom_yandex_runtime_bindings_ArchivingHandler_Lcom_yandex_runtime_bindings_ArchivingHandler_Handler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	[JavaTypeParameters(new string[] { "Key", "Value" })]
	IDictionary? Add(IDictionary? p0, bool p1, IArchivingHandler? p2, IArchivingHandler? p3);

	[Register("add", "(J)J", "GetAdd_JHandler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	long Add(long p0);

	[Register("add", "(Ljava/lang/Object;Lcom/yandex/runtime/bindings/ArchivingHandler;)Ljava/lang/Object;", "GetAdd_Ljava_lang_Object_Lcom_yandex_runtime_bindings_ArchivingHandler_Handler:Com.Yandex.Runtime.Bindings.IArchiveInvoker, Yandex.MapKit.Lite")]
	[JavaTypeParameters(new string[] { "T" })]
	Java.Lang.Object? Add(Java.Lang.Object? p0, IArchivingHandler? p1);
}
