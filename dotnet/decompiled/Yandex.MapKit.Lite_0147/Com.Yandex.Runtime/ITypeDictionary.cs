using System;
using System.Collections;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime;

[Register("com/yandex/runtime/TypeDictionary", "", "Com.Yandex.Runtime.ITypeDictionaryInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface ITypeDictionary : IJavaObject, IDisposable, IJavaPeerable
{
	IDictionary? AllItems
	{
		[Register("getAllItems", "()Ljava/util/Map;", "GetGetAllItemsHandler:Com.Yandex.Runtime.ITypeDictionaryInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("getItem", "(Ljava/lang/Class;)Ljava/lang/Object;", "GetGetItem_Ljava_lang_Class_Handler:Com.Yandex.Runtime.ITypeDictionaryInvoker, Yandex.MapKit.Lite")]
	[JavaTypeParameters(new string[] { "U extends T" })]
	Java.Lang.Object? GetItem(Class? p0);
}
