using Android.Views;
using Android.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;

namespace Auchan.Android.Ecom.AddressStoreSelection;

internal sealed class ListItemPickupStoreControls
{
	public CompoundButton RadioButton { get; } = holder.RequireCachedView<CompoundButton>(2131298135);

	public TextView Name { get; } = holder.RequireCachedView<TextView>(2131297632);

	public TextView Address { get; } = holder.RequireCachedView<TextView>(2131296384);

	public View TopSeparator { get; } = holder.RequireCachedView<View>(2131298709);

	public View BottomSeparator { get; } = holder.RequireCachedView<View>(2131296555);

	public View Delete { get; } = holder.RequireCachedView<View>(2131296923);

	public ListItemPickupStoreControls(CachingViewHolder holder)
	{
	}
}
