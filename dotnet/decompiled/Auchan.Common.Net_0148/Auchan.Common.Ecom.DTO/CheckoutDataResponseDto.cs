using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Auchan.Common.Networking;
using Auchan.Common.Profile.Orders.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.Ecom.DTO;

internal sealed record CheckoutDataResponseDto : ApiV2ResponseDto, IVpnStateDto
{
	internal sealed record DataDto
	{
		[JsonProperty("recipient", Required = Required.Always)]
		public required RecipientDto Recipient { get; init; }

		[JsonProperty("delivery_method", Required = Required.Always)]
		public required DeliveryMethodDto DeliveryMethod { get; init; }

		[JsonProperty("additional_benefit")]
		public required AdditionalBenefitDto? AdditionalBenefit { get; init; }

		[JsonProperty("products")]
		public required IReadOnlyList<ProductDto>? Products { get; init; }

		[JsonProperty("adult_products")]
		public required IReadOnlyList<ProductDto>? AdultProducts { get; init; }

		[JsonProperty("summary", Required = Required.Always)]
		public required SummaryDto Summary { get; init; }

		[JsonProperty("available_payments", Required = Required.Always)]
		public required IReadOnlyList<AvailablePaymentDto> AvailablePayments { get; init; }

		[JsonProperty("replacements", Required = Required.Always)]
		public required IReadOnlyList<ReplacementDto> Replacements { get; init; }

		[JsonProperty("needs_recalculate")]
		public required bool? NeedsRecalculate { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private DataDto(DataDto original)
		{
			Recipient = original.Recipient;
			DeliveryMethod = original.DeliveryMethod;
			AdditionalBenefit = original.AdditionalBenefit;
			Products = original.Products;
			AdultProducts = original.AdultProducts;
			Summary = original.Summary;
			AvailablePayments = original.AvailablePayments;
			Replacements = original.Replacements;
			NeedsRecalculate = original.NeedsRecalculate;
		}

		public DataDto()
		{
		}
	}

	internal sealed record RecipientDto
	{
		[JsonProperty("name")]
		public required string? Name { get; init; }

		[JsonProperty("phone")]
		public required string? Phone { get; init; }

		[JsonProperty("email")]
		public required string? Email { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private RecipientDto(RecipientDto original)
		{
			Name = original.Name;
			Phone = original.Phone;
			Email = original.Email;
		}

		public RecipientDto()
		{
		}
	}

	internal sealed record DeliveryMethodDto
	{
		[JsonProperty("id", Required = Required.Always)]
		public required long Id { get; init; }

		[JsonProperty("method_id", Required = Required.Always)]
		public required DeliveryMethod Method { get; init; }

		[JsonProperty("delivery_to_door")]
		public required bool? ToDoor { get; init; }

		[JsonProperty("address")]
		public required AddressDto? Address { get; init; }

		[JsonProperty("shop")]
		public required ShopDto? Shop { get; init; }

		[JsonProperty("car")]
		public required CarDto? Car { get; init; }

		[JsonProperty("dates")]
		public required IReadOnlyList<DateDto>? Dates { get; init; }

		[JsonProperty("delivery_time_hint")]
		public required string? DeliveryTimeHint { get; init; }

		[JsonProperty("min_slot_price")]
		public required decimal? MinSlotPrice { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private DeliveryMethodDto(DeliveryMethodDto original)
		{
			Id = original.Id;
			Method = original.Method;
			ToDoor = original.ToDoor;
			Address = original.Address;
			Shop = original.Shop;
			Car = original.Car;
			Dates = original.Dates;
			DeliveryTimeHint = original.DeliveryTimeHint;
			MinSlotPrice = original.MinSlotPrice;
		}

		public DeliveryMethodDto()
		{
		}
	}

	internal sealed record AddressDto
	{
		[JsonProperty("address_string", Required = Required.Always)]
		public required string Address { get; init; }

		[JsonProperty("flat")]
		public required string? Flat { get; init; }

		[JsonProperty("floor")]
		public required string? Floor { get; init; }

		[JsonProperty("porch")]
		public required string? Porch { get; init; }

		[JsonProperty("intercom")]
		public required string? Intercom { get; init; }

		[JsonProperty("comment")]
		public required string? Comment { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private AddressDto(AddressDto original)
		{
			Address = original.Address;
			Flat = original.Flat;
			Floor = original.Floor;
			Porch = original.Porch;
			Intercom = original.Intercom;
			Comment = original.Comment;
		}

		public AddressDto()
		{
		}
	}

	internal sealed record ShopDto
	{
		[JsonProperty("address_string", Required = Required.Always)]
		public required string Address { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private ShopDto(ShopDto original)
		{
			Address = original.Address;
		}

		public ShopDto()
		{
		}
	}

	internal sealed record CarDto
	{
		[JsonProperty("car_color")]
		public required string? Color { get; init; }

		[JsonProperty("car_mark")]
		public required string? Brand { get; init; }

		[JsonProperty("car_number")]
		public required string? Number { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private CarDto(CarDto original)
		{
			Color = original.Color;
			Brand = original.Brand;
			Number = original.Number;
		}

		public CarDto()
		{
		}
	}

	internal sealed record DateDto
	{
		[JsonProperty("date", Required = Required.Always)]
		public required DateTimeOffset Date { get; init; }

		[JsonProperty("day", Required = Required.Always)]
		public required string Day { get; init; }

		[JsonProperty("times", Required = Required.Always)]
		public required IReadOnlyList<TimeDto> Time { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private DateDto(DateDto original)
		{
			Date = original.Date;
			Day = original.Day;
			Time = original.Time;
		}

		public DateDto()
		{
		}
	}

	internal sealed record TimeDto
	{
		[JsonProperty("id", Required = Required.Always)]
		public required string Id { get; init; }

		[JsonProperty("timeslot", Required = Required.Always)]
		public required string Slot { get; init; }

		[JsonProperty("timeslot_name", Required = Required.Always)]
		public required string Name { get; init; }

		[JsonProperty("slot_price")]
		public required decimal? Price { get; init; }

		[JsonProperty("has_surge")]
		public required bool? HasSurge { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private TimeDto(TimeDto original)
		{
			Id = original.Id;
			Slot = original.Slot;
			Name = original.Name;
			Price = original.Price;
			HasSurge = original.HasSurge;
		}

		public TimeDto()
		{
		}
	}

	internal sealed record InformersDto
	{
		[JsonProperty("active_two_mechanic")]
		public required string? TwoMechanicInformer { get; init; }

		[JsonProperty("informer")]
		public required string? PointsInformer { get; init; }

		[JsonProperty("is_alcohol")]
		public required string? AlcoholInformer { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private InformersDto(InformersDto original)
		{
			TwoMechanicInformer = original.TwoMechanicInformer;
			PointsInformer = original.PointsInformer;
			AlcoholInformer = original.AlcoholInformer;
		}

		public InformersDto()
		{
		}
	}

	internal sealed record PointsDto
	{
		[JsonProperty("total", Required = Required.Always)]
		public required long Total { get; init; }

		[JsonProperty("available", Required = Required.Always)]
		public required long Available { get; init; }

		[JsonProperty("burnable_points")]
		public required string? BurnablePoints { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private PointsDto(PointsDto original)
		{
			Total = original.Total;
			Available = original.Available;
			BurnablePoints = original.BurnablePoints;
		}

		public PointsDto()
		{
		}
	}

	internal sealed record PromocodeConditionDto
	{
		[JsonProperty("is_success", Required = Required.Always)]
		public required bool IsSuccess { get; init; }

		[JsonProperty("promo_code", Required = Required.Always)]
		public required string PromoCode { get; init; }

		[JsonProperty("message")]
		public required string? Message { get; init; }

		[JsonProperty("link_name")]
		public required string? LinkName { get; init; }

		[JsonProperty("slug")]
		public required string? Slug { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private PromocodeConditionDto(PromocodeConditionDto original)
		{
			IsSuccess = original.IsSuccess;
			PromoCode = original.PromoCode;
			Message = original.Message;
			LinkName = original.LinkName;
			Slug = original.Slug;
		}

		public PromocodeConditionDto()
		{
		}
	}

	internal sealed record ProductDto
	{
		[JsonProperty("offer_id", Required = Required.Always)]
		public required long OfferId { get; init; }

		[JsonProperty("image_url")]
		public required string? ImageUrl { get; init; }

		[JsonProperty("qty")]
		public required decimal Qty { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private ProductDto(ProductDto original)
		{
			OfferId = original.OfferId;
			ImageUrl = original.ImageUrl;
			Qty = original.Qty;
		}

		public ProductDto()
		{
		}
	}

	internal sealed record DeliveryTariffDto
	{
		[JsonProperty("delivery_price")]
		public required decimal? DeliveryPrice { get; init; }

		[JsonProperty("tariff_basket_price")]
		public required decimal? TariffBasketPrice { get; init; }

		[JsonProperty("overprice")]
		public required decimal? Overprice { get; init; }

		[JsonProperty("standard_weight")]
		public required decimal? StandardWeight { get; init; }

		[JsonProperty("max_weight")]
		public required decimal? MaxWeight { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private DeliveryTariffDto(DeliveryTariffDto original)
		{
			DeliveryPrice = original.DeliveryPrice;
			TariffBasketPrice = original.TariffBasketPrice;
			Overprice = original.Overprice;
			StandardWeight = original.StandardWeight;
			MaxWeight = original.MaxWeight;
		}

		public DeliveryTariffDto()
		{
		}
	}

	[JsonConverter(typeof(StringEnumConverter))]
	internal enum PaymentCodeDto
	{
		Unknown,
		[EnumMember(Value = "online")]
		Online,
		[EnumMember(Value = "offline")]
		Offline
	}

	internal sealed record ReplacementDto
	{
		[JsonProperty("replacement_method_id", Required = Required.Always)]
		public required int ReplacementMethodId { get; init; }

		[JsonProperty("replacement_method", Required = Required.Always)]
		public required string ReplacementMethod { get; init; }

		[JsonProperty("default_value", Required = Required.Always)]
		public required bool IsDefault { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private ReplacementDto(ReplacementDto original)
		{
			ReplacementMethodId = original.ReplacementMethodId;
			ReplacementMethod = original.ReplacementMethod;
			IsDefault = original.IsDefault;
		}

		public ReplacementDto()
		{
		}
	}

	[JsonProperty("data")]
	public required DataDto Data { get; init; }

	public VpnState VpnState { get; set; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CheckoutDataResponseDto(CheckoutDataResponseDto original)
		: base(original)
	{
		Data = original.Data;
		VpnState = original.VpnState;
	}

	public CheckoutDataResponseDto()
	{
	}
}
