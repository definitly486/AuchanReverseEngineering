using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLFI_V(nint jnienv, nint klass, nint p0, float p1, int p2);
