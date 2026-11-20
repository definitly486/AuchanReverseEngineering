using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate float _JniMarshal_PPLI_F(nint jnienv, nint klass, nint p0, int p1);
