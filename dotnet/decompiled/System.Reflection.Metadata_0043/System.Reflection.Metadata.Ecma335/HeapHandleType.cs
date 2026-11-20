namespace System.Reflection.Metadata.Ecma335;

internal static class HeapHandleType
{
	internal static bool IsValidHeapOffset(uint offset)
	{
		return (offset & 0xE0000000u) == 0;
	}
}
