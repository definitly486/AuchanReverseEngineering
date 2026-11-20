using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.DynamicFeedback;
using Google.Android.Material.TextField;

namespace Auchan.Android.DynamicFeedback.Controls;

[Register("auchan.Android.Feedback.layout_drop_down_list")]
public class ListSelectionField : ConstraintLayoutWidgetBase
{
	public ListSelectionField(Context context, DynamicFeedbackViewModel dynamicFeedbackViewModel, FieldItemViewModel fieldItemViewModel, ILifecycleOwner viewLifecycleOwner)
		: base(context)
	{
		View view = View.Inflate(context, 2131493151, this);
		TextInputLayout listSelectionLayout = view.RequireViewById<TextInputLayout>(2131297457);
		TextView listChoice = listSelectionLayout.RequireViewById<TextView>(2131297454);
		listSelectionLayout.Hint = fieldItemViewModel.Hint;
		dynamicFeedbackViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			listChoice.Enabled = dynamicFeedbackViewModel.IsFieldEnabled(dynamicFeedbackViewModel.SelectedCityName, fieldItemViewModel);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedCityName")))).AutoDisposeOnDestroy(viewLifecycleOwner);
		fieldItemViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				listChoice.Text = fieldItemViewModel.Text;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Text")),
			(delegate
			{
				listSelectionLayout.SetError(fieldItemViewModel.ErrorText, fieldItemViewModel.Error);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "ErrorText", "Error" }))
		})).AutoDisposeOnDestroy(viewLifecycleOwner);
		fieldItemViewModel.BindEvents(((View)listChoice).OnClick((Action)delegate
		{
			dynamicFeedbackViewModel.OnListPickerClicked(fieldItemViewModel);
		})).AutoDisposeOnDestroy(viewLifecycleOwner);
	}
}
