using System.Runtime.CompilerServices;

namespace System.Text.Json.Serialization;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class JsonStringEnumMemberNameAttribute : Attribute
{
	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
