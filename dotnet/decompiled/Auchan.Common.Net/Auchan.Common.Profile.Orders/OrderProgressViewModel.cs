using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Extensions;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile.Orders;

public sealed class OrderProgressViewModel : BaseItemViewModel
{
	public sealed class Item(CustomerStatus current, CustomerStatus itemType)
	{
		public CustomerStatus ItemType => itemType;

		public State State => GetState(current, itemType);

		public bool LeftVisible => ItemType != CustomerStatus.InForm;

		public bool RightVisible
		{
			get
			{
				if (ItemType != CustomerStatus.Delivered)
				{
					return ItemType != CustomerStatus.Completed;
				}
				return false;
			}
		}

		public string Title => itemType switch
		{
			CustomerStatus.Completed => "Получен", 
			CustomerStatus.ReadyToIssue => "Готов к выдаче", 
			CustomerStatus.Delivered => "Доставлен", 
			CustomerStatus.OnWay => "В пути", 
			CustomerStatus.InProcessBuild => "Собираем", 
			CustomerStatus.InForm => "Принят", 
			CustomerStatus.Takeout => "Уже несём", 
			CustomerStatus.Accepted => "Принят", 
			_ => string.Empty, 
		};

		private static State GetState(CustomerStatus current, CustomerStatus toCheck)
		{
			OrderStatus orderStatus = Map(current);
			OrderStatus orderStatus2 = Map(toCheck);
			if (orderStatus == orderStatus2)
			{
				return State.Current;
			}
			if (orderStatus > orderStatus2)
			{
				return State.Passed;
			}
			return State.ToBe;
		}

		private static OrderStatus Map(CustomerStatus from)
		{
			return from switch
			{
				CustomerStatus.InForm => OrderStatus.InForm, 
				CustomerStatus.Accepted => OrderStatus.Accepted, 
				CustomerStatus.InProcessBuild => OrderStatus.InProcessBuild, 
				CustomerStatus.OnWay => OrderStatus.OnWay, 
				CustomerStatus.Delivered => OrderStatus.Delivered, 
				CustomerStatus.ReadyToIssue => OrderStatus.ReadyToIssue, 
				CustomerStatus.Takeout => OrderStatus.Takeout, 
				CustomerStatus.Completed => OrderStatus.Completed, 
				CustomerStatus.Canceled => OrderStatus.Canceled, 
				_ => throw new NotImplementedException("dead code"), 
			};
		}
	}

	private enum OrderStatus
	{
		InForm,
		Accepted,
		InProcessBuild,
		OnWay,
		Delivered,
		ReadyToIssue,
		Takeout,
		Completed,
		Canceled
	}

	public enum State
	{
		Passed,
		Current,
		ToBe
	}

	[CompilerGenerated]
	private IReadOnlyList<Item> _003CItems_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CVisibility_003Ek__BackingField;

	public IReadOnlyList<Item> Items
	{
		[CompilerGenerated]
		get
		{
			return _003CItems_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CItems_003Ek__BackingField, value))
			{
				_003CItems_003Ek__BackingField = value;
				RaisePropertyChanged("Items");
			}
		}
	} = ImmutableList<Item>.Empty;

	public bool Visibility
	{
		[CompilerGenerated]
		get
		{
			return _003CVisibility_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CVisibility_003Ek__BackingField != value)
			{
				_003CVisibility_003Ek__BackingField = value;
				RaisePropertyChanged("Visibility");
			}
		}
	}

	public void SetOrder(IListOrderModel orderModel)
	{
		ImmutableList<Item>.Builder builder = ImmutableList.CreateBuilder<Item>();
		CustomerStatus status = orderModel.Status;
		if (orderModel.IsValid)
		{
			builder.Add(new Item(status, CustomerStatus.InForm));
			builder.Add(new Item(status, CustomerStatus.InProcessBuild));
			if (orderModel.DeliveryMethod.IsDelivery())
			{
				builder.Add(new Item(status, CustomerStatus.OnWay));
				builder.Add(new Item(status, CustomerStatus.Delivered));
			}
			else
			{
				builder.Add(new Item(status, CustomerStatus.ReadyToIssue));
				if (orderModel.StoreHasPickupPoint || orderModel.IsAuchanDriveOrder)
				{
					builder.Add(new Item(status, CustomerStatus.Takeout));
				}
				builder.Add(new Item(status, CustomerStatus.Completed));
			}
		}
		Items = builder.ToImmutable();
		Visibility = status switch
		{
			CustomerStatus.InForm => true, 
			CustomerStatus.InProcessBuild => true, 
			CustomerStatus.OnWay => true, 
			CustomerStatus.Delivered => false, 
			CustomerStatus.ReadyToIssue => true, 
			CustomerStatus.Takeout => true, 
			CustomerStatus.Completed => false, 
			CustomerStatus.Canceled => false, 
			CustomerStatus.Accepted => true, 
			_ => false, 
		};
	}
}
