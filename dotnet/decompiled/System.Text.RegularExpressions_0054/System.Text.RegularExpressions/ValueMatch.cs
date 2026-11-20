namespace System.Text.RegularExpressions;

public readonly ref struct ValueMatch
{
	private readonly int _index;

	private readonly int _length;

	public int Index => _index;

	internal ValueMatch(int index, int length)
	{
		_index = index;
		_length = length;
	}
}
