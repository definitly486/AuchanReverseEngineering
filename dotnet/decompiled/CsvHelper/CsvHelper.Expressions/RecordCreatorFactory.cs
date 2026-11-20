using System;
using System.Reflection;

namespace CsvHelper.Expressions;

public class RecordCreatorFactory
{
	private readonly DynamicRecordCreator dynamicRecordCreator;

	private readonly PrimitiveRecordCreator primitiveRecordCreator;

	private readonly ObjectRecordCreator objectRecordCreator;

	public RecordCreatorFactory(CsvReader reader)
	{
		dynamicRecordCreator = new DynamicRecordCreator(reader);
		primitiveRecordCreator = new PrimitiveRecordCreator(reader);
		objectRecordCreator = new ObjectRecordCreator(reader);
	}

	public virtual RecordCreator MakeRecordCreator(Type recordType)
	{
		if (recordType.GetTypeInfo().IsPrimitive)
		{
			return primitiveRecordCreator;
		}
		if (recordType == typeof(object))
		{
			return dynamicRecordCreator;
		}
		return objectRecordCreator;
	}
}
