using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;

namespace Auchan.Android.Common.UiUtils;

public class EndlessRecyclerAdapter<T> : ObservableRecyclerAdapter<T, CachingViewHolder>
{
	public int FirstItemAdapterPosition
	{
		get
		{
			if (!EndlessEnabled)
			{
				return 0;
			}
			return 1073741823;
		}
	}

	public int MinItemsForEndless { get; set; } = 2;

	private bool EndlessEnabled => RealItemCount >= MinItemsForEndless;

	public override int ItemCount
	{
		get
		{
			if (!EndlessEnabled)
			{
				return RealItemCount;
			}
			return int.MaxValue;
		}
	}

	public int RealItemCount => base.DataSource?.Count ?? 0;

	public override void OnAttachedToRecyclerView(RecyclerView recyclerView)
	{
		base.OnAttachedToRecyclerView(recyclerView);
		recyclerView.ScrollToPosition(FirstItemAdapterPosition);
	}

	public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
	{
		int position2 = RealPosition(position);
		base.OnBindViewHolder(holder, position2);
	}

	public int RealPosition(int adapterPosition)
	{
		if (!EndlessEnabled)
		{
			return adapterPosition;
		}
		int num = adapterPosition % base.DataSource.Count - FirstItemAdapterPosition % base.DataSource.Count;
		if (num < 0)
		{
			return base.DataSource.Count + num;
		}
		return num;
	}
}
