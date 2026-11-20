using System;
using System.Collections.Generic;
using Android.Runtime;
using Android.Util;
using Java.Interop;

namespace AndroidX.Camera.Core.ResolutionSelector;

[Register("androidx/camera/core/resolutionselector/ResolutionFilter", "", "AndroidX.Camera.Core.ResolutionSelector.IResolutionFilterInvoker")]
public interface IResolutionFilter : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("filter", "(Ljava/util/List;I)Ljava/util/List;", "GetFilter_Ljava_util_List_IHandler:AndroidX.Camera.Core.ResolutionSelector.IResolutionFilterInvoker, Xamarin.AndroidX.Camera.Core")]
	IList<Size> Filter(IList<Size> p0, int p1);
}
