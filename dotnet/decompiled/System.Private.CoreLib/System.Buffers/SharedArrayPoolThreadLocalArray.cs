namespace System.Buffers;

internal struct SharedArrayPoolThreadLocalArray
{
	public Array Array;

	public int MillisecondsTimeStamp;

	public SharedArrayPoolThreadLocalArray(Array array)
	{
		Array = array;
		MillisecondsTimeStamp = 0;
	}
}
