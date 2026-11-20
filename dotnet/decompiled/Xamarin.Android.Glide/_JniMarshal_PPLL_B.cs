using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPLL_B(nint jnienv, nint klass, nint p0, nint p1);
