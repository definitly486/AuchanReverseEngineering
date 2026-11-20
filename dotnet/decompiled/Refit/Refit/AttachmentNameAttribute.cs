using System;

namespace Refit;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
[Obsolete("Use Refit.StreamPart, Refit.ByteArrayPart, Refit.FileInfoPart or if necessary, inherit from Refit.MultipartItem", false)]
public class AttachmentNameAttribute(string name) : Attribute()
{
	public string Name { get; protected set; } = name;
}
