using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Tiles;

[Register("com/yandex/mapkit/tiles/TileProvider", "", "Com.Yandex.Mapkit.Tiles.ITileProviderInvoker")]
public interface ITileProvider : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("load", "(Lcom/yandex/mapkit/TileId;Lcom/yandex/mapkit/Version;Ljava/util/Map;Ljava/lang/String;)Lcom/yandex/mapkit/RawTile;", "GetLoad_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map_Ljava_lang_String_Handler:Com.Yandex.Mapkit.Tiles.ITileProviderInvoker, Yandex.MapKit.Lite")]
	RawTile Load(TileId p0, Version p1, IDictionary<string, string> p2, string p3);
}
