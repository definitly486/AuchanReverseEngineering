using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Tiles;

[Register("com/yandex/mapkit/tiles/UrlProvider", "", "Com.Yandex.Mapkit.Tiles.IUrlProviderInvoker")]
public interface IUrlProvider : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("formatUrl", "(Lcom/yandex/mapkit/TileId;Lcom/yandex/mapkit/Version;Ljava/util/Map;)Ljava/lang/String;", "GetFormatUrl_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map_Handler:Com.Yandex.Mapkit.Tiles.IUrlProviderInvoker, Yandex.MapKit.Lite")]
	string FormatUrl(TileId p0, Version p1, IDictionary<string, string> p2);
}
