namespace Java.Interop;

internal struct JavaVMThreadAttachArgs
{
	public JniVersion version;

	public nint name;

	public nint group;
}
