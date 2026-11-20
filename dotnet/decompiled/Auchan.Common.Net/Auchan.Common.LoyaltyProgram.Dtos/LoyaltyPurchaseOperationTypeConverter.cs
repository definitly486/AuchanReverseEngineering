using System;
using System.Collections.Generic;
using Auchan.Common.LoyaltyProgram.Enums;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public sealed class LoyaltyPurchaseOperationTypeConverter : JsonConverter
{
	private readonly Dictionary<string, LoyaltyPurchaseOperationTypeDto> _values = new Dictionary<string, LoyaltyPurchaseOperationTypeDto>
	{
		{
			"PF",
			LoyaltyPurchaseOperationTypeDto.PointsIncome
		},
		{
			"ER",
			LoyaltyPurchaseOperationTypeDto.Purchase
		},
		{
			"PC",
			LoyaltyPurchaseOperationTypeDto.PurchaseReturn
		},
		{
			"PE",
			LoyaltyPurchaseOperationTypeDto.PointsExpiration
		},
		{
			"RV",
			LoyaltyPurchaseOperationTypeDto.PurchaseReturn
		}
	};

	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
	}

	public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
	{
		LoyaltyPurchaseOperationTypeDto loyaltyPurchaseOperationTypeDto = LoyaltyPurchaseOperationTypeDto.Undefined;
		string text = reader.Value?.ToString();
		if (!string.IsNullOrEmpty(text) && _values.ContainsKey(text))
		{
			loyaltyPurchaseOperationTypeDto = _values[text];
		}
		return loyaltyPurchaseOperationTypeDto;
	}

	public override bool CanConvert(Type objectType)
	{
		return true;
	}
}
