namespace System.Text.Json.Serialization.Metadata;

public class DefaultJsonTypeInfoResolver
{
	private static MemberAccessor s_memberAccessor;

	internal static void ClearMemberAccessorCaches()
	{
		s_memberAccessor?.Clear();
	}
}
