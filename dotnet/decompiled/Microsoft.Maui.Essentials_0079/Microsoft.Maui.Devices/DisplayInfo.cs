using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maui.Devices;

public readonly struct DisplayInfo : IEquatable<DisplayInfo>
{
	[CompilerGenerated]
	private readonly float _003CRefreshRate_003Ek__BackingField;

	public double Width { get; }

	public double Height { get; }

	public double Density { get; }

	public DisplayOrientation Orientation { get; }

	public DisplayRotation Rotation { get; }

	public DisplayInfo(double width, double height, double density, DisplayOrientation orientation, DisplayRotation rotation, float rate)
	{
		Width = width;
		Height = height;
		Density = density;
		Orientation = orientation;
		Rotation = rotation;
		_003CRefreshRate_003Ek__BackingField = rate;
	}

	public static bool operator ==(DisplayInfo left, DisplayInfo right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(DisplayInfo left, DisplayInfo right)
	{
		return !left.Equals(right);
	}

	public override bool Equals(object obj)
	{
		if (obj is DisplayInfo other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(DisplayInfo other)
	{
		if (Width.Equals(other.Width) && Height.Equals(other.Height) && Density.Equals(other.Density) && Orientation.Equals(other.Orientation))
		{
			return Rotation.Equals(other.Rotation);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (Height, Width, Density, Orientation, Rotation).GetHashCode();
	}

	public override string ToString()
	{
		return $"{"Height"}: {Height}, {"Width"}: {Width}, {"Density"}: {Density}, {"Orientation"}: {Orientation}, {"Rotation"}: {Rotation}";
	}
}
