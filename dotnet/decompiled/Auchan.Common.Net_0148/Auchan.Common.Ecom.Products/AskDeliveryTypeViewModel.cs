using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Extensions;

namespace Auchan.Common.Ecom.Products;

public class AskDeliveryTypeViewModel : ScreenViewModel
{
	public class Parameter
	{
		public ReceivingMethod TargetMethod { get; set; }

		public bool SelectedStoreHasOfflinePayment { get; }

		public Parameter(ReceivingMethod targetMethod, bool selectedStoreHasOfflinePayment)
		{
			TargetMethod = targetMethod;
			SelectedStoreHasOfflinePayment = selectedStoreHasOfflinePayment;
		}
	}

	private readonly Parameter _parameter;

	private readonly Subject<AgreeState> _onAnswer = new Subject<AgreeState>();

	private readonly IEcomContext _ecomContext;

	private readonly Auchan.Common.Ecom.Cart.Cart _cart;

	[CompilerGenerated]
	private (int, int) _003CBoldMessageStartEnd_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsAboutUpdateCartVisible_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CMessage_003Ek__BackingField;

	public string AboutUpdateCartText => "Обращаем внимание, что при изменении способа доставки состав корзины может быть изменен.";

	public string YesButtonText => "Да";

	public string NoButtonText => "Нет";

	public (int, int) BoldMessageStartEnd
	{
		[CompilerGenerated]
		get
		{
			return _003CBoldMessageStartEnd_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!EqualityComparer<(int, int)>.Default.Equals(_003CBoldMessageStartEnd_003Ek__BackingField, value))
			{
				_003CBoldMessageStartEnd_003Ek__BackingField = value;
				RaisePropertyChanged("BoldMessageStartEnd");
			}
		}
	}

	public bool IsAboutUpdateCartVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsAboutUpdateCartVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsAboutUpdateCartVisible_003Ek__BackingField != value)
			{
				_003CIsAboutUpdateCartVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsAboutUpdateCartVisible");
			}
		}
	}

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return _003CTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
			}
		}
	} = string.Empty;

	public string Message
	{
		[CompilerGenerated]
		get
		{
			return _003CMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CMessage_003Ek__BackingField = value;
				RaisePropertyChanged("Message");
			}
		}
	} = string.Empty;

	public IObservable<AgreeState> OnAnswer => _onAnswer.Debounce();

	public AskDeliveryTypeViewModel(Parameter parameter, IEcomContext ecomContext, Auchan.Common.Ecom.Cart.Cart cart)
	{
		_parameter = parameter;
		_ecomContext = ecomContext;
		_cart = cart;
	}

	protected override async Task Start()
	{
		await base.Start();
		string text = GetMethodTypeText(_parameter.TargetMethod) + ".";
		if (!_parameter.SelectedStoreHasOfflinePayment)
		{
			Title = "Изменить магазин?";
			Message = "В данном магазине недоступна оплата при получении. Выберите другой магазин с самовывозом.";
		}
		else
		{
			Title = ((_ecomContext.ReceivingMethod == ReceivingMethod.RegionDefault) ? ("Выбрать способ доставки " + GetMethodTypeTitleText(_parameter.TargetMethod) + "?") : "Изменить способ доставки?");
			Message = "Добавление товара в корзину возможно только при способе доставки " + text;
		}
		BoldMessageStartEnd = (Message.Length - text.Length, Message.Length);
		IsAboutUpdateCartVisible = _cart.Items.Any();
	}

	public void Reply(AgreeState answer)
	{
		_onAnswer.OnNext(answer);
	}

	private string GetMethodTypeText(ReceivingMethod receivingMethod)
	{
		return receivingMethod switch
		{
			ReceivingMethod.Delivery => "по адресу", 
			ReceivingMethod.Pickup => "самовывоз из магазина", 
			_ => string.Empty, 
		};
	}

	private string GetMethodTypeTitleText(ReceivingMethod receivingMethod)
	{
		return receivingMethod switch
		{
			ReceivingMethod.Delivery => "по адресу", 
			ReceivingMethod.Pickup => "самовывоз", 
			_ => string.Empty, 
		};
	}
}
