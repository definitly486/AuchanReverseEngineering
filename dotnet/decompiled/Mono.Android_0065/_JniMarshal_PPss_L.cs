using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPss_L(nint jnienv, nint klass, ushort p0, ushort p1);
