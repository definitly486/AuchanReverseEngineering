using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPIFI_V(nint jnienv, nint klass, int p0, float p1, int p2);
