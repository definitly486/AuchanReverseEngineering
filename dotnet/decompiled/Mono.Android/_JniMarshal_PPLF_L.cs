using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPLF_L(nint jnienv, nint klass, nint p0, float p1);
