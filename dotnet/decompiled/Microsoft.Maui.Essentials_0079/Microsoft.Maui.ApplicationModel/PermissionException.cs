using System;

namespace Microsoft.Maui.ApplicationModel;

public class PermissionException : UnauthorizedAccessException
{
	public PermissionException(string message)
		: base(message)
	{
	}
}
