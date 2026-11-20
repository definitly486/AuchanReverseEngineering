using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Threading;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Common;

public abstract class OptionSelectorViewModel<TOption, TItem> : ScreenViewModel<OptionSelectorViewModel<TOption, TItem>.Parameter>, IOptionSelectorViewModel<TOption, TItem> where TOption : ISelectionItemViewModel<TItem> where TItem : ITitle
{
	public sealed class Parameter : BrokeredParameter<Result<TItem>>
	{
		public required TItem Preselected { get; init; }

		public required IReadOnlyCollection<TItem> Items { get; init; }

		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	private bool _apply;

	protected TItem Selected
	{
		[CompilerGenerated]
		get
		{
			return _003CSelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSelected_003Ek__BackingField, value))
			{
				_003CSelected_003Ek__BackingField = value;
				RaisePropertyChanged("Selected");
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
		protected set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
			}
		}
	} = "";

	public string ApplyButtonTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CApplyButtonTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			if (!string.Equals(_003CApplyButtonTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CApplyButtonTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ApplyButtonTitle");
			}
		}
	} = "";

	public IReadOnlyList<TOption> Items { get; }

	public UICommand<TOption> SelectItemCommand { get; } = new UICommand<TOption>();

	public UICommand ApplyCommand { get; } = new UICommand();

	public UICommand CloseDialogCommand { get; } = new UICommand();

	protected OptionSelectorViewModel(BrokerToken parameter)
		: base(parameter)
	{
		Selected = base.Argument.Preselected;
		Items = base.Argument.Items.Select((TItem i) => NewOption(i)).ToImmutableList();
		SelectItemCommand.Subscribe(OnItemSelected).AddTo(base.CloseDisposable);
		ApplyCommand.Subscribe(OnApplyCommand).AddTo(base.CloseDisposable);
	}

	protected abstract TOption NewOption(TItem item);

	protected virtual void OnItemSelected(TOption model)
	{
		Selected = model.Item;
		foreach (TOption item in Items)
		{
			TOption current = item;
			current.Selected = EqualityComparer<TOption>.Default.Equals(current, model);
		}
	}

	private void OnApplyCommand(Unit unit)
	{
		_apply = true;
		CloseDialogCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(_apply ? ((Result<TItem>)Selected) : Result.Failure<TItem>("no result"));
	}
}
