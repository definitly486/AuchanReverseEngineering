using System;
using System.Collections.Generic;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;

namespace Auchan.Common.Common;

public class HighlightScreenViewModel : ScreenViewModel<HighlightScreenViewModel.Parameter>
{
	public class Parameter : BrokeredParameter
	{
		public string Title { get; init; } = string.Empty;

		public string Description { get; init; } = string.Empty;

		public required Dictionary<string, Action> Views { get; init; }

		public required UICommand CloseCommand { get; init; }
	}

	public virtual string Title => base.Argument.Title;

	public virtual string Description => base.Argument.Description;

	public UICommand<string> ViewClickCommand { get; } = new UICommand<string>();

	public UICommand CloseCommand => base.Argument.CloseCommand;

	public HighlightScreenViewModel(BrokerToken brokerToken)
		: base(brokerToken)
	{
		ViewClickCommand.Subscribe(delegate(string viewId)
		{
			CloseCommand.Trigger();
			base.Argument.Views[viewId]?.Invoke();
		}).AddTo(base.CloseDisposable);
	}
}
