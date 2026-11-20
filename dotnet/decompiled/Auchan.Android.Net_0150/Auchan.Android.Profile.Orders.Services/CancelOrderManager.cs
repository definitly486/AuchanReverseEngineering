using System.Threading.Tasks;
using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Common;
using Auchan.Common.Profile.Orders;
using Auchan.Common.Profile.Orders.Dto;
using Auchan.Common.Profile.Orders.Services;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Profile.Orders.Services;

internal sealed class CancelOrderManager : ICancelOrderManager
{
	private readonly FragmentFactory _fragmentFactory;

	public CancelOrderManager(FragmentFactory fragmentFactory)
	{
		_fragmentFactory = fragmentFactory;
	}

	public Task<AgreeState> AskDoYouWantToCancelOrder()
	{
		return MainThread.InvokeOnMainThreadAsync(delegate
		{
			if (Platform.CurrentActivity is AppCompatActivity appCompatActivity)
			{
				AskDoYouWantToCancelOrderFragment askDoYouWantToCancelOrderFragment = _fragmentFactory.Instantiate<AskDoYouWantToCancelOrderFragment>();
				askDoYouWantToCancelOrderFragment.Show(appCompatActivity.SupportFragmentManager, null);
				return askDoYouWantToCancelOrderFragment.Execute();
			}
			return Task.FromResult(AgreeState.None);
		});
	}

	public Task<AskForOrderCancellationReasonViewModel.Result?> AskForOrderCancellationReason(PossibleOrderCancellationReasonsDto reasons)
	{
		return MainThread.InvokeOnMainThreadAsync(delegate
		{
			if (Platform.CurrentActivity is AppCompatActivity appCompatActivity)
			{
				AskForOrderCancellationReasonFragment askForOrderCancellationReasonFragment = _fragmentFactory.Instantiate<AskForOrderCancellationReasonFragment>();
				askForOrderCancellationReasonFragment.Arguments = reasons.ToNavBundle();
				askForOrderCancellationReasonFragment.Show(appCompatActivity.SupportFragmentManager, null);
				return askForOrderCancellationReasonFragment.Execute();
			}
			return Task.FromResult<AskForOrderCancellationReasonViewModel.Result>(null);
		});
	}

	public Task<AgreeState> ShowOrderCannotBeCanceled()
	{
		return MainThread.InvokeOnMainThreadAsync(delegate
		{
			if (Platform.CurrentActivity is AppCompatActivity appCompatActivity)
			{
				OrderCannotBeCanceledFragment orderCannotBeCanceledFragment = _fragmentFactory.Instantiate<OrderCannotBeCanceledFragment>();
				orderCannotBeCanceledFragment.Show(appCompatActivity.SupportFragmentManager, null);
				return orderCannotBeCanceledFragment.Execute();
			}
			return Task.FromResult(AgreeState.None);
		});
	}
}
