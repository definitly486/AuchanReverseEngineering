using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base;

namespace Auchan.Android.Catalog;

public class ExpandableCategoryViewHolder : CachingViewHolder
{
	private bool _isSubCategory;

	private readonly TextView _titleLabel;

	public bool IsSubCategory
	{
		get
		{
			return _isSubCategory;
		}
		set
		{
			_isSubCategory = value;
			_titleLabel.SetPadding(value ? Converter.DpToPx(20f) : 0, _titleLabel.PaddingTop, _titleLabel.PaddingRight, _titleLabel.PaddingBottom);
			_titleLabel.Selected = value;
			_titleLabel.SetTextSize(ComplexUnitType.Sp, value ? 14 : 16);
		}
	}

	public ExpandableCategoryViewHolder(View itemView)
		: base(itemView)
	{
		_titleLabel = itemView.RequireViewById<TextView>(2131298655);
	}
}
