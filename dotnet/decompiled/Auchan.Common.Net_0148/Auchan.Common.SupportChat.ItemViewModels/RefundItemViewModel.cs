using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.SupportChat.Models;

namespace Auchan.Common.SupportChat.ItemViewModels;

public sealed class RefundItemViewModel : SelectionItemViewModel<RefundItem, RefundScreenViewModel>
{
	private readonly decimal _step;

	[CompilerGenerated]
	private decimal _003CSelectedCount_003Ek__BackingField;

	public decimal SelectedCount
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!decimal.Equals(_003CSelectedCount_003Ek__BackingField, value))
			{
				decimal selectedCount = SelectedCount;
				_003CSelectedCount_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedCountText");
				RaisePropertyChanged("IsCanAdd");
				RaisePropertyChanged("IsCanRemove");
				decimal selectedCount2 = SelectedCount;
				OnSelectedCountChanged(selectedCount, selectedCount2);
				RaisePropertyChanged("SelectedCount");
			}
		}
	}

	public string SelectedCountText => $"{SelectedCount:0.##}";

	public bool IsCanAdd
	{
		get
		{
			decimal selectedCount = SelectedCount;
			decimal? availableToReturn = base.Item.AvailableToReturn;
			return (selectedCount < availableToReturn.GetValueOrDefault()) & availableToReturn.HasValue;
		}
	}

	public bool IsCanRemove => SelectedCount > 0m;

	public RefundItemViewModel(RefundItem item, RefundScreenViewModel parent, bool selected)
		: base(item, parent, selected)
	{
		decimal valueOrDefault = base.Item.AvailableToReturn.GetValueOrDefault();
		_step = (item.IsWeightGoods ? valueOrDefault : 1m);
		SelectedCount = _step;
	}

	public void Increment()
	{
		decimal selectedCount = SelectedCount;
		decimal? availableToReturn = base.Item.AvailableToReturn;
		if ((selectedCount < availableToReturn.GetValueOrDefault()) & availableToReturn.HasValue)
		{
			decimal num = SelectedCount + _step;
			decimal num2 = num;
			availableToReturn = base.Item.AvailableToReturn;
			if ((num2 > availableToReturn.GetValueOrDefault()) & availableToReturn.HasValue)
			{
				num = base.Item.AvailableToReturn.Value;
			}
			SelectedCount = num;
		}
	}

	public void Decrement()
	{
		if (SelectedCount > 0m)
		{
			decimal num = SelectedCount - _step;
			if (num < 0m)
			{
				num = default(decimal);
			}
			SelectedCount = num;
		}
	}

	private void OnSelectedCountChanged(decimal old, decimal @new)
	{
		base.Parent.UpdateSelection();
	}
}
