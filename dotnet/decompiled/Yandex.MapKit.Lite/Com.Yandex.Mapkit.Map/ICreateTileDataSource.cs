using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/CreateTileDataSource", "", "Com.Yandex.Mapkit.Map.ICreateTileDataSourceInvoker")]
public interface ICreateTileDataSource : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("createTileDataSource", "(Lcom/yandex/mapkit/map/TileDataSourceBuilder;)V", "GetCreateTileDataSource_Lcom_yandex_mapkit_map_TileDataSourceBuilder_Handler:Com.Yandex.Mapkit.Map.ICreateTileDataSourceInvoker, Yandex.MapKit.Lite")]
	void CreateTileDataSource(ITileDataSourceBuilder p0);
}
