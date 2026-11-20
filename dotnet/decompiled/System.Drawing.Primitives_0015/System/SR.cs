namespace System;

internal static class SR
{
	internal static string Format(string resourceFormat, object p1)
	{
		_ = 1;
		global::_003C_003Ey__InlineArray2<object> buffer = default(global::_003C_003Ey__InlineArray2<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<object>, object>(ref buffer, 0) = resourceFormat;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<object>, object>(ref buffer, 1) = p1;
		return string.Join(", ", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<object>, object>(in buffer, 2));
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		_ = 1;
		global::_003C_003Ey__InlineArray3<object> buffer = default(global::_003C_003Ey__InlineArray3<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<object>, object>(ref buffer, 0) = resourceFormat;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<object>, object>(ref buffer, 1) = p1;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<object>, object>(ref buffer, 2) = p2;
		return string.Join(", ", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray3<object>, object>(in buffer, 3));
	}

	internal static string Format(string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			_ = 1;
			return resourceFormat + ", " + string.Join(", ", args);
		}
		return resourceFormat;
	}
}
