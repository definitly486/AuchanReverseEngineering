using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Ecom.Products.ViewModels;

namespace Auchan.Android.Catalog.ProductDetails;

[Register("Auchan.Android.Catalog.ProductDetails.ProductDetailsNutrientsView")]
public class ProductDetailsNutrientsView : BaseCustomView<ProductDetailsNutrientsElementViewModel>
{
	private TextView _title;

	private ViewGroup _proteinsLayout;

	private TextView _proteinsTitle;

	private TextView _proteins;

	private ViewGroup _fatsLayout;

	private TextView _fatsTitle;

	private TextView _fats;

	private ViewGroup _carbsLayout;

	private TextView _carbsTitle;

	private TextView _carbs;

	private ViewGroup _caloriesLayout;

	private TextView _caloriesTitle;

	private TextView _calories;

	protected override int LayoutId => 2131493172;

	public ProductDetailsNutrientsView(Context context)
		: base(context)
	{
	}

	public ProductDetailsNutrientsView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public ProductDetailsNutrientsView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public ProductDetailsNutrientsView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public ProductDetailsNutrientsView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	protected override void Init(Context context, IAttributeSet attrs = null)
	{
		base.Init(context, attrs);
		_title = base.View.RequireViewById<TextView>(2131298646);
		_proteinsLayout = base.View.RequireViewById<ViewGroup>(2131298108);
		_proteinsTitle = _proteinsLayout.RequireViewById<TextView>(2131298109);
		_proteins = _proteinsLayout.RequireViewById<TextView>(2131298107);
		_fatsLayout = base.View.RequireViewById<ViewGroup>(2131297146);
		_fatsTitle = _fatsLayout.RequireViewById<TextView>(2131297147);
		_fats = _fatsLayout.RequireViewById<TextView>(2131297145);
		_carbsLayout = base.View.RequireViewById<ViewGroup>(2131296636);
		_carbsTitle = _carbsLayout.RequireViewById<TextView>(2131296637);
		_carbs = _carbsLayout.RequireViewById<TextView>(2131296635);
		_caloriesLayout = base.View.RequireViewById<ViewGroup>(2131296608);
		_caloriesTitle = _caloriesLayout.RequireViewById<TextView>(2131296609);
		_calories = _caloriesLayout.RequireViewById<TextView>(2131296607);
	}

	protected override void DoBind()
	{
		Visibility = base.ViewModel.IsVisible.ToVisibility();
		_title.Text = base.ViewModel.Title;
		_proteinsLayout.Visibility = base.ViewModel.ProteinsAvailable.ToVisibility();
		_proteinsTitle.Text = base.ViewModel.ProteinsTitle;
		_proteins.Text = base.ViewModel.Proteins;
		_fatsLayout.Visibility = base.ViewModel.FatsAvailable.ToVisibility();
		_fatsTitle.Text = base.ViewModel.FatsTitle;
		_fats.Text = base.ViewModel.Fats;
		_carbsLayout.Visibility = base.ViewModel.CarbsAvailable.ToVisibility();
		_carbsTitle.Text = base.ViewModel.CarbsTitle;
		_carbs.Text = base.ViewModel.Carbs;
		_caloriesLayout.Visibility = base.ViewModel.CaloriesAvailable.ToVisibility();
		_caloriesTitle.Text = base.ViewModel.CaloriesTitle;
		_calories.Text = base.ViewModel.Calories;
	}
}
