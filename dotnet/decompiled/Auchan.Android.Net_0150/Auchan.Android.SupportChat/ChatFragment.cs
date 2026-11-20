using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Graphics;
using AndroidX.Core.View;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.DynamicFeedback;
using Auchan.Android.Extensions;
using Auchan.Android.SupportChat.MessagesRecycler;
using Auchan.Android.SupportChat.Views;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.Extensions;
using Auchan.Common.SupportChat;
using Auchan.Common.SupportChat.ItemViewModels;
using EBind;
using Google.Android.Material.TextField;
using VisibilitySwitch;

namespace Auchan.Android.SupportChat;

[Register("auchan.Android.SupportChat.SupportChatFragment")]
internal class ChatFragment : BaseToolbarFragment<SupportChatViewModel>
{
	internal class ChatInputLayout : TextInputLayout
	{
		public ChatInputLayout(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
		}

		public ChatInputLayout(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(context, attrs, defStyleAttr)
		{
		}

		public IDisposable Setup(Context context, SupportChatViewModel vm)
		{
			Drawable sendMessageDrawable = context.GetDrawable(2131231347) ?? throw new NullReferenceException("ic_send_message");
			Drawable attachClipDrawable = context.GetDrawable(2131231038) ?? throw new NullReferenceException("ic_attach_clip");
			return vm.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
			{
				EndIconDrawable = (vm.SendButtonEnabled ? sendMessageDrawable : attachClipDrawable);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SendButtonEnabled"))));
		}
	}

	private enum MenuItemId
	{
		Gallery,
		Photo,
		File
	}

	private enum ViewHolderType
	{
		IncomingMessage,
		OutgoingMessage,
		DateItem,
		StatusItem,
		WritingItem,
		RefundOrder
	}

	private NestedScrollView _scrollView;

	private RecyclerView _chatRecyclerView;

	private RecyclerView _macroRecyclerView;

	private View _touchIntercept;

	private View _chatContainer;

	private LinearLayoutManager _layoutManager;

	private ChatInputLayout? _chatInputLayout;

	private ViewGroup.MarginLayoutParams? _chatLayoutParamsOriginal;

	private ViewGroup _errorLayout;

	private TextView _errorTitle;

	private TextView _errorMessage;

	private ViewGroup _progressLayout;

	private ViewGroup _defaultLayout;

	private SoftInput? _softInputMode;

	private ObservableRecyclerAdapter<BaseSupportChatItemViewModel, CachingViewHolder> _chatAdapter;

	private ObservableRecyclerAdapter<MacroItemViewModel, CachingViewHolder> _macroAdapter;

	private int _lastBottomPosition = -1;

	private bool _didScrollUp;

	private WindowInsetsCompat _windowInsets = new WindowInsetsCompat(null);

	private readonly Subject<Unit> _scrollDownSubject = new Subject<Unit>();

	private Button _qrButton;

	private Button _retryButton;

	private const int SCROLL_DURATION_MS = 500;

	protected override int LayoutId => 2131493106;

	private IObservable<Unit> _scrollDownCommand => _scrollDownSubject.Sample(TimeSpan.FromMilliseconds(500L));

	private int ScrollRange => Math.Max(_macroRecyclerView.Bottom, _scrollView.ComputeVerticalScrollRange());

	public ChatFragment(Func<Fragment, SupportChatViewModel> viewModel)
		: base(viewModel)
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	protected override void OnNavigationButtonClick()
	{
		RequireActivity().OnBackPressed();
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		if (RequireActivity() is BaseActivity baseActivity)
		{
			baseActivity.OnInsetsChanged(OnActivityInsetsUpdate).AutoDisposeOnDestroy(this);
		}
	}

	private void OnActivityInsetsUpdate(object? sender, ChangedActivityInsetsArgs e)
	{
		_windowInsets = e.Insets;
		UpdateLayoutDueWindowInsetsChange();
	}

	private void UpdateLayoutDueWindowInsetsChange()
	{
		if (_chatInputLayout != null)
		{
			if (_chatLayoutParamsOriginal == null)
			{
				_chatLayoutParamsOriginal = new ViewGroup.MarginLayoutParams(_chatInputLayout.LayoutParameters);
			}
			Insets insets = _windowInsets.GetInsets(WindowInsetsCompat.Type.SystemBars());
			Insets insets2 = _windowInsets.GetInsets(WindowInsetsCompat.Type.Ime());
			int bottom = ((insets2.Bottom > 0) ? (insets2.Bottom - insets.Bottom) : 0);
			_chatInputLayout.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams lp)
			{
				lp.BottomMargin = _chatLayoutParamsOriginal.BottomMargin + bottom;
			});
			if (insets2.Bottom > 0)
			{
				SmoothScrollToLastPosition().SafeFireAndForget((Action<Exception>)null, false);
			}
		}
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		base.ToolbarTitle = base.ViewModel.Title;
		_scrollView = view.RequireViewById<NestedScrollView>(2131298303);
		_chatRecyclerView = view.RequireViewById<RecyclerView>(2131296766);
		_macroRecyclerView = view.RequireViewById<RecyclerView>(2131297507);
		_chatInputLayout = view.RequireViewById<ChatInputLayout>(2131296765);
		_defaultLayout = view.RequireViewById<ViewGroup>(2131296904);
		_errorLayout = view.RequireViewById<ViewGroup>(2131297111);
		_errorTitle = _errorLayout.RequireViewById<TextView>(2131298646);
		_errorMessage = _errorLayout.RequireViewById<TextView>(2131297563);
		_qrButton = _errorLayout.RequireViewById<Button>(2131298371);
		_retryButton = _errorLayout.RequireViewById<Button>(2131296325);
		_progressLayout = view.RequireViewById<ViewGroup>(2131298079);
		_chatContainer = view.RequireViewById<View>(2131296763);
		_touchIntercept = view.RequireViewById<View>(2131298737);
		_chatInputLayout.SetEndIconActivated(endIconActivated: true);
		_scrollView.SmoothScrollingEnabled = true;
		_chatAdapter = new ObservableRecyclerAdapter<BaseSupportChatItemViewModel, CachingViewHolder>
		{
			GetItemViewTypeDelegate = GetViewHolderType,
			CreateViewHolderDelegate = CreateViewHolder,
			DataSource = base.ViewModel.ItemViewModels,
			BindViewHolderDelegate = BindMessageViewHolder
		};
		_chatRecyclerView.SetAdapter(_chatAdapter);
		_chatRecyclerView.SetItemAnimator(null);
		_chatRecyclerView.AddItemDecoration(new ChatItemDecoration(base.ViewModel));
		_layoutManager = new LinearLayoutManager(Context);
		_chatRecyclerView.SetLayoutManager(_layoutManager);
		_macroAdapter = new ObservableRecyclerAdapter<MacroItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493354,
			DataSource = base.ViewModel.MacroItemViewModels,
			BindViewHolderDelegate = BindMacroViewHolder
		};
		_macroRecyclerView.SetAdapter(_macroAdapter);
		_macroRecyclerView.SetItemAnimator(null);
		_macroRecyclerView.AddItemDecoration(new ChatItemDecoration(base.ViewModel));
		_macroRecyclerView.SetLayoutManager(new SupportChatLayoutManager(Context)
		{
			ItemsPerLine = 0,
			RatingsPerLine = 5,
			MacroButtons = base.ViewModel.MacroItemViewModels
		});
		Bind();
		UpdateLayoutDueWindowInsetsChange();
	}

	public override void OnResume()
	{
		base.OnResume();
		_softInputMode = base.Activity?.Window?.Attributes?.SoftInputMode;
		RequireActivity().Window?.SetSoftInputMode(SoftInput.AdjustResize);
		UpdateLayoutDueWindowInsetsChange();
		if (View != null)
		{
			View.PostDelayed(ScrollToBottomSampling, 100L);
		}
		else
		{
			ScrollToBottomSampling();
		}
	}

	public override void OnPause()
	{
		base.OnPause();
		RequireActivity().Window?.SetSoftInputMode(_softInputMode ?? SoftInput.AdjustPan);
	}

	public override void OnDestroyView()
	{
		base.OnDestroyView();
		base.ViewModel.CloseCommand.Trigger();
	}

	private int GetViewHolderType(int position)
	{
		BaseSupportChatItemViewModel baseSupportChatItemViewModel = base.ViewModel.ItemViewModels[position];
		if (!(baseSupportChatItemViewModel is IncomingMessageViewModel))
		{
			if (!(baseSupportChatItemViewModel is OutgoingMessageViewModel))
			{
				if (!(baseSupportChatItemViewModel is DateItemViewModel))
				{
					if (!(baseSupportChatItemViewModel is StatusItemViewModel))
					{
						if (!(baseSupportChatItemViewModel is WritingMessageViewModel))
						{
							if (baseSupportChatItemViewModel is RefundOrderListItemViewModel)
							{
								return 5;
							}
							throw new ArgumentException($"Unknown data type {baseSupportChatItemViewModel.GetType()} at positon {position}", "position");
						}
						return 4;
					}
					return 3;
				}
				return 2;
			}
			return 1;
		}
		return 0;
	}

	private CachingViewHolder CreateViewHolder(ViewGroup parent, int type)
	{
		Context? context = Context;
		if (context == null)
		{
			throw new InvalidOperationException("no context");
		}
		Context context2 = context;
		return type switch
		{
			0 => new CachingViewHolder(new IncomingMessageView(context2)), 
			1 => new CachingViewHolder(new MessageView(context2, MessageView.Alignment.Right, 20)), 
			2 => new CachingViewHolder(new DateView(context2)), 
			3 => new CachingViewHolder(new StatusView(context2)), 
			4 => new CachingViewHolder(new WritingMessageView(context2)), 
			5 => new CachingViewHolder(new RefundOrderMessageView(context2)), 
			_ => throw new ArgumentException($"Unknown message type {type}", "type"), 
		};
	}

	private void BindMessageViewHolder(CachingViewHolder viewHolder, BaseSupportChatItemViewModel viewModel, int position, ICollection<IDisposable> disposables)
	{
		BaseMessageViewModel bvm = viewModel as BaseMessageViewModel;
		if (bvm != null && base.ViewModel.ItemViewModels.Where((BaseSupportChatItemViewModel v) => v is BaseMessageViewModel { IsImage: not false } baseMessageViewModel && baseMessageViewModel.AttachmentUrl != null).LastOrDefault() == bvm)
		{
			bvm.ImageLoadedEvent += new DisposableDelegate<Action>(delegate
			{
				ScrollToBottomSampling();
			}, delegate(Action h)
			{
				bvm.ImageLoadedEvent -= h;
			}).AddTo(disposables);
		}
		if (!(viewModel is WritingMessageViewModel message))
		{
			if (!(viewModel is IncomingMessageViewModel message2))
			{
				if (!(viewModel is OutgoingMessageViewModel message3))
				{
					if (!(viewModel is DateItemViewModel dateItemViewModel))
					{
						if (!(viewModel is StatusItemViewModel statusItemViewModel))
						{
							if (viewModel is RefundOrderListItemViewModel ivm && viewHolder.ItemView is RefundOrderMessageView refundOrderMessageView)
							{
								refundOrderMessageView.Bind(ivm, disposables);
								return;
							}
						}
						else if (viewHolder.ItemView is StatusView statusView)
						{
							statusView.StatusTextView.Text = statusItemViewModel.Status;
							return;
						}
					}
					else if (viewHolder.ItemView is DateView dateView)
					{
						dateView.DateTextView.Text = dateItemViewModel.DateText;
						return;
					}
				}
				else if (viewHolder.ItemView is MessageView messageView)
				{
					messageView.Bind(message3, disposables);
					return;
				}
			}
			else if (viewHolder.ItemView is IncomingMessageView incomingMessageView)
			{
				incomingMessageView.Bind(message2, disposables);
				return;
			}
		}
		else if (viewHolder.ItemView is WritingMessageView writingMessageView)
		{
			writingMessageView.Bind(message, disposables);
			return;
		}
		throw new InvalidDataException($"can't bind {viewModel.GetType()} to {viewHolder.ItemView.GetType()}");
	}

	private void BindMacroViewHolder(CachingViewHolder viewHolder, MacroItemViewModel viewModel, int position, CompositeDisposable disposables)
	{
		RelativeLayout relativeLayout = viewHolder.RequireCachedView<RelativeLayout>(2131297506);
		TextView textView = viewHolder.RequireCachedView<TextView>(2131298603);
		RelativeLayout relativeLayout2 = viewHolder.RequireCachedView<RelativeLayout>(2131298146);
		ImageView imageView = viewHolder.RequireCachedView<ImageView>(2131296760);
		textView.Text = viewModel.MacroText;
		if (viewModel.IsRating)
		{
			relativeLayout2.Visibility = ViewStates.Visible;
			relativeLayout.Visibility = ViewStates.Gone;
		}
		else
		{
			relativeLayout2.Visibility = ViewStates.Gone;
			relativeLayout.Visibility = ViewStates.Visible;
		}
		imageView.SetImageResource(viewModel.MacroText switch
		{
			"1" => 2131689499, 
			"2" => 2131689500, 
			"3" => 2131689501, 
			"4" => 2131689502, 
			"5" => 2131689503, 
			_ => 2131689503, 
		});
		viewModel.BindEvents(viewHolder.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.MacroSelectedCommand.Trigger(viewModel);
		})).AddTo(disposables);
	}

	private void Bind()
	{
		_chatInputLayout.Setup(Context, base.ViewModel).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OpenResendCommand.SafeSubscribe(NavigateToResend, ViewLifecycleOwner);
		base.ViewModel.OpenFileSendErrorCommand.SafeSubscribe(NavigateToFileUpload, ViewLifecycleOwner);
		base.ViewModel.OpenRefundCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<RefundFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.NavigateToFeedbackCommand.SafeSubscribe(NavigateToFeedback, ViewLifecycleOwner);
		_scrollDownCommand.PerformSamplingTask(SmoothScrollToBottom).Subscribe().AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.MacroItemViewModels.SafeSubscribeToCollectionChanged(delegate
		{
			ScrollToBottomSampling();
			_chatInputLayout.Enabled = !base.ViewModel.InputBlocked;
			_chatInputLayout.Alpha = (base.ViewModel.InputBlocked ? 0.5f : 1f);
			_chatInputLayout.DescendantFocusability = (base.ViewModel.InputBlocked ? DescendantFocusability.BlockDescendants : DescendantFocusability.AfterDescendants);
			_chatInputLayout.EditText.Hint = (base.ViewModel.InputBlocked ? base.ViewModel.ChooseButtonPlaceholder : base.ViewModel.MessagePlaceholder);
		}, ViewLifecycleOwner);
		base.ViewModel.ItemViewModels.SafeSubscribeToCollectionChanged(delegate
		{
			ScrollToBottomSampling();
		}, ViewLifecycleOwner);
		_chatInputLayout.EditText.Hint = base.ViewModel.MessagePlaceholder;
		VisibilitySwitch<SupportChatViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<SupportChatViewModel.VisualState>(SupportChatViewModel.VisualState.Default)
		{
			{
				SupportChatViewModel.VisualState.Default,
				_defaultLayout
			},
			{
				SupportChatViewModel.VisualState.Error,
				_errorLayout
			},
			{
				SupportChatViewModel.VisualState.IsProgress,
				_progressLayout
			}
		};
		_errorTitle.Text = base.ViewModel.ErrorTitle;
		_errorMessage.Text = base.ViewModel.ErrorMessage;
		_qrButton.Visibility = ViewStates.Gone;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				if (base.ViewModel.State == SupportChatViewModel.VisualState.Error)
				{
					base.Activity.HideKeyboard();
				}
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				_chatInputLayout.EditText.Text = base.ViewModel.Message;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Message"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((TextView)_chatInputLayout.EditText).OnTextChanged((Action)delegate
		{
			base.ViewModel.SetMessageSilent(_chatInputLayout.EditText.Text ?? "");
		}), _scrollView.OnLayoutChange(delegate(object? s, View.LayoutChangeEventArgs e)
		{
			if (e.OldBottom == 0 && e.Bottom != 0)
			{
				ScrollToBottomSampling();
			}
		}), _scrollView.OnScrollChange(delegate(object? s, NestedScrollView.ScrollChangeEventArgs e)
		{
			_didScrollUp = e.ScrollY > e.OldScrollY;
			if (e.ScrollY - e.OldScrollY < 0)
			{
				View.HideKeyboard(base.Activity);
			}
			_lastBottomPosition = e.ScrollY + _scrollView.Height;
		}), _touchIntercept.OnTouch(delegate(object? o, View.TouchEventArgs e)
		{
			MotionEvent motionEvent = MotionEvent.Obtain(e.Event);
			MotionEventActions action = motionEvent.Action;
			if (action == MotionEventActions.Down)
			{
				_didScrollUp = false;
			}
			if (action == MotionEventActions.Up && !_didScrollUp)
			{
				View.HideKeyboard(base.Activity);
			}
			_chatContainer.DispatchTouchEvent(motionEvent);
			motionEvent.Recycle();
			e.Handled = false;
		}), _touchIntercept.OnClick((Action)delegate
		{
		}), _retryButton.OnClick(base.ViewModel.Retry)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		_chatInputLayout.SetEndIconOnClickListener(new ViewOnClickListener(delegate(View view)
		{
			if (View != null)
			{
				if (base.ViewModel.SendButtonEnabled)
				{
					base.ViewModel.SendCommand.Trigger();
				}
				else
				{
					base.ViewModel.OnAttachButtonClick();
					View.HideKeyboard(RequireContext());
					AttachButtonPopupWindow.Show(base.ViewModel, View, view);
				}
			}
		}));
	}

	private void ScrollToBottomSampling()
	{
		_scrollDownSubject.OnNext(Unit.Default);
	}

	private Task SmoothScrollToBottom()
	{
		_scrollView.SmoothScrollTo(0, ScrollRange - _scrollView.Height, 500);
		_lastBottomPosition = ScrollRange;
		return Task.Delay(500);
	}

	private async Task SmoothScrollToLastPosition()
	{
		await Task.Delay(500);
		_scrollView.SmoothScrollTo(0, _lastBottomPosition - _scrollView.Height, 500);
	}

	private void NavigateToResend(SupportChatSendErrorViewModel.Parameter parameter)
	{
		FragmentManager supportFragmentManager = RequireActivity().SupportFragmentManager;
		SupportChatSendErrorFragment supportChatSendErrorFragment = supportFragmentManager.FragmentFactory.Instantiate<SupportChatSendErrorFragment>();
		supportChatSendErrorFragment.Arguments = parameter.ToNavBundle();
		supportChatSendErrorFragment.Show(supportFragmentManager, null);
	}

	private void NavigateToFileUpload(BrokerToken parameter)
	{
		ShowAsync<SupportChatSendFileFragment, BrokerToken>(parameter).SafeFireAndForget((Action<Exception>)null, false);
	}

	private void NavigateToFeedback(DynamicFeedbackViewModel.Parameter parameter)
	{
		NavigateTo<DynamicFeedbackFragment, DynamicFeedbackViewModel.Parameter>(parameter);
	}
}
