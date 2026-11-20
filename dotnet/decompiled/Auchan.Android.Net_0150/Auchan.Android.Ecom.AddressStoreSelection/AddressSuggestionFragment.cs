using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Extensions;
using Auchan.Common.Addresses;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.AddressStoreSelection.ViewModels;
using Auchan.Common.Extensions;
using Google.Android.Material.Card;
using Google.Android.Material.TextField;

namespace Auchan.Android.Ecom.AddressStoreSelection;

internal class AddressSuggestionFragment : BaseBottomSheetDialogFragment<AddressSuggestionViewModel>
{
	private sealed class Controls
	{
		public MaterialCardView AddressOutline { get; } = view.RequireViewById<MaterialCardView>(2131296392);

		public TextInputLayout AddressInputLayout { get; } = view.RequireViewById<TextInputLayout>(2131296401);

		public TextInputEditText AddressInput { get; } = view.RequireViewById<TextInputEditText>(2131296400);

		public RecyclerView AddressSuggestionList { get; } = view.RequireViewById<RecyclerView>(2131296405);

		public TextView SaveButton { get; } = view.RequireViewById<TextView>(2131298287);

		public View Progress { get; } = view.RequireViewById<View>(2131298077);

		public TextView ErrorText { get; } = view.RequireViewById<TextView>(2131297113);

		public Controls(View view)
		{
		}
	}

	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493441;

	public AddressSuggestionFragment(Func<BrokerToken, AddressSuggestionViewModel> newViewModel)
		: base((Func<Fragment, AddressSuggestionViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override View? OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
	{
		View? view = base.OnCreateView(inflater, container, savedInstanceState);
		view.SetMinimumHeight((int)((double)base.Resources.DisplayMetrics.HeightPixels * 0.9));
		return view;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Window? window = Dialog?.Window ?? throw new InvalidOperationException("no window");
		Controls controls = new Controls(view);
		window.HideKeyboardOnTouchOutside(controls.AddressInput, ViewLifecycleOwner, controls.AddressSuggestionList);
		view.PostDelayed(delegate
		{
			controls.AddressInput.ForceFocusKeyboard();
		}, 500L);
		ObservableRecyclerAdapter<Suggestion, CachingViewHolder> adapter = new ObservableRecyclerAdapter<Suggestion, CachingViewHolder>
		{
			CellLayoutId = 2131493211,
			BindViewHolderDelegate = OnBindAddressSuggestion,
			DataSource = base.ViewModel.Suggestions
		};
		controls.AddressSuggestionList.SetAdapter(adapter);
		controls.AddressInputLayout.Hint = base.ViewModel.HintText;
		controls.SaveButton.Text = base.ViewModel.SaveText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[5]
		{
			(delegate
			{
				OnAddressOrValidationChanged(controls, base.ViewModel.AddressValidation, base.ViewModel.Address);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "AddressValidation", "Address" })),
			(delegate
			{
				controls.SaveButton.Enabled = base.ViewModel.SaveEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SaveEnabled")),
			(delegate
			{
				if (base.ViewModel.SaveEnabled)
				{
					controls.AddressInput.ForceUnfocusKeyboard();
				}
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SaveEnabled")),
			(delegate
			{
				controls.Progress.Visibility = (base.ViewModel.State == VisualState.InProgress).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				controls.AddressInput.ApplyText(base.ViewModel.Address);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Address"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((TextView)controls.AddressInput).OnTextChanged((Action)delegate
		{
			base.ViewModel.Address = controls?.AddressInput?.Text ?? "";
		}), controls.SaveButton.OnClick(base.ViewModel.OnSaveClick)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}

	private void OnAddressOrValidationChanged(Controls controls, string? addressValidation, string address)
	{
		controls.AddressInputLayout.EndIconVisible = base.ViewModel.IsEndIconVisible;
		controls.AddressInputLayout.EndIconDrawable = Context.GetDrawable(base.ViewModel.IsHaveAddressValidationError ? 2131231383 : 2131231122);
		controls.AddressInputLayout.EndIconMode = (base.ViewModel.IsHaveAddressValidationError ? (-1) : 2);
		controls.ErrorText.Text = addressValidation;
		controls.ErrorText.Visibility = base.ViewModel.IsHaveAddressValidationError.ToVisibility();
		controls.AddressInputLayout.HintTextColor = ContextCompat.GetColorStateList(Context, base.ViewModel.IsHaveAddressValidationError ? 2131100555 : 2131100600);
		controls.AddressInputLayout.SetEndIconTintList(base.ViewModel.IsHaveAddressValidationError ? ContextCompat.GetColorStateList(Context, 2131100555) : null);
		controls.AddressOutline.SetStrokeColor(ContextCompat.GetColorStateList(Context, base.ViewModel.IsHaveAddressValidationError ? 2131100555 : 2131099847));
	}

	private void OnBindAddressSuggestion(CachingViewHolder holder, Suggestion model, int position, CompositeDisposable disposable)
	{
		((TextView)holder.ItemView).Text = model.Address?.AddressLine;
		holder.ItemView.RxClick().Subscribe(delegate
		{
			base.ViewModel.OnAddressSuggestionSelected(position);
		}).AddTo(disposable);
	}
}
