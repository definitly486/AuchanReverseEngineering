using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPIBB_V(nint jnienv, nint klass, int p0, sbyte p1, sbyte p2);
