using System.Collections.Generic;
using Auchan.Common.Ecom.Cart.ViewModels;

namespace Auchan.Common.Ecom.Cart;

public class PaymentUrlHelper
{
	private readonly string _returnUrlSubstring;

	private readonly string _failureUrlSubstring;

	public const string ORDER_ID_PARAM = "orderId";

	public const string SUCCESS_URL_PART = "checkout-success";

	public const string FAILED_URL_PART = "checkout-failed";

	public string ReturnUrl { get; }

	public string FailureUrl { get; }

	public PaymentUrlHelper()
	{
		_returnUrlSubstring = "https://auchan.ru/checkout-success";
		_failureUrlSubstring = "https://auchan.ru/checkout-failed";
		ReturnUrl = _returnUrlSubstring + "?orderId={orderId}";
		FailureUrl = _failureUrlSubstring + "?orderId={orderId}";
	}

	public CheckoutWebViewModel.Parameter GetParameter(string paymentUrl, string orderId)
	{
		return GetParameter(paymentUrl, new global::_003C_003Ez__ReadOnlySingleElementList<string>(orderId));
	}

	public CheckoutWebViewModel.Parameter GetParameter(string paymentUrl, IEnumerable<string> orderIds)
	{
		return new CheckoutWebViewModel.Parameter
		{
			Url = paymentUrl,
			ReturnUrlSubstring = _returnUrlSubstring,
			FailureUrlSubstring = _failureUrlSubstring,
			OrderIds = orderIds
		};
	}
}
