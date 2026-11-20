namespace DryIoc;

public enum IfAlreadyRegistered : byte
{
	AppendNotKeyed,
	Throw,
	Keep,
	Replace,
	AppendNewImplementation
}
