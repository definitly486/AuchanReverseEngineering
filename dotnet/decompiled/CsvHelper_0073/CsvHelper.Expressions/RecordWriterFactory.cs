using System;
using System.Collections.Generic;
using System.Dynamic;

namespace CsvHelper.Expressions;

public class RecordWriterFactory
{
	private readonly ExpandoObjectRecordWriter expandoObjectRecordWriter;

	private readonly DynamicRecordWriter dynamicRecordWriter;

	private readonly PrimitiveRecordWriter primitiveRecordWriter;

	private readonly ObjectRecordWriter objectRecordWriter;

	public RecordWriterFactory(CsvWriter writer)
	{
		expandoObjectRecordWriter = new ExpandoObjectRecordWriter(writer);
		dynamicRecordWriter = new DynamicRecordWriter(writer);
		primitiveRecordWriter = new PrimitiveRecordWriter(writer);
		objectRecordWriter = new ObjectRecordWriter(writer);
	}

	public virtual RecordWriter MakeRecordWriter(Type recordType)
	{
		if (recordType.IsPrimitive)
		{
			return primitiveRecordWriter;
		}
		if (typeof(IDictionary<string, object>).IsAssignableFrom(recordType))
		{
			return expandoObjectRecordWriter;
		}
		if (typeof(IDynamicMetaObjectProvider).IsAssignableFrom(recordType))
		{
			return dynamicRecordWriter;
		}
		return objectRecordWriter;
	}
}
