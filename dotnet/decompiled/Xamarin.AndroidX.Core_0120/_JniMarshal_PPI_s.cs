using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate ushort _JniMarshal_PPI_s(nint jnienv, nint klass, int p0);
