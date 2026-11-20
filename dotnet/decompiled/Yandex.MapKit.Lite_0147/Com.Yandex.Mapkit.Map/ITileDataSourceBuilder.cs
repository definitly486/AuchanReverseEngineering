using System;
using System.Collections.Generic;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry.Geo;
using Com.Yandex.Mapkit.Layers;
using Com.Yandex.Mapkit.Tiles;
using Java.Interop;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/TileDataSourceBuilder", "", "Com.Yandex.Mapkit.Map.ITileDataSourceBuilderInvoker")]
public interface ITileDataSourceBuilder : IBaseDataSourceBuilder, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("setProjection", "(Lcom/yandex/mapkit/geometry/geo/Projection;)V", "GetSetProjection_Lcom_yandex_mapkit_geometry_geo_Projection_Handler:Com.Yandex.Mapkit.Map.ITileDataSourceBuilderInvoker, Yandex.MapKit.Lite")]
	void SetProjection(IProjection p0);

	[Register("setTileFormat", "(Lcom/yandex/mapkit/layers/TileFormat;)V", "GetSetTileFormat_Lcom_yandex_mapkit_layers_TileFormat_Handler:Com.Yandex.Mapkit.Map.ITileDataSourceBuilderInvoker, Yandex.MapKit.Lite")]
	void SetTileFormat(TileFormat p0);

	[Register("setTileProvider", "(Lcom/yandex/mapkit/tiles/TileProvider;)V", "GetSetTileProvider_Lcom_yandex_mapkit_tiles_TileProvider_Handler:Com.Yandex.Mapkit.Map.ITileDataSourceBuilderInvoker, Yandex.MapKit.Lite")]
	void SetTileProvider(ITileProvider p0);

	[Register("setTileUrlProvider", "(Lcom/yandex/mapkit/tiles/UrlProvider;)V", "GetSetTileUrlProvider_Lcom_yandex_mapkit_tiles_UrlProvider_Handler:Com.Yandex.Mapkit.Map.ITileDataSourceBuilderInvoker, Yandex.MapKit.Lite")]
	void SetTileUrlProvider(IUrlProvider p0);

	[Register("setZoomRanges", "(Ljava/util/List;)V", "GetSetZoomRanges_Ljava_util_List_Handler:Com.Yandex.Mapkit.Map.ITileDataSourceBuilderInvoker, Yandex.MapKit.Lite")]
	void SetZoomRanges(IList<ZoomRange> p0);
}
