using System;
using System.Collections.Generic;
using Auchan.Common.Common;
using Auchan.Common.Ecom.AddressStoreSelection;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Onboardings.DTO;

public class OnboardingDTO
{
	[JsonProperty("guid")]
	public string Id { get; set; }

	[JsonProperty("position", ItemConverterType = typeof(EnumMemberJsonConverter<ShowAt>))]
	public IReadOnlyList<ShowAt> Positions { get; set; }

	[JsonProperty("priority")]
	public int Priority { get; set; }

	[JsonProperty("show_count")]
	public int ShowCount { get; set; }

	[JsonProperty("title")]
	public string? Title { get; set; }

	[JsonProperty("name")]
	public string? Name { get; set; }

	[JsonProperty("description")]
	public string? Description { get; set; }

	[JsonProperty("button_text")]
	public string? ButtonText { get; set; }

	[JsonProperty("animationUrl")]
	public string? AnimationUrl { get; set; }

	[JsonProperty("pictureUrl")]
	public string? PictureUrl { get; set; }

	[JsonProperty("button_action")]
	[JsonConverter(typeof(EnumMemberJsonConverter<OnboardingActionType>))]
	public OnboardingActionType ActionType { get; set; }

	[JsonProperty("webview_native")]
	public string? NativeContent { get; set; }

	[JsonProperty("webview_url")]
	public string? WebViewUrl { get; set; }

	[JsonProperty("deeplink")]
	public string? Deeplink { get; set; }

	[JsonProperty("clipboard_text")]
	public string? ClipboardContent { get; set; }

	[JsonProperty("delivery_type", ItemConverterType = typeof(EnumMemberJsonConverter<ReceivingMethod>))]
	public IReadOnlyList<ReceivingMethod> ReceivingMethods { get; set; } = Array.Empty<ReceivingMethod>();
}
