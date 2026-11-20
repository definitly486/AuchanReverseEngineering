using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.Core.Graphics;
using AndroidX.Core.View;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Base.Widgets;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.AccomplishedTransfer;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;
using EBind;
using Google.Android.Material.Button;

namespace Auchan.Android.LoyaltyProgram.PointsTransfer;

internal class LoyaltyPointsTransferToCharityFragment : BaseToolbarFragment<LoyaltyPointsTransferToCharityViewModel>, IFragmentResultReceiver<int>
{
	private const int FinalDialogRequestCode = 19101;

	private EditText _amountInput;

	private ViewGroup _pointsTab;

	private ViewGroup _stampsTab;

	protected override int LayoutId => 2131493054;

	public LoyaltyPointsTransferToCharityFragment(Func<LoyaltyPointsTransferNavigationParameter, LoyaltyPointsTransferToCharityViewModel> newViewModel)
		: base((Func<Fragment, LoyaltyPointsTransferToCharityViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<LoyaltyPointsTransferNavigationParameter>())))
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_pointsTab = view.RequireViewById<ViewGroup>(2131297940);
		TextView pointsTitleLabel = view.RequireViewById<TextView>(2131297953);
		TextView pointsIntLabel = view.RequireViewById<TextView>(2131297938);
		TextView pointsFractionLabel = view.RequireViewById<TextView>(2131297933);
		_stampsTab = view.RequireViewById<ViewGroup>(2131298448);
		TextView stampsTitleLabel = view.RequireViewById<TextView>(2131298456);
		TextView stampsIntLabel = view.RequireViewById<TextView>(2131298447);
		TextView textView = view.RequireViewById<TextView>(2131296757);
		TextView textView2 = view.RequireViewById<TextView>(2131296753);
		View view2 = view.RequireViewById<View>(2131297597);
		TextView textView3 = view.RequireViewById<TextView>(2131297598);
		TextView enterPointsAmountLabel = view.RequireViewById<TextView>(2131297099);
		OutlinedTextInput amountInputLayout = view.RequireViewById<OutlinedTextInput>(2131296438);
		_amountInput = amountInputLayout.EditText;
		_amountInput.InputType = InputTypes.ClassNumber;
		MaterialButton transferButton = view.RequireViewById<MaterialButton>(2131298751);
		base.ToolbarTitle = base.ViewModel.ScreenTitle;
		textView.Text = base.ViewModel.TransferOperationDescriptionTitleText;
		textView2.Text = base.ViewModel.TransferOperationDescriptionText;
		textView3.Text = base.ViewModel.MoreDetailsLabel;
		enterPointsAmountLabel.Text = base.ViewModel.EnterAmountLabel;
		transferButton.Text = base.ViewModel.TransferButtonText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[11]
		{
			(delegate
			{
				UpdateLoyaltyTabs(base.ViewModel.PointsType);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsType")),
			(delegate
			{
				pointsTitleLabel.Text = base.ViewModel.PointsTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsTitle")),
			(delegate
			{
				pointsIntLabel.Text = base.ViewModel.PointsBalanceIntString;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsBalanceIntString")),
			(delegate
			{
				pointsFractionLabel.Text = base.ViewModel.PointsBalanceFractionString;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsBalanceFractionString")),
			(delegate
			{
				stampsTitleLabel.Text = base.ViewModel.StampsTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StampsTitle")),
			(delegate
			{
				stampsIntLabel.Text = base.ViewModel.StampsBalanceString;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StampsBalanceString")),
			(delegate
			{
				enterPointsAmountLabel.Text = base.ViewModel.EnterAmountLabel;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EnterAmountLabel")),
			(delegate
			{
				_amountInput.ApplyText(base.ViewModel.PointsAmount);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsAmount")),
			(delegate
			{
				amountInputLayout.Hint = base.ViewModel.AmountInputHint;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AmountInputHint")),
			(delegate
			{
				amountInputLayout.SetError(base.ViewModel.AmountErrorText, !base.ViewModel.IsAmountValid);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "AmountErrorText", "IsAmountValid" })),
			(delegate
			{
				transferButton.Enabled = base.ViewModel.IsTransferButtonEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsTransferButtonEnabled"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(view2.OnClick(base.ViewModel.OnNavigateToCharityDetailsSelected), ((View)transferButton).OnClick((Action)delegate
		{
			base.ViewModel.OnTransferButtonSelected().SafeFireAndForget((Action<Exception>)null, false);
		}), _pointsTab.OnClick(base.ViewModel.PointsTabTapped), _stampsTab.OnClick(base.ViewModel.StampsTabTapped), ((TextView)_amountInput).OnTextChanged((Action)delegate
		{
			base.ViewModel.PointsAmount = _amountInput.Text ?? "";
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		amountInputLayout.ButtonTapped += new DisposableDelegate<Action<OutlinedTextInput.ButtonStyle>>(delegate(OutlinedTextInput.ButtonStyle style)
		{
			AmountInputButtonTapped(style);
		}, delegate(Action<OutlinedTextInput.ButtonStyle> h)
		{
			amountInputLayout.ButtonTapped -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.NavigateToTransferSuccess.SafeSubscribe(delegate(LoyaltyPointsSentToCharityNavigationParameter p)
		{
			OnNavigateToTransferSuccess(p).SafeFireAndForget((Action<Exception>)null, false);
		}, ViewLifecycleOwner);
		base.ViewModel.NavigateToTransferFailure.SafeSubscribe(OnNavigateToTransferFailure, ViewLifecycleOwner);
	}

	private void AmountInputButtonTapped(OutlinedTextInput.ButtonStyle style)
	{
		if (style == OutlinedTextInput.ButtonStyle.Clear)
		{
			base.ViewModel.PointsAmount = "";
		}
	}

	private void UpdateLoyaltyTabs(LoyaltyPointType pointType)
	{
		_pointsTab.Activated = pointType == LoyaltyPointType.Points;
		_stampsTab.Activated = pointType == LoyaltyPointType.Stamps;
		_stampsTab.Visibility = base.ViewModel.ShowStamps.ToInvisibleVisibility();
	}

	private async Task OnNavigateToTransferSuccess(LoyaltyPointsSentToCharityNavigationParameter obj)
	{
		FragmentActivity fragmentActivity = RequireActivity();
		if (!(fragmentActivity is BaseActivity ba))
		{
			return;
		}
		Insets insets = ba.WindowInsets.GetInsets(WindowInsetsCompat.Type.Ime());
		InputMethodManager.FromContext(Context).HideSoftInputFromWindow(View.WindowToken, HideSoftInputFlags.None);
		if (insets.Bottom > 0)
		{
			while (insets.Bottom > 0)
			{
				await Task.Delay(100);
				insets = ba.WindowInsets.GetInsets(WindowInsetsCompat.Type.Ime());
			}
		}
		try
		{
			Show<LoyaltyPointsSentToCharityFragment, LoyaltyPointsSentToCharityNavigationParameter>(obj);
		}
		catch (ObjectDisposedException)
		{
		}
	}

	private void OnNavigateToTransferFailure(LoyaltyTransferErrorViewModel.Parameter parameter)
	{
		Show<LoyaltyPointTransferErrorFragment, LoyaltyTransferErrorViewModel.Parameter>(parameter);
	}

	protected override void OnNavigationButtonClick()
	{
		InputMethodManager.FromContext(Context).HideSoftInputFromWindow(View.WindowToken, HideSoftInputFlags.None);
		base.ParentFragmentManager.PopBackStack();
	}

	public void OnResult(int requestCode, int value)
	{
		base.ParentFragmentManager.PopBackStack("LoyaltyTransferFlowBackstack", 1);
	}
}
