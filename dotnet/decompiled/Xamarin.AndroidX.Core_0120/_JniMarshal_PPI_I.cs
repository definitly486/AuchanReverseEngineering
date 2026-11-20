using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate int _JniMarshal_PPI_I(nint jnienv, nint klass, int p0);
