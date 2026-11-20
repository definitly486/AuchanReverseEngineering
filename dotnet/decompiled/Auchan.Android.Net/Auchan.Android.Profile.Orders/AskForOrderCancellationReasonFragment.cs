using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Orders;
using Auchan.Common.Profile.Orders.Dto;
using Google.Android.Material.RadioButton;
using Google.Android.Material.TextField;

namespace Auchan.Android.Profile.Orders;

internal class AskForOrderCancellationReasonFragment : BaseBottomSheetDialogFragment<AskForOrderCancellationReasonViewModel>
{
	private readonly TaskCompletionSource<AskForOrderCancellationReasonViewModel.Result> _tcs = new TaskCompletionSource<AskForOrderCancellationReasonViewModel.Result>();

	private int? _previousViewBottom;

	protected override int LayoutId => 2131493448;

	public override int Theme => 2131951914;

	public AskForOrderCancellationReasonFragment(Func<PossibleOrderCancellationReasonsDto, AskForOrderCancellationReasonViewModel> newViewModel)
		: base((Func<Fragment, AskForOrderCancellationReasonViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.NavParam<PossibleOrderCancellationReasonsDto>())))
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Dialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
		TextView textView = view.RequireViewById<TextView>(2131297266);
		View view2 = view.RequireViewById<View>(2131296795);
		Button proceedButton = view.RequireViewById<Button>(2131297997);
		TextInputLayout reasonDescriptionTextInputLayout = view.RequireViewById<TextInputLayout>(2131298156);
		TextInputEditText textInputEditText = reasonDescriptionTextInputLayout.RequireViewById<TextInputEditText>(2131296825);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298157);
		recyclerView.AddItemDecoration(new VerticalSpaceItemDecoration(-6));
		recyclerView.SetAdapter(new ObservableRecyclerAdapter<SelectionItemViewModel<CancellationReasonDto>, CachingViewHolder>
		{
			CellLayoutId = 2131493266,
			DataSource = base.ViewModel.Items,
			BindViewHolderDelegate = OnBindItem,
			ClickCallback = OnItemSelected
		});
		textView.Text = base.ViewModel.ScreenTitle;
		proceedButton.Text = base.ViewModel.ProceedButtonText;
		reasonDescriptionTextInputLayout.Hint = base.ViewModel.TextEditHint;
		EditText? editText = reasonDescriptionTextInputLayout.EditText;
		IInputFilter[] filters = new InputFilterLengthFilter[1]
		{
			new InputFilterLengthFilter(base.ViewModel.MaxTextLength)
		};
		editText.SetFilters(filters);
		textInputEditText.ImeOptions = ImeAction.Done;
		textInputEditText.SetRawInputType(InputTypes.ClassText);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			proceedButton.Enabled = base.ViewModel.IsCanProceed;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCanProceed")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(view2.OnClick((Action)delegate
		{
			OnAnswer(null);
		}), ((View)proceedButton).OnClick((Action)delegate
		{
			OnAnswer(base.ViewModel.GetResult());
		}), base.Activity.Window.DecorView.ViewTreeObserver.OnGlobalLayout(OnGlobalLayout), ((TextView)reasonDescriptionTextInputLayout.EditText).OnTextChanged((EventHandler<TextChangedEventArgs>)delegate
		{
			base.ViewModel.ReasonDescription = reasonDescriptionTextInputLayout.EditText.Text;
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OnItemSelectedCommand.SafeSubscribe(delegate
		{
			ShowKeyboardIfNeed();
		}, ViewLifecycleOwner);
	}

	private void OnGlobalLayout(object sender, EventArgs e)
	{
		Rect rect = new Rect();
		View.GetWindowVisibleDisplayFrame(rect);
		if (_previousViewBottom.HasValue)
		{
			if (_previousViewBottom.Value != rect.Bottom)
			{
				View.RequestLayout();
			}
			if (_previousViewBottom.Value < rect.Bottom)
			{
				View.RequestFocus();
			}
			else if (_previousViewBottom.Value > rect.Bottom)
			{
				RecyclerView recyclerView = View.RequireViewById<RecyclerView>(2131298157);
				int selectedIndex = base.ViewModel.SelectedIndex;
				LinearLayoutManager linearLayoutManager = (LinearLayoutManager)recyclerView.GetLayoutManager();
				if (linearLayoutManager.FindFirstVisibleItemPosition() >= selectedIndex || selectedIndex >= linearLayoutManager.FindLastVisibleItemPosition())
				{
					linearLayoutManager.ScrollToPosition(selectedIndex);
				}
			}
		}
		_previousViewBottom = rect.Bottom;
	}

	private void ShowKeyboardIfNeed()
	{
		SelectionItemViewModel<CancellationReasonDto>? selectedItem = base.ViewModel.SelectedItem;
		if (selectedItem != null && selectedItem.Item.IsCommentaryObligatory)
		{
			TextInputEditText textInputEditText = View.RequireViewById<TextInputEditText>(2131296825);
			textInputEditText.RequestFocus();
			InputMethodManager.FromContext(textInputEditText.Context).ShowSoftInput(textInputEditText, ShowFlags.Implicit);
		}
	}

	private static void OnBindItem(CachingViewHolder holder, SelectionItemViewModel<CancellationReasonDto> item, int position, CompositeDisposable disposable)
	{
		MaterialRadioButton element = (MaterialRadioButton)holder.ItemView;
		element.Text = item.Item.Reason;
		item.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			element.Checked = item.Selected;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
	}

	private void OnItemSelected(CachingViewHolder cachingViewHolder, SelectionItemViewModel<CancellationReasonDto> listPickerItemViewModel, int position)
	{
		base.ViewModel.OnItemSelected(position);
	}

	public Task<AskForOrderCancellationReasonViewModel.Result?> Execute()
	{
		return _tcs.Task;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		_tcs.TrySetResult(null);
	}

	private void OnAnswer(AskForOrderCancellationReasonViewModel.Result result)
	{
		_tcs.TrySetResult(result);
		Dismiss();
	}
}
