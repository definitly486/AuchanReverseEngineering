using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPFL_V(nint jnienv, nint klass, float p0, nint p1);
