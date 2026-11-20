using System;
using Newtonsoft.Json.Serialization;

namespace Akavache;

internal class JsonDateTimeContractResolver(IContractResolver? contractResolver, DateTimeKind? forceDateTimeKindOverride) : DefaultContractResolver()
{
	public IContractResolver? ExistingContractResolver { get; set; } = contractResolver;

	public DateTimeKind? ForceDateTimeKindOverride { get; set; } = forceDateTimeKindOverride;

	public JsonDateTimeContractResolver()
		: this(null, null)
	{
	}

	public override JsonContract ResolveContract(Type type)
	{
		JsonContract jsonContract = ExistingContractResolver?.ResolveContract(type);
		if (jsonContract?.Converter != null)
		{
			return jsonContract;
		}
		if (jsonContract == null)
		{
			jsonContract = base.ResolveContract(type);
		}
		if (type == typeof(DateTime) || type == typeof(DateTime?))
		{
			jsonContract.Converter = ((ForceDateTimeKindOverride == DateTimeKind.Local) ? JsonDateTimeTickConverter.LocalDateTimeKindDefault : JsonDateTimeTickConverter.Default);
		}
		else if (type == typeof(DateTimeOffset) || type == typeof(DateTimeOffset?))
		{
			jsonContract.Converter = JsonDateTimeOffsetTickConverter.Default;
		}
		return jsonContract;
	}
}
