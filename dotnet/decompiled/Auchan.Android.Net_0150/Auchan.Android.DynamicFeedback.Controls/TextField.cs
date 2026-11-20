using System;
using System.Collections.Generic;
using Android.Content;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.DynamicFeedback;
using Google.Android.Material.TextField;
using InputMask;

namespace Auchan.Android.DynamicFeedback.Controls;

public class TextField : ConstraintLayoutWidgetBase
{
	public TextField(Context context, FieldItemViewModel itemViewModel, ILifecycleOwner viewLifecycleOwner)
		: base(context)
	{
		View view = View.Inflate(context, 2131493193, this);
		TextInputLayout editTextInputLayout = view.RequireViewById<TextInputLayout>(2131298543);
		editTextInputLayout.Hint = itemViewModel.Hint;
		editTextInputLayout.EditText.SetMaxLength(itemViewModel.MaxLength);
		editTextInputLayout.EditText.ImeOptions = ImeAction.Next;
		if (itemViewModel.HasPhoneMask)
		{
			MaskedTextChangedListener.Companion.InstallOn(editTextInputLayout.EditText, itemViewModel.Mask, null);
		}
		itemViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				editTextInputLayout.SetError(itemViewModel.ErrorText, itemViewModel.Error);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "ErrorText", "Error" })),
			(delegate
			{
				editTextInputLayout.EditText.ApplyText(itemViewModel.Text);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Text"))
		})).AutoDisposeOnDestroy(viewLifecycleOwner);
		((TextView)editTextInputLayout.EditText).OnTextChanged((EventHandler<TextChangedEventArgs>)delegate
		{
			itemViewModel.Text = editTextInputLayout.EditText.Text ?? "";
		}).AutoDisposeOnDestroy(viewLifecycleOwner);
	}
}
