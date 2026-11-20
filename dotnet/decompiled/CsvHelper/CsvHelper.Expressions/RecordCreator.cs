using System;
using System.Collections.Generic;

namespace CsvHelper.Expressions;

public abstract class RecordCreator
{
	private readonly Dictionary<Type, Delegate> createRecordFuncs = new Dictionary<Type, Delegate>();

	protected CsvReader Reader { get; private set; }

	protected ExpressionManager ExpressionManager { get; private set; }

	public RecordCreator(CsvReader reader)
	{
		Reader = reader;
		ExpressionManager = new ExpressionManager(reader);
	}

	public virtual Func<T> GetCreateRecordDelegate<T>(Type recordType)
	{
		if (!createRecordFuncs.TryGetValue(recordType, out Delegate value))
		{
			value = (createRecordFuncs[recordType] = CreateCreateRecordDelegate(recordType));
		}
		return (Func<T>)value;
	}

	protected abstract Delegate CreateCreateRecordDelegate(Type recordType);
}
