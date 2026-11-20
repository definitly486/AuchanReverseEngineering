using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPLIIL_B(nint jnienv, nint klass, nint p0, int p1, int p2, nint p3);
