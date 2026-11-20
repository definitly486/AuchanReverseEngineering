using System;

namespace Polly.Utilities;

internal static class KeyHelper
{
	private const int GuidPartLength = 8;

	public static string GuidPart()
	{
		return Guid.NewGuid().ToString().Substring(0, 8);
	}
}
