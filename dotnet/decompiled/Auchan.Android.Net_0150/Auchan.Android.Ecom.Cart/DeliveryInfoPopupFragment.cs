using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.ViewModels;

namespace Auchan.Android.Ecom.Cart;

internal class DeliveryInfoPopupFragment : BaseBottomSheetDialogFragment<DeliveryInfoPopupViewModel>
{
	private sealed class Controls(View view)
	{
		public View View => view;

		public TextView Title { get; } = view.RequireViewById<TextView>(2131298646);

		public View CloseButton { get; } = view.RequireViewById<View>(2131296791);

		public TextView KeyTitle { get; } = view.RequireViewById<TextView>(2131297412);

		public TextView ValueTitle { get; } = view.RequireViewById<TextView>(2131298793);

		public ViewGroup ContentLayout { get; } = view.RequireViewById<ViewGroup>(2131296839);

		public TextView OkButton { get; } = view.RequireViewById<TextView>(2131297727);
	}

	private sealed class ListItem(View view)
	{
		public View View => view;

		public ImageView Icon { get; } = view.RequireViewById<ImageView>(2131297308);

		public TextView Key { get; } = view.RequireViewById<TextView>(2131297411);

		public TextView Value { get; } = view.RequireViewById<TextView>(2131298792);
	}

	protected override int LayoutId => 2131493454;

	public override int Theme => 2131951914;

	public DeliveryInfoPopupFragment(Func<DeliveryInfoPopupViewModel.Parameter?, DeliveryInfoPopupViewModel> newViewModel)
		: base((Func<Fragment, DeliveryInfoPopupViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.NavParam<DeliveryInfoPopupViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Controls controls = new Controls(view);
		controls.Title.Text = base.ViewModel.Title;
		controls.KeyTitle.Text = base.ViewModel.KeyTitle;
		controls.ValueTitle.Text = base.ViewModel.ValueTitle;
		controls.OkButton.Text = base.ViewModel.OkText;
		foreach (DeliveryInfoPopupViewModel.Item item in base.ViewModel.Items)
		{
			if (item.Type == DeliveryInfoPopupViewModel.Type.Separator)
			{
				base.LayoutInflater.Inflate(2131493216, controls.ContentLayout, attachToRoot: true);
				continue;
			}
			View view2 = base.LayoutInflater.Inflate(2131493215, controls.ContentLayout, attachToRoot: false);
			ListItem listItem = new ListItem(view2);
			listItem.Icon.SetImageResource(GetIconResource(item.Type));
			listItem.Key.Text = item.Key;
			listItem.Value.Text = item.Value;
			controls.ContentLayout.AddView(view2);
		}
		base.ViewModel.BindEvents(controls.CloseButton.OnClick(base.ViewModel.CloseCommand.Trigger), controls.OkButton.OnClick(base.ViewModel.CloseCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}

	private int GetIconResource(DeliveryInfoPopupViewModel.Type iconType)
	{
		return iconType switch
		{
			DeliveryInfoPopupViewModel.Type.Delivery => 2131231373, 
			DeliveryInfoPopupViewModel.Type.ExpressDelivery => 2131231160, 
			DeliveryInfoPopupViewModel.Type.Overweight => 2131231266, 
			_ => throw new ArgumentOutOfRangeException("iconType"), 
		};
	}
}
