using System.Security.Cryptography;
using System.Text;

namespace Auchan.Common.Helpers;

public static class HashHelper
{
	public static string GetMD5(string input)
	{
		return GetMD5(input, Encoding.UTF8);
	}

	public static string GetMD5(string input, Encoding encoding)
	{
		byte[] array = MD5.HashData(encoding.GetBytes(input));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}
}
