using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate float _JniMarshal_PPI_F(nint jnienv, nint klass, int p0);
