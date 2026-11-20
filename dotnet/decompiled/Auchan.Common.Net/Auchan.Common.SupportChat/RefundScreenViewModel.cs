using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.SupportChat.DTO;
using Auchan.Common.SupportChat.ItemViewModels;
using Auchan.Common.SupportChat.Models;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat;

public sealed class RefundScreenViewModel : ScreenViewModel<RefundScreenViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<Result>
	{
		public required IReadOnlyList<RefundItem> Items { get; init; }

		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	public sealed class Result
	{
		public required bool GoBack { get; init; }

		public required string Text { get; init; }

		public required string Data { get; init; }
	}

	private Result _result = new Result
	{
		GoBack = true,
		Text = "",
		Data = ""
	};

	[CompilerGenerated]
	private IReadOnlyList<RefundItemViewModel> _003CSelectedItems_003Ek__BackingField;

	public string Title => "Состав покупки";

	public IReadOnlyList<RefundItemViewModel> Items { get; } = Array.Empty<RefundItemViewModel>();

	public IReadOnlyList<RefundItemViewModel> SelectedItems
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedItems_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSelectedItems_003Ek__BackingField, value))
			{
				_003CSelectedItems_003Ek__BackingField = value;
				RaisePropertyChanged("IsCanGoNext");
				RaisePropertyChanged("SelectedItems");
			}
		}
	} = Array.Empty<RefundItemViewModel>();

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand NextCommand { get; } = new UICommand();

	public string NextText => "Продолжить";

	public bool IsCanGoNext => SelectedItems.Count > 0;

	public RefundScreenViewModel(BrokerToken brokerToken)
		: base(brokerToken)
	{
		List<RefundItemViewModel> list = new List<RefundItemViewModel>();
		list.AddRange(base.Argument.Items.Select((RefundItem i) => new RefundItemViewModel(i, this, selected: false)));
		Items = new _003C_003Ez__ReadOnlyList<RefundItemViewModel>(list);
	}

	protected override async Task Start()
	{
		await base.Start();
		NextCommand.Subscribe(delegate
		{
			OnNextCommand();
		}).AddTo(base.CloseDisposable);
	}

	public void OnItemChecked(RefundItemViewModel ivm)
	{
		ivm.Selected = !ivm.Selected;
		UpdateSelection();
	}

	public void UpdateSelection()
	{
		List<RefundItemViewModel> list = new List<RefundItemViewModel>();
		list.AddRange(Items.Where((RefundItemViewModel i) => i.Selected && i.SelectedCount > 0m));
		SelectedItems = new _003C_003Ez__ReadOnlyList<RefundItemViewModel>(list);
	}

	private void OnNextCommand()
	{
		RefundProductsRequestDto refundProductsRequestDto = new RefundProductsRequestDto();
		List<RefundProductsRequestDto.ProductDto> list = new List<RefundProductsRequestDto.ProductDto>();
		list.AddRange(SelectedItems.Select((RefundItemViewModel i) => new RefundProductsRequestDto.ProductDto
		{
			GimaId = i.Item.GimaId,
			Quantity = i.SelectedCount,
			PricePerOne = i.Item.PricePerOne
		}));
		refundProductsRequestDto.Products = new _003C_003Ez__ReadOnlyList<RefundProductsRequestDto.ProductDto>(list);
		RefundProductsRequestDto value = refundProductsRequestDto;
		List<string> list2 = new List<string>();
		list2.AddRange(SelectedItems.Select((RefundItemViewModel i) => $"{i.Item.Title} {i.SelectedCountText} (артикул {i.Item.GimaId}) {i.Item.PricePerOneChatText}"));
		IReadOnlyList<string> values = new _003C_003Ez__ReadOnlyList<string>(list2);
		string text = string.Join('\n', values);
		_result = new Result
		{
			GoBack = false,
			Text = text,
			Data = JsonConvert.SerializeObject(value)
		};
		CloseCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(_result);
	}
}
