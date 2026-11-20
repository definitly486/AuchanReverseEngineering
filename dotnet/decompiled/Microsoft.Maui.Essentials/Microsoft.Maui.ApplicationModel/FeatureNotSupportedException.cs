using System;

namespace Microsoft.Maui.ApplicationModel;

public class FeatureNotSupportedException : NotSupportedException
{
	public FeatureNotSupportedException()
	{
	}

	public FeatureNotSupportedException(string message)
		: base(message)
	{
	}
}
