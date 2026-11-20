using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.SupportChat.DTO;
using Auchan.Common.SupportChat.Models;

namespace Auchan.Common.SupportChat.ItemViewModels;

public class RefundOrderPopupChatItemViewModel : BaseSupportChatItemViewModel
{
	[CompilerGenerated]
	private readonly IReadOnlyList<RefundItem> _003CItems_003Ek__BackingField;

	public required IReadOnlyList<RefundItem> Items
	{
		[CompilerGenerated]
		get
		{
			return _003CItems_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			if (!object.Equals(_003CItems_003Ek__BackingField, value))
			{
				_003CItems_003Ek__BackingField = value;
				RaisePropertyChanged("Items");
			}
		}
	}

	public override bool ShouldBeDisplayed => false;

	public static RefundOrderPopupChatItemViewModel New(CacheMessage message)
	{
		if (StructMessageReceivedWSDTO.TryParse(message.Text, out StructMessageReceivedWSDTO message2) && message2 is ProductsStructMessageReceiveWSDTO productsStructMessageReceiveWSDTO)
		{
			RefundOrderPopupChatItemViewModel refundOrderPopupChatItemViewModel = new RefundOrderPopupChatItemViewModel();
			List<RefundItem> list = new List<RefundItem>();
			list.AddRange(productsStructMessageReceiveWSDTO.Data.Products.Select((ProductsStructMessageReceiveWSDTO.ProductDto i) => new RefundItem
			{
				Image = i.ImageUrl,
				Title = i.Name,
				Price = i.Price,
				PricePerOne = i.PricePerOne,
				Status = i.Status,
				AvailableToReturn = i.AvailableToReturn,
				GimaId = i.GimaId,
				IsEnabled = i.IsEnabled,
				IsWeightGoods = (i.ItemType == ProductsStructMessageReceiveWSDTO.ItemTypeDto.Weight)
			}));
			refundOrderPopupChatItemViewModel.Items = new _003C_003Ez__ReadOnlyList<RefundItem>(list);
			return refundOrderPopupChatItemViewModel;
		}
		return new RefundOrderPopupChatItemViewModel
		{
			Items = Array.Empty<RefundItem>()
		};
	}
}
