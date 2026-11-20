using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Unicode;

namespace System.Text.Encodings.Web;

public class TextEncoderSettings
{
	private AllowedBmpCodePointsBitmap _allowedCodePointsBitmap;

	public TextEncoderSettings(params UnicodeRange[] allowedRanges)
	{
		if (allowedRanges == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.allowedRanges);
		}
		AllowRanges(allowedRanges);
	}

	public virtual void AllowRange(UnicodeRange range)
	{
		if (range == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.range);
		}
		int firstCodePoint = range.FirstCodePoint;
		int length = range.Length;
		for (int i = 0; i < length; i++)
		{
			int num = firstCodePoint + i;
			_allowedCodePointsBitmap.AllowChar((char)num);
		}
	}

	public virtual void AllowRanges(params UnicodeRange[] ranges)
	{
		if (ranges == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.ranges);
		}
		for (int i = 0; i < ranges.Length; i++)
		{
			AllowRange(ranges[i]);
		}
	}

	public virtual IEnumerable<int> GetAllowedCodePoints()
	{
		for (int i = 0; i <= 65535; i++)
		{
			if (_allowedCodePointsBitmap.IsCharAllowed((char)i))
			{
				yield return i;
			}
		}
	}

	internal ref readonly AllowedBmpCodePointsBitmap GetAllowedCodePointsBitmap()
	{
		if (GetType() == typeof(TextEncoderSettings))
		{
			return ref _allowedCodePointsBitmap;
		}
		StrongBox<AllowedBmpCodePointsBitmap> strongBox = new StrongBox<AllowedBmpCodePointsBitmap>();
		foreach (int allowedCodePoint in GetAllowedCodePoints())
		{
			if ((uint)allowedCodePoint <= 65535u)
			{
				strongBox.Value.AllowChar((char)allowedCodePoint);
			}
		}
		return ref strongBox.Value;
	}
}
