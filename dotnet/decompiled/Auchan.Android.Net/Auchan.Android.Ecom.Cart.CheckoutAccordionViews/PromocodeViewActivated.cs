using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Text;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Controls;
using Auchan.Android.Ecom.Cart.CheckoutAccordionViews.PromocodeView;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Controls.Accordion;
using Auchan.Common.Ecom.Cart.ViewModels;

namespace Auchan.Android.Ecom.Cart.CheckoutAccordionViews;

public class PromocodeViewActivated : ConstraintLayoutWidgetBase
{
	private TextView _titleText;

	private TextViewWithOk _textViewWithOk;

	private View _minusButton;

	private TextView _promocodeErrorTextView;

	private TextView _promocodeErrorLinkTextView;

	private View _promocodeErrorContainer;

	public TextViewWithOk TextViewWithOk => _textViewWithOk;

	public PromocodeViewActivated(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public PromocodeViewActivated(Context context)
		: base(context)
	{
		Initialize(context);
	}

	public PromocodeViewActivated(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize(context);
	}

	public PromocodeViewActivated(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context);
	}

	public PromocodeViewActivated(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context);
	}

	private void Initialize(Context context)
	{
		int resource = 2131493142;
		View view = View.Inflate(context, resource, this);
		_titleText = view.RequireViewById<TextView>(2131298659);
		_textViewWithOk = view.RequireViewById<TextViewWithOk>(2131298106);
		_minusButton = view.RequireViewById<View>(2131297275);
		_promocodeErrorContainer = view.RequireViewById<View>(2131298102);
		_promocodeErrorTextView = _promocodeErrorContainer.RequireViewById<TextView>(2131298104);
		_promocodeErrorLinkTextView = _promocodeErrorContainer.RequireViewById<TextView>(2131298103);
	}

	public void Setup(CheckoutViewModel viewModel, ILifecycleOwner lifecycleOwner)
	{
		_titleText.Text = viewModel.PromocodeTitle;
		_textViewWithOk.IsEnabled = true;
		_textViewWithOk.OkButton.Text = viewModel.PromocodeButtonOk;
		_textViewWithOk.CancelButton.Text = viewModel.PromocodeButtonCancel;
		viewModel.PromocodeFocusCommand.Where((Unit _) => viewModel.PromocodeState == AccordionElementState.Active).SafeSubscribe(delegate
		{
			FocusKeyboard();
		}, lifecycleOwner);
		viewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[11]
		{
			(delegate
			{
				_textViewWithOk.Input.ApplyText(viewModel.PromocodeValue);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PromocodeValue")),
			(delegate
			{
				_textViewWithOk.Hint = viewModel.PromocodeEditTextHint;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PromocodeEditTextHint")),
			(delegate
			{
				_textViewWithOk.IsError = viewModel.PromocodeError;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PromocodeError")),
			(delegate
			{
				_textViewWithOk.IsPromocodeEntered = viewModel.PromocodeEntered;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PromocodeEntered")),
			(delegate
			{
				_textViewWithOk.IsPromocodeInfoExists = !string.IsNullOrEmpty(viewModel.PromocodeInfo);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PromocodeInfo")),
			(delegate
			{
				_textViewWithOk.OkButton.Visibility = (viewModel.PromocodeValue.Length > 0 && !viewModel.PromocodeEntered).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "PromocodeValue", "PromocodeEntered" })),
			(delegate
			{
				_textViewWithOk.ClearButton.Visibility = (viewModel.PromocodeValue.Length > 0 && !viewModel.PromocodeEntered).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "PromocodeValue", "PromocodeEntered" })),
			(delegate
			{
				_textViewWithOk.CancelButton.Visibility = viewModel.PromocodeEntered.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PromocodeEntered")),
			(delegate
			{
				_promocodeErrorContainer.Visibility = viewModel.PromocodeError.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PromocodeError")),
			(delegate
			{
				_promocodeErrorTextView.Text = viewModel.PromocodeErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PromocodeErrorMessage")),
			(delegate
			{
				_promocodeErrorLinkTextView.TextFormatted = HtmlCompat.FromHtml(viewModel.PromocodeErrorLink, 0);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PromocodeErrorLink"))
		})).AutoDisposeOnDestroy(lifecycleOwner);
		viewModel.BindEvents(((TextView)_textViewWithOk.Input).OnTextChanged((Action)delegate
		{
			viewModel.PromocodeValue = _textViewWithOk.Input.Text ?? "";
		}), _textViewWithOk.OkButton.OnClick(viewModel.OnPromocodeOkClicked), _minusButton.OnClick(viewModel.OnPromocodeRemoveClicked), _textViewWithOk.OkInfoView.OnClick((Action)delegate
		{
			ShowPopupAsync(viewModel).SafeFireAndForget((Action<Exception>)null, false);
		}), _promocodeErrorContainer.OnClick((Action)delegate
		{
			viewModel.PromocodeErrorCommand.Trigger();
		}), ((View)_textViewWithOk.CancelButton).OnClick((Action)delegate
		{
			viewModel.PromocodeCancelCommand.Trigger();
		})).AutoDisposeOnDestroy(lifecycleOwner);
	}

	private void FocusKeyboard()
	{
		_textViewWithOk.Input.ForceFocusKeyboard();
	}

	private async Task ShowPopupAsync(CheckoutViewModel viewModel)
	{
		if (FindFocus() is EditText editText)
		{
			editText.ClearFocus();
			editText.HideKeyboard(editText.Context);
			await Task.Delay(500);
		}
		PromocodeInfoPopup.Show(viewModel, _textViewWithOk.OkInfoView);
	}
}
