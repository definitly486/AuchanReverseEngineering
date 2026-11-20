using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base.WidgetBases;
using Auchan.Common.DynamicFeedback;

namespace Auchan.Android.DynamicFeedback.Controls;

public class InfoView : LinearLayoutWidgetBase
{
	public InfoView(Context context, FieldItemViewModel fieldItemViewModel, ILifecycleOwner lifecycleOwner)
		: base(context)
	{
		View? view = View.Inflate(context, 2131493158, this);
		TextView textView = view.RequireViewById<TextView>(2131297367);
		TextView textView2 = view.RequireViewById<TextView>(2131297366);
		textView.Text = "Данные о товаре";
		textView2.Text = fieldItemViewModel.Hint;
	}
}
