namespace DryIoc;

public enum IfUnresolved : byte
{
	Throw,
	ReturnDefault,
	ReturnDefaultIfNotRegistered
}
