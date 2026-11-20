using System;

namespace Refit;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
public class QueryAttribute : Attribute
{
	private CollectionFormat? collectionFormat;

	public string Delimiter { get; protected set; } = ".";

	public string? Prefix { get; protected set; }

	public string? Format { get; set; }

	public CollectionFormat CollectionFormat
	{
		get
		{
			return collectionFormat.GetValueOrDefault();
		}
		set
		{
			collectionFormat = value;
		}
	}

	public bool IsCollectionFormatSpecified => collectionFormat.HasValue;

	public QueryAttribute()
	{
	}

	public QueryAttribute(string delimiter)
	{
		Delimiter = delimiter;
	}

	public QueryAttribute(string delimiter, string prefix)
	{
		Delimiter = delimiter;
		Prefix = prefix;
	}

	public QueryAttribute(string delimiter, string prefix, string format)
	{
		Delimiter = delimiter;
		Prefix = prefix;
		Format = format;
	}

	public QueryAttribute(CollectionFormat collectionFormat)
	{
		CollectionFormat = collectionFormat;
	}
}
