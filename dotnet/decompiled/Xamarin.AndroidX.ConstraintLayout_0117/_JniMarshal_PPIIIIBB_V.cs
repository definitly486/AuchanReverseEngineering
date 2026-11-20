using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPIIIIBB_V(nint jnienv, nint klass, int p0, int p1, int p2, int p3, sbyte p4, sbyte p5);
