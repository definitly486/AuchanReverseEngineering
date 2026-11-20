namespace NanoXLSX;

public struct Range
{
	public Address EndAddress;

	public Address StartAddress;

	public Range(Address start, Address end)
	{
		if (start.CompareTo(end) < 0)
		{
			StartAddress = start;
			EndAddress = end;
		}
		else
		{
			StartAddress = end;
			EndAddress = start;
		}
	}

	public override string ToString()
	{
		Address startAddress = StartAddress;
		string text = startAddress.ToString();
		startAddress = EndAddress;
		return text + ":" + startAddress.ToString();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Range range))
		{
			return false;
		}
		if (StartAddress.Equals(range.StartAddress))
		{
			return EndAddress.Equals(range.EndAddress);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ToString().GetHashCode();
	}

	public static bool operator ==(Range range1, Range range2)
	{
		return range1.Equals(range2);
	}

	public static bool operator !=(Range range1, Range range2)
	{
		return !range1.Equals(range2);
	}
}
