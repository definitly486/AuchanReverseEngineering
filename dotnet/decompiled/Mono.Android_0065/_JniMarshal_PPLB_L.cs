using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPLB_L(nint jnienv, nint klass, nint p0, sbyte p1);
