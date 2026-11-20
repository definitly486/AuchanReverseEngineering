using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPssII_L(nint jnienv, nint klass, ushort p0, ushort p1, int p2, int p3);
