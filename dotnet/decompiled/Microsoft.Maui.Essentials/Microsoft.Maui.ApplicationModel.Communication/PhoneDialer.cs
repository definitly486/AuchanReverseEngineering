namespace Microsoft.Maui.ApplicationModel.Communication;

public static class PhoneDialer
{
	private static IPhoneDialer? defaultImplementation;

	public static IPhoneDialer Default => defaultImplementation ?? (defaultImplementation = new PhoneDialerImplementation());
}
