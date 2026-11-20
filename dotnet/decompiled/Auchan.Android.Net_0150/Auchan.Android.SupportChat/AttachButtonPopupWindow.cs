using System;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.SupportChat;

namespace Auchan.Android.SupportChat;

internal sealed class AttachButtonPopupWindow : PopupWindow
{
	private readonly SupportChatViewModel _viewModel;

	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	public AttachButtonPopupWindow(SupportChatViewModel viewModel, View contentView, int width, int height)
		: base(contentView, width, height)
	{
		_viewModel = viewModel;
		Focusable = true;
		OutsideTouchable = true;
		Touchable = true;
		SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
		base.DismissEvent += OnDismissEvent;
		ViewGroup viewGroup = contentView.RequireViewById<ViewGroup>(2131297891);
		TextView textView = contentView.RequireViewById<TextView>(2131297890);
		ViewGroup viewGroup2 = contentView.RequireViewById<ViewGroup>(2131298801);
		TextView textView2 = contentView.RequireViewById<TextView>(2131298800);
		ViewGroup viewGroup3 = contentView.RequireViewById<ViewGroup>(2131298335);
		TextView textView3 = contentView.RequireViewById<TextView>(2131298334);
		textView.Text = _viewModel.SelectPhotoFromGalleryText;
		textView2.Text = _viewModel.SelectVideoFromGalleryText;
		textView3.Text = _viewModel.SelectFileText;
		_viewModel.BindEvents(((View)viewGroup).OnClick((Action)delegate
		{
			TriggerAndDimiss(_viewModel.SelectPhotoFromGalleryCommand);
		}), ((View)viewGroup2).OnClick((Action)delegate
		{
			TriggerAndDimiss(_viewModel.SelectVideoFromGalleryCommand);
		}), ((View)viewGroup3).OnClick((Action)delegate
		{
			TriggerAndDimiss(_viewModel.SelectFileCommand);
		})).AddTo(_disposables);
	}

	private void TriggerAndDimiss(UICommand command)
	{
		command.Trigger();
		Dismiss();
	}

	private void OnDismissEvent(object sender, EventArgs e)
	{
		_disposables.Dispose();
	}

	public static void Show(SupportChatViewModel viewModel, View rootView, View atTopOf)
	{
		View view = LayoutInflater.From(rootView.Context).Inflate(2131493458, null, attachToRoot: false);
		view.Measure(View.MeasureSpec.MakeMeasureSpec(rootView.Width, MeasureSpecMode.AtMost), View.MeasureSpec.MakeMeasureSpec(rootView.Height, MeasureSpecMode.AtMost));
		new AttachButtonPopupWindow(viewModel, view, view.MeasuredWidth, view.MeasuredHeight).ShowAsDropDown(atTopOf, -atTopOf.Width / 2, atTopOf.Height / ((Build.VERSION.SdkInt >= BuildVersionCodes.N) ? 2 : (-2)), GravityFlags.Right);
	}
}
