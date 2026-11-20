using System;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Runtime.View;

[Register("com/yandex/runtime/view/Surface", "", "Com.Yandex.Runtime.View.ISurfaceInvoker")]
public interface ISurface : IJavaObject, IDisposable, IJavaPeerable
{
	PointF AnchorPoint
	{
		[Register("getAnchorPoint", "()Landroid/graphics/PointF;", "GetGetAnchorPointHandler:Com.Yandex.Runtime.View.ISurfaceInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setAnchorPoint", "(Landroid/graphics/PointF;)V", "GetSetAnchorPoint_Landroid_graphics_PointF_Handler:Com.Yandex.Runtime.View.ISurfaceInvoker, Yandex.MapKit.Lite")]
		set;
	}
}
