using System;

namespace Refit;

public enum BodySerializationMethod
{
	Default,
	[Obsolete("Use BodySerializationMethod.Serialized instead", false)]
	Json,
	UrlEncoded,
	Serialized
}
