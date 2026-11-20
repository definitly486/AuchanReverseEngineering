using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPBBBB_V(nint jnienv, nint klass, sbyte p0, sbyte p1, sbyte p2, sbyte p3);
