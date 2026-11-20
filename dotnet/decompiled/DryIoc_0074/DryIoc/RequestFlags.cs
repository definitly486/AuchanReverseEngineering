using System;

namespace DryIoc;

[Flags]
public enum RequestFlags : byte
{
	Default = 0,
	TracksTransientDisposable = 1,
	IsSingletonOrDependencyOfSingleton = 2,
	IsWrappedInFunc = 4,
	IsResolutionCall = 8,
	OpensResolutionScope = 0x10,
	StopRecursiveDependencyCheck = 0x20,
	IsGeneratedResolutionDependencyExpression = 0x40,
	IsDirectlyWrappedInFunc = 0x80
}
