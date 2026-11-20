using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class Sse3 : Sse2
{
	public new abstract class X64 : Sse2.X64
	{
		public new static bool IsSupported
		{
			[Intrinsic]
			get
			{
				return false;
			}
		}
	}

	public new static bool IsSupported
	{
		[Intrinsic]
		get
		{
			return false;
		}
	}

	public static Vector128<float> AddSubtract(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> AddSubtract(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> HorizontalAdd(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> HorizontalAdd(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> HorizontalSubtract(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> HorizontalSubtract(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<double> LoadAndDuplicateToVector128(double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<sbyte> LoadDquVector128(sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<byte> LoadDquVector128(byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<short> LoadDquVector128(short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<ushort> LoadDquVector128(ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<int> LoadDquVector128(int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<uint> LoadDquVector128(uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<long> LoadDquVector128(long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<ulong> LoadDquVector128(ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> MoveAndDuplicate(Vector128<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> MoveHighAndDuplicate(Vector128<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> MoveLowAndDuplicate(Vector128<float> source)
	{
		throw new PlatformNotSupportedException();
	}
}
