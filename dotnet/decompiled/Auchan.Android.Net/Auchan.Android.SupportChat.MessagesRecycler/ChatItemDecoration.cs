using System.Linq;
using Android.Graphics;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Common.SupportChat;
using Auchan.Common.SupportChat.ItemViewModels;

namespace Auchan.Android.SupportChat.MessagesRecycler;

internal class ChatItemDecoration : RecyclerView.ItemDecoration
{
	private readonly SupportChatViewModel _viewModel;

	public ChatItemDecoration(SupportChatViewModel viewModel)
	{
		_viewModel = viewModel;
	}

	public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
	{
		base.GetItemOffsets(outRect, view, parent, state);
		BaseSupportChatItemViewModel baseSupportChatItemViewModel;
		int top;
		if (view is IChatContentView)
		{
			int childAdapterPosition = parent.GetChildAdapterPosition(view);
			baseSupportChatItemViewModel = _viewModel.ItemViewModels.ElementAtOrDefault(childAdapterPosition);
			BaseSupportChatItemViewModel baseSupportChatItemViewModel2 = _viewModel.ItemViewModels.ElementAtOrDefault(childAdapterPosition - 1);
			if (baseSupportChatItemViewModel is IncomingMessageViewModel)
			{
				if (!(baseSupportChatItemViewModel2 is OutgoingMessageViewModel))
				{
					IncomingMessageViewModel incomingMessageViewModel = (IncomingMessageViewModel)baseSupportChatItemViewModel;
					if (!(baseSupportChatItemViewModel2 is IncomingMessageViewModel incomingMessageViewModel2))
					{
						goto IL_00e4;
					}
					top = ((incomingMessageViewModel.OperatorName == incomingMessageViewModel2.OperatorName) ? Converter.DpToPx(4f) : Converter.DpToPx(16f));
				}
				else
				{
					top = Converter.DpToPx(16f);
				}
			}
			else if (baseSupportChatItemViewModel is OutgoingMessageViewModel)
			{
				if (!(baseSupportChatItemViewModel2 is IncomingMessageViewModel))
				{
					goto IL_00e4;
				}
				top = Converter.DpToPx(16f);
			}
			else
			{
				if (baseSupportChatItemViewModel is BaseMessageViewModel)
				{
					goto IL_00e4;
				}
				top = ((baseSupportChatItemViewModel is DateItemViewModel) ? Converter.DpToPx(24f) : ((!(baseSupportChatItemViewModel is StatusItemViewModel)) ? outRect.Top : Converter.DpToPx(24f)));
			}
			goto IL_0116;
		}
		outRect.Top = Converter.DpToPx(6f);
		outRect.Left = Converter.DpToPx(6f);
		return;
		IL_00e4:
		top = Converter.DpToPx(4f);
		goto IL_0116;
		IL_0116:
		outRect.Top = top;
		if (baseSupportChatItemViewModel is DateItemViewModel || baseSupportChatItemViewModel is StatusItemViewModel)
		{
			outRect.Bottom = Converter.DpToPx(24f);
		}
	}
}
