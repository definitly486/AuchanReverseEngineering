using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Base.Widgets;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Ecom.Address;
using DryIoc;
using EBind;
using Google.Android.Material.Button;
using Google.Android.Material.TextField;

namespace Auchan.Android.Ecom.AddressStoreSelection;

internal class AddressDetailsFragment : BaseDialogFragment<AddressDetailsViewModel>
{
	private readonly TaskCompletionSource _tcs = new TaskCompletionSource();

	private MaterialButton? _saveButton;

	public override int Theme => 2131951957;

	protected override int LayoutId => 2131492980;

	public AddressDetailsFragment(Func<BrokerToken, AddressDetailsViewModel> newViewModel)
		: base((Func<AndroidX.Fragment.App.Fragment, AddressDetailsViewModel>)((AndroidX.Fragment.App.Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298679);
		View view2 = view.RequireViewById<View>(2131296490);
		RadioButtonSelector nameSelector = view.RequireViewById<RadioButtonSelector>(2131297638);
		view.RequireViewById<NestedScrollView>(2131298301);
		TextView textView2 = view.RequireViewById<TextView>(2131296398);
		TextView textView3 = view.RequireViewById<TextView>(2131296406);
		TextInputLayout nameLayout = view.RequireViewById<TextInputLayout>(2131297634);
		OutlinedErrorEditText nameText = view.RequireViewById<OutlinedErrorEditText>(2131297636);
		TextInputLayout textInputLayout = view.RequireViewById<TextInputLayout>(2131297972);
		OutlinedErrorEditText porchText = view.RequireViewById<OutlinedErrorEditText>(2131297973);
		TextInputLayout textInputLayout2 = view.RequireViewById<TextInputLayout>(2131297203);
		OutlinedErrorEditText floorText = view.RequireViewById<OutlinedErrorEditText>(2131297204);
		TextInputLayout textInputLayout3 = view.RequireViewById<TextInputLayout>(2131297194);
		OutlinedErrorEditText flatText = view.RequireViewById<OutlinedErrorEditText>(2131297195);
		TextInputLayout textInputLayout4 = view.RequireViewById<TextInputLayout>(2131297376);
		OutlinedErrorEditText intercomText = view.RequireViewById<OutlinedErrorEditText>(2131297377);
		TextInputLayout commentLayout = view.RequireViewById<TextInputLayout>(2131296817);
		OutlinedErrorEditText commentText = view.RequireViewById<OutlinedErrorEditText>(2131296825);
		TextView commentExpandedHint = view.RequireViewById<TextView>(2131296815);
		TextView commentCounter = view.RequireViewById<TextView>(2131296811);
		MaterialButton fillLaterButton = view.RequireViewById<MaterialButton>(2131297158);
		_saveButton = view.RequireViewById<MaterialButton>(2131298284);
		MaterialButton deleteButton = view.RequireViewById<MaterialButton>(2131296924);
		textView.Text = base.ViewModel.Title;
		nameLayout.Hint = base.ViewModel.AddressNameHint;
		textInputLayout.Hint = base.ViewModel.PorchHint;
		textInputLayout2.Hint = base.ViewModel.FloorHint;
		textInputLayout3.Hint = base.ViewModel.FlatHint;
		textInputLayout4.Hint = base.ViewModel.IntercomHint;
		commentExpandedHint.Text = base.ViewModel.CommentHint;
		textView2.Text = base.ViewModel.StreetHouseText;
		textView3.Text = base.ViewModel.StreetHouseAddress;
		fillLaterButton.Text = base.ViewModel.FillLaterButtonText;
		_saveButton.Text = base.ViewModel.SaveButtonText;
		deleteButton.Text = base.ViewModel.DeleteButtonText;
		UpdateCommentLayout(commentLayout, commentText, commentExpandedHint);
		nameSelector.SetButtons(base.ViewModel.NameButtons, ViewLifecycleOwner);
		InputFilterLengthFilter inputFilterLengthFilter = new InputFilterLengthFilter(base.ViewModel.MaxOtherFieldLength);
		InputFilterLengthFilter inputFilterLengthFilter2 = new InputFilterLengthFilter(base.ViewModel.MaxCommentLength);
		InputFilterLengthFilter inputFilterLengthFilter3 = new InputFilterLengthFilter(base.ViewModel.MaxNameLength);
		OutlinedErrorEditText outlinedErrorEditText = nameText;
		IInputFilter[] filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter3 };
		outlinedErrorEditText.SetFilters(filters);
		OutlinedErrorEditText outlinedErrorEditText2 = porchText;
		filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter };
		outlinedErrorEditText2.SetFilters(filters);
		OutlinedErrorEditText outlinedErrorEditText3 = floorText;
		filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter };
		outlinedErrorEditText3.SetFilters(filters);
		OutlinedErrorEditText outlinedErrorEditText4 = flatText;
		filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter };
		outlinedErrorEditText4.SetFilters(filters);
		OutlinedErrorEditText outlinedErrorEditText5 = intercomText;
		filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter };
		outlinedErrorEditText5.SetFilters(filters);
		OutlinedErrorEditText outlinedErrorEditText6 = commentText;
		filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter2 };
		outlinedErrorEditText6.SetFilters(filters);
		Dialog.Window.HideKeyboardOnTouchOutside(ViewLifecycleOwner, nameText, porchText, floorText, flatText, intercomText, commentText);
		SetNextButtonAction(nameText, porchText, floorText, flatText, intercomText, commentText);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[14]
		{
			(delegate
			{
				nameSelector.SelectButton(base.ViewModel.SelectedNameIndex);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedNameIndex")),
			(delegate
			{
				nameText.ApplyText(base.ViewModel.EnteredName);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EnteredName")),
			(delegate
			{
				porchText.ApplyText(base.ViewModel.Porch);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Porch")),
			(delegate
			{
				floorText.ApplyText(base.ViewModel.Floor);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Floor")),
			(delegate
			{
				flatText.ApplyText(base.ViewModel.Flat);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Flat")),
			(delegate
			{
				intercomText.ApplyText(base.ViewModel.Intercom);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Intercom")),
			(delegate
			{
				commentText.ApplyText(base.ViewModel.Comment);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Comment")),
			(delegate
			{
				commentCounter.Text = base.ViewModel.CommentLength;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Comment")),
			(delegate
			{
				UpdateCommentLayout(commentLayout, commentText, commentExpandedHint);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Comment")),
			(delegate
			{
				nameLayout.Visibility = base.ViewModel.NameFieldVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NameFieldVisible")),
			(delegate
			{
				SetSaveButtonState(base.ViewModel.SaveButtonActive);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SaveButtonActive")),
			(delegate
			{
				_saveButton.Visibility = base.ViewModel.SaveButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SaveButtonVisible")),
			(delegate
			{
				fillLaterButton.Visibility = base.ViewModel.FillLaterButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("FillLaterButtonVisible")),
			(delegate
			{
				deleteButton.Visibility = base.ViewModel.DeleteButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeleteButtonVisible"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((TextView)nameText).OnTextChanged((Action)delegate
		{
			base.ViewModel.EnteredName = nameText.Text ?? "";
		}), ((TextView)porchText).OnTextChanged((Action)delegate
		{
			base.ViewModel.Porch = porchText.Text ?? "";
		}), ((TextView)floorText).OnTextChanged((Action)delegate
		{
			base.ViewModel.Floor = floorText.Text ?? "";
		}), ((TextView)flatText).OnTextChanged((Action)delegate
		{
			base.ViewModel.Flat = flatText.Text ?? "";
		}), ((TextView)intercomText).OnTextChanged((Action)delegate
		{
			base.ViewModel.Intercom = intercomText.Text ?? "";
		}), ((TextView)commentText).OnTextChanged((Action)delegate
		{
			base.ViewModel.Comment = commentText.Text ?? "";
		}), ((View)commentText).OnFocusChange((Action)delegate
		{
			if (commentText.HasFocus)
			{
				commentText.ForceFocusKeyboard();
			}
			UpdateCommentLayout(commentLayout, commentText, commentExpandedHint);
		}), ((View)_saveButton).OnClick((Action)delegate
		{
			base.ViewModel.SaveCommand.Trigger();
		}), ((View)fillLaterButton).OnClick((Action)delegate
		{
			base.ViewModel.Close();
		}), ((View)deleteButton).OnClick((Action)delegate
		{
			base.ViewModel.DeleteItemCommand.Trigger();
		}), view2.OnClick((Action)delegate
		{
			base.ViewModel.CloseCommand.Trigger(base.ViewModel.IsNew);
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		nameSelector.SelectionChanged += new DisposableDelegate<Action>(delegate
		{
			base.ViewModel.SelectedNameIndex = nameSelector.SelectedIndex;
		}, delegate(Action d)
		{
			nameSelector.SelectionChanged -= d;
		});
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenAskToRemoveAddressPopupCommand.SafeSubscribe(delegate(BrokerToken parameter)
		{
			AskToRemoveAddressPopupFragment askToRemoveAddressPopupFragment = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<FragmentFactory>().Instantiate<AskToRemoveAddressPopupFragment>();
			askToRemoveAddressPopupFragment.Arguments = parameter.ToNavBundle();
			askToRemoveAddressPopupFragment.Show(base.ChildFragmentManager, null);
		}, ViewLifecycleOwner);
	}

	private void SetNextButtonAction(OutlinedErrorEditText nameText, OutlinedErrorEditText porchText, OutlinedErrorEditText floorText, OutlinedErrorEditText flatText, OutlinedErrorEditText intercomText, OutlinedErrorEditText commentText)
	{
		nameText.EditorAction += new DisposableDelegate<EventHandler<TextView.EditorActionEventArgs>>(delegate(object? s, TextView.EditorActionEventArgs e)
		{
			if (e.ActionId == ImeAction.Next)
			{
				porchText.ForceFocusKeyboard();
			}
		}, delegate(EventHandler<TextView.EditorActionEventArgs> h)
		{
			porchText.EditorAction -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		porchText.EditorAction += new DisposableDelegate<EventHandler<TextView.EditorActionEventArgs>>(delegate(object? s, TextView.EditorActionEventArgs e)
		{
			if (e.ActionId == ImeAction.Next)
			{
				floorText.ForceFocusKeyboard();
			}
		}, delegate(EventHandler<TextView.EditorActionEventArgs> h)
		{
			porchText.EditorAction -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		floorText.EditorAction += new DisposableDelegate<EventHandler<TextView.EditorActionEventArgs>>(delegate(object? s, TextView.EditorActionEventArgs e)
		{
			if (e.ActionId == ImeAction.Next)
			{
				flatText.ForceFocusKeyboard();
			}
		}, delegate(EventHandler<TextView.EditorActionEventArgs> h)
		{
			floorText.EditorAction -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		flatText.EditorAction += new DisposableDelegate<EventHandler<TextView.EditorActionEventArgs>>(delegate(object? s, TextView.EditorActionEventArgs e)
		{
			if (e.ActionId == ImeAction.Next)
			{
				intercomText.ForceFocusKeyboard();
			}
		}, delegate(EventHandler<TextView.EditorActionEventArgs> h)
		{
			flatText.EditorAction -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		intercomText.EditorAction += new DisposableDelegate<EventHandler<TextView.EditorActionEventArgs>>(delegate(object? s, TextView.EditorActionEventArgs e)
		{
			if (e.ActionId == ImeAction.Next)
			{
				commentText.ForceFocusKeyboard();
			}
		}, delegate(EventHandler<TextView.EditorActionEventArgs> h)
		{
			intercomText.EditorAction -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void UpdateCommentLayout(TextInputLayout commentLayout, OutlinedErrorEditText commentText, TextView commentExpandedHint)
	{
		commentLayout.HintEnabled = commentText.HasFocus || !string.IsNullOrEmpty(commentText.Text);
		commentText.Hint = " ";
		commentLayout.Hint = (commentLayout.HintEnabled ? base.ViewModel.CommentHint : " ");
		commentExpandedHint.Visibility = (!commentText.HasFocus && string.IsNullOrEmpty(commentText.Text)).ToVisibility();
	}

	public override Dialog OnCreateDialog(Bundle? savedInstanceState)
	{
		Dialog dialog = base.OnCreateDialog(savedInstanceState);
		Window? window = dialog.Window;
		if (window != null)
		{
			window.SetSoftInputMode(SoftInput.AdjustPan);
			return dialog;
		}
		return dialog;
	}

	private void SetSaveButtonState(bool enabled)
	{
		if (_saveButton != null)
		{
			_saveButton.Enabled = enabled;
			_saveButton.SetBackgroundColor(enabled ? new Color(ContextCompat.GetColor(RequireContext(), 2131100611)) : new Color(ContextCompat.GetColor(RequireContext(), 2131100615)));
		}
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		_tcs.TrySetResult();
	}
}
