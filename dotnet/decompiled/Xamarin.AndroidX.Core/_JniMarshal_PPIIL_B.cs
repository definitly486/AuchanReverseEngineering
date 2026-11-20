using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPIIL_B(nint jnienv, nint klass, int p0, int p1, nint p2);
