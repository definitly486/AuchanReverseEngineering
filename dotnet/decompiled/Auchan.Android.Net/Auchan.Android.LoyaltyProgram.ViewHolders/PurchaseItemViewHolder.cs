using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;
using Google.Android.Material.Card;

namespace Auchan.Android.LoyaltyProgram.ViewHolders;

public class PurchaseItemViewHolder : CachingViewHolder
{
	private static Dictionary<QualifiedLoyaltyOperationType, int[]> OperationTypesColorAndIcon = new Dictionary<QualifiedLoyaltyOperationType, int[]>
	{
		{
			QualifiedLoyaltyOperationType.PointsRecieved,
			new int[2] { 2131100592, 2131231255 }
		},
		{
			QualifiedLoyaltyOperationType.PointsGivenAway,
			new int[2] { 2131100592, 2131231255 }
		},
		{
			QualifiedLoyaltyOperationType.StampsRecieved,
			new int[2] { 2131100592, 2131231370 }
		},
		{
			QualifiedLoyaltyOperationType.StampsGivenAway,
			new int[2] { 2131100592, 2131231368 }
		},
		{
			QualifiedLoyaltyOperationType.Purchase,
			new int[2] { 2131099856, 2131231304 }
		},
		{
			QualifiedLoyaltyOperationType.Order,
			new int[2] { 2131099856, 2131231304 }
		},
		{
			QualifiedLoyaltyOperationType.PointsCorrected,
			new int[2] { 2131100545, 2131231258 }
		},
		{
			QualifiedLoyaltyOperationType.StampsCorrecred,
			new int[2] { 2131100545, 2131231365 }
		},
		{
			QualifiedLoyaltyOperationType.PointsExpired,
			new int[2] { 2131099729, 2131231262 }
		},
		{
			QualifiedLoyaltyOperationType.StampsExpired,
			new int[2] { 2131099729, 2131231262 }
		},
		{
			QualifiedLoyaltyOperationType.GameStamps,
			new int[2] { 2131099648, 2131231183 }
		},
		{
			QualifiedLoyaltyOperationType.GamePoints,
			new int[2] { 2131099648, 2131231183 }
		},
		{
			QualifiedLoyaltyOperationType.Refund,
			new int[2] { 2131100559, 2131231307 }
		}
	};

	private MaterialCardView iconCard;

	private ImageView icon;

	private TextView nameLabel;

	private TextView purchaseTotalLabel;

	private TextView timeLabel;

	private ViewGroup pointsLayout;

	private TextView expressPointsValueLabel;

	private TextView pointsValueLabel;

	private TextView stampsValueLabel;

	private ImageView pointsIcon;

	private ImageView epointsIcon;

	private ImageView stampsIcon;

	private ViewGroup bigPointsLayout;

	private TextView bigPointsValueLabel;

	private TextView bigEPointsValueLabel;

	private TextView bigStampsValueLabel;

	private ImageView bigPointsIcon;

	private ImageView bigEPointsIcon;

	private ImageView bigStampsIcon;

	public PurchaseItemViewHolder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public PurchaseItemViewHolder(View itemView)
		: base(itemView)
	{
		iconCard = itemView.RequireViewById<MaterialCardView>(2131297313);
		icon = iconCard.RequireViewById<ImageView>(2131297308);
		nameLabel = itemView.RequireViewById<TextView>(2131297637);
		purchaseTotalLabel = itemView.RequireViewById<TextView>(2131298120);
		timeLabel = itemView.RequireViewById<TextView>(2131298640);
		pointsLayout = itemView.RequireViewById<ViewGroup>(2131297940);
		expressPointsValueLabel = pointsLayout.RequireViewById<TextView>(2131297132);
		pointsValueLabel = pointsLayout.RequireViewById<TextView>(2131297956);
		stampsValueLabel = pointsLayout.RequireViewById<TextView>(2131298457);
		pointsIcon = pointsLayout.RequireViewById<ImageView>(2131297935);
		epointsIcon = pointsLayout.RequireViewById<ImageView>(2131297103);
		stampsIcon = pointsLayout.RequireViewById<ImageView>(2131298446);
		bigPointsLayout = itemView.RequireViewById<ViewGroup>(2131296531);
		bigPointsValueLabel = bigPointsLayout.RequireViewById<TextView>(2131296532);
		bigEPointsValueLabel = bigPointsLayout.RequireViewById<TextView>(2131296529);
		bigStampsValueLabel = bigPointsLayout.RequireViewById<TextView>(2131296534);
		bigPointsIcon = bigPointsLayout.RequireViewById<ImageView>(2131296530);
		bigEPointsIcon = bigPointsLayout.RequireViewById<ImageView>(2131296528);
		bigStampsIcon = bigPointsLayout.RequireViewById<ImageView>(2131296533);
	}

	public void DoBind(Context context, PurchaseItemViewModel model, CompositeDisposable disposable)
	{
		if (model.OperationType == QualifiedLoyaltyOperationType.Purchase)
		{
			_ = 1;
		}
		else
			_ = model.OperationType == QualifiedLoyaltyOperationType.Order;
		nameLabel.Text = model.OperationName;
		purchaseTotalLabel.Text = model.Amount;
		timeLabel.Text = model.FormattedTime;
		pointsValueLabel.Text = model.Points;
		expressPointsValueLabel.Text = model.EPoints;
		stampsValueLabel.Text = model.Stamps;
		bigPointsValueLabel.Text = model.Amount;
		bigEPointsValueLabel.Text = model.Amount;
		bigStampsValueLabel.Text = model.Amount;
		bool isOrderOrPurchase = model.IsOrderOrPurchase;
		purchaseTotalLabel.Visibility = isOrderOrPurchase.ToVisibility();
		pointsLayout.Visibility = isOrderOrPurchase.ToVisibility();
		TextView textView = pointsValueLabel;
		ViewStates visibility = (pointsIcon.Visibility = (isOrderOrPurchase && model.HasPoints).ToVisibility());
		textView.Visibility = visibility;
		TextView textView2 = expressPointsValueLabel;
		visibility = (epointsIcon.Visibility = (isOrderOrPurchase && model.HasEPoints).ToVisibility());
		textView2.Visibility = visibility;
		TextView textView3 = stampsValueLabel;
		visibility = (stampsIcon.Visibility = (isOrderOrPurchase && model.HasStamps).ToVisibility());
		textView3.Visibility = visibility;
		bigPointsLayout.Visibility = (!isOrderOrPurchase).ToVisibility();
		TextView textView4 = bigPointsValueLabel;
		visibility = (bigPointsIcon.Visibility = (!isOrderOrPurchase && model.HasPoints).ToVisibility());
		textView4.Visibility = visibility;
		TextView textView5 = bigEPointsValueLabel;
		visibility = (bigEPointsIcon.Visibility = (!isOrderOrPurchase && model.HasEPoints).ToVisibility());
		textView5.Visibility = visibility;
		TextView textView6 = bigStampsValueLabel;
		visibility = (bigStampsIcon.Visibility = (!isOrderOrPurchase && model.HasStamps).ToVisibility());
		textView6.Visibility = visibility;
		SetOperationType(model.OperationType);
	}

	private void SetOperationType(QualifiedLoyaltyOperationType operationType)
	{
		OperationTypesColorAndIcon.TryGetValue(operationType, out var value);
		if (value != null)
		{
			iconCard.SetCardBackgroundColor(ContextCompat.GetColor(iconCard.Context, value[0]));
			icon.SetImageResource(value[1]);
		}
	}
}
