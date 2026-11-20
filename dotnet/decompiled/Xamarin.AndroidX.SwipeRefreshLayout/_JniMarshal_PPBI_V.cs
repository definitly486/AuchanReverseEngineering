using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPBI_V(nint jnienv, nint klass, sbyte p0, int p1);
