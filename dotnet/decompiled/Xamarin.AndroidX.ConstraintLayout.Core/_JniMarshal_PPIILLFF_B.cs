using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPIILLFF_B(nint jnienv, nint klass, int p0, int p1, nint p2, nint p3, float p4, float p5);
