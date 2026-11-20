using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.Cart.Models;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public class DeliveryInfoPopupViewModel : ScreenViewModel
{
	public sealed record Parameter
	{
		public required ReceivingMethod ReceivingMethod { get; init; }

		public required IReadOnlyList<Item> Items { get; init; }

		public static Parameter For(Store store, ReceivingMethod receivingMethod, bool isAdultInCart)
		{
			decimal standardWeightForDeliveryType = store.GetStandardWeightForDeliveryType(receivingMethod);
			IReadOnlyList<Store.DeliveryTariff> tariffsForDeliveryType = store.GetTariffsForDeliveryType(receivingMethod);
			decimal overweightPricePerKiloForDeilveryType = store.GetOverweightPricePerKiloForDeilveryType(receivingMethod);
			Parameter obj = new Parameter
			{
				ReceivingMethod = receivingMethod
			};
			List<Item> list = new List<Item>();
			list.AddRange(tariffsForDeliveryType.Select((Store.DeliveryTariff i) => new Item(receivingMethod, $"{"Доставка"} {i.DeliveryPrice:C0}", $"от {i.BasketCost:C0}")));
			list.Add(Item.Separator);
			list.Add(new Item(Type.Overweight, $"Доплата за вес {0:C0}/кг", $"до {standardWeightForDeliveryType} кг"));
			list.Add(new Item(Type.Overweight, $"Доплата за вес {overweightPricePerKiloForDeilveryType:C0}/кг", $"от {standardWeightForDeliveryType} кг"));
			obj.Items = new _003C_003Ez__ReadOnlyList<Item>(list);
			return obj;
		}

		public static Parameter For(Store store, ReceivingMethod receivingMethod, bool isAdultInCart, decimal weightValue, decimal orderPriceValue)
		{
			decimal standardWeightForDeliveryType = store.GetStandardWeightForDeliveryType(receivingMethod);
			decimal overweightPricePerKiloForDeilveryType = store.GetOverweightPricePerKiloForDeilveryType(receivingMethod);
			decimal num = weightValue - standardWeightForDeliveryType;
			ImmutableList<Item>.Builder builder = ImmutableList.CreateBuilder<Item>();
			Store.DeliveryTariff deliveryTariff = store.GetTariffForDeliveryByOrderSize(receivingMethod, orderPriceValue) ?? store.GetTariffsForDeliveryType(receivingMethod).FirstOrDefault();
			if (deliveryTariff != null && deliveryTariff.DeliveryPrice > default(decimal))
			{
				builder.Add(new Item(receivingMethod, $"Доставка {deliveryTariff.DeliveryPrice:C0}", $"от {deliveryTariff.BasketCost:C0}"));
			}
			decimal num2 = num * overweightPricePerKiloForDeilveryType;
			if (num2 > 0m)
			{
				builder.Add(new Item(Type.Overweight, $"Доплата за вес {num2:C0}", $"от {standardWeightForDeliveryType} кг"));
			}
			return new Parameter
			{
				ReceivingMethod = receivingMethod,
				Items = builder.ToImmutable()
			};
		}

		public static Parameter For(DeliveryMethod deliveryMethod, DeliveryTariff tariff)
		{
			ReceivingMethod receivingMethod = deliveryMethod.Method.ToReceivingMethod();
			ImmutableList<Item>.Builder builder = ImmutableList.CreateBuilder<Item>();
			decimal? deliveryPrice = tariff.DeliveryPrice;
			if ((deliveryPrice.GetValueOrDefault() > default(decimal)) & deliveryPrice.HasValue)
			{
				builder.Add(new Item(receivingMethod, $"Доставка {tariff.DeliveryPrice:C0}", $"от {tariff.BasketPrice:C0}"));
			}
			deliveryPrice = tariff.Overprice;
			if ((deliveryPrice.GetValueOrDefault() > default(decimal)) & deliveryPrice.HasValue)
			{
				deliveryPrice = tariff.StandardWeight;
				if ((deliveryPrice.GetValueOrDefault() > default(decimal)) & deliveryPrice.HasValue)
				{
					builder.Add(new Item(Type.Overweight, $"Доплата за вес {tariff.Overprice:C0}", $"от {tariff.StandardWeight} кг"));
				}
			}
			return new Parameter
			{
				ReceivingMethod = receivingMethod,
				Items = builder.ToImmutable()
			};
		}

		[CompilerGenerated]
		[SetsRequiredMembers]
		private Parameter(Parameter original)
		{
			ReceivingMethod = original.ReceivingMethod;
			Items = original.Items;
		}

		public Parameter()
		{
		}
	}

	public sealed record Item
	{
		public static Item Separator => new Item(Type.Separator, "", "");

		public Type Type { get; }

		public string Key { get; }

		public string Value { get; }

		[JsonConstructor]
		public Item(Type type, string key, string value)
		{
			Type = type;
			Key = key;
			Value = value;
		}

		public Item(ReceivingMethod method, string key, string value)
			: this(ReceivingMethod2Type(method), key, value)
		{
		}

		private static Type ReceivingMethod2Type(ReceivingMethod method)
		{
			return method switch
			{
				ReceivingMethod.Delivery => Type.Delivery, 
				ReceivingMethod.ExpressDelivery => Type.ExpressDelivery, 
				_ => throw new ArgumentOutOfRangeException("method"), 
			};
		}
	}

	public enum Type
	{
		Delivery,
		ExpressDelivery,
		Overweight,
		Separator
	}

	private readonly Parameter _parameter;

	public string Title
	{
		get
		{
			if (_parameter.ReceivingMethod == ReceivingMethod.ExpressDelivery)
			{
				return "Быстрая доставка";
			}
			return "Доставка";
		}
	}

	public string KeyTitle => "Стоимость";

	public string ValueTitle => "Корзина";

	public string OkText => "Хорошо";

	public IReadOnlyList<Item> Items => _parameter.Items;

	public UICommand CloseCommand { get; } = new UICommand();

	public DeliveryInfoPopupViewModel(Parameter parameter)
	{
		_parameter = parameter;
	}
}
