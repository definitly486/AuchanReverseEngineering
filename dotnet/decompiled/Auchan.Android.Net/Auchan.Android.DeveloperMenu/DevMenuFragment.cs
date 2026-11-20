using System;
using System.Collections.Generic;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.Logs;
using Auchan.Common.Base;
using Auchan.Common.DeveloperMenu;
using Google.Android.Material.TextField;

namespace Auchan.Android.DeveloperMenu;

[Register("auchan.Android.DeveloperMenu.DevMenuFragment")]
internal class DevMenuFragment : BaseToolbarFragment<DevMenuViewModel>
{
	protected override int LayoutId => 2131493019;

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public DevMenuFragment(Func<Fragment, DevMenuViewModel> viewModel)
		: base(viewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		base.ToolbarTitle = base.ViewModel.ScreenTitle;
		AppCompatSpinner appCompatSpinner = view.RequireViewById<AppCompatSpinner>(2131296979);
		Button saveButton = view.RequireViewById<Button>(2131296978);
		Button buttonFrom = GetButtonFrom(view, 2131296976, base.ViewModel.OpenLogsButtonText);
		Button resetCacheButton = GetButtonFrom(view, 2131296977, base.ViewModel.ResetCacheButtonText);
		TextInputLayout textInputLayout = view.RequireViewById<TextInputLayout>(2131298851);
		TextInputEditText yamKeyEditText = view.RequireViewById<TextInputEditText>(2131298850);
		saveButton.Text = base.ViewModel.SaveButtonText;
		textInputLayout.Hint = base.ViewModel.AppMetricaCustomKeyText;
		ArrayAdapter<string> adapter = new ArrayAdapter<string>(RequireContext(), 2131493527, base.ViewModel.EnvironmentVariants);
		appCompatSpinner.Adapter = adapter;
		appCompatSpinner.SetSelection(base.ViewModel.CurrentEnvironment);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				OnHaveChangesChanged(saveButton, base.ViewModel.HaveChanges);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HaveChanges")),
			(delegate
			{
				OnCanResetCacheChanged(resetCacheButton, base.ViewModel.CanResetCache);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanResetCache")),
			(delegate
			{
				yamKeyEditText.ApplyText(base.ViewModel.AppMetricaCustomKey);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AppMetricaCustomKey"))
		})).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.BindEvents(appCompatSpinner.OnItemSelected(delegate(object? o, AdapterView.ItemSelectedEventArgs e)
		{
			base.ViewModel.SelectedEnvironment = e.Position;
		}), ((View)buttonFrom).OnClick((Action)delegate
		{
			NavigateTo<LogFragment>();
		}), ((View)saveButton).OnClick((Action)delegate
		{
			base.ViewModel.SaveChanges().SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)resetCacheButton).OnClick((Action)delegate
		{
			base.ViewModel.ResetCache().SafeFireAndForget((Action<Exception>)null, false);
		}), ((TextView)yamKeyEditText).OnTextChanged((Action)delegate
		{
			base.ViewModel.AppMetricaCustomKey = yamKeyEditText.Text ?? "";
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private Button GetButtonFrom(View view, int id, string withText)
	{
		Button button = view.RequireViewById<ConstraintLayout>(id).RequireViewById<Button>(2131296587);
		button.Text = withText;
		return button;
	}

	private void OnHaveChangesChanged(Button saveButton, bool value)
	{
		TextViewCompat.SetTextAppearance(saveButton, value ? 2131951937 : 2131951942);
		saveButton.SetBackgroundResource(value ? 2131231003 : 2131231005);
		saveButton.Enabled = value;
	}

	private void OnCanResetCacheChanged(Button resetCacheButton, bool value)
	{
		TextViewCompat.SetTextAppearance(resetCacheButton, value ? 2131952019 : 2131951942);
		resetCacheButton.SetBackgroundResource(value ? 2131231540 : 2131231005);
		resetCacheButton.Enabled = value;
	}
}
