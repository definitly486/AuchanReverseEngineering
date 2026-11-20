using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Streams;

namespace Auchan.Android.Streams;

public class StreamListItem : ConstraintLayoutWidgetBase
{
	public StreamListItem(Context context, StreamItemViewModel streamItemViewModel, StreamListViewModel streamListViewModel, ILifecycleOwner lifecycleOwner)
		: base(context)
	{
		ImageView imageView = View.Inflate(context, 2131493350, this).RequireViewById<ImageView>(2131296511);
		imageView.FromUrl(streamItemViewModel.ImageUrl);
		streamListViewModel.BindEvents(((View)imageView).OnClick((Action)delegate
		{
			streamListViewModel.OnStreamClicked(streamItemViewModel);
		})).AutoDisposeOnDestroy(lifecycleOwner);
	}
}
