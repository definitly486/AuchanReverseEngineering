namespace SkiaSharp;

internal interface ISKNonVirtualReferenceCounted : ISKReferenceCounted
{
	void UnreferenceNative();
}
