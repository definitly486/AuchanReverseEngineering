using System;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;

namespace Auchan.Common.InfoPages.Models;

public class FAQEntry : BaseItemViewModel
{
	[CompilerGenerated]
	private bool _003CisExpanded_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CId_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CQuestion_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAnswer_003Ek__BackingField;

	public bool isExpanded
	{
		[CompilerGenerated]
		get
		{
			return _003CisExpanded_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CisExpanded_003Ek__BackingField != value)
			{
				_003CisExpanded_003Ek__BackingField = value;
				RaisePropertyChanged("isExpanded");
			}
		}
	}

	public int Id
	{
		[CompilerGenerated]
		get
		{
			return _003CId_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CId_003Ek__BackingField != value)
			{
				_003CId_003Ek__BackingField = value;
				RaisePropertyChanged("Id");
			}
		}
	}

	public string Question
	{
		[CompilerGenerated]
		get
		{
			return _003CQuestion_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CQuestion_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CQuestion_003Ek__BackingField = value;
				RaisePropertyChanged("Question");
			}
		}
	}

	public string Answer
	{
		[CompilerGenerated]
		get
		{
			return _003CAnswer_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CAnswer_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAnswer_003Ek__BackingField = value;
				RaisePropertyChanged("Answer");
			}
		}
	}

	public FAQEntry(int id, string question, string answer)
	{
		Id = id;
		Question = question;
		Answer = answer;
	}
}
