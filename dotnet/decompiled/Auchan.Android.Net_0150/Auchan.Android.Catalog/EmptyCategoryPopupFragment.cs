using System;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Analytics;
using Auchan.Common.Ecom.Products.ViewModels;

namespace Auchan.Android.Catalog;

internal class EmptyCategoryPopupFragment : BaseBottomSheetDialogFragment<EmptyCategoryPopupViewModel>
{
	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493465;

	public EmptyCategoryPopupFragment(Func<Fragment, EmptyCategoryPopupViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		base.Behavior.Draggable = false;
		TextView textView = view.RequireViewById<TextView>(2131298646);
		TextView textView2 = view.RequireViewById<TextView>(2131296958);
		Button button = view.RequireViewById<Button>(2131296587);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Description;
		button.Text = base.ViewModel.ButtonText;
		button.OnClick(ReturnToMyCategories).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public override void OnCancel(IDialogInterface dialog)
	{
		base.OnCancel(dialog);
		base.ParentFragment?.ParentFragmentManager.PopBackStack();
	}

	private void ReturnToMyCategories()
	{
		Auchan.Common.Analytics.AppAnalytics.AppMetrica.TrackEvent("Tap_MainPersonal_Back");
		base.ParentFragment?.ParentFragmentManager.PopBackStack();
	}
}
