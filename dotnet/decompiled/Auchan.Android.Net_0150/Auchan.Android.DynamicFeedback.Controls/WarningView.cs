using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base.WidgetBases;
using Auchan.Common.DynamicFeedback;

namespace Auchan.Android.DynamicFeedback.Controls;

public class WarningView : ConstraintLayoutWidgetBase
{
	private readonly DynamicFeedbackViewModel _dynamicFeedbackViewModel;

	public WarningView(Context context, DynamicFeedbackViewModel dynamicFeedbackViewModel, ILifecycleOwner viewLifecycleOwner)
		: base(context)
	{
		_dynamicFeedbackViewModel = dynamicFeedbackViewModel;
		View.Inflate(context, 2131493205, this).RequireViewById<TextView>(2131298825).Text = _dynamicFeedbackViewModel.WarningViewMessage;
	}
}
