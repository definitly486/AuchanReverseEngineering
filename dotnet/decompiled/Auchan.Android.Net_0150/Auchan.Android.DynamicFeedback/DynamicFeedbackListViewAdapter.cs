using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using AndroidX.Lifecycle;
using Auchan.Android.Common;
using Auchan.Android.DynamicFeedback.Controls;
using Auchan.Common.DynamicFeedback;
using Google.Android.Material.CheckBox;

namespace Auchan.Android.DynamicFeedback;

public class DynamicFeedbackListViewAdapter : VariableItemsListViewAdapter<DynamicFeedbackViewModel, FieldItemViewModel>
{
	public DynamicFeedbackListViewAdapter(Context context, DynamicFeedbackViewModel viewModel, ICollection<FieldItemViewModel> itemViewModels, ILifecycleOwner viewLifecycleOwner)
		: base(context, viewModel, itemViewModels, viewLifecycleOwner)
	{
	}

	protected override View GetViewFromType(ViewGroup container, FieldItemViewModel fieldItemViewModel)
	{
		switch (fieldItemViewModel.FieldType)
		{
		case FieldType.Bool:
			return new MaterialCheckBox(_context)
			{
				Text = fieldItemViewModel.Hint
			};
		case FieldType.Date:
		case FieldType.DateTime:
			return new DateField(_context, base.ViewModel, fieldItemViewModel, _viewLifecycleOwner);
		case FieldType.Integer:
			return new NumericField(_context, fieldItemViewModel, _viewLifecycleOwner);
		case FieldType.Float:
			return new NumericField(_context, fieldItemViewModel, _viewLifecycleOwner);
		case FieldType.ListSelection:
			return new ListSelectionField(_context, base.ViewModel, fieldItemViewModel, _viewLifecycleOwner);
		case FieldType.TextField50:
		case FieldType.TextField250:
		case FieldType.TextField500:
		case FieldType.TextFieldUnlimited:
			return new TextField(_context, fieldItemViewModel, _viewLifecycleOwner);
		case FieldType.File:
			return new FileSelectionField(_context, base.ViewModel, _viewLifecycleOwner);
		case FieldType.Info:
			return new InfoView(_context, fieldItemViewModel, _viewLifecycleOwner);
		case FieldType.Warning:
			return new WarningView(_context, base.ViewModel, _viewLifecycleOwner);
		case FieldType.Header:
			return new HeaderView(_context, base.ViewModel, _viewLifecycleOwner);
		case FieldType.SendButton:
			return new SendButtonView(_context, base.ViewModel, _viewLifecycleOwner);
		default:
			throw new Exception("Bad type");
		}
	}
}
