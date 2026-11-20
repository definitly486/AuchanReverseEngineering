namespace System.Reflection.Metadata;

internal struct TypeNameParseOptions
{
	internal bool IsAssemblyGetType { get; }

	public TypeNameParseOptions()
	{
		IsAssemblyGetType = false;
	}
}
