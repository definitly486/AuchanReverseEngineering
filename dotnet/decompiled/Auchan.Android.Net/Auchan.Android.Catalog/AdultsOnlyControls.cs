using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Auchan.Android.Extensions;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Extensions;

namespace Auchan.Android.Catalog;

internal sealed class AdultsOnlyControls(View view)
{
	private readonly TextView _adultsOnlyText = view.RequireViewById<TextView>(2131296413);

	public void Setup(IAdultsOnlyItemViewModel viewModel, ICollection<IDisposable> disposables)
	{
		_adultsOnlyText.Text = viewModel.AdultsOnlyText;
		viewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			view.Visibility = viewModel.ShouldBlur.ToVisibility();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ShouldBlur")))).AddTo(disposables);
	}
}
