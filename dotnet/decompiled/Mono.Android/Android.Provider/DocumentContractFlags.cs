using System.Runtime.Versioning;

namespace Android.Provider;

public enum DocumentContractFlags
{
	[SupportedOSPlatform("android30.0")]
	DirBlocksOpenDocumentTree = 32768,
	DirPrefersGrid = 16,
	DirPrefersLastModified = 32,
	DirSupportsCreate = 8,
	[SupportedOSPlatform("android29.0")]
	Partial = 8192,
	[SupportedOSPlatform("android24.0")]
	SupportsCopy = 128,
	SupportsDelete = 4,
	[SupportedOSPlatform("android29.0")]
	SupportsMetadata = 16384,
	[SupportedOSPlatform("android24.0")]
	SupportsMove = 256,
	[SupportedOSPlatform("android24.0")]
	SupportsRemove = 1024,
	SupportsRename = 64,
	[SupportedOSPlatform("android26.0")]
	SupportsSettings = 2048,
	SupportsThumbnail = 1,
	SupportsWrite = 2,
	[SupportedOSPlatform("android24.0")]
	VirtualDocument = 512,
	[SupportedOSPlatform("android26.0")]
	WebLinkable = 4096
}
