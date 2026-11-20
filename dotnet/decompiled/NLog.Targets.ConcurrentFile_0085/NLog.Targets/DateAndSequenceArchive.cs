using System;

namespace NLog.Targets;

internal sealed class DateAndSequenceArchive
{
	private readonly string _dateFormat;

	public string FileName { get; }

	public DateTime Date { get; }

	public int Sequence { get; }

	public bool HasValidSequence
	{
		get
		{
			if (Sequence != int.MinValue)
			{
				return Sequence != int.MaxValue;
			}
			return false;
		}
	}

	public bool HasSameFormattedDate(DateTime date)
	{
		return string.Equals(date.ToString(_dateFormat), Date.ToString(_dateFormat), StringComparison.Ordinal);
	}

	public DateAndSequenceArchive(string fileName, DateTime date, string dateFormat, int sequence)
	{
		FileName = fileName ?? throw new ArgumentNullException("fileName");
		_dateFormat = dateFormat ?? throw new ArgumentNullException("dateFormat");
		Date = date;
		Sequence = sequence;
	}
}
