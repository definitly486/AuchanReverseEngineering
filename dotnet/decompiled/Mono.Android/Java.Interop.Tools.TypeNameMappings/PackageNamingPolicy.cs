using System;

namespace Java.Interop.Tools.TypeNameMappings;

internal enum PackageNamingPolicy
{
	[Obsolete("No longer supported. Use PackageNamingPolicy.LowercaseCrc64 instead.", true)]
	LowercaseHash = 0,
	Lowercase = 1,
	LowercaseWithAssemblyName = 2,
	[Obsolete("No longer supported. Use PackageNamingPolicy.LowercaseCrc64 instead.", true)]
	LowercaseMD5 = 0,
	LowercaseCrc64 = 3
}
