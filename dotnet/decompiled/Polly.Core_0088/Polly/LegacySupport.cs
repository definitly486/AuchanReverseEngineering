using System.Collections.Generic;
using System.ComponentModel;
using Polly.Utils;

namespace Polly;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class LegacySupport
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void SetProperties(this ResilienceProperties resilienceProperties, IDictionary<string, object?> properties, out IDictionary<string, object?> oldProperties)
	{
		Guard.NotNull(resilienceProperties, "resilienceProperties");
		Guard.NotNull(properties, "properties");
		oldProperties = resilienceProperties.Options;
		resilienceProperties.Options = properties;
	}
}
