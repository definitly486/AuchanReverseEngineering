using System;
using System.Globalization;
using Auchan.Common.Profile.Orders.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.Ecom.DTO;

public class CheckoutReceive
{
	public sealed class DateTimeOffsetConverter : IsoDateTimeConverter
	{
		public DateTimeOffsetConverter()
		{
			base.DateTimeFormat = "yyyy-MM-dd";
			base.Culture = CultureInfo.InvariantCulture;
		}
	}

	[JsonProperty("id")]
	public required long Id { get; set; }

	[JsonProperty("methodId")]
	public required DeliveryMethod MethodId { get; set; }

	[JsonProperty("deliveryAddress")]
	public UserAddress? DeliveryAddress { get; set; }

	[JsonProperty("delivery_to_door")]
	public bool DeliveryToDoor { get; set; }

	[JsonProperty("deliveryDate", NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(DateTimeOffsetConverter))]
	public DateTimeOffset? DeliveryDate { get; set; }

	[JsonProperty("deliveryDateTime", NullValueHandling = NullValueHandling.Ignore)]
	public string? DeliveryDateTime { get; set; }

	[JsonProperty("pickUpComment")]
	public string? PickupComment { get; set; }

	[JsonProperty("pickupDate", NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(DateTimeOffsetConverter))]
	public DateTimeOffset? PickupDate { get; set; }

	[JsonProperty("pickupDateTime")]
	public string? PickupDateTime { get; set; }

	[JsonProperty("promoCode")]
	public string? Promocode { get; set; }

	[JsonProperty("replacement_method_id")]
	public int? ReplacementMethodId { get; set; }

	[JsonProperty("used_points")]
	public decimal UsedPoints { get; set; }

	[JsonProperty("stamp_discount")]
	public bool DiscardStamps { get; set; }
}
