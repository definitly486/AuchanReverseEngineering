using System;
using System.Collections;
using System.Linq;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion;

public class CollectionGenericConverter : IEnumerableConverter
{
	public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
	{
		IList list = (IList)ObjectResolver.Current.Resolve(memberMapData.Member.MemberType());
		Type type = memberMapData.Member.MemberType().GetGenericArguments()[0];
		ITypeConverter converter = row.Context.TypeConverterCache.GetConverter(type);
		if (memberMapData.IsNameSet || (row.Configuration.HasHeaderRecord && !memberMapData.IsIndexSet))
		{
			object field;
			for (int i = 0; row.TryGetField(type, memberMapData.Names.FirstOrDefault() ?? string.Empty, i, out field); i++)
			{
				list.Add(field);
			}
		}
		else
		{
			int num = ((memberMapData.IndexEnd < memberMapData.Index) ? (row.Parser.Count - 1) : memberMapData.IndexEnd);
			for (int j = memberMapData.Index; j <= num; j++)
			{
				object value = converter.ConvertFromString(row.GetField(j), row, memberMapData);
				list.Add(value);
			}
		}
		return list;
	}
}
