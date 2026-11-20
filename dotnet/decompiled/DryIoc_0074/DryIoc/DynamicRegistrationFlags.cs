using System;

namespace DryIoc;

[Flags]
public enum DynamicRegistrationFlags : byte
{
	NoFlags = 0,
	AsFallback = 1,
	Service = 2,
	Decorator = 4,
	DecoratorOfAnyTypeViaObjectServiceType = 8
}
