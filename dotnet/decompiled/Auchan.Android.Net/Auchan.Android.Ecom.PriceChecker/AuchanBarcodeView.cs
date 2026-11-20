using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Common.Helpers;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Ecom.PriceChecker;

[Register("auchan.Android.SelfScan.AuchanBarcodeView")]
public class AuchanBarcodeView : FrameLayout
{
	private AuchanViewFinder? _viewFinder;

	private CameraController? _controller;

	private bool _isScanning;

	private bool _torchEnabled;

	private int _cornersType;

	private int _cornersRadius;

	private int _maskPaddingBottom;

	private float[]? _radii;

	private Path? _path;

	public AuchanViewFinder? ViewFinder => _viewFinder;

	public bool Centering
	{
		set
		{
			_controller.SetCentering(value);
		}
	}

	public bool TorchEnabled => _torchEnabled;

	public AuchanBarcodeView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public AuchanBarcodeView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public AuchanBarcodeView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet attrs)
	{
		CreateLayout(context, attrs);
		TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.AuchanBarcodeView);
		_cornersType = typedArray.GetInt(3, 0);
		_cornersRadius = typedArray.GetDimensionPixelSize(2, 0);
		_maskPaddingBottom = typedArray.GetDimensionPixelSize(4, 0);
		typedArray.Recycle();
		if (_cornersType > 0)
		{
			BuildPath();
		}
	}

	protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
	{
		base.OnSizeChanged(w, h, oldw, oldh);
		if (_path != null)
		{
			_path.Reset();
			_path.AddRoundRect(new RectF(0f, 0f, base.Width, base.Height - _maskPaddingBottom), _radii, Path.Direction.Cw);
		}
	}

	protected override void DispatchDraw(Canvas canvas)
	{
		if (_path != null)
		{
			canvas.ClipPath(_path);
		}
		base.DispatchDraw(canvas);
	}

	private void CreateLayout(Context context, IAttributeSet attrs)
	{
	}

	private void BuildPath()
	{
		_radii = new float[8];
		_path = new Path();
		if ((_cornersType & 1) == 1)
		{
			_radii[0] = _cornersRadius;
			_radii[1] = _cornersRadius;
		}
		if ((_cornersType & 2) == 2)
		{
			_radii[2] = _cornersRadius;
			_radii[3] = _cornersRadius;
		}
		if ((_cornersType & 4) == 4)
		{
			_radii[4] = _cornersRadius;
			_radii[5] = _cornersRadius;
		}
		if ((_cornersType & 8) == 8)
		{
			_radii[6] = _cornersRadius;
			_radii[7] = _cornersRadius;
		}
	}

	public void Pause()
	{
	}

	public void PauseAndWait()
	{
	}

	public void Resume()
	{
		_controller.Refresh();
	}

	public void Stop()
	{
		MainThread.EnsureOnMainThread();
		if (_isScanning)
		{
			_isScanning = false;
		}
	}

	public void SetRect(Rect rect)
	{
		new Size(rect.Width(), rect.Height());
		ViewFinder.SetFramingRect(rect);
	}

	public void ToggleTorch()
	{
		_torchEnabled = !_torchEnabled;
	}

	public override bool OnTouchEvent(MotionEvent e)
	{
		bool result = base.OnTouchEvent(e);
		switch (e.Action)
		{
		case MotionEventActions.Down:
			return true;
		case MotionEventActions.Up:
		{
			float x = e.GetX();
			float y = e.GetY();
			_controller.AutoFocus((int)x, (int)y);
			break;
		}
		}
		return result;
	}
}
