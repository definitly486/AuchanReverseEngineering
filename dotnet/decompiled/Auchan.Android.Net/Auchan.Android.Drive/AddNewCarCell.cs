using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.ConstraintLayout.Widget;

namespace Auchan.Android.Drive;

[Register("auchan.drive.add_car_cell")]
public class AddNewCarCell : ConstraintLayout
{
	public AddNewCarCell(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
		Init(Application.Context);
	}

	public AddNewCarCell(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Init(context);
	}

	public AddNewCarCell(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Init(context);
	}

	private void Init(Context context)
	{
		LayoutInflater.From(context).Inflate(2131492904, this, attachToRoot: true);
	}
}
