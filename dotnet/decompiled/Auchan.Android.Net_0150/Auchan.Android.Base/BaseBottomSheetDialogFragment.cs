using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.Core.Graphics;
using AndroidX.Core.View;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Navigation;
using DryIoc;
using Google.Android.Material.BottomSheet;
using Java.Interop;

namespace Auchan.Android.Base;

public abstract class BaseBottomSheetDialogFragment : BottomSheetDialogFragment, IDialogInterfaceOnShowListener, IJavaObject, IDisposable, IJavaPeerable, INativeController
{
	protected class BottomSheetDialog : Google.Android.Material.BottomSheet.BottomSheetDialog
	{
		public required BaseBottomSheetDialogFragment Fragment { get; init; }

		public BottomSheetDialog(Context context)
			: base(context)
		{
		}

		public BottomSheetDialog(Context context, int theme)
			: base(context, theme)
		{
		}

		protected BottomSheetDialog(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected BottomSheetDialog(Context context, bool cancelable, IDialogInterfaceOnCancelListener? cancelListener)
			: base(context, cancelable, cancelListener)
		{
		}

		public override void OnAttachedToWindow()
		{
			base.OnAttachedToWindow();
			Fragment.OnDialogAttachedToWindow(this);
		}
	}

	private Insets? _originalMargin;

	private Insets? _originalPadding;

	private BottomSheetBehavior? _behavior;

	private View? _bottomSheet;

	private View? _container;

	private View? _coordinator;

	protected abstract int LayoutId { get; }

	protected virtual bool FullScreen => false;

	protected virtual bool IsDragToCloseEnabled => false;

	protected BottomSheetBehavior Behavior => _behavior ?? (_behavior = BottomSheetBehavior.From(BottomSheet));

	protected virtual View BottomSheet => _bottomSheet ?? (_bottomSheet = Dialog?.RequireViewById<View>(2131296966) ?? throw new InvalidOperationException("dialog isn't ready"));

	protected virtual View Container => _container ?? (_container = Dialog?.RequireViewById<View>(2131296837) ?? throw new InvalidOperationException("dialog isn't ready"));

	protected virtual View Coordinator => _coordinator ?? (_coordinator = Dialog?.RequireViewById<View>(2131296848) ?? throw new InvalidOperationException("dialog isn't ready"));

	protected WindowInsetsCompat WindowInsets { get; private set; } = new WindowInsetsCompat(null);

	protected virtual int InsetsTypeMask => WindowInsetsCompat.Type.SystemBars() | WindowInsetsCompat.Type.Ime();

	object? INativeController.View => View;

	public override View? OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
	{
		return inflater.Inflate(LayoutId, container, attachToRoot: false);
	}

	protected virtual IOnApplyWindowInsetsListener CreateInsetListener()
	{
		return new OnApplyWindowInsetsListener(OnInsetsChanged);
	}

	protected virtual void OnInsetsChanged(WindowInsetsCompat insets)
	{
		Insets sbi = insets.GetInsets(InsetsTypeMask);
		if (_originalMargin == null)
		{
			ViewGroup.MarginLayoutParams marginLayoutParams = (ViewGroup.MarginLayoutParams)Container.LayoutParameters;
			_originalMargin = Insets.Of(marginLayoutParams.LeftMargin, marginLayoutParams.TopMargin, marginLayoutParams.RightMargin, marginLayoutParams.BottomMargin);
		}
		if (_originalPadding == null)
		{
			_originalPadding = Insets.Of(BottomSheet.PaddingLeft, BottomSheet.PaddingTop, BottomSheet.PaddingRight, BottomSheet.PaddingBottom);
		}
		Container.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams lp)
		{
			lp.TopMargin = _originalMargin.Top + sbi.Top;
		});
		BottomSheet.SetPadding(_originalPadding.Left, _originalPadding.Top, _originalPadding.Right, _originalPadding.Bottom + sbi.Bottom);
	}

	public override Dialog OnCreateDialog(Bundle? savedInstanceState)
	{
		BottomSheetDialog obj = new BottomSheetDialog(Context, Theme)
		{
			Fragment = this
		};
		obj.SetOnShowListener(this);
		return obj;
	}

	public virtual void OnShow(IDialogInterface? dialog)
	{
		Behavior.State = 3;
	}

	protected virtual void OnDialogAttachedToWindow(BottomSheetDialog dialog)
	{
		Coordinator.SetFitsSystemWindows(fitSystemWindows: false);
		Container.SetFitsSystemWindows(fitSystemWindows: false);
		ViewCompat.SetOnApplyWindowInsetsListener(Container, CreateInsetListener());
		Container.RequestApplyInsets();
		if (IsDragToCloseEnabled)
		{
			Behavior.AddBottomSheetCallback(new BottomSheetBehaviorCallback());
		}
		if (FullScreen)
		{
			BottomSheet.UpdateLayoutParams<ViewGroup.LayoutParams>((Action<ViewGroup.LayoutParams>)delegate(ViewGroup.LayoutParams lp)
			{
				lp.Height = -1;
			});
		}
	}
}
internal abstract class BaseBottomSheetDialogFragment<T> : BaseBottomSheetDialogFragment, IOnNavigateFrom where T : ScreenViewModel
{
	private readonly Func<AndroidX.Fragment.App.Fragment, T> _newViewModel;

	protected T ViewModel { get; private set; }

	protected BaseBottomSheetDialogFragment(Func<AndroidX.Fragment.App.Fragment, T> newViewModel)
	{
		_newViewModel = newViewModel;
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		ViewModel = this.Retain("ViewModel", delegate
		{
			T val = _newViewModel(this);
			val.DoStart(this).SafeFireAndForget((Action<Exception>)null, false);
			return val;
		}, delegate(T vm)
		{
			vm.Dispose();
		});
	}

	public override void OnStart()
	{
		base.OnStart();
		if (!base.IsHidden)
		{
			ViewModel.DoResume().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public override void OnStop()
	{
		base.OnStop();
		if (!base.IsHidden)
		{
			ViewModel.DoPause().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public override void OnHiddenChanged(bool hidden)
	{
		base.OnHiddenChanged(hidden);
		if (Lifecycle.CurrentState.IsAtLeast(AndroidX.Lifecycle.Lifecycle.State.Started))
		{
			if (hidden)
			{
				ViewModel.DoPause().SafeFireAndForget((Action<Exception>)null, false);
			}
			else
			{
				ViewModel.DoResume().SafeFireAndForget((Action<Exception>)null, false);
			}
		}
	}

	public NavigationPossibilityType OnNavigateFrom()
	{
		return ((IOnNavigateFrom)ViewModel)?.OnNavigateFrom() ?? NavigationPossibilityType.Impossible;
	}

	protected TFragment Show<TFragment>() where TFragment : DialogFragment
	{
		return Show<TFragment, object>(null);
	}

	protected TFragment Show<TFragment, TParameter>(TParameter? parameter) where TFragment : DialogFragment
	{
		TFragment val = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<FragmentFactory>().Instantiate<TFragment>();
		if (parameter != null)
		{
			val.Arguments = parameter.ToNavBundle();
		}
		val.Show(base.ChildFragmentManager, null);
		return val;
	}

	protected Task<TFragment> ShowAsync<TFragment>() where TFragment : DialogFragment
	{
		return ShowAsync<TFragment, object>(null);
	}

	protected async Task<TFragment> ShowAsync<TFragment, TParameter>(TParameter? parameter) where TFragment : DialogFragment
	{
		await RequireActivity().WaitForStateAsync(AndroidX.Lifecycle.Lifecycle.State.Resumed);
		TFragment val = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<FragmentFactory>().Instantiate<TFragment>();
		if (parameter != null)
		{
			val.Arguments = parameter.ToNavBundle();
		}
		val.Show(base.ChildFragmentManager, null);
		return val;
	}
}
