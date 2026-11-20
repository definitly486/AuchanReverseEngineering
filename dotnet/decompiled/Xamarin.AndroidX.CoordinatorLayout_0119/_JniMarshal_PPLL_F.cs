using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate float _JniMarshal_PPLL_F(nint jnienv, nint klass, nint p0, nint p1);
