using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPBI_B(nint jnienv, nint klass, sbyte p0, int p1);
