namespace Java.Interop;

internal delegate int GetEnvDelegate(nint javavm, out nint envptr, int version);
