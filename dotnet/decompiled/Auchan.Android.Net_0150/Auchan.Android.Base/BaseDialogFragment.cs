using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Graphics;
using AndroidX.Core.View;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.DependencyInjection;
using DryIoc;

namespace Auchan.Android.Base;

internal abstract class BaseDialogFragment : DialogFragment, INativeController
{
	private Insets? _originalMargin;

	private Insets? _originalPadding;

	private View? _content;

	private View? _insetTargetView;

	protected View Content => _content ?? (_content = Dialog?.RequireViewById<ViewGroup>(2131296838) ?? throw new InvalidOperationException("dialog isn't ready. Call later"));

	protected abstract int LayoutId { get; }

	protected virtual View? InsetTargetView => _insetTargetView ?? (_insetTargetView = View?.FindViewById<View>(2131296966) ?? View);

	public override int Theme => 2131951975;

	public override bool Cancelable => false;

	protected WindowInsetsCompat WindowInsets { get; private set; } = new WindowInsetsCompat(null);

	protected virtual int InsetsTypeMask => WindowInsetsCompat.Type.SystemBars() | WindowInsetsCompat.Type.Ime();

	object? INativeController.View => View;

	public override View? OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
	{
		return inflater.Inflate(LayoutId, container, attachToRoot: false);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		view.SetFitsSystemWindows(fitSystemWindows: false);
		ViewCompat.SetOnApplyWindowInsetsListener(view, CreateInsetListener(view));
		view.RequestApplyInsets();
	}

	protected virtual IOnApplyWindowInsetsListener CreateInsetListener(View view)
	{
		return new OnApplyWindowInsetsListener(delegate(WindowInsetsCompat insets)
		{
			WindowInsets = insets;
			OnWindowInsetsChanged(insets);
		});
	}

	protected virtual void OnWindowInsetsChanged(WindowInsetsCompat insets)
	{
		if (View != null && InsetTargetView != null)
		{
			Insets sbi = insets.GetInsets(InsetsTypeMask);
			if (_originalPadding == null)
			{
				_originalPadding = Insets.Of(InsetTargetView.PaddingLeft, InsetTargetView.PaddingTop, InsetTargetView.PaddingRight, InsetTargetView.PaddingBottom);
			}
			if (_originalMargin == null)
			{
				ViewGroup.MarginLayoutParams marginLayoutParams = (ViewGroup.MarginLayoutParams)InsetTargetView.LayoutParameters;
				_originalMargin = Insets.Of(marginLayoutParams.LeftMargin, marginLayoutParams.TopMargin, marginLayoutParams.RightMargin, marginLayoutParams.BottomMargin);
			}
			InsetTargetView.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams lp)
			{
				lp.TopMargin = _originalMargin.Top + sbi.Top;
			});
			InsetTargetView.SetPadding(_originalPadding.Left, _originalPadding.Top, _originalPadding.Right, _originalPadding.Bottom + sbi.Bottom);
		}
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

	protected void UpdateEditTextIfNeeded(EditText editText, string txt)
	{
		if (editText.Text != txt)
		{
			editText.Text = txt;
		}
	}
}
internal abstract class BaseDialogFragment<T> : BaseDialogFragment where T : ScreenViewModel
{
	private readonly Func<Fragment, T> _newViewModel;

	protected T ViewModel { get; private set; }

	protected BaseDialogFragment(Func<Fragment, T> newViewModel)
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
}
