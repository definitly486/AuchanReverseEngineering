using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Runtime;

[Register("com/yandex/runtime/DataProviderWithId", "", "Com.Yandex.Runtime.IDataProviderWithIdInvoker")]
public interface IDataProviderWithId : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("load", "()[B", "GetLoadHandler:Com.Yandex.Runtime.IDataProviderWithIdInvoker, Yandex.MapKit.Lite")]
	byte[] Load();

	[Register("providerId", "()Ljava/lang/String;", "GetProviderIdHandler:Com.Yandex.Runtime.IDataProviderWithIdInvoker, Yandex.MapKit.Lite")]
	string ProviderId();
}
