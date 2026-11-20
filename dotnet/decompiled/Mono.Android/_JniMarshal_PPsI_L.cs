using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPsI_L(nint jnienv, nint klass, ushort p0, int p1);
