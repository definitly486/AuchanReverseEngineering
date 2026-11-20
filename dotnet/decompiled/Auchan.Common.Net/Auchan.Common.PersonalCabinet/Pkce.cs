using System;
using System.Security.Cryptography;
using System.Text;

namespace Auchan.Common.PersonalCabinet;

internal static class Pkce
{
	public static (string codeChallenge, string verifier) Generate(int size = 32)
	{
		using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
		byte[] data = new byte[size];
		randomNumberGenerator.GetBytes(data);
		string text = Base64UrlEncode(data);
		byte[] bytes = Encoding.UTF8.GetBytes(text);
		using SHA256 sHA = SHA256.Create();
		return (codeChallenge: Base64UrlEncode(sHA.ComputeHash(bytes)), verifier: text);
	}

	private static string Base64UrlEncode(byte[] data)
	{
		return Convert.ToBase64String(data).Replace("+", "-").Replace("/", "_")
			.TrimEnd('=');
	}
}
