using System;

namespace NLog.Internal;

internal sealed class SimpleStringReader
{
	private readonly string _text;

	internal int Position { get; set; }

	internal string Text => _text;

	public SimpleStringReader(string text)
	{
		_text = text;
		Position = 0;
	}

	internal int Peek()
	{
		if (Position < _text.Length)
		{
			return _text[Position];
		}
		return -1;
	}

	internal int Read()
	{
		if (Position < _text.Length)
		{
			return _text[Position++];
		}
		return -1;
	}

	internal string Substring(int startIndex, int endIndex)
	{
		return _text.Substring(startIndex, endIndex - startIndex);
	}

	internal string ReadUntilMatch(Func<int, bool> charFinder)
	{
		int position = Position;
		int arg;
		while ((arg = Peek()) != -1)
		{
			if (charFinder(arg))
			{
				return Substring(position, Position);
			}
			Read();
		}
		return Substring(position, Position);
	}
}
