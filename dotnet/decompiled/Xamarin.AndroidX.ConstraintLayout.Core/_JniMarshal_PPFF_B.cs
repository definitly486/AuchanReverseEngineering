using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPFF_B(nint jnienv, nint klass, float p0, float p1);
