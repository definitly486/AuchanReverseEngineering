using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Common;
using Auchan.Common.SupportChat.DTO;
using Auchan.Common.SupportChat.Models;

namespace Auchan.Common.SupportChat.ItemViewModels;

public sealed class RefundOrderListItemViewModel : BaseMessageViewModel, IIdentifiable
{
	[CompilerGenerated]
	private readonly ReadOnlyEquatableList<RefundOrderItemViewModel> _003CItems_003Ek__BackingField;

	public ReadOnlyEquatableList<RefundOrderItemViewModel> Items
	{
		[CompilerGenerated]
		get
		{
			return _003CItems_003Ek__BackingField;
		}
		[CompilerGenerated]
		private init
		{
			if (!(_003CItems_003Ek__BackingField == value))
			{
				_003CItems_003Ek__BackingField = value;
				RaisePropertyChanged("IsIndicatorVisible");
				RaisePropertyChanged("Items");
			}
		}
	} = new ReadOnlyEquatableList<RefundOrderItemViewModel>();

	public bool IsIndicatorVisible => Items.Count > 1;

	public static BaseMessageViewModel New(SupportChatViewModel parent, CacheMessage message)
	{
		if (StructMessageReceivedWSDTO.TryParse(message.Text, out StructMessageReceivedWSDTO message2) && message2 is ChipsStructMessageReceivedWSDTO chipsStructMessageReceivedWSDTO)
		{
			RefundOrderListItemViewModel refundOrderListItemViewModel = new RefundOrderListItemViewModel(message);
			List<RefundOrderItemViewModel> list = new List<RefundOrderItemViewModel>();
			list.AddRange(chipsStructMessageReceivedWSDTO.Data.Purchases.Select((ChipsStructMessageReceivedWSDTO.PurchaseDto i) => new RefundOrderItemViewModel
			{
				Parent = parent,
				Name = i.Name,
				Amount = i.Amount,
				Quantity = i.Quantity,
				Status = ((i.Status == null || i.StatusBackground == null || i.StatusForeground == null) ? null : new RefundOrderStatus
				{
					Text = i.Status,
					Background = ColorTranslator.FromHtml(i.StatusBackground),
					Foreground = ColorTranslator.FromHtml(i.StatusForeground)
				}),
				Store = i.Store
			}));
			refundOrderListItemViewModel.Items = new ReadOnlyEquatableList<RefundOrderItemViewModel>(new _003C_003Ez__ReadOnlyList<RefundOrderItemViewModel>(list));
			return refundOrderListItemViewModel;
		}
		return new IncomingMessageViewModel(message, MessageLayoutType.Single);
	}

	private RefundOrderListItemViewModel(CacheMessage message)
		: base(message, MessageLayoutType.Single)
	{
	}

	public string GetId()
	{
		return $"refund: {base.Message.Id}";
	}
}
