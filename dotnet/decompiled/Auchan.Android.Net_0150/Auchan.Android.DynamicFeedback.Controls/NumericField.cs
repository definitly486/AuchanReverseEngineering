using System;
using System.Collections.Generic;
using Android.Content;
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

public class NumericField : ConstraintLayoutWidgetBase
{
	public NumericField(Context context, FieldItemViewModel itemViewModel, ILifecycleOwner viewLifecycleOwner)
		: base(context)
	{
		int resource = ((itemViewModel.FieldType == FieldType.Integer) ? 2131493159 : 2131493155);
		int id = ((itemViewModel.FieldType == FieldType.Integer) ? 2131297373 : 2131297199);
		View view = View.Inflate(context, resource, this);
		TextInputLayout editTextInputLayout = view.RequireViewById<TextInputLayout>(id);
		editTextInputLayout.Hint = itemViewModel.Hint;
		itemViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				editTextInputLayout.EditText.ApplyText(itemViewModel.Text);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Text")),
			(delegate
			{
				editTextInputLayout.SetError(itemViewModel.ErrorText, itemViewModel.Error);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "ErrorText", "Error" }))
		})).AutoDisposeOnDestroy(viewLifecycleOwner);
		itemViewModel.BindEvents(((TextView)editTextInputLayout.EditText).OnTextChanged((Action)delegate
		{
			itemViewModel.Text = editTextInputLayout.EditText.Text ?? "";
		})).AutoDisposeOnDestroy(viewLifecycleOwner);
	}
}
