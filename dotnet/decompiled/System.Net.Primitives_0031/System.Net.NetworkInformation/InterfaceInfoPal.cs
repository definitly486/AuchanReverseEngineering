using System.Buffers;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Net.NetworkInformation;

internal static class InterfaceInfoPal
{
	public static uint InterfaceNameToIndex<TChar>(ReadOnlySpan<TChar> interfaceName) where TChar : unmanaged, IBinaryNumber<TChar>
	{
		int num = 0;
		byte[] array = null;
		if (typeof(TChar) == typeof(byte))
		{
			num = interfaceName.Length + 1;
		}
		else if (typeof(TChar) == typeof(char))
		{
			ReadOnlySpan<char> chars = MemoryMarshal.Cast<TChar, char>(interfaceName);
			num = Encoding.UTF8.GetByteCount(chars) + 1;
		}
		try
		{
			Span<byte> span = (((uint)num > 512u) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(num))) : stackalloc byte[512]).Slice(0, num);
			if (typeof(TChar) == typeof(byte))
			{
				MemoryMarshal.Cast<TChar, byte>(interfaceName).CopyTo(span);
			}
			else if (typeof(TChar) == typeof(char))
			{
				ReadOnlySpan<char> chars2 = MemoryMarshal.Cast<TChar, char>(interfaceName);
				Encoding.UTF8.GetBytes(chars2, span);
			}
			span[span.Length - 1] = 0;
			return global::Interop.Sys.InterfaceNameToIndex(span);
		}
		finally
		{
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}
	}
}
