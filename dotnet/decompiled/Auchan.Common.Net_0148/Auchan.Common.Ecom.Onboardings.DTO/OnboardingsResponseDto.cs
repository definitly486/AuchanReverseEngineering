using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Onboardings.DTO;

internal sealed class OnboardingsResponseDto
{
	public sealed class OnboardingDto
	{
		[JsonProperty("id")]
		public required int Id { get; init; }

		[JsonProperty("name")]
		public required string Name { get; init; }

		[JsonProperty("type")]
		public required IReadOnlyCollection<ShowAtDto> ShowAt { get; init; }

		[JsonProperty("rank")]
		public int Priority { get; init; }

		[JsonProperty("show_count")]
		public int ShowCount { get; init; }

		[JsonProperty("title")]
		public string? Title { get; init; }

		[JsonProperty("hex_title")]
		public string? TitleColor { get; init; }

		[JsonProperty("description")]
		public string? Description { get; init; }

		[JsonProperty("button_text")]
		public string? ButtonText { get; init; }

		[JsonProperty("animation_url")]
		public string? Animation { get; init; }

		[JsonProperty("image")]
		public string? Image { get; init; }

		[JsonProperty("button_action")]
		public ButtonActionDto? ButtonAction { get; init; }

		[JsonProperty("delivery_type")]
		public IReadOnlyList<DeliveryTypeDto> DeliveryType { get; init; } = Array.Empty<DeliveryTypeDto>();
	}

	public enum ShowAtDto
	{
		Unknown,
		[EnumMember(Value = "before_auth")]
		BeforeAuth,
		[EnumMember(Value = "home_page")]
		Home,
		[EnumMember(Value = "loyalty_page")]
		Loyalty
	}

	public enum DeliveryTypeDto
	{
		Unknown,
		[EnumMember(Value = "delivery")]
		Delivery,
		[EnumMember(Value = "pickup")]
		Pickup,
		[EnumMember(Value = "car_pickup")]
		CarPickup
	}

	public sealed class ButtonActionDto
	{
		[JsonProperty("url")]
		public string? Url { get; init; }

		[JsonProperty("deeplink")]
		public string? Deeplink { get; init; }

		[JsonProperty("native")]
		public string? Native { get; init; }

		[JsonProperty("clipboard")]
		public string? Clipboard { get; init; }
	}

	[JsonProperty("data")]
	public IReadOnlyList<OnboardingDto> Data { get; init; } = Array.Empty<OnboardingDto>();
}
