using System;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.Onboardings.DTO;
using Auchan.Common.Ecom.Onboardings.Models;
using DryIoc;

namespace Auchan.Common.Ecom.Onboardings.Infrastructure;

internal static class OnboardingsMapper
{
	internal static bool IsValid(this OnboardingsResponseDto.OnboardingDto @this)
	{
		if (@this.ShowAt.Any((OnboardingsResponseDto.ShowAtDto i) => i != OnboardingsResponseDto.ShowAtDto.Unknown))
		{
			if (string.IsNullOrEmpty(@this.Animation))
			{
				return !string.IsNullOrEmpty(@this.Image);
			}
			return true;
		}
		return false;
	}

	internal static OnboardingModel Map(this OnboardingsResponseDto.OnboardingDto @this, IResolver resolver)
	{
		return new OnboardingModel
		{
			Id = @this.Id,
			Name = @this.Name,
			ShowAt = (from i in @this.ShowAt
				where i != OnboardingsResponseDto.ShowAtDto.Unknown
				select (ShowAt)(i - 1)).ToImmutableList(),
			Priority = @this.Priority,
			ShowCount = @this.ShowCount,
			Title = (@this.Title ?? ""),
			TitleColor = (string.IsNullOrEmpty(@this.TitleColor) ? Color.Transparent : ColorTranslator.FromHtml(@this.TitleColor)),
			Description = (@this.Description ?? ""),
			Decoration = @this.GetDecoration(),
			Action = @this.GetAction(resolver),
			ReceivingMethods = @this.DeliveryType.Select((OnboardingsResponseDto.DeliveryTypeDto i) => i.Map()).ToImmutableArray()
		};
	}

	internal static IOnboardingDecoration GetDecoration(this OnboardingsResponseDto.OnboardingDto @this)
	{
		if (!string.IsNullOrEmpty(@this.Animation))
		{
			return new OnboardingAnimationDecoration(@this.Animation);
		}
		if (!string.IsNullOrEmpty(@this.Image))
		{
			return new OnboardingImageDecoration(@this.Image);
		}
		throw new InvalidOperationException("There is no image or animation. This element should be filtered on validation step");
	}

	internal static IOnboardingAction GetAction(this OnboardingsResponseDto.OnboardingDto @this, IResolver resolver)
	{
		if (!string.IsNullOrEmpty(@this.ButtonAction?.Clipboard))
		{
			return new ClipboardAction(resolver, @this.ButtonText, @this.ButtonAction.Clipboard);
		}
		if (!string.IsNullOrEmpty(@this.ButtonAction?.Url))
		{
			return new WebViewUrlAction(resolver, @this.ButtonText, @this.ButtonAction.Url);
		}
		if (!string.IsNullOrEmpty(@this.ButtonAction?.Deeplink))
		{
			return new DeeplinkAction(resolver, @this.ButtonText, @this.ButtonAction.Deeplink);
		}
		if (!string.IsNullOrEmpty(@this.ButtonAction?.Native))
		{
			return new NativeContentAction(resolver, @this.ButtonText, @this.ButtonAction.Native);
		}
		return new NoAction
		{
			Text = (@this.ButtonText ?? "")
		};
	}

	internal static ReceivingMethod Map(this OnboardingsResponseDto.DeliveryTypeDto @this)
	{
		return @this switch
		{
			OnboardingsResponseDto.DeliveryTypeDto.Delivery => ReceivingMethod.Delivery, 
			OnboardingsResponseDto.DeliveryTypeDto.CarPickup => ReceivingMethod.CarPickup, 
			OnboardingsResponseDto.DeliveryTypeDto.Pickup => ReceivingMethod.Pickup, 
			_ => throw new InvalidOperationException("Unknown delivery method. This element should be filtered on validation step"), 
		};
	}
}
