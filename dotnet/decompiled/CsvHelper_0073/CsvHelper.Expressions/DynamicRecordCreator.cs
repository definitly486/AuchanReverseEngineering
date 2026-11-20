using System;
using System.Collections.Generic;

namespace CsvHelper.Expressions;

public class DynamicRecordCreator : RecordCreator
{
	public DynamicRecordCreator(CsvReader reader)
		: base(reader)
	{
	}

	protected override Delegate CreateCreateRecordDelegate(Type recordType)
	{
		return new Func<object>(CreateDynamicRecord);
	}

	protected virtual dynamic CreateDynamicRecord()
	{
		FastDynamicObject fastDynamicObject = new FastDynamicObject();
		IDictionary<string, object> dictionary = fastDynamicObject;
		if (base.Reader.HeaderRecord != null)
		{
			for (int i = 0; i < base.Reader.HeaderRecord.Length; i++)
			{
				GetDynamicPropertyNameArgs args = new GetDynamicPropertyNameArgs(i, base.Reader.Context);
				string key = base.Reader.Configuration.GetDynamicPropertyName(args);
				base.Reader.TryGetField(i, out string field);
				dictionary[key] = field;
			}
		}
		else
		{
			for (int j = 0; j < base.Reader.Parser.Count; j++)
			{
				GetDynamicPropertyNameArgs args2 = new GetDynamicPropertyNameArgs(j, base.Reader.Context);
				string key2 = base.Reader.Configuration.GetDynamicPropertyName(args2);
				string field2 = base.Reader.GetField(j);
				dictionary[key2] = field2;
			}
		}
		return fastDynamicObject;
	}
}
