using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate long _JniMarshal_PPI_J(nint jnienv, nint klass, int p0);
