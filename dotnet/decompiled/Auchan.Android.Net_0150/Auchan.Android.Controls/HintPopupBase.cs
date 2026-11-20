using System;
using System.Reactive.Disposables;
using Android.Views;
using Android.Widget;
using Auchan.Android.Extensions;
using Auchan.Common.Extensions;

namespace Auchan.Android.Controls;

internal abstract class HintPopupBase : PopupWindow
{
	protected readonly CompositeDisposable _closeDisposables = new CompositeDisposable();

	public HintPopupBase(View contentView, int width, int height)
		: base(contentView, width, height)
	{
		Focusable = true;
		OutsideTouchable = true;
		Touchable = true;
		SoftInputMode = SoftInput.StateAlwaysHidden;
		contentView.OnClick((Action)delegate
		{
			Dismiss();
		}).AddTo(_closeDisposables);
	}

	public override void Dismiss()
	{
		base.Dismiss();
		_closeDisposables.Clear();
	}
}
