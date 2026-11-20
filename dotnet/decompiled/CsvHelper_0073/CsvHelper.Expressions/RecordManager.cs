using System;

namespace CsvHelper.Expressions;

public class RecordManager
{
	private readonly RecordCreatorFactory? recordCreatorFactory;

	private readonly RecordHydrator? recordHydrator;

	private readonly RecordWriterFactory? recordWriterFactory;

	public RecordManager(CsvReader reader)
	{
		recordCreatorFactory = ObjectResolver.Current.Resolve<RecordCreatorFactory>(new object[1] { reader });
		recordHydrator = ObjectResolver.Current.Resolve<RecordHydrator>(new object[1] { reader });
	}

	public RecordManager(CsvWriter writer)
	{
		recordWriterFactory = ObjectResolver.Current.Resolve<RecordWriterFactory>(new object[1] { writer });
	}

	public Func<T> GetReadDelegate<T>(Type recordType)
	{
		if (recordCreatorFactory == null)
		{
			throw new InvalidOperationException("The record creator factory is null.");
		}
		return recordCreatorFactory.MakeRecordCreator(recordType).GetCreateRecordDelegate<T>(recordType);
	}

	public void Hydrate<T>(T record)
	{
		if (recordHydrator == null)
		{
			throw new InvalidOperationException("The record hydrator is null.");
		}
		recordHydrator.Hydrate(record);
	}

	public Action<T> GetWriteDelegate<T>(RecordTypeInfo typeInfo)
	{
		if (recordWriterFactory == null)
		{
			throw new InvalidOperationException("The record creator factory is null.");
		}
		return recordWriterFactory.MakeRecordWriter(typeInfo.RecordType).GetWriteDelegate<T>(typeInfo);
	}
}
