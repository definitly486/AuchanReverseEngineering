using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using Auchan.Common.Base;
using Auchan.Common.DynamicFeedback;

namespace Auchan.Android.DynamicFeedback.Controls;

public class HeaderView : LinearLayoutWidgetBase
{
	public HeaderView(Context context, DynamicFeedbackViewModel dynamicFeedbackViewModel, ILifecycleOwner viewLifecycleOwner)
		: base(context)
	{
		View view = View.Inflate(context, 2131493156, this);
		TextView hint = view.RequireViewById<TextView>(2131297152);
		CategoriesAndTopicsControls categoriesAndTopicsControls = new CategoriesAndTopicsControls(view.RequireViewById<View>(2131296712));
		if (dynamicFeedbackViewModel.WithTopicAndCategory)
		{
			categoriesAndTopicsControls.Setup(dynamicFeedbackViewModel, viewLifecycleOwner);
			categoriesAndTopicsControls.View.Visibility = ViewStates.Visible;
		}
		else
		{
			categoriesAndTopicsControls.View.Visibility = ViewStates.Gone;
		}
		dynamicFeedbackViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			hint.Text = dynamicFeedbackViewModel.GreetingsString;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("GreetingsString")))).AutoDisposeOnDestroy(viewLifecycleOwner);
	}
}
