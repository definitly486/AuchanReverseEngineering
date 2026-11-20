using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLIIF_V(nint jnienv, nint klass, nint p0, int p1, int p2, float p3);
