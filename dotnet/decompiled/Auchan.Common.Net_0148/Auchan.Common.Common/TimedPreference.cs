using System;
using Newtonsoft.Json;

namespace Auchan.Common.Common;

internal class TimedPreference<T>
{
	[JsonProperty("expiration")]
	public DateTime Expiration { get; set; }

	[JsonProperty("value")]
	public T Value { get; set; }

	[JsonConstructor]
	public TimedPreference(T value, TimeSpan lifespan)
	{
		Value = value;
		Expiration = DateTime.UtcNow.Add(lifespan);
	}

	public TimedPreference(T value)
	{
		Value = value;
		Expiration = DateTime.UtcNow.Add(TimeSpan.FromDays(30));
	}
}
