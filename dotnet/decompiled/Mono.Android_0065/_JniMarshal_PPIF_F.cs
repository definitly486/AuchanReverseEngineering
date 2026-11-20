using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate float _JniMarshal_PPIF_F(nint jnienv, nint klass, int p0, float p1);
