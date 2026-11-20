using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate double _JniMarshal_PPI_D(nint jnienv, nint klass, int p0);
