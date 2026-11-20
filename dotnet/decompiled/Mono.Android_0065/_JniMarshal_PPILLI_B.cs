using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPILLI_B(nint jnienv, nint klass, int p0, nint p1, nint p2, int p3);
