using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Managers.Dialogs;

public abstract class AgeGateDialog : IAgeGateDialog
{
	private readonly Lazy<IDataBroker> _dataBroker;

	protected volatile Task<AgreeState>? _current;

	protected AgeGateDialog(Lazy<IDataBroker> dataBroker)
	{
		_dataBroker = dataBroker;
	}

	public Task<AgreeState> ShowAgeGateDialogAsync(AgeGateViewModel.Parameter parameter)
	{
		Task<AgreeState> current = _current;
		if (current != null)
		{
			return current;
		}
		return _current = DoAsync(parameter);
		async Task<AgreeState> DoAsync(AgeGateViewModel.Parameter parameter2)
		{
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			_ = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			awaiter.GetResult();
			await MainThread.InvokeOnMainThreadAsync(() => PlatformShowAgeGateDialogAsync(_dataBroker.Value.Push(parameter2)));
			AgreeState result = await parameter2.WaitForResultAsync();
			_current = null;
			return result;
		}
	}

	protected abstract Task PlatformShowAgeGateDialogAsync(BrokerToken token);
}
