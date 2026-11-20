using System;
using Android.Runtime;
using Java.Interop;

namespace Kotlin.Jvm.Internal.Markers;

[Register("kotlin/jvm/internal/markers/KMappedMarker", "", "Kotlin.Jvm.Internal.Markers.IKMappedMarkerInvoker")]
public interface IKMappedMarker : IJavaObject, IDisposable, IJavaPeerable
{
}
