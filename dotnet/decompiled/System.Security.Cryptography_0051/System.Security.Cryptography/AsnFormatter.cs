namespace System.Security.Cryptography;

internal abstract class AsnFormatter
{
	private static readonly AsnFormatter s_instance = new ManagedAsnFormatter();

	internal static AsnFormatter Instance => s_instance;

	public string Format(Oid oid, byte[] rawData, bool multiLine)
	{
		return FormatNative(oid, rawData, multiLine) ?? Convert.ToHexString(rawData);
	}

	protected abstract string FormatNative(Oid oid, byte[] rawData, bool multiLine);

	protected static string EncodeSpaceSeparatedHexString(byte[] sArray)
	{
		return string.Create(sArray.Length * 3 - 1, sArray, delegate(Span<char> hexOrder, byte[] array)
		{
			int num = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (i != 0)
				{
					hexOrder[num++] = ' ';
				}
				int num2 = array[i];
				hexOrder[num++] = System.HexConverter.ToCharUpper(num2 >> 4);
				hexOrder[num++] = System.HexConverter.ToCharUpper(num2);
			}
		});
	}
}
