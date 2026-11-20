namespace System.Xml;

internal static class BinHexEncoder
{
	internal static void Encode(byte[] buffer, int index, int count, XmlWriter writer)
	{
		ArgumentNullException.ThrowIfNull(buffer, "buffer");
		ArgumentOutOfRangeException.ThrowIfNegative(index, "index");
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(count, buffer.Length - index, "count");
		char[] array = new char[(count * 2 < 128) ? (count * 2) : 128];
		int num = index + count;
		while (index < num)
		{
			int num2 = ((count < 64) ? count : 64);
			System.HexConverter.EncodeToUtf16(buffer.AsSpan(index, num2), array);
			writer.WriteRaw(array, 0, num2 * 2);
			index += num2;
			count -= num2;
		}
	}

	internal static string Encode(byte[] inArray, int offsetIn, int count)
	{
		return Convert.ToHexString(inArray, offsetIn, count);
	}
}
