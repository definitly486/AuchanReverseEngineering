using System;

namespace CsvHelper;

public struct RecordTypeInfo
{
	public Type RecordType { get; }

	public bool IsObject { get; }

	public int HashCode { get; }

	public RecordTypeInfo(Type recordType, bool isObject)
	{
		RecordType = recordType;
		IsObject = isObject;
		HashCode = recordType.GetHashCode();
	}
}
