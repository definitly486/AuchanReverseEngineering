using System;

namespace Android.Runtime;

[Obsolete("Please use [System.Diagnostics.CodeAnalysis.DynamicDependencyAttribute]")]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
public sealed class PreserveAttribute : Attribute
{
	public bool AllMembers;

	public bool Conditional;
}
