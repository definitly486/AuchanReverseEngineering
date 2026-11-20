namespace NLog.MessageTemplates;

internal readonly struct Hole
{
	public readonly string Name;

	public readonly string? Format;

	public readonly CaptureType CaptureType;

	public readonly short Index;

	public readonly short Alignment;

	public Hole(string name, string? format, CaptureType captureType, short parameterIndex, short alignment)
	{
		Name = name;
		Format = format;
		CaptureType = captureType;
		Index = parameterIndex;
		Alignment = alignment;
	}
}
