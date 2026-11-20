using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLB_V(nint jnienv, nint klass, nint p0, sbyte p1);
