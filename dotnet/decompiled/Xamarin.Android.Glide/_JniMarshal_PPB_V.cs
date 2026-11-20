using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPB_V(nint jnienv, nint klass, sbyte p0);
