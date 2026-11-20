namespace Java.Interop;

internal struct JavaVMInterface
{
	public nint reserved0;

	public nint reserved1;

	public nint reserved2;

	public DestroyJavaVMDelegate DestroyJavaVM;

	public AttachCurrentThreadDelegate AttachCurrentThread;

	public DetachCurrentThreadDelegate DetachCurrentThread;

	public GetEnvDelegate GetEnv;

	public AttachCurrentThreadAsDaemonDelegate AttachCurrentThreadAsDaemon;
}
