using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPLLLL_B(nint jnienv, nint klass, nint p0, nint p1, nint p2, nint p3);
