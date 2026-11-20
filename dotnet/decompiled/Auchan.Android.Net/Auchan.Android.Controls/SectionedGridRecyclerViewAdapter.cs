using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using ViewSparsedRecycler;

namespace Auchan.Android.Controls;

public class SectionedGridRecyclerViewAdapter : RecyclerView.Adapter
{
	private readonly Context mContext;

	private const int SECTION_TYPE = 0;

	private bool mValid = true;

	private readonly int mSectionResourceId;

	private readonly int mTextResourceId;

	private readonly RecyclerView.Adapter mBaseAdapter;

	private readonly List<GridSection> mSections = new List<GridSection>();

	private readonly RecyclerView mRecyclerView;

	public override int ItemCount
	{
		get
		{
			if (!mValid)
			{
				return 0;
			}
			return mBaseAdapter.ItemCount + mSections.Count;
		}
	}

	public SectionedGridRecyclerViewAdapter(Context context, int sectionResourceId, int textResourceId, RecyclerView recyclerView, RecyclerView.Adapter baseAdapter)
	{
		mSectionResourceId = sectionResourceId;
		mTextResourceId = textResourceId;
		mBaseAdapter = baseAdapter;
		mContext = context;
		mRecyclerView = recyclerView;
		SectionedGridDataObserver sectionedGridDataObserver = new SectionedGridDataObserver();
		sectionedGridDataObserver.Changed += delegate
		{
			mValid = mBaseAdapter.ItemCount > 0;
			NotifyDataSetChanged();
		};
		sectionedGridDataObserver.ItemRangeChanged += delegate(object? sender, EventAdapterDataObserver.ItemRangeChangedEventArgs args)
		{
			mValid = mBaseAdapter.ItemCount > 0;
			NotifyItemRangeChanged(args.PositionStart, args.ItemCount);
		};
		sectionedGridDataObserver.ItemRangeInserted += delegate(object? sender, EventAdapterDataObserver.ItemRangeInsertedEventArgs args)
		{
			mValid = mBaseAdapter.ItemCount > 0;
			NotifyItemRangeInserted(args.PositionStart, args.ItemCount);
		};
		sectionedGridDataObserver.ItemRangeRemoved += delegate(object? sender, EventAdapterDataObserver.ItemRangeRemovedEventArgs args)
		{
			NotifyItemRangeRemoved(args.PositionStart, args.ItemCount);
		};
		mBaseAdapter.RegisterAdapterDataObserver(sectionedGridDataObserver);
		GridLayoutManager obj = (GridLayoutManager)mRecyclerView.GetLayoutManager();
		obj.SetSpanSizeLookup(new SectionedGridSpanSizeLookup(obj, IsSectionHeaderPosition));
	}

	public bool IsSectionHeaderPosition(int position)
	{
		return mSections.Any((GridSection x) => x.SectionedPosition == position);
	}

	public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
	{
		if (viewType != 0)
		{
			return mBaseAdapter.OnCreateViewHolder(parent, viewType - 1);
		}
		return new SectionViewHolder(LayoutInflater.From(mContext).Inflate(mSectionResourceId, parent, attachToRoot: false), mTextResourceId);
	}

	public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
	{
		if (IsSectionHeaderPosition(position))
		{
			((SectionViewHolder)holder).Title.Text = mSections.First((GridSection x) => x.SectionedPosition == position).Title;
		}
		else
		{
			mBaseAdapter.OnBindViewHolder(holder, SectionedPositionToPosition(position));
		}
	}

	public override int GetItemViewType(int position)
	{
		if (!IsSectionHeaderPosition(position))
		{
			return mBaseAdapter.GetItemViewType(SectionedPositionToPosition(position)) + 1;
		}
		return 0;
	}

	public override long GetItemId(int position)
	{
		if (!IsSectionHeaderPosition(position))
		{
			return mBaseAdapter.GetItemId(SectionedPositionToPosition(position));
		}
		return int.MaxValue - position;
	}

	public void SetSections(GridSection[] sections)
	{
		bool flag = true;
		if (sections.Length == mSections.Count)
		{
			for (int i = 0; i < mSections.Count; i++)
			{
				GridSection gridSection = mSections[i];
				GridSection gridSection2 = sections[i];
				if (gridSection2.Title != gridSection.Title || gridSection2.FirstPosition != gridSection.FirstPosition)
				{
					flag = false;
					break;
				}
			}
		}
		else
		{
			flag = false;
		}
		if (!flag)
		{
			mSections.Clear();
			Array.Sort(sections, (GridSection o, GridSection o1) => (o.FirstPosition != o1.FirstPosition) ? ((o.FirstPosition >= o1.FirstPosition) ? 1 : (-1)) : 0);
			int num = 0;
			foreach (GridSection gridSection3 in sections)
			{
				gridSection3.SectionedPosition = gridSection3.FirstPosition + num;
				mSections.Add(gridSection3);
				num++;
			}
			NotifyDataSetChanged();
		}
	}

	public int PositionToSectionedPosition(int position)
	{
		int num = mSections.TakeWhile((GridSection section) => section.FirstPosition <= position).Count();
		return position + num;
	}

	public int SectionedPositionToPosition(int sectionedPosition)
	{
		if (IsSectionHeaderPosition(sectionedPosition))
		{
			return -1;
		}
		int num = 0;
		using (List<GridSection>.Enumerator enumerator = mSections.GetEnumerator())
		{
			while (enumerator.MoveNext() && enumerator.Current.SectionedPosition <= sectionedPosition)
			{
				num--;
			}
		}
		return sectionedPosition + num;
	}
}
