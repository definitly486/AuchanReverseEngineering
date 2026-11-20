using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;

namespace Auchan.Android.Common;

public abstract class VariableItemsListViewAdapter<TViewModel, TItemViewModel> : BaseAdapter<TItemViewModel>
{
	protected readonly Context _context;

	protected readonly ILifecycleOwner _viewLifecycleOwner;

	protected ICollection<TItemViewModel> ItemViewModels { get; set; }

	protected TViewModel ViewModel { get; set; }

	public override TItemViewModel this[int position] => ItemViewModels.ElementAtOrDefault(position);

	public override int Count => ItemViewModels.Count;

	public VariableItemsListViewAdapter(Context context, TViewModel viewModel, ICollection<TItemViewModel> itemViewModels, ILifecycleOwner viewLifecycleOwner)
	{
		_context = context;
		ViewModel = viewModel;
		ItemViewModels = itemViewModels;
		_viewLifecycleOwner = viewLifecycleOwner;
	}

	public override long GetItemId(int position)
	{
		return position;
	}

	public override View GetView(int position, View convertView, ViewGroup parent)
	{
		TItemViewModel val = ItemViewModels.ElementAtOrDefault(position);
		if (val == null)
		{
			return new View(_context);
		}
		convertView = GetViewFromType(parent, val);
		return convertView;
	}

	protected abstract View GetViewFromType(ViewGroup container, TItemViewModel itemViewModel);
}
