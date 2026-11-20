using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLFB_V(nint jnienv, nint klass, nint p0, float p1, sbyte p2);
