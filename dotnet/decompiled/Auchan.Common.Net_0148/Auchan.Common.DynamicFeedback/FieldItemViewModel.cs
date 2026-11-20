using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Controls.ListPicker;
using Auchan.Common.DynamicFeedback.Responses;
using Auchan.Common.PersonalCabinet.Authorization;

namespace Auchan.Common.DynamicFeedback;

public class FieldItemViewModel : BaseItemViewModel
{
	public readonly FieldType FieldType;

	private string _hint;

	public bool? BoolResult;

	[CompilerGenerated]
	private string _003CText_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CMaxLength_003Ek__BackingField;

	public bool HasEmailMask;

	public bool HasPhoneMask;

	[CompilerGenerated]
	private List<ListPickerItemViewModel> _003CListPickerItemViewModels_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CBinding_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CDisplay_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CError_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorText_003Ek__BackingField;

	public string Hint
	{
		get
		{
			if (!Binding)
			{
				return _hint;
			}
			return _hint + "*";
		}
		set
		{
			if (!string.Equals(_hint, value, StringComparison.Ordinal))
			{
				_hint = value;
				RaisePropertyChanged("Hint");
			}
		}
	}

	public long Position { get; }

	public string EnglishName { get; }

	public string Text
	{
		[CompilerGenerated]
		get
		{
			return _003CText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				string text = Text;
				_003CText_003Ek__BackingField = value;
				RaisePropertyChanged("IsEmailValid");
				RaisePropertyChanged("IsPhoneValid");
				string text2 = Text;
				OnTextChanged(text, text2);
				RaisePropertyChanged("Text");
			}
		}
	} = string.Empty;

	public int MaxLength
	{
		[CompilerGenerated]
		get
		{
			return _003CMaxLength_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CMaxLength_003Ek__BackingField != value)
			{
				_003CMaxLength_003Ek__BackingField = value;
				RaisePropertyChanged("MaxLength");
			}
		}
	} = 5000;

	public string Mask { get; }

	public bool HasAnyMask => !string.IsNullOrEmpty(Mask);

	public bool IsEmailValid
	{
		get
		{
			if (!string.IsNullOrEmpty(Text))
			{
				return AuthValidationHelper.IsValidEmail(Text);
			}
			return true;
		}
	}

	public bool IsPhoneValid
	{
		get
		{
			if (!string.IsNullOrEmpty(Text))
			{
				return AuthValidationHelper.IsValidPhone(Text);
			}
			return true;
		}
	}

	public List<ListPickerItemViewModel> ListPickerItemViewModels
	{
		[CompilerGenerated]
		get
		{
			return _003CListPickerItemViewModels_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CListPickerItemViewModels_003Ek__BackingField, value))
			{
				_003CListPickerItemViewModels_003Ek__BackingField = value;
				RaisePropertyChanged("HasSelectedItemInListPicker");
				RaisePropertyChanged("ListPickerItemViewModels");
			}
		}
	} = new List<ListPickerItemViewModel>();

	public bool HasSelectedItemInListPicker => ListPickerItemViewModels.Any((ListPickerItemViewModel x) => x.Selected);

	public bool Binding
	{
		[CompilerGenerated]
		get
		{
			return _003CBinding_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CBinding_003Ek__BackingField != value)
			{
				_003CBinding_003Ek__BackingField = value;
				RaisePropertyChanged("Hint");
				RaisePropertyChanged("Binding");
			}
		}
	}

	public bool Display
	{
		[CompilerGenerated]
		get
		{
			return _003CDisplay_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CDisplay_003Ek__BackingField != value)
			{
				_003CDisplay_003Ek__BackingField = value;
				RaisePropertyChanged("Display");
			}
		}
	}

	public bool Error
	{
		[CompilerGenerated]
		get
		{
			return _003CError_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CError_003Ek__BackingField != value)
			{
				_003CError_003Ek__BackingField = value;
				RaisePropertyChanged("Error");
			}
		}
	}

	public string ErrorText
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorText_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorText");
			}
		}
	} = string.Empty;

	public FieldItemViewModel(FieldType fieldType, FeedbackFieldDto fieldDto)
	{
		FieldType = fieldType;
		_hint = fieldDto.NameFos ?? "";
		EnglishName = fieldDto.EnglishName ?? "";
		Position = fieldDto.Position;
		Binding = fieldDto.Binding;
		Display = fieldDto.Display;
		MaxLength = fieldType switch
		{
			FieldType.TextField50 => 50, 
			FieldType.TextField250 => 250, 
			FieldType.TextField500 => 500, 
			_ => MaxLength, 
		};
		switch (fieldType)
		{
		case FieldType.Date:
			Mask = "[00].[00].[00]";
			break;
		case FieldType.DateTime:
			Mask = "[00].[00].[00], [00]:[00]";
			break;
		default:
			Mask = string.Empty;
			break;
		}
		Mask? mask = fieldDto.Mask;
		if (mask.HasValue)
		{
			switch (mask.GetValueOrDefault())
			{
			case Auchan.Common.DynamicFeedback.Responses.Mask.PhoneMask:
				Mask = "+7 ([000]) [000]-[00]-[00]";
				HasPhoneMask = true;
				break;
			case Auchan.Common.DynamicFeedback.Responses.Mask.EmailMask:
				HasEmailMask = true;
				break;
			}
		}
	}

	public void OnListItemSelected(ListPickerItemViewModel selectedListPickerItemViewModel)
	{
		Text = selectedListPickerItemViewModel.Text;
		ListPickerItemViewModels.ForEach(delegate(ListPickerItemViewModel j)
		{
			j.Selected = false;
		});
		ListPickerItemViewModel listPickerItemViewModel = ListPickerItemViewModels.FirstOrDefault((ListPickerItemViewModel x) => x.Text == selectedListPickerItemViewModel.Text);
		if (listPickerItemViewModel != null)
		{
			listPickerItemViewModel.Selected = true;
		}
	}

	public void ShowNotFillError()
	{
		Error = true;
		ErrorText = "Поле не заполнено полностью";
	}

	public void ShowRequiredError()
	{
		Error = true;
		ErrorText = "Поле обязательное";
	}

	public void ShowMaxLenghtReachedError()
	{
		Error = true;
		ErrorText = $"Предел символов: {MaxLength}";
	}

	public void ShowEmailError()
	{
		Error = true;
		ErrorText = "Некорректно введён Email";
	}

	public void RemoveError()
	{
		Error = false;
		ErrorText = string.Empty;
	}

	private void OnTextChanged(string old, string @new)
	{
		RemoveError();
		if (@new.Length == MaxLength)
		{
			ShowMaxLenghtReachedError();
		}
		else if (HasEmailMask && !IsEmailValid)
		{
			ShowEmailError();
		}
	}
}
