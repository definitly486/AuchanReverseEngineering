using System;

namespace Akavache.Core;

[AttributeUsage(AttributeTargets.All)]
internal sealed class PreserveAttribute : Attribute
{
	public bool AllMembers { get; set; }

	public bool Conditional { get; }

	public PreserveAttribute(bool allMembers, bool conditional)
	{
		AllMembers = allMembers;
		Conditional = conditional;
	}

	public PreserveAttribute()
	{
	}
}
