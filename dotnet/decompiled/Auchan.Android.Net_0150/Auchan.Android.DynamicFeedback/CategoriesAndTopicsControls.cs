using System;
using System.Collections.Generic;
using System.Linq;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Controls.ListPicker;
using Auchan.Common.DynamicFeedback;
using Google.Android.Material.TextField;

namespace Auchan.Android.DynamicFeedback;

internal sealed class CategoriesAndTopicsControls(View view)
{
	private readonly TextInputLayout _categoryTextInputLayout = view.RequireViewById<TextInputLayout>(2131296730);

	private readonly TextInputEditText _categoryEditText = view.RequireViewById<TextInputEditText>(2131296727);

	private readonly TextInputLayout _topicTextInputLayout = view.RequireViewById<TextInputLayout>(2131298716);

	private readonly TextInputEditText _topicEditText = view.RequireViewById<TextInputEditText>(2131298715);

	public View View => view;

	public void Setup(DynamicFeedbackViewModel dynamicFeedbackViewModel, ILifecycleOwner viewLifecycleOwner)
	{
		FieldItemViewModel categoryVm = dynamicFeedbackViewModel.CategoryItemViewModel;
		FieldItemViewModel topicVm = dynamicFeedbackViewModel.TopicItemViewModel;
		_categoryTextInputLayout.Hint = categoryVm.Hint;
		_topicTextInputLayout.Hint = topicVm.Hint;
		_topicEditText.Enabled = dynamicFeedbackViewModel.CategorySelected;
		categoryVm.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			_categoryEditText.Text = categoryVm.Text;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Text")))).AutoDisposeOnDestroy(viewLifecycleOwner);
		topicVm.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			_topicEditText.Text = topicVm.Text;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Text")))).AutoDisposeOnDestroy(viewLifecycleOwner);
		dynamicFeedbackViewModel.BindEvents(((View)_categoryEditText).OnClick((Action)delegate
		{
			categoryVm.ListPickerItemViewModels = dynamicFeedbackViewModel.GetItemsForCategories();
			ListPickerItemViewModel listPickerItemViewModel = categoryVm.ListPickerItemViewModels.FirstOrDefault((ListPickerItemViewModel x) => x.Text == _categoryEditText.Text);
			if (listPickerItemViewModel != null)
			{
				listPickerItemViewModel.Selected = true;
			}
			dynamicFeedbackViewModel.OnListPickerClicked(categoryVm);
		}), ((TextView)_categoryEditText).OnTextChanged((Action)delegate
		{
			categoryVm.Text = _categoryEditText.Text ?? "";
			if (!string.IsNullOrEmpty(_categoryEditText.Text))
			{
				dynamicFeedbackViewModel.OnCategorySelected(new ListPickerItemViewModel(_categoryEditText.Text, selected: true));
				_topicEditText.Enabled = dynamicFeedbackViewModel.CategorySelected;
				topicVm.Text = string.Empty;
			}
		}), ((View)_topicEditText).OnClick((Action)delegate
		{
			topicVm.ListPickerItemViewModels = dynamicFeedbackViewModel.GetItemsForTopics();
			ListPickerItemViewModel listPickerItemViewModel = topicVm.ListPickerItemViewModels.FirstOrDefault((ListPickerItemViewModel x) => x.Text == _topicEditText.Text);
			if (listPickerItemViewModel != null)
			{
				listPickerItemViewModel.Selected = true;
			}
			dynamicFeedbackViewModel.OnListPickerClicked(topicVm);
		}), ((TextView)_topicEditText).OnTextChanged((Action)delegate
		{
			topicVm.Text = _topicEditText.Text ?? "";
			if (!string.IsNullOrEmpty(_topicEditText.Text))
			{
				dynamicFeedbackViewModel.OnTopicSelected(new ListPickerItemViewModel(_topicEditText.Text, selected: true)).SafeFireAndForget((Action<Exception>)null, false);
			}
		})).AutoDisposeOnDestroy(viewLifecycleOwner);
	}
}
