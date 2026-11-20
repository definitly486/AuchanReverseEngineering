using System;
using System.Text.RegularExpressions;

namespace Auchan.Common.PersonalCabinet.Authorization.AuthPush;

public class AuthPushListener
{
	public Action<string>? OnPinReceivedAction { get; set; }

	public void TryFindPin(string? stringFromPush)
	{
		if (stringFromPush != null && !string.IsNullOrWhiteSpace(stringFromPush))
		{
			string value = Regex.Match(stringFromPush, "\\d+", RegexOptions.None, TimeSpan.FromSeconds(60L)).Value;
			if (value != null && value.Length == 4)
			{
				OnPinReceivedAction?.Invoke(value);
			}
		}
	}
}
