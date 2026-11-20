using System;
using System.Collections.Generic;
using Microsoft.Maui.Devices;

namespace Microsoft.Maui.Storage;

public class FilePickerFileType
{
	private readonly IDictionary<DevicePlatform, IEnumerable<string>> fileTypes;

	public IEnumerable<string> Value => GetPlatformFileType(DeviceInfo.Current.Platform);

	public FilePickerFileType(IDictionary<DevicePlatform, IEnumerable<string>> fileTypes)
	{
		this.fileTypes = fileTypes;
	}

	protected virtual IEnumerable<string> GetPlatformFileType(DevicePlatform platform)
	{
		if (fileTypes.TryGetValue(platform, out IEnumerable<string> value))
		{
			return value;
		}
		throw new PlatformNotSupportedException("This platform does not support this file type.");
	}
}
