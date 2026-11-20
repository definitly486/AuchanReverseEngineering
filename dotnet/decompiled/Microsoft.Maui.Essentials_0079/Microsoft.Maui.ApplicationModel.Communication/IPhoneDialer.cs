namespace Microsoft.Maui.ApplicationModel.Communication;

public interface IPhoneDialer
{
	bool IsSupported { get; }

	void Open(string number);
}
