using Android.Content;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base.WidgetBases;
using Auchan.Common.Streams;

namespace Auchan.Android.Streams;

public class BlockTitleListItem : ConstraintLayoutWidgetBase
{
	public BlockTitleListItem(Context context, StreamItemViewModel itemViewModel)
		: base(context)
	{
		View.Inflate(context, 2131493351, this).RequireViewById<TextView>(2131296538).Text = itemViewModel.BlockTitle;
	}
}
