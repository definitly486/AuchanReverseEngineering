using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;

namespace Auchan.Android.Drive;

[Register("auchan.drive.car_cell")]
public class UserCarCell : ConstraintLayout
{
	private TextView _carNumber;

	private TextView _carDescription;

	public string CarNumber { get; set; }

	public string CarDescription { get; set; }

	public UserCarCell(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
		Init(Application.Context);
	}

	public UserCarCell(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Init(context);
	}

	public UserCarCell(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Init(context);
	}

	public void ForceChangeData()
	{
		if (_carNumber != null && _carDescription != null)
		{
			_carNumber.Text = CarNumber;
			_carDescription.Text = CarDescription;
		}
	}

	private void Init(Context context)
	{
		View view = LayoutInflater.From(context).Inflate(2131493530, this, attachToRoot: true);
		_carNumber = view.RequireViewById<TextView>(2131296628);
		_carDescription = view.RequireViewById<TextView>(2131296627);
	}
}
