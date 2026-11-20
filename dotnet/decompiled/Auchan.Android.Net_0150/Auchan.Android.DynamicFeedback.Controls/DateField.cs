using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Text;
using Android.Text.Method;
using Android.Views;
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

public class DateField : ConstraintLayoutWidgetBase
{
	private readonly FieldItemViewModel _itemViewModel;

	private readonly ILifecycleOwner _viewLifecycleOwner;

	private DynamicFeedbackViewModel _dynamicFeedbackViewModel;

	public DateField(Context context, DynamicFeedbackViewModel dynamicFeedbackViewModel, FieldItemViewModel itemViewModel, ILifecycleOwner viewLifecycleOwner)
		: base(context)
	{
		_dynamicFeedbackViewModel = dynamicFeedbackViewModel;
		_itemViewModel = itemViewModel;
		_viewLifecycleOwner = viewLifecycleOwner;
		Initialize(context);
	}

	private void Initialize(Context context)
	{
		int resource = ((_itemViewModel.FieldType == FieldType.DateTime) ? 2131493148 : 2131493147);
		View view = View.Inflate(context, resource, this);
		TextInputLayout textInputLayout = view.RequireViewById<TextInputLayout>(2131297921);
		EditText editTextPlaceholder = textInputLayout.RequireViewById<EditText>(2131297920);
		TextInputLayout editTextInputLayout = view.RequireViewById<TextInputLayout>(2131297372);
		EditText editText = editTextInputLayout.RequireViewById<EditText>(2131297041);
		SetEditTextMask(editText);
		editTextPlaceholder.Text = ((_itemViewModel.FieldType == FieldType.DateTime) ? _dynamicFeedbackViewModel.DateTimePlaceholder : _dynamicFeedbackViewModel.DatePlaceholder);
		editTextInputLayout.Hint = _itemViewModel.Hint;
		editTextInputLayout.BoxBackgroundColor = textInputLayout.BoxBackgroundColor;
		Color transparentTextColor = new Color(0, 0, 0, 0);
		Color textColor = new Color(139, 145, 152, 255);
		editTextPlaceholder.SetTextColor(transparentTextColor);
		_itemViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				editText.ApplyText(_itemViewModel.Text);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Text")),
			(delegate
			{
				editTextInputLayout.SetError(_itemViewModel.ErrorText, _itemViewModel.Error);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "ErrorText", "Error" }))
		})).AutoDisposeOnDestroy(_viewLifecycleOwner);
		_itemViewModel.BindEvents(((TextView)editText).OnTextChanged((Action)delegate
		{
			_itemViewModel.Text = editText.Text ?? "";
			UpdatePlaceholderVisibility();
		}), ((View)editText).OnFocusChange((EventHandler<FocusChangeEventArgs>)delegate
		{
			UpdatePlaceholderVisibility();
		})).AutoDisposeOnDestroy(_viewLifecycleOwner);
		void UpdatePlaceholderVisibility()
		{
			editTextPlaceholder.SetTextColor((string.IsNullOrEmpty(editText.Text) && editText.IsFocused) ? textColor : transparentTextColor);
		}
	}

	private void SetEditTextMask(EditText editText)
	{
		editText.InputType = InputTypes.ClassDatetime;
		editText.KeyListener = DigitsKeyListener.GetInstance("0123456789 .,:");
		MaskedTextChangedListener.Companion.InstallOn(editText, _itemViewModel.Mask, null);
	}
}
