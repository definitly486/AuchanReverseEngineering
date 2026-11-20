using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal struct StringHeap
{
	private static string[] s_virtualValues;

	internal readonly MemoryBlock Block;

	private VirtualHeap _lazyVirtualHeap;

	internal StringHeap(MemoryBlock block, MetadataKind metadataKind)
	{
		_lazyVirtualHeap = null;
		if (s_virtualValues == null && metadataKind != MetadataKind.Ecma335)
		{
			s_virtualValues = new string[71]
			{
				"System.Runtime.WindowsRuntime", "System.Runtime", "System.ObjectModel", "System.Runtime.WindowsRuntime.UI.Xaml", "System.Runtime.InteropServices.WindowsRuntime", "System.Numerics.Vectors", "Dispose", "AttributeTargets", "AttributeUsageAttribute", "Color",
				"CornerRadius", "DateTimeOffset", "Duration", "DurationType", "EventHandler`1", "EventRegistrationToken", "Exception", "GeneratorPosition", "GridLength", "GridUnitType",
				"ICommand", "IDictionary`2", "IDisposable", "IEnumerable", "IEnumerable`1", "IList", "IList`1", "INotifyCollectionChanged", "INotifyPropertyChanged", "IReadOnlyDictionary`2",
				"IReadOnlyList`1", "KeyTime", "KeyValuePair`2", "Matrix", "Matrix3D", "Matrix3x2", "Matrix4x4", "NotifyCollectionChangedAction", "NotifyCollectionChangedEventArgs", "NotifyCollectionChangedEventHandler",
				"Nullable`1", "Plane", "Point", "PropertyChangedEventArgs", "PropertyChangedEventHandler", "Quaternion", "Rect", "RepeatBehavior", "RepeatBehaviorType", "Size",
				"System", "System.Collections", "System.Collections.Generic", "System.Collections.Specialized", "System.ComponentModel", "System.Numerics", "System.Windows.Input", "Thickness", "TimeSpan", "Type",
				"Uri", "Vector2", "Vector3", "Vector4", "Windows.Foundation", "Windows.UI", "Windows.UI.Xaml", "Windows.UI.Xaml.Controls.Primitives", "Windows.UI.Xaml.Media", "Windows.UI.Xaml.Media.Animation",
				"Windows.UI.Xaml.Media.Media3D"
			};
		}
		Block = TrimEnd(block);
	}

	private static MemoryBlock TrimEnd(MemoryBlock block)
	{
		if (block.Length == 0)
		{
			return block;
		}
		int num = block.Length - 1;
		while (num >= 0 && block.PeekByte(num) == 0)
		{
			num--;
		}
		if (num == block.Length - 1)
		{
			return block;
		}
		return block.GetMemoryBlockAt(0, num + 2);
	}

	internal string GetString(StringHandle handle, MetadataStringDecoder utf8Decoder)
	{
		if (!handle.IsVirtual)
		{
			return GetNonVirtualString(handle, utf8Decoder, null);
		}
		return GetVirtualHandleString(handle, utf8Decoder);
	}

	internal static string GetVirtualString(StringHandle.VirtualIndex index)
	{
		return s_virtualValues[(int)index];
	}

	private string GetNonVirtualString(StringHandle handle, MetadataStringDecoder utf8Decoder, byte[] prefixOpt)
	{
		char terminator = ((handle.StringKind == StringKind.DotTerminated) ? '.' : '\0');
		int numberOfBytesRead;
		return Block.PeekUtf8NullTerminated(handle.GetHeapOffset(), prefixOpt, utf8Decoder, out numberOfBytesRead, terminator);
	}

	private string GetVirtualHandleString(StringHandle handle, MetadataStringDecoder utf8Decoder)
	{
		return handle.StringKind switch
		{
			StringKind.Virtual => GetVirtualString(handle.GetVirtualIndex()), 
			StringKind.WinRTPrefixed => GetNonVirtualString(handle, utf8Decoder, MetadataReader.WinRTPrefix), 
			_ => throw ExceptionUtilities.UnexpectedValue(handle.StringKind), 
		};
	}

	internal bool EqualsRaw(StringHandle rawHandle, string asciiString)
	{
		return Block.CompareUtf8NullTerminatedStringWithAsciiString(rawHandle.GetHeapOffset(), asciiString) == 0;
	}
}
