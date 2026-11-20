using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPFB_V(nint jnienv, nint klass, float p0, sbyte p1);
