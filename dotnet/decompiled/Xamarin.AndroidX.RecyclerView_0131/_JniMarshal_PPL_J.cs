using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate long _JniMarshal_PPL_J(nint jnienv, nint klass, nint p0);
