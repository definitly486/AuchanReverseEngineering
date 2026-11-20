using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;
using Google.Android.Material.Card;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram;

internal sealed class OperationDetailsFragment : BaseBottomSheetDialogFragment<OperationDetailsViewModel>
{
	private TextView _title;

	private View _closeButton;

	private ImageView _icon;

	private MaterialCardView _descriptionBackground;

	private TextView _operationValue;

	private ImageView _operationValueIcon;

	private TextView _time;

	private TextView _storeName;

	private TextView _storeAddress;

	private LinearLayout _defaultView;

	private View _errorView;

	private TextView _errorText;

	private TextView _errorTitle;

	private ImageView _errorImage;

	private ImageView _errorCloseButton;

	protected override int LayoutId => 2131493479;

	public override int Theme => 2131951914;

	public OperationDetailsFragment(Func<OperationDetailsViewModel.Parameter, OperationDetailsViewModel> newViewModel)
		: base((Func<Fragment, OperationDetailsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<OperationDetailsViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		InitializeViews();
		SetStyle();
		SetValues();
		DoBind();
	}

	private void InitializeViews()
	{
		_defaultView = View.RequireViewById<LinearLayout>(2131296911);
		_errorView = View.RequireViewById<ConstraintLayout>(2131297111);
		_title = _defaultView.RequireViewById<TextView>(2131298646);
		_closeButton = _defaultView.RequireViewById<ImageView>(2131296795);
		_icon = _defaultView.RequireViewById<ImageView>(2131297308);
		_descriptionBackground = _defaultView.RequireViewById<MaterialCardView>(2131296961);
		_operationValue = _descriptionBackground.RequireViewById<TextView>(2131298795);
		_operationValueIcon = _descriptionBackground.RequireViewById<ImageView>(2131298794);
		_time = _descriptionBackground.RequireViewById<TextView>(2131298640);
		_storeName = _defaultView.RequireViewById<TextView>(2131298520);
		_storeAddress = _defaultView.RequireViewById<TextView>(2131298488);
		_errorTitle = _errorView.RequireViewById<TextView>(2131298646);
		_errorCloseButton = _errorView.RequireViewById<ImageView>(2131296795);
		_errorText = _errorView.RequireViewById<TextView>(2131296808);
		_errorImage = _errorView.RequireViewById<ImageView>(2131296807);
	}

	private void SetStyle()
	{
		if (base.ViewModel.HasPointIcon)
		{
			_operationValueIcon.Visibility = ViewStates.Visible;
			bool flag = base.ViewModel.OperationType == QualifiedLoyaltyOperationType.StampsRecieved || base.ViewModel.OperationType == QualifiedLoyaltyOperationType.StampsGivenAway || base.ViewModel.OperationType == QualifiedLoyaltyOperationType.StampsCorrecred || base.ViewModel.OperationType == QualifiedLoyaltyOperationType.StampsExpired || base.ViewModel.OperationType == QualifiedLoyaltyOperationType.GameStamps;
			_operationValueIcon.SetImageResource(flag ? 2131231223 : (base.ViewModel.HasPurchaseEPoints ? 2131231221 : 2131231224));
		}
		SetStyleByOperationType(base.ViewModel.OperationType);
	}

	private void SetStyleByOperationType(QualifiedLoyaltyOperationType operationType)
	{
		switch (operationType)
		{
		case QualifiedLoyaltyOperationType.PointsRecieved:
		case QualifiedLoyaltyOperationType.PointsGivenAway:
			_descriptionBackground.SetCardBackgroundColor(ContextCompat.GetColor(Context, 2131100627));
			_icon.SetImageResource(2131231261);
			break;
		case QualifiedLoyaltyOperationType.Purchase:
			_descriptionBackground.SetCardBackgroundColor(ContextCompat.GetColor(Context, 2131099688));
			_icon.SetImageResource(2131231257);
			break;
		case QualifiedLoyaltyOperationType.Order:
			_descriptionBackground.SetCardBackgroundColor(Context.GetColor(2131099688));
			_icon.SetImageResource(2131231257);
			break;
		case QualifiedLoyaltyOperationType.PointsCorrected:
			_descriptionBackground.SetCardBackgroundColor(ContextCompat.GetColor(Context, 2131100587));
			_icon.SetImageResource(2131231259);
			break;
		case QualifiedLoyaltyOperationType.PointsExpired:
			_descriptionBackground.SetCardBackgroundColor(ContextCompat.GetColor(Context, 2131100551));
			_icon.SetImageResource(2131231263);
			break;
		case QualifiedLoyaltyOperationType.StampsCorrecred:
			_descriptionBackground.SetCardBackgroundColor(ContextCompat.GetColor(Context, 2131100588));
			_icon.SetImageResource(2131231366);
			break;
		case QualifiedLoyaltyOperationType.StampsExpired:
			_descriptionBackground.SetCardBackgroundColor(ContextCompat.GetColor(Context, 2131100589));
			_icon.SetImageResource(2131231367);
			break;
		case QualifiedLoyaltyOperationType.StampsRecieved:
			_descriptionBackground.SetCardBackgroundColor(ContextCompat.GetColor(Context, 2131100590));
			_icon.SetImageResource(2131231371);
			break;
		case QualifiedLoyaltyOperationType.StampsGivenAway:
			_descriptionBackground.SetCardBackgroundColor(ContextCompat.GetColor(Context, 2131100590));
			_icon.SetImageResource(2131231369);
			break;
		case QualifiedLoyaltyOperationType.GamePoints:
			_descriptionBackground.SetCardBackgroundColor(ContextCompat.GetColor(Context, 2131100538));
			_icon.SetImageResource(2131231182);
			break;
		case QualifiedLoyaltyOperationType.GameStamps:
			_descriptionBackground.SetCardBackgroundColor(ContextCompat.GetColor(Context, 2131100538));
			_icon.SetImageResource(2131231182);
			_operationValueIcon.SetImageResource(2131231223);
			break;
		case QualifiedLoyaltyOperationType.DelayedPoints:
			break;
		}
	}

	private void SetValues()
	{
		_title.Text = base.ViewModel.Title;
		_operationValue.Text = base.ViewModel.Amount;
		_time.Text = base.ViewModel.FormattedTime;
	}

	private void DoBind()
	{
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				_defaultView
			},
			{
				VisualState.Error,
				_errorView
			}
		};
		_errorText.SetLinkedHtml(base.ViewModel.ConnectionErrorText, base.ViewModel.HandleLink).AutoDisposeAllOnDestroy(ViewLifecycleOwner);
		_errorText.AddScrollBehaviour();
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				_errorTitle.Text = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				_errorImage.FromUrlWithPlaceholder(base.ViewModel.ConnectionErrorImage, 2131231054);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ConnectionErrorImage")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				SetStoreInfo(base.ViewModel.HasStoreInfo);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasStoreInfo"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(_errorCloseButton.OnClick(Dismiss), _closeButton.OnClick(Dismiss)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void SetStoreInfo(bool hasStoreInfo)
	{
		if (hasStoreInfo)
		{
			_storeName.Text = base.ViewModel.StoreName;
			_storeAddress.Text = base.ViewModel.StoreAddress;
			TextView storeName = _storeName;
			ViewStates visibility = (_storeAddress.Visibility = ViewStates.Visible);
			storeName.Visibility = visibility;
		}
	}
}
