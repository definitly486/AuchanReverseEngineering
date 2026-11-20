using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.Utils;

namespace Auchan.Android.SelfScan;

[Register("auchan.Android.SelfScan.UITestBarcodeInputView")]
public class UITestBarcodeInputView : LinearLayout
{
	private EditText _barcodeTextField;

	private Button _imitateScanButton;

	protected UITestBarcodeInputView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public UITestBarcodeInputView(Context? context)
		: base(context)
	{
	}

	public UITestBarcodeInputView(Context? context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context);
	}

	public UITestBarcodeInputView(Context? context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context);
	}

	public void Setup(Action<string> imitateScanAction, ILifecycleOwner lifecycleOwner)
	{
		Visibility = ViewStates.Visible;
		((View)_imitateScanButton).OnClick((Action)delegate
		{
			imitateScanAction(_barcodeTextField.Text ?? string.Empty);
		}).AutoDisposeOnDestroy(lifecycleOwner);
	}

	private void Initialize(Context context)
	{
		Orientation = Orientation.Vertical;
		_barcodeTextField = new EditText(context);
		_barcodeTextField.SetBackgroundColor(Color.White);
		_barcodeTextField.SetHeight(Util.ConvertDpToPixels(60f));
		_barcodeTextField.SetWidth(Util.ConvertDpToPixels(200f));
		_imitateScanButton = new Button(context);
		_imitateScanButton.SetBackgroundColor(Color.Red);
		_imitateScanButton.SetHeight(Util.ConvertDpToPixels(50f));
		_imitateScanButton.SetWidth(Util.ConvertDpToPixels(200f));
		_imitateScanButton.SetTextColor(Color.White);
		_imitateScanButton.Text = "IMITATE SCAN";
		AddView(_barcodeTextField);
		AddView(_imitateScanButton);
	}
}
