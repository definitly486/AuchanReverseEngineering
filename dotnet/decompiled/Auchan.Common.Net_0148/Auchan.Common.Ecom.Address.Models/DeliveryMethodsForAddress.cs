using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Extensions;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Address.Models;

public sealed record DeliveryMethodsForAddress
{
	public sealed record ExpressDeliveryUnavailable
	{
		public string UnavailableHint { get; init; } = string.Empty;
	}

	public sealed record Delivery
	{
		public required Store Store { get; init; }

		public decimal? CostFreeFrom { get; init; }

		public decimal CostMin { get; init; }

		public string? DeliveryStartsAt { get; init; }

		public string? DeliveryTimeHint { get; init; }

		public bool IsDefault { get; init; }

		[JsonIgnore]
		public string DeliveryStartText
		{
			get
			{
				if (string.IsNullOrWhiteSpace(DeliveryTimeHint))
				{
					return FormatDeliveryStartsAt(DeliveryStartsAt);
				}
				return DeliveryTimeHint;
			}
		}

		private static string FormatDeliveryStartsAt(string? deliveryStartsAt)
		{
			if (!DateTimeOffset.TryParse(deliveryStartsAt, out var result))
			{
				return string.Empty;
			}
			return $"{result.GetTodayTomorrowOrDate()} с {result:HH:mm}";
		}

		[CompilerGenerated]
		[SetsRequiredMembers]
		private Delivery(Delivery original)
		{
			Store = original.Store;
			CostFreeFrom = original.CostFreeFrom;
			CostMin = original.CostMin;
			DeliveryStartsAt = original.DeliveryStartsAt;
			DeliveryTimeHint = original.DeliveryTimeHint;
			IsDefault = original.IsDefault;
		}

		public Delivery()
		{
		}
	}

	public bool IsDeliveryAvailable { get; init; }

	public City? Region { get; init; }

	public Delivery? StandardDelivery { get; init; }

	public Delivery? ExpressDelivery { get; init; }

	public ExpressDeliveryUnavailable? ExpressDeliveryUnavailableInfo { get; init; }
}
