namespace System.Reflection.Emit;

internal struct ILExceptionBlock
{
	internal Type extype;

	internal int type;

	internal int start;

	internal int len;

	internal int filter_offset;
}
