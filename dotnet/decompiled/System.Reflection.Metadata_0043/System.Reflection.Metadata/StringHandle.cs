using System.Reflection.Metadata.Ecma335;

namespace System.Reflection.Metadata;

public readonly struct StringHandle : IEquatable<StringHandle>
{
	internal enum VirtualIndex
	{
		System_Runtime_WindowsRuntime,
		System_Runtime,
		System_ObjectModel,
		System_Runtime_WindowsRuntime_UI_Xaml,
		System_Runtime_InteropServices_WindowsRuntime,
		System_Numerics_Vectors,
		Dispose,
		AttributeTargets,
		AttributeUsageAttribute,
		Color,
		CornerRadius,
		DateTimeOffset,
		Duration,
		DurationType,
		EventHandler1,
		EventRegistrationToken,
		Exception,
		GeneratorPosition,
		GridLength,
		GridUnitType,
		ICommand,
		IDictionary2,
		IDisposable,
		IEnumerable,
		IEnumerable1,
		IList,
		IList1,
		INotifyCollectionChanged,
		INotifyPropertyChanged,
		IReadOnlyDictionary2,
		IReadOnlyList1,
		KeyTime,
		KeyValuePair2,
		Matrix,
		Matrix3D,
		Matrix3x2,
		Matrix4x4,
		NotifyCollectionChangedAction,
		NotifyCollectionChangedEventArgs,
		NotifyCollectionChangedEventHandler,
		Nullable1,
		Plane,
		Point,
		PropertyChangedEventArgs,
		PropertyChangedEventHandler,
		Quaternion,
		Rect,
		RepeatBehavior,
		RepeatBehaviorType,
		Size,
		System,
		System_Collections,
		System_Collections_Generic,
		System_Collections_Specialized,
		System_ComponentModel,
		System_Numerics,
		System_Windows_Input,
		Thickness,
		TimeSpan,
		Type,
		Uri,
		Vector2,
		Vector3,
		Vector4,
		Windows_Foundation,
		Windows_UI,
		Windows_UI_Xaml,
		Windows_UI_Xaml_Controls_Primitives,
		Windows_UI_Xaml_Media,
		Windows_UI_Xaml_Media_Animation,
		Windows_UI_Xaml_Media_Media3D,
		Count
	}

	private readonly uint _value;

	internal bool IsVirtual => (_value & 0x80000000u) != 0;

	public bool IsNil => (_value & 0x9FFFFFFFu) == 0;

	internal StringKind StringKind => (StringKind)(_value >> 29);

	private StringHandle(uint value)
	{
		_value = value;
	}

	internal static StringHandle FromOffset(int heapOffset)
	{
		return new StringHandle((uint)(0 | heapOffset));
	}

	internal int GetHeapOffset()
	{
		return (int)(_value & 0x1FFFFFFF);
	}

	internal VirtualIndex GetVirtualIndex()
	{
		return (VirtualIndex)(_value & 0x1FFFFFFF);
	}

	public override bool Equals(object? obj)
	{
		if (obj is StringHandle)
		{
			return Equals((StringHandle)obj);
		}
		return false;
	}

	public bool Equals(StringHandle other)
	{
		return _value == other._value;
	}

	public override int GetHashCode()
	{
		return (int)_value;
	}

	public static bool operator ==(StringHandle left, StringHandle right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(StringHandle left, StringHandle right)
	{
		return !left.Equals(right);
	}
}
