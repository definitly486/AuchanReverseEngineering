using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart;

namespace Auchan.Android.Ecom.Cart;

internal sealed class SharedCartIsObsoletedFragment : BaseBottomSheetDialogFragment<SharedCartIsObsoletedViewModel>
{
	private sealed class Controls(View view)
	{
		public View View => view;

		public TextView Title { get; } = view.RequireViewById<TextView>(2131298646);

		public TextView Description { get; } = view.RequireViewById<TextView>(2131296958);

		public View Close { get; } = view.RequireViewById<View>(2131296789);

		public TextView ToCatalog { get; } = view.RequireViewById<TextView>(2131298662);

		public TextView ToHome { get; } = view.RequireViewById<TextView>(2131298663);
	}

	protected override int LayoutId => 2131493493;

	public override int Theme => 2131951914;

	public SharedCartIsObsoletedFragment(Func<BrokerToken, SharedCartIsObsoletedViewModel> newViewModel)
		: base((Func<Fragment, SharedCartIsObsoletedViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Controls controls = new Controls(view);
		controls.Title.Text = base.ViewModel.TitleText;
		controls.Description.Text = base.ViewModel.DescriptionText;
		controls.ToCatalog.Text = base.ViewModel.ToCatalogText;
		controls.ToHome.Text = base.ViewModel.ToHomeText;
		base.ViewModel.BindEvents(controls.Close.OnClick(base.ViewModel.Close), controls.ToCatalog.OnClick(base.ViewModel.OnCatalog), controls.ToHome.OnClick(base.ViewModel.OnHome)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}
}
