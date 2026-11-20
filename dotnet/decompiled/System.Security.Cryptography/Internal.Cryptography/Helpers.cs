using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Cryptography;

namespace Internal.Cryptography;

internal static class Helpers
{
	internal static readonly PbeParameters Windows3desPbe;

	internal static readonly PbeParameters WindowsAesPbe;

	[UnsupportedOSPlatformGuard("browser")]
	[UnsupportedOSPlatformGuard("wasi")]
	internal static bool HasSymmetricEncryption { get; }

	[UnsupportedOSPlatformGuard("browser")]
	[UnsupportedOSPlatformGuard("wasi")]
	internal static bool HasMD5 { get; }

	[return: NotNullIfNotNull("src")]
	public static byte[] CloneByteArray(this byte[] src)
	{
		if (src != null)
		{
			if (src.Length == 0)
			{
				return src;
			}
			return (byte[])src.Clone();
		}
		return null;
	}

	internal static bool ContainsNull<T>(this ReadOnlySpan<T> span)
	{
		return Unsafe.IsNullRef(in MemoryMarshal.GetReference(span));
	}

	internal static void RngFill(Span<byte> destination)
	{
		RandomNumberGenerator.Fill(destination);
	}

	public static bool UsesIv(this CipherMode cipherMode)
	{
		return cipherMode != CipherMode.ECB;
	}

	public static byte[] GetCipherIv(this CipherMode cipherMode, byte[] iv)
	{
		if (cipherMode.UsesIv())
		{
			if (iv == null)
			{
				throw new CryptographicException("Cryptography_MissingIV");
			}
			return iv;
		}
		return null;
	}

	public static byte[] FixupKeyParity(this byte[] key)
	{
		byte[] array = new byte[key.Length];
		for (int i = 0; i < key.Length; i++)
		{
			array[i] = (byte)(key[i] & 0xFE);
			byte b = (byte)((array[i] & 0xF) ^ (array[i] >> 4));
			byte b2 = (byte)((b & 3) ^ (b >> 2));
			if ((byte)((b2 & 1) ^ (b2 >> 1)) == 0)
			{
				array[i] |= 1;
			}
		}
		return array;
	}

	internal static char[] ToHexArrayUpper(this byte[] bytes)
	{
		char[] array = new char[bytes.Length * 2];
		System.HexConverter.EncodeToUtf16(bytes, array);
		return array;
	}

	internal static string ToHexStringUpper(this byte[] bytes)
	{
		return Convert.ToHexString(bytes);
	}

	internal static bool ContentsEqual(this byte[] a1, byte[] a2)
	{
		if (a1 == null)
		{
			return a2 == null;
		}
		if (a2 == null || a1.Length != a2.Length)
		{
			return false;
		}
		return ((ReadOnlySpan<byte>)a1.AsSpan()).SequenceEqual((ReadOnlySpan<byte>)a2);
	}

	internal static ReadOnlyMemory<byte> DecodeOctetStringAsMemory(ReadOnlyMemory<byte> encodedOctetString)
	{
		try
		{
			ReadOnlySpan<byte> span = encodedOctetString.Span;
			if (AsnDecoder.TryReadPrimitiveOctetString(span, AsnEncodingRules.BER, out var value, out var bytesConsumed))
			{
				if (bytesConsumed != span.Length)
				{
					throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
				}
				if (span.Overlaps(value, out var elementOffset))
				{
					return encodedOctetString.Slice(elementOffset, value.Length);
				}
			}
			byte[] array = AsnDecoder.ReadOctetString(span, AsnEncodingRules.BER, out bytesConsumed);
			if (bytesConsumed != span.Length)
			{
				throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
			}
			return array;
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}

	internal static bool IsValidDay(this Calendar calendar, int year, int month, int day, int era)
	{
		if (calendar.IsValidMonth(year, month, era) && day >= 1)
		{
			return day <= calendar.GetDaysInMonth(year, month, era);
		}
		return false;
	}

	private static bool IsValidMonth(this Calendar calendar, int year, int month, int era)
	{
		if (calendar.IsValidYear(year) && month >= 1)
		{
			return month <= calendar.GetMonthsInYear(year, era);
		}
		return false;
	}

	private static bool IsValidYear(this Calendar calendar, int year)
	{
		if (year >= calendar.GetYear(calendar.MinSupportedDateTime))
		{
			return year <= calendar.GetYear(calendar.MaxSupportedDateTime);
		}
		return false;
	}

	internal static void DisposeAll(this IEnumerable<IDisposable> disposables)
	{
		foreach (IDisposable disposable in disposables)
		{
			disposable.Dispose();
		}
	}

	public static int GetPaddingSize(this SymmetricAlgorithm algorithm, CipherMode mode, int feedbackSizeInBits)
	{
		return ((mode == CipherMode.CFB) ? feedbackSizeInBits : algorithm.BlockSize) / 8;
	}

	internal static ReadOnlyMemory<byte>? ToNullableMemory(this byte[] array)
	{
		if (array == null)
		{
			return null;
		}
		return array;
	}

	static Helpers()
	{
		_ = 0;
		HasSymmetricEncryption = 0 == 0;
		_ = 0;
		HasMD5 = 0 == 0;
		Windows3desPbe = new PbeParameters(PbeEncryptionAlgorithm.TripleDes3KeyPkcs12, HashAlgorithmName.SHA1, 2000);
		WindowsAesPbe = new PbeParameters(PbeEncryptionAlgorithm.Aes256Cbc, HashAlgorithmName.SHA256, 2000);
	}
}
