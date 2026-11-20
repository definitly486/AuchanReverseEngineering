using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Deeplinks;

public sealed class DeeplinkTypeConverter : JsonConverter
{
	private readonly Dictionary<string, DeeplinkType> _values = new Dictionary<string, DeeplinkType>
	{
		{
			"category",
			DeeplinkType.Category
		},
		{
			"product",
			DeeplinkType.Product
		},
		{
			"authorization",
			DeeplinkType.Authorization
		},
		{
			"cart",
			DeeplinkType.Cart
		},
		{
			"cashback",
			DeeplinkType.Cashback
		},
		{
			"catalog",
			DeeplinkType.Catalog
		},
		{
			"info-exchange-refund",
			DeeplinkType.InfoExchangeRefund
		},
		{
			"info-payment-delivery",
			DeeplinkType.InfoPaymentDelivery
		},
		{
			"info-faq",
			DeeplinkType.InfoFAQ
		},
		{
			"profile",
			DeeplinkType.Profile
		},
		{
			"selfscan",
			DeeplinkType.Selfscan
		},
		{
			"user-subscription",
			DeeplinkType.UserSubscriptions
		},
		{
			"streams",
			DeeplinkType.Streams
		},
		{
			"gift-cards",
			DeeplinkType.GiftCards
		},
		{
			"notifications",
			DeeplinkType.Notifications
		}
	};

	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
	}

	public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
	{
		DeeplinkType deeplinkType = DeeplinkType.None;
		string text = reader.Value?.ToString()?.Replace("*", "");
		if (!string.IsNullOrEmpty(text) && _values.ContainsKey(text))
		{
			deeplinkType = _values[text];
		}
		return deeplinkType;
	}

	public override bool CanConvert(Type objectType)
	{
		return true;
	}
}
