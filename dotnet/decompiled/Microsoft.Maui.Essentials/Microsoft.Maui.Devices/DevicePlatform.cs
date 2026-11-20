using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maui.Devices;

public readonly struct DevicePlatform : IEquatable<DevicePlatform>
{
	private readonly string devicePlatform;

	[CompilerGenerated]
	private static readonly DevicePlatform _003CmacOS_003Ek__BackingField = new DevicePlatform("macOS");

	[CompilerGenerated]
	private static readonly DevicePlatform _003CMacCatalyst_003Ek__BackingField = new DevicePlatform("MacCatalyst");

	[CompilerGenerated]
	private static readonly DevicePlatform _003CtvOS_003Ek__BackingField = new DevicePlatform("tvOS");

	[CompilerGenerated]
	private static readonly DevicePlatform _003CTizen_003Ek__BackingField = new DevicePlatform("Tizen");

	[CompilerGenerated]
	private static readonly DevicePlatform _003CUWP_003Ek__BackingField = new DevicePlatform("WinUI");

	[CompilerGenerated]
	private static readonly DevicePlatform _003CWinUI_003Ek__BackingField = new DevicePlatform("WinUI");

	[CompilerGenerated]
	private static readonly DevicePlatform _003CwatchOS_003Ek__BackingField = new DevicePlatform("watchOS");

	[CompilerGenerated]
	private static readonly DevicePlatform _003CUnknown_003Ek__BackingField = new DevicePlatform("Unknown");

	public static DevicePlatform Android { get; } = new DevicePlatform("Android");

	public static DevicePlatform iOS { get; } = new DevicePlatform("iOS");

	private DevicePlatform(string devicePlatform)
	{
		if (devicePlatform == null)
		{
			throw new ArgumentNullException("devicePlatform");
		}
		if (devicePlatform.Length == 0)
		{
			throw new ArgumentException("devicePlatform");
		}
		this.devicePlatform = devicePlatform;
	}

	public bool Equals(DevicePlatform other)
	{
		return Equals(other.devicePlatform);
	}

	internal bool Equals(string other)
	{
		return string.Equals(devicePlatform, other, StringComparison.Ordinal);
	}

	public override bool Equals(object obj)
	{
		if (obj is DevicePlatform)
		{
			return Equals((DevicePlatform)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (devicePlatform != null)
		{
			return devicePlatform.GetHashCode(StringComparison.Ordinal);
		}
		return 0;
	}

	public override string ToString()
	{
		return devicePlatform ?? string.Empty;
	}

	public static bool operator ==(DevicePlatform left, DevicePlatform right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(DevicePlatform left, DevicePlatform right)
	{
		return !left.Equals(right);
	}
}
