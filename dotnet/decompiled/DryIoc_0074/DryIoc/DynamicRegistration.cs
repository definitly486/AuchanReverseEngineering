namespace DryIoc;

public sealed class DynamicRegistration
{
	public readonly Factory Factory;

	public readonly IfAlreadyRegistered IfAlreadyRegistered;

	public readonly object ServiceKey;

	public DynamicRegistration(Factory factory, IfAlreadyRegistered ifAlreadyRegistered = IfAlreadyRegistered.AppendNotKeyed, object serviceKey = null)
	{
		Factory = factory.ThrowIfNull().DoNotCache();
		ServiceKey = serviceKey;
		IfAlreadyRegistered = ifAlreadyRegistered;
	}
}
