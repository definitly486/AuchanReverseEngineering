using System.Text;

namespace SQLitePCL;

internal static class util
{
	public static utf8z to_utf8z(this string s)
	{
		return utf8z.FromString(s);
	}

	public static byte[] to_utf8_with_z(this string sourceText)
	{
		if (sourceText == null)
		{
			return null;
		}
		byte[] array = new byte[Encoding.UTF8.GetByteCount(sourceText) + 1];
		int bytes = Encoding.UTF8.GetBytes(sourceText, 0, sourceText.Length, array, 0);
		array[bytes] = 0;
		return array;
	}
}
