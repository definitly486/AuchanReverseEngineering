using System;
using System.Collections.Generic;
using System.Linq;

namespace CsvHelper.Expressions;

public abstract class RecordWriter
{
	private readonly Dictionary<int, Delegate> typeActions = new Dictionary<int, Delegate>();

	private readonly int objectHashCode = typeof(object).GetHashCode();

	protected CsvWriter Writer { get; private set; }

	protected ExpressionManager ExpressionManager { get; private set; }

	public RecordWriter(CsvWriter writer)
	{
		Writer = writer;
		ExpressionManager = ObjectResolver.Current.Resolve<ExpressionManager>(new object[1] { writer });
	}

	public virtual Action<T> GetWriteDelegate<T>(RecordTypeInfo typeInfo)
	{
		int num = typeInfo.HashCode;
		if (typeInfo.IsObject)
		{
			num = HashCode.Combine(objectHashCode, num);
		}
		if (!typeActions.TryGetValue(num, out Delegate value))
		{
			value = (typeActions[num] = CreateWriteDelegate<T>(typeInfo.RecordType));
		}
		return (Action<T>)value;
	}

	protected virtual Action<T> CreateWriteDelegate<T>(T record)
	{
		return CreateWriteDelegate<T>(Writer.GetTypeInfoForRecord(record).RecordType);
	}

	protected abstract Action<T> CreateWriteDelegate<T>(Type recordType);

	protected virtual Action<T>? CombineDelegates<T>(IEnumerable<Action<T>> delegates)
	{
		return (Action<T>)delegates.Aggregate<Delegate, Delegate>(null, Delegate.Combine);
	}
}
