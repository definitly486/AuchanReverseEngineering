using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPBL_V(nint jnienv, nint klass, sbyte p0, nint p1);
