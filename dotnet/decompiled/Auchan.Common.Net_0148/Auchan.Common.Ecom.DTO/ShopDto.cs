using System.Collections.Generic;
using Auchan.Common.Ecom.Replacements;
using Auchan.Common.Profile.Orders.Enums;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class ShopDto
{
	[JsonProperty("merchant_id", Required = Required.Always)]
	public int MerchantId { get; set; }

	[JsonProperty("name", Required = Required.Always)]
	public string Name { get; set; }

	[JsonProperty("name_auchan", Required = Required.Always)]
	public string NameAuchan { get; set; }

	[JsonProperty("default", Required = Required.Always)]
	public bool Default { get; set; }

	[JsonProperty("region_id", Required = Required.Always)]
	public long RegionId { get; set; }

	[JsonProperty("address_string")]
	public string? AddressString { get; set; }

	[JsonProperty("geo_lat")]
	public float? GeoLat { get; set; }

	[JsonProperty("geo_lon")]
	public float? GeoLon { get; set; }

	[JsonProperty("delivery")]
	public ShopDeliveryDto? Delivery { get; set; }

	[JsonProperty("express_delivery")]
	public ShopExpressDeliveryDto? ExpressDelivery { get; set; }

	[JsonProperty("express_starts_at")]
	public string? ExpressStartsAt { get; set; }

	[JsonProperty("express_ends_at")]
	public string? ExpressEndsAt { get; set; }

	[JsonProperty("pickup")]
	public ShopPickupDto? Pickup { get; set; }

	[JsonProperty("car_pickup")]
	public ShopPickupDto? CarPickup { get; set; }

	[JsonProperty("delivery_methods")]
	public List<ReceiveMethod> ReceiveMethods { get; set; }

	[JsonProperty("delivery_to_door")]
	public bool? DeliveryToDoor { get; set; }

	[JsonProperty("payment_methods")]
	public List<PaymentMethod> PaymentMethods { get; set; }

	[JsonProperty("time_work")]
	public TimeWorkDto TimeWork { get; set; }

	[JsonProperty("temp_time_work", Required = Required.Default)]
	public List<TempWorkHoursDto> TempTimeWork { get; set; } = new List<TempWorkHoursDto>();

	[JsonProperty("format")]
	public string? Format { get; set; }

	[JsonProperty("phone")]
	public string? Phone { get; set; }

	[JsonProperty("email")]
	public string? Email { get; set; }

	[JsonProperty("photo_urls")]
	public IReadOnlyList<string> PhotoUrls { get; set; }

	[JsonProperty("schema_urls")]
	public IReadOnlyList<string> SchemaUrls { get; set; }

	[JsonProperty("description")]
	public string? Description { get; set; }

	[JsonProperty("pickup_description")]
	public string? PickupDescription { get; set; }

	[JsonProperty("pickup_schema_url")]
	public string? PickupSchemaUrl { get; set; }

	[JsonProperty("car_pickup_description")]
	public string? CarPickupDescription { get; set; }

	[JsonProperty("car_pickup_schema_url")]
	public string? CarPickupSchemaUrl { get; set; }

	[JsonProperty("pickup_position")]
	public int? PickupPosition { get; set; }

	[JsonProperty("collect_order")]
	public bool? CollectOrder { get; set; }

	[JsonProperty("replacement")]
	public IEnumerable<ReplacementDto>? Replacements { get; set; }

	[JsonProperty("interval")]
	public double? DistanceFromUserLocation { get; set; }

	[JsonProperty("delivery_starts_at")]
	public string? DeliveryStartsAt { get; set; }

	[JsonProperty("delivery_ends_at")]
	public string? DeliveryEndsAt { get; set; }

	[JsonProperty("services", Required = Required.Default)]
	public List<ShopServiceDto> Services { get; set; } = new List<ShopServiceDto>();

	[JsonProperty("public_transport", Required = Required.Default)]
	public string? PublicTransport { get; set; }

	[JsonProperty("temp_work_description", Required = Required.Default)]
	public string? TempWorkDescription { get; set; }

	[JsonProperty("temp_work_text_color", Required = Required.Default)]
	public string? TempWorkTextColor { get; set; }

	[JsonProperty("temp_work_background_color", Required = Required.Default)]
	public string? TempWorkBackgroundColor { get; set; }

	[JsonProperty("working_status", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsOpen { get; set; }

	[JsonProperty("working_status_description", Required = Required.Default)]
	public string? OpenStatusDescription { get; set; }

	[JsonProperty("parking_lots")]
	public int? ParkingLots { get; set; }
}
