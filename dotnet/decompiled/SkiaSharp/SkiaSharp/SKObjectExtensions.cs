namespace SkiaSharp;

internal static class SKObjectExtensions
{
	public static void SafeUnRef(this ISKReferenceCounted obj)
	{
		if (obj is ISKNonVirtualReferenceCounted iSKNonVirtualReferenceCounted)
		{
			iSKNonVirtualReferenceCounted.UnreferenceNative();
		}
		else
		{
			SkiaApi.sk_refcnt_safe_unref(obj.Handle);
		}
	}
}
