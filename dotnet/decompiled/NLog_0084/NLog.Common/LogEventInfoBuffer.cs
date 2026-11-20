using System;
using System.ComponentModel;
using NLog.Internal;

namespace NLog.Common;

[Obsolete("Use AsyncRequestQueue instead. Marked obsolete on NLog 5.0")]
[EditorBrowsable(EditorBrowsableState.Never)]
public class LogEventInfoBuffer
{
	private readonly object _lockObject = new object();

	private readonly bool _growAsNeeded;

	private readonly int _growLimit;

	private AsyncLogEventInfo[] _buffer;

	private int _getPointer;

	private int _putPointer;

	private int _count;

	public int Size => _buffer.Length;

	internal int Count
	{
		get
		{
			lock (_lockObject)
			{
				return _count;
			}
		}
	}

	public LogEventInfoBuffer(int size, bool growAsNeeded, int growLimit)
	{
		_growAsNeeded = growAsNeeded;
		_buffer = new AsyncLogEventInfo[size];
		_growLimit = growLimit;
		_getPointer = 0;
		_putPointer = 0;
	}

	public int Append(AsyncLogEventInfo eventInfo)
	{
		lock (_lockObject)
		{
			if (_count >= _buffer.Length)
			{
				if (_growAsNeeded && _buffer.Length < _growLimit)
				{
					int num = _buffer.Length * 2;
					if (num >= _growLimit)
					{
						num = _growLimit;
					}
					InternalLogger.Trace("Enlarging LogEventInfoBuffer from {0} to {1}", _buffer.Length, num);
					AsyncLogEventInfo[] array = new AsyncLogEventInfo[num];
					Array.Copy(_buffer, 0, array, 0, _buffer.Length);
					_buffer = array;
				}
				else
				{
					_getPointer++;
				}
			}
			_putPointer %= _buffer.Length;
			_buffer[_putPointer] = eventInfo;
			_putPointer++;
			_count++;
			if (_count >= _buffer.Length)
			{
				_count = _buffer.Length;
			}
			return _count;
		}
	}

	public AsyncLogEventInfo[] GetEventsAndClear()
	{
		lock (_lockObject)
		{
			int count = _count;
			if (count == 0)
			{
				return ArrayHelper.Empty<AsyncLogEventInfo>();
			}
			AsyncLogEventInfo[] array = new AsyncLogEventInfo[count];
			for (int i = 0; i < count; i++)
			{
				int num = (_getPointer + i) % _buffer.Length;
				AsyncLogEventInfo asyncLogEventInfo = _buffer[num];
				_buffer[num] = default(AsyncLogEventInfo);
				array[i] = asyncLogEventInfo;
			}
			_count = 0;
			_getPointer = 0;
			_putPointer = 0;
			return array;
		}
	}
}
