using System;

namespace Java.Interop;

public struct JniNativeMethodRegistration
{
	public string Name;

	public string Signature;

	public Delegate Marshaler;

	public JniNativeMethodRegistration(string name, string signature, Delegate marshaler)
	{
		Name = name ?? throw new ArgumentNullException("name");
		Signature = signature ?? throw new ArgumentNullException("signature");
		Marshaler = marshaler ?? throw new ArgumentNullException("marshaler");
	}
}
