using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Common.Streams;

namespace Auchan.Android.Streams;

public class StreamsListViewAdapter : BaseAdapter<StreamItemViewModel>
{
	private readonly List<StreamItemViewModel> _models;

	private readonly StreamListViewModel _streamListViewModel;

	private readonly Context _context;

	private readonly ILifecycleOwner _lifecycleOwner;

	public override StreamItemViewModel this[int position] => _models[position];

	public override int Count => _models.Count;

	public StreamsListViewAdapter(Context context, StreamListViewModel streamListViewModel, ILifecycleOwner viewLifecycleOwner)
	{
		_models = streamListViewModel.StreamItemViewModels.ToList();
		_context = context;
		_lifecycleOwner = viewLifecycleOwner;
		_streamListViewModel = streamListViewModel;
	}

	public override long GetItemId(int position)
	{
		return position;
	}

	public override View GetView(int position, View convertView, ViewGroup parent)
	{
		StreamItemViewModel streamItemViewModel = _models[position];
		if (streamItemViewModel != null)
		{
			convertView = GetViewFromType(streamItemViewModel);
		}
		return convertView;
	}

	private View GetViewFromType(StreamItemViewModel streamItemViewModel)
	{
		if (streamItemViewModel.IsBlockTitle)
		{
			return new BlockTitleListItem(_context, streamItemViewModel);
		}
		return new StreamListItem(_context, streamItemViewModel, _streamListViewModel, _lifecycleOwner);
	}
}
