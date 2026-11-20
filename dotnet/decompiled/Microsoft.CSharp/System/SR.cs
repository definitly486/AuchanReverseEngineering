namespace System;

internal static class SR
{
	internal static string GetResourceString(string resourceKey)
	{
		_ = 1;
		return resourceKey;
	}

	internal static string GetResourceString(string resourceKey, string defaultString)
	{
		string resourceString = GetResourceString(resourceKey);
		if (!(resourceKey == resourceString) && resourceString != null)
		{
			return resourceString;
		}
		return defaultString;
	}

	internal static string Format(string resourceFormat, object p1)
	{
		_ = 1;
		global::_003C_003Ey__InlineArray2<object> buffer = default(global::_003C_003Ey__InlineArray2<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<object>, object>(ref buffer, 0) = resourceFormat;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<object>, object>(ref buffer, 1) = p1;
		return string.Join(", ", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<object>, object>(in buffer, 2));
	}
}
