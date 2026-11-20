using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPLI_B(nint jnienv, nint klass, nint p0, int p1);
