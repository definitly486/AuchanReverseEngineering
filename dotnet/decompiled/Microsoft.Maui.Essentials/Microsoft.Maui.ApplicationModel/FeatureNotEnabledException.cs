using System;

namespace Microsoft.Maui.ApplicationModel;

public class FeatureNotEnabledException : InvalidOperationException
{
	public FeatureNotEnabledException(string message)
		: base(message)
	{
	}
}
