using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.Navigation;
using Auchan.Common.Profile.Orders.Dto;

namespace Auchan.Common.Profile.Orders;

[RequiresAuthorization]
public sealed class AskForOrderCancellationReasonViewModel : ScreenViewModel
{
	public sealed class Result
	{
		public CancellationReasonDto CancellationReason { get; }

		public string? Commentary { get; }

		public Result(CancellationReasonDto cancellationReason, string? commentary)
		{
			CancellationReason = cancellationReason;
			Commentary = commentary;
		}
	}

	public readonly UICommand OnItemSelectedCommand = new UICommand();

	[CompilerGenerated]
	private SelectionItemViewModel<CancellationReasonDto>? _003CSelectedItem_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CReasonDescription_003Ek__BackingField;

	public string ScreenTitle => "Укажите, пожалуйста, причину отмены";

	public string TextEditHint => "Напишите комментарий";

	public string ProceedButtonText => "Отменить заказ";

	public int MaxTextLength => 255;

	public IReadOnlyList<SelectionItemViewModel<CancellationReasonDto>> Items { get; }

	public SelectionItemViewModel<CancellationReasonDto>? SelectedItem
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedItem_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CSelectedItem_003Ek__BackingField, value))
			{
				_003CSelectedItem_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedIndex");
				RaisePropertyChanged("IsCanProceed");
				RaisePropertyChanged("SelectedItem");
			}
		}
	}

	public int SelectedIndex => Items.IndexOf<SelectionItemViewModel<CancellationReasonDto>>(SelectedItem);

	public bool IsCanProceed
	{
		get
		{
			if (SelectedItem != null)
			{
				if (SelectedItem.Item.IsCommentaryObligatory)
				{
					return ReasonDescription.Length > 0;
				}
				return true;
			}
			return false;
		}
	}

	public string ReasonDescription
	{
		[CompilerGenerated]
		get
		{
			return _003CReasonDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CReasonDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CReasonDescription_003Ek__BackingField = value;
				RaisePropertyChanged("IsCanProceed");
				RaisePropertyChanged("ReasonDescription");
			}
		}
	} = string.Empty;

	public AskForOrderCancellationReasonViewModel(PossibleOrderCancellationReasonsDto reasons)
	{
		Items = reasons.Reasons.Select((CancellationReasonDto r) => new SelectionItemViewModel<CancellationReasonDto>(r, selected: false)).ToList();
	}

	public void OnItemSelected(int index)
	{
		for (int i = 0; i < Items.Count; i++)
		{
			Items[i].Selected = index == i;
		}
		SelectedItem = Items[index];
		OnItemSelectedCommand.Trigger();
	}

	public Result? GetResult()
	{
		if (!IsCanProceed)
		{
			return null;
		}
		return new Result(SelectedItem.Item, ReasonDescription);
	}
}
