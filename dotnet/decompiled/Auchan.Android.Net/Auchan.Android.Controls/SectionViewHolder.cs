using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Controls;

public class SectionViewHolder : RecyclerView.ViewHolder
{
	public TextView Title;

	public SectionViewHolder(View itemView, int mTextResourceid)
		: base(itemView)
	{
		Title = itemView.RequireViewById<TextView>(mTextResourceid);
	}
}
