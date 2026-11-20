using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Content.Resources;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.DynamicFeedback;
using Auchan.Android.Extensions;
using Auchan.Android.SupportChat;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;
using Auchan.Common.Reviews;
using EBind;
using Google.Android.Material.TextField;
using Google.Flexbox;
using Java.Interop;
using Java.Util;
using Microsoft.Maui.ApplicationModel;
using VisibilitySwitch;

namespace Auchan.Android.Reviews;

internal class AddReviewFragment : BaseBottomSheetDialogFragment<AddReviewViewModel>, View.IOnTouchListener, IJavaObject, IDisposable, IJavaPeerable, DatePickerDialog.IOnDateSetListener, TextView.IOnEditorActionListener
{
	private const int CommentFieldKeyboardGapDp = 72;

	private PhotoSelectionView _photoSelectionView;

	private AppCompatButton _sendReviewButton;

	private RecyclerView _triggerWordsRecycler;

	private ObservableRecyclerAdapter<AddReviewViewModel.TriggerWordItem, CachingViewHolder> _triggerWordsAdapter;

	private OutlinedErrorEditText _manufacturerEditText;

	private OutlinedErrorEditText _productionDateEditText;

	private TextInputLayout _productionDateLayout;

	private NestedScrollView _scrollView;

	private OutlinedErrorEditText _commentEditText;

	private ValueAnimator _commentProgressColorAnimator;

	private int? _currentProgressColor;

	private int? _currentTrackColor;

	private int? _currentTextColor;

	private int? _previousViewBottom;

	protected override bool FullScreen => true;

	public override int Theme => 2131951916;

	protected override int LayoutId => 2131492978;

	public AddReviewFragment(Func<BrokerToken, AddReviewViewModel> newViewModel)
		: base((Func<AndroidX.Fragment.App.Fragment, AddReviewViewModel>)((AndroidX.Fragment.App.Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnDestroyView()
	{
		_commentProgressColorAnimator?.Cancel();
		_commentProgressColorAnimator?.Dispose();
		_commentProgressColorAnimator = null;
		base.OnDestroyView();
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Cancelable = false;
		base.Behavior.Draggable = false;
		base.Behavior.Hideable = false;
		base.Behavior.SkipCollapsed = true;
		Dialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
		_scrollView = view.RequireViewById<NestedScrollView>(2131298257);
		TextView textView = _scrollView.RequireViewById<TextView>(2131298296);
		ImageView imageView = _scrollView.RequireViewById<ImageView>(2131296791);
		ImageView imageView2 = _scrollView.RequireViewById<ImageView>(2131297999);
		TextView textView2 = _scrollView.RequireViewById<TextView>(2131298001);
		TextView textView3 = _scrollView.RequireViewById<TextView>(2131298137);
		RatingView ratingView = _scrollView.RequireViewById<RatingView>(2131298148);
		TextView triggerWordsTitleTextView = _scrollView.RequireViewById<TextView>(2131298771);
		_triggerWordsRecycler = _scrollView.RequireViewById<RecyclerView>(2131298770);
		TextInputLayout commentLayout = _scrollView.RequireViewById<TextInputLayout>(2131296818);
		_commentEditText = commentLayout.RequireViewById<OutlinedErrorEditText>(2131296812);
		LinearLayout additionalFieldsContainer = _scrollView.RequireViewById<LinearLayout>(2131296372);
		TextInputLayout manufacturerLayout = _scrollView.RequireViewById<TextInputLayout>(2131297513);
		_manufacturerEditText = manufacturerLayout.RequireViewById<OutlinedErrorEditText>(2131297511);
		TextView manufacturerHelper = _scrollView.RequireViewById<TextView>(2131297512);
		_productionDateLayout = _scrollView.RequireViewById<TextInputLayout>(2131298031);
		_productionDateEditText = _productionDateLayout.RequireViewById<OutlinedErrorEditText>(2131298030);
		TextView productionHelper = _scrollView.RequireViewById<TextView>(2131298032);
		TextView textView4 = _scrollView.RequireViewById<TextView>(2131296346);
		_photoSelectionView = _scrollView.RequireViewById<PhotoSelectionView>(2131297888);
		TextView photoUploadErrorText = _scrollView.RequireViewById<TextView>(2131297889);
		SnackView snackView = _scrollView.RequireViewById<SnackView>(2131296758);
		LinearLayout linearLayout = _scrollView.RequireViewById<LinearLayout>(2131296345);
		TextView textView5 = _scrollView.RequireViewById<TextView>(2131297325);
		ConstraintLayout commentLengthWarning = view.RequireViewById<ConstraintLayout>(2131296819);
		TextView commentLengthWarningText = commentLengthWarning.RequireViewById<TextView>(2131296821);
		ProgressBar commentLengthWarningProgress = commentLengthWarning.RequireViewById<ProgressBar>(2131296820);
		TextView textView6 = _scrollView.RequireViewById<TextView>(2131298265);
		_sendReviewButton = _scrollView.RequireViewById<AppCompatButton>(2131298349);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		DatePickerDialog datePicker = CreateDatePicker();
		_triggerWordsRecycler.SetLayoutManager(new FlexboxLayoutManager(Context));
		_triggerWordsRecycler.AddItemDecoration(new GridSpacesItemDecoration2(8, 8));
		_triggerWordsRecycler.NestedScrollingEnabled = false;
		_triggerWordsAdapter = new ObservableRecyclerAdapter<AddReviewViewModel.TriggerWordItem, CachingViewHolder>
		{
			CellLayoutId = 2131493321,
			DataSource = base.ViewModel.TriggerWords,
			BindViewHolderDelegate = BindTriggerWord
		};
		_triggerWordsRecycler.SetAdapter(_triggerWordsAdapter);
		textView.Text = base.ViewModel.Title;
		imageView2.FromUrl(base.ViewModel.ProductImageUrl);
		textView2.Text = base.ViewModel.ProductName;
		textView3.Text = base.ViewModel.RateProductText;
		ratingView.Setup(delegate(int starIndex)
		{
			base.ViewModel.Rating = starIndex + 1;
		}, ViewLifecycleOwner, 40f, 4f, 5, base.ViewModel.Rating);
		textView4.Text = base.ViewModel.AddFileText;
		textView5.Text = base.ViewModel.LimitationsWarningText;
		commentLengthWarningText.Text = base.ViewModel.LengthInformerText;
		InputFilterLengthFilter inputFilterLengthFilter = new InputFilterLengthFilter(base.ViewModel.MaxCommentLength);
		_commentEditText.SetFilters(new IInputFilter[1] { inputFilterLengthFilter });
		UpdateCommentProgressWarning(commentLengthWarningText, commentLengthWarningProgress);
		textView6.AddLinkedText(base.ViewModel.ReviewRulesLinkedText, new Color(ResourcesCompat.GetColor(base.Activity.Resources, 2131099859, base.Activity.Theme)), underlineLinks: false);
		TextViewCompat.SetTextAppearance(snackView.TextView, 2131952190);
		snackView.AddLinkedText(base.ViewModel.ChatBotText, new Color(ResourcesCompat.GetColor(base.Activity.Resources, 2131100604, base.Activity.Theme)));
		_sendReviewButton.Text = base.ViewModel.SendReviewButtonText;
		base.ViewModel.FileResults.SafeSubscribeToCollectionChanged(delegate
		{
			RenderSelectedPhotos();
		}, ViewLifecycleOwner);
		base.ViewModel.ImageLoadFailedStubs.SafeSubscribeToCollectionChanged(delegate
		{
			RenderSelectedPhotos();
		}, ViewLifecycleOwner);
		RenderSelectedPhotos();
		_manufacturerEditText.SetOnEditorActionListener(this);
		_productionDateEditText.ShowSoftInputOnFocus = false;
		VisibilitySwitch<VisualState> viewSwitch = new VisibilitySwitch<VisualState>(base.ViewModel.State)
		{
			{
				VisualState.Default,
				_scrollView
			},
			{
				VisualState.InProgress,
				frameLayout
			},
			VisualState.Error
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[21]
		{
			(delegate
			{
				commentLayout.Hint = base.ViewModel.CommentText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CommentText")),
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				triggerWordsTitleTextView.Text = base.ViewModel.TriggerWordsTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TriggerWordsTitle")),
			(delegate
			{
				triggerWordsTitleTextView.Visibility = base.ViewModel.ShowTriggerWords.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ShowTriggerWords")),
			(delegate
			{
				_triggerWordsRecycler.Visibility = base.ViewModel.ShowTriggerWords.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ShowTriggerWords")),
			(delegate
			{
				RenderTriggerWords();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TriggerWords")),
			(delegate
			{
				_commentEditText.ApplyText(base.ViewModel.Comment);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Comment")),
			(delegate
			{
				_photoSelectionView.Visibility = base.ViewModel.HasFileResults.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasFileResults")),
			(delegate
			{
				photoUploadErrorText.Text = base.ViewModel.PhotoUploadErrorText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PhotoUploadErrorText")),
			(delegate
			{
				photoUploadErrorText.Visibility = base.ViewModel.ShowPhotoUploadError.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ShowPhotoUploadError")),
			(delegate
			{
				commentLengthWarning.Visibility = base.ViewModel.ShowCommentProgressWarning.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ShowCommentProgressWarning")),
			(delegate
			{
				commentLengthWarningText.Text = base.ViewModel.LengthInformerText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("LengthInformerText")),
			(delegate
			{
				UpdateCommentProgressWarning(commentLengthWarningText, commentLengthWarningProgress);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "CommentProgressPercent", "CommentProgressState" })),
			(delegate
			{
				additionalFieldsContainer.Visibility = base.ViewModel.ShowAdditionalProductFields.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ShowAdditionalProductFields")),
			(delegate
			{
				manufacturerLayout.Hint = base.ViewModel.ManufacturerLabel;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ManufacturerLabel")),
			(delegate
			{
				_productionDateLayout.Hint = base.ViewModel.ProductionDateLabel;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductionDateLabel")),
			(delegate
			{
				manufacturerHelper.Text = base.ViewModel.OptionalFieldHintText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OptionalFieldHintText")),
			(delegate
			{
				productionHelper.Text = base.ViewModel.OptionalFieldHintText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OptionalFieldHintText")),
			(delegate
			{
				_manufacturerEditText.ApplyText(base.ViewModel.Manufacturer);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Manufacturer")),
			(delegate
			{
				_productionDateEditText.ApplyText(base.ViewModel.ProductProductionDateText);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductProductionDateText")),
			(delegate
			{
				AddReviewButtonState(base.ViewModel.SendReviewButtonEnabled);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SendReviewButtonEnabled"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(imageView.OnClick(base.ViewModel.CloseCommand.Trigger), linearLayout.OnClick(base.ViewModel.UploadImageCommand.Trigger), _sendReviewButton.OnClick(SendReviewTapped), ((TextView)_commentEditText).OnTextChanged((Action)delegate
		{
			base.ViewModel.Comment = _commentEditText.Text;
		}), _commentEditText.OnFocusChange(delegate(object? _, View.FocusChangeEventArgs args)
		{
			OnInputFocusChanged(_commentEditText, args.HasFocus);
			if (!_commentEditText.HasFocus)
			{
				commentLayout.EndIconVisible = false;
			}
			else if (!string.IsNullOrEmpty(_commentEditText.Text))
			{
				commentLayout.EndIconVisible = true;
			}
		}), ((TextView)_manufacturerEditText).OnTextChanged((Action)delegate
		{
			base.ViewModel.Manufacturer = _manufacturerEditText.Text ?? string.Empty;
		}), _manufacturerEditText.OnFocusChange(delegate(object? _, View.FocusChangeEventArgs args)
		{
			OnInputFocusChanged(_manufacturerEditText, args.HasFocus);
			if (!_manufacturerEditText.HasFocus)
			{
				manufacturerLayout.EndIconVisible = false;
			}
			else if (!string.IsNullOrEmpty(_manufacturerEditText.Text))
			{
				manufacturerLayout.EndIconVisible = true;
			}
		}), ((TextView)_productionDateEditText).OnTextChanged((Action)delegate
		{
			if (string.IsNullOrEmpty(_productionDateEditText.Text))
			{
				base.ViewModel.ProductProductionDate = null;
			}
		}), _productionDateEditText.OnFocusChange(delegate(object? _, View.FocusChangeEventArgs args)
		{
			OnInputFocusChanged(_productionDateEditText, args.HasFocus);
			if (args.HasFocus)
			{
				_productionDateEditText.HideKeyboard(RequireContext());
				datePicker.Show();
			}
		}), base.Activity.Window.DecorView.ViewTreeObserver.OnGlobalLayout(OnGlobalLayout)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenInfoPageCommand.SafeSubscribe(OpenInfoPage, ViewLifecycleOwner);
		base.ViewModel.GoToFeedbackCommand.SafeSubscribe(OpenFeedback, ViewLifecycleOwner);
		base.ViewModel.GoToSupportChatCommand.SafeSubscribe(delegate
		{
			OpenSupportChat();
		}, ViewLifecycleOwner);
		_commentEditText.SetOnTouchListener(this);
		_commentEditText.LayoutChange += new DisposableDelegate<EventHandler<View.LayoutChangeEventArgs>>(CommentLayoutChanged, delegate(EventHandler<View.LayoutChangeEventArgs> h)
		{
			_commentEditText.LayoutChange -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private DatePickerDialog CreateDatePicker()
	{
		Calendar instance = Calendar.Instance;
		DatePickerDialog datePickerDialog = new DatePickerDialog(RequireContext(), this, instance.Get(CalendarField.Year), instance.Get(CalendarField.Month), instance.Get(CalendarField.Date));
		datePickerDialog.DatePicker.SetBackgroundResource(2131100630);
		datePickerDialog.DatePicker.MaxDate = instance.TimeInMillis;
		datePickerDialog.SetOnDismissListener(this);
		datePickerDialog.AutoDisposeOnDestroy(ViewLifecycleOwner);
		return datePickerDialog;
	}

	private void CommentLayoutChanged(object sender, View.LayoutChangeEventArgs e)
	{
		if (_commentEditText.HasFocus)
		{
			ScrollTextViewToBottom();
		}
	}

	private void OnGlobalLayout(object sender, EventArgs e)
	{
		Rect rect = new Rect();
		View.GetWindowVisibleDisplayFrame(rect);
		if (_previousViewBottom.HasValue && _previousViewBottom.Value > rect.Bottom)
		{
			ScrollFocusedInputToVisible();
		}
		_previousViewBottom = rect.Bottom;
	}

	private void OnInputFocusChanged(View inputView, bool hasFocus)
	{
		if (hasFocus)
		{
			ScrollFocusedInputToVisible(inputView);
		}
	}

	private void ScrollFocusedInputToVisible()
	{
		View focusedInput = GetFocusedInput();
		if (focusedInput != null)
		{
			ScrollFocusedInputToVisible(focusedInput);
		}
	}

	private View? GetFocusedInput()
	{
		if (_commentEditText.HasFocus)
		{
			return _commentEditText;
		}
		if (_manufacturerEditText.HasFocus)
		{
			return _manufacturerEditText;
		}
		if (_productionDateEditText.HasFocus)
		{
			return _productionDateEditText;
		}
		return null;
	}

	private void ScrollFocusedInputToVisible(View inputView)
	{
		if (inputView == _commentEditText)
		{
			ScrollTextViewToBottom();
			return;
		}
		int topRelativeTo = inputView.GetTopRelativeTo(_scrollView);
		int pos = topRelativeTo - base.Resources.DisplayMetrics.HeightPixels / 3;
		if (pos < 0)
		{
			pos = 0;
		}
		MainThread.BeginInvokeOnMainThread(async delegate
		{
			await Task.Delay(50);
			_scrollView.SmoothScrollTo(0, pos);
		});
	}

	private void ScrollTextViewToBottom()
	{
		int num = _commentEditText.Top;
		View view = _commentEditText.Parent as View;
		while (view != null && view != _scrollView)
		{
			num += view.Top;
			view = view.Parent as View;
		}
		int num2 = num + _commentEditText.Height;
		Rect rect = new Rect();
		_scrollView.GetHitRect(rect);
		int num3 = rect.Bottom - rect.Top;
		int pos = num2 - num3 + Converter.DpToPx(72f);
		if (pos < 0)
		{
			pos = 0;
		}
		MainThread.BeginInvokeOnMainThread(async delegate
		{
			await Task.Delay(50);
			_scrollView.SmoothScrollTo(0, pos);
		});
	}

	private void OpenFeedback(DynamicFeedbackViewModel.Parameter parameter)
	{
		base.ParentFragment.ParentFragmentManager.BeginTransaction().Hide(base.ParentFragment).Add<DynamicFeedbackFragment>(base.ParentFragment, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
		Dismiss();
	}

	private void OpenSupportChat()
	{
		base.ParentFragment.ParentFragmentManager.BeginTransaction().Hide(base.ParentFragment).Add<ChatFragment>(base.ParentFragment)
			.AddToBackStack(null)
			.Commit();
		Dismiss();
	}

	private void SendReviewTapped()
	{
		base.ViewModel.SendReviewCommand.Trigger();
		_scrollView.SmoothScrollTo(0, 0);
	}

	public bool OnTouch(View v, MotionEvent e)
	{
		if (!(v is TextInputEditText textInputEditText))
		{
			return false;
		}
		switch (e.ActionMasked)
		{
		case MotionEventActions.Down:
		case MotionEventActions.Move:
		{
			bool disallowIntercept = textInputEditText.CanScrollVertically(1) || textInputEditText.CanScrollVertically(-1);
			v.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept);
			break;
		}
		case MotionEventActions.Up:
		case MotionEventActions.Cancel:
			v.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: false);
			break;
		}
		return false;
	}

	private void AddReviewButtonState(bool enabled)
	{
		_sendReviewButton.Enabled = enabled;
		_sendReviewButton.Alpha = (enabled ? 1f : 0.5f);
	}

	private void RenderSelectedPhotos()
	{
		_photoSelectionView.ChangeFileResultsView(base.ViewModel.FileResults, base.ViewModel.ImageLoadFailedStubs, base.ViewModel.OnRemoveFileResult, base.ViewModel.OnRemoveImageLoadFailedStub, base.ViewModel.OnRemoveFileResultsClicked, base.ViewModel.OnImagePreviewLoadFailed, ViewLifecycleOwner);
	}

	private void RenderTriggerWords()
	{
		if (_triggerWordsAdapter != null)
		{
			_triggerWordsAdapter.DataSource = base.ViewModel.TriggerWords;
			_triggerWordsAdapter.NotifyDataSetChanged();
		}
	}

	private void BindTriggerWord(CachingViewHolder viewHolder, AddReviewViewModel.TriggerWordItem triggerWord, int index, CompositeDisposable disposables)
	{
		TextView textView = viewHolder.RequireCachedView<TextView>(2131298646);
		textView.Text = triggerWord.Name;
		int backgroundResource = (triggerWord.IsSelected ? 2131230907 : 2131230906);
		textView.SetBackgroundResource(backgroundResource);
		viewHolder.ItemView.SetOnClickListener(new ViewOnClickListener((Action)delegate
		{
			base.ViewModel.ToggleTriggerWordCommand.Trigger(triggerWord.Id);
		}).AddTo(disposables));
	}

	private void OpenInfoPage(InfoPageViewModel.Parameter parameter)
	{
		FragmentManager supportFragmentManager = RequireActivity().SupportFragmentManager;
		BottomSheetInfoPageFragmentContainer bottomSheetInfoPageFragmentContainer = supportFragmentManager.FragmentFactory.Instantiate<BottomSheetInfoPageFragmentContainer>();
		bottomSheetInfoPageFragmentContainer.Arguments = parameter.ToNavBundle();
		bottomSheetInfoPageFragmentContainer.Show(supportFragmentManager, null);
	}

	private void UpdateCommentProgressWarning(TextView commentLengthWarningText, ProgressBar commentLengthWarningProgress)
	{
		int commentProgressPercent = base.ViewModel.CommentProgressPercent;
		AddReviewViewModel.CommentProgressIndicatorState commentProgressState = base.ViewModel.CommentProgressState;
		int id = 2131099859;
		if (commentProgressState == AddReviewViewModel.CommentProgressIndicatorState.QuarterGray)
		{
			id = 2131099789;
		}
		int id2 = ((commentProgressState == AddReviewViewModel.CommentProgressIndicatorState.QuarterGray) ? 2131099680 : 2131099681);
		int id3 = ((commentProgressState == AddReviewViewModel.CommentProgressIndicatorState.QuarterGray) ? 2131099789 : 2131100611);
		int color = ContextCompat.GetColor(Context, id);
		int color2 = ContextCompat.GetColor(Context, id2);
		int color3 = ContextCompat.GetColor(Context, id3);
		if (!_currentProgressColor.HasValue || !_currentTrackColor.HasValue || !_currentTextColor.HasValue)
		{
			ApplyCommentProgressColors(commentLengthWarningProgress, commentLengthWarningText, color, color2, color3);
			_currentProgressColor = color;
			_currentTrackColor = color2;
			_currentTextColor = color3;
		}
		else if (_currentProgressColor != color || _currentTrackColor != color2 || _currentTextColor != color3)
		{
			AnimateCommentProgressColors(commentLengthWarningProgress, commentLengthWarningText, _currentProgressColor.Value, _currentTrackColor.Value, _currentTextColor.Value, color, color2, color3);
		}
		if (!OperatingSystem.IsAndroidVersionAtLeast(24))
		{
			commentLengthWarningProgress.Progress = commentProgressPercent;
		}
		else
		{
			commentLengthWarningProgress.SetProgress(commentProgressPercent, animate: false);
		}
	}

	private void AnimateCommentProgressColors(ProgressBar progressBar, TextView progressText, int fromProgressColor, int fromTrackColor, int fromTextColor, int toProgressColor, int toTrackColor, int toTextColor)
	{
		_commentProgressColorAnimator?.Cancel();
		_commentProgressColorAnimator?.Dispose();
		ValueAnimator valueAnimator = ValueAnimator.OfFloat(0f, 1f);
		valueAnimator.SetDuration(220L);
		valueAnimator.Update += delegate(object? _, ValueAnimator.AnimatorUpdateEventArgs args)
		{
			float fraction = args.Animation?.AnimatedFraction ?? 1f;
			int num = LerpColor(fromProgressColor, toProgressColor, fraction);
			int num2 = LerpColor(fromTrackColor, toTrackColor, fraction);
			int num3 = LerpColor(fromTextColor, toTextColor, fraction);
			ApplyCommentProgressColors(progressBar, progressText, num, num2, num3);
			_currentProgressColor = num;
			_currentTrackColor = num2;
			_currentTextColor = num3;
		};
		valueAnimator.AnimationEnd += delegate
		{
			_currentProgressColor = toProgressColor;
			_currentTrackColor = toTrackColor;
			_currentTextColor = toTextColor;
		};
		valueAnimator.Start();
		_commentProgressColorAnimator = valueAnimator;
	}

	private static int LerpColor(int fromColor, int toColor, float fraction)
	{
		int num = (fromColor >> 24) & 0xFF;
		int num2 = (fromColor >> 16) & 0xFF;
		int num3 = (fromColor >> 8) & 0xFF;
		int num4 = fromColor & 0xFF;
		int num5 = (toColor >> 24) & 0xFF;
		int num6 = (toColor >> 16) & 0xFF;
		int num7 = (toColor >> 8) & 0xFF;
		int num8 = toColor & 0xFF;
		int alpha = (int)((float)num + (float)(num5 - num) * fraction);
		int red = (int)((float)num2 + (float)(num6 - num2) * fraction);
		int green = (int)((float)num3 + (float)(num7 - num3) * fraction);
		int blue = (int)((float)num4 + (float)(num8 - num4) * fraction);
		return Color.Argb(alpha, red, green, blue);
	}

	private static void ApplyCommentProgressColors(ProgressBar progressBar, TextView progressText, int progressColor, int trackColor, int textColor)
	{
		if (progressBar.ProgressDrawable?.Mutate() is LayerDrawable layerDrawable)
		{
			if (layerDrawable.NumberOfLayers > 0)
			{
				layerDrawable.GetDrawable(0)?.Mutate()?.SetTint(trackColor);
			}
			if (layerDrawable.NumberOfLayers > 1)
			{
				layerDrawable.GetDrawable(1)?.Mutate()?.SetTint(progressColor);
			}
		}
		progressText.SetTextColor(new Color(textColor));
	}

	public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
	{
		base.ViewModel.ProductProductionDate = view.DateTime;
		_productionDateLayout.EndIconVisible = true;
	}

	public bool OnEditorAction(TextView v, ImeAction actionId, KeyEvent e)
	{
		if (actionId == ImeAction.Done)
		{
			_manufacturerEditText.ForceUnfocusKeyboard();
		}
		return true;
	}

	public override void OnDismiss(IDialogInterface dialog)
	{
		if (dialog is DatePickerDialog)
		{
			_productionDateEditText.ClearFocus();
		}
		else
		{
			base.OnDismiss(dialog);
		}
	}
}
