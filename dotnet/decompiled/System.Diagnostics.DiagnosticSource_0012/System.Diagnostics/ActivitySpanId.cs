using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Diagnostics;

public readonly struct ActivitySpanId : IEquatable<ActivitySpanId>
{
	private readonly string _hexString;

	internal ActivitySpanId(string hexString)
	{
		_hexString = hexString;
	}

	public unsafe static ActivitySpanId CreateRandom()
	{
		Unsafe.SkipInit(out ulong num);
		ActivityTraceId.SetToRandomBytes(new Span<byte>(&num, 8));
		return new ActivitySpanId(Convert.ToHexStringLower(new ReadOnlySpan<byte>(&num, 8)));
	}

	public static ActivitySpanId CreateFromString(ReadOnlySpan<char> idData)
	{
		if (idData.Length != 16 || !ActivityTraceId.IsLowerCaseHexAndNotAllZeros(idData))
		{
			throw new ArgumentOutOfRangeException("idData");
		}
		return new ActivitySpanId(idData.ToString());
	}

	public string ToHexString()
	{
		return _hexString ?? "0000000000000000";
	}

	public override string ToString()
	{
		return ToHexString();
	}

	public static bool operator ==(ActivitySpanId spanId1, ActivitySpanId spandId2)
	{
		return spanId1._hexString == spandId2._hexString;
	}

	public static bool operator !=(ActivitySpanId spanId1, ActivitySpanId spandId2)
	{
		return spanId1._hexString != spandId2._hexString;
	}

	public bool Equals(ActivitySpanId spanId)
	{
		return _hexString == spanId._hexString;
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is ActivitySpanId activitySpanId)
		{
			return _hexString == activitySpanId._hexString;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ToHexString().GetHashCode();
	}
}
