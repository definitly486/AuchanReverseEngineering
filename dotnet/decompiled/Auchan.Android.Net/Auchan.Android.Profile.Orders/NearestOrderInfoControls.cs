using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.Profile.Orders.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Profile.Orders;

namespace Auchan.Android.Profile.Orders;

internal class NearestOrderInfoControls(View view)
{
	private readonly ImageView _image = view.RequireViewById<ImageView>(2131297319);

	private readonly TextView _title = view.RequireViewById<TextView>(2131297764);

	private readonly TextView _description = view.RequireViewById<TextView>(2131297763);

	public void Bind(NearestOrderInfoViewModel viewModel, ILifecycleOwner lifecycleOwner)
	{
		viewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				_image.SetImageResource(viewModel.Status.ToIconResourceId());
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Status")),
			(delegate
			{
				_title.Text = viewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				_description.Text = viewModel.Description;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Description")),
			(delegate
			{
				view.Visibility = viewModel.Visible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Visible"))
		})).AutoDisposeOnDestroy(lifecycleOwner);
		viewModel.BindEvents(view.OnClick((Action)delegate
		{
			viewModel.OpenQuickInfoPopupAsync().SafeFireAndForget((Action<Exception>)null, false);
		})).AutoDisposeOnDestroy(lifecycleOwner);
	}
}
