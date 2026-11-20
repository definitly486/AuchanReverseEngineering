using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPL_L(nint jnienv, nint klass, nint p0);
