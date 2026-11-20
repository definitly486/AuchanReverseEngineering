using System;

namespace DryIoc;

[Flags]
public enum FactoryFlags : byte
{
	Default = 0,
	PleaseDontSetDoNotCache = 1,
	DoNotCache = 2,
	AsResolutionCall = 4
}
