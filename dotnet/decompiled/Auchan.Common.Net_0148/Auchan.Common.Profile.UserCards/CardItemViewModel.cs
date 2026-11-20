using System;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;

namespace Auchan.Common.Profile.UserCards;

public class CardItemViewModel : BaseItemViewModel
{
	public string DeleteViewTitle = "Карта удалена!";

	[CompilerGenerated]
	private bool _003CIsRemoving_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CId_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPan_003Ek__BackingField;

	[CompilerGenerated]
	private CardSchemeType _003CScheme_003Ek__BackingField;

	public bool IsRemoving
	{
		[CompilerGenerated]
		get
		{
			return _003CIsRemoving_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsRemoving_003Ek__BackingField != value)
			{
				_003CIsRemoving_003Ek__BackingField = value;
				RaisePropertyChanged("IsRemoving");
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
		private set
		{
			if (_003CId_003Ek__BackingField != value)
			{
				_003CId_003Ek__BackingField = value;
				RaisePropertyChanged("Id");
			}
		}
	}

	public string Pan
	{
		[CompilerGenerated]
		get
		{
			return _003CPan_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CPan_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPan_003Ek__BackingField = value;
				RaisePropertyChanged("Pan");
			}
		}
	}

	public CardSchemeType Scheme
	{
		[CompilerGenerated]
		get
		{
			return _003CScheme_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CScheme_003Ek__BackingField != value)
			{
				_003CScheme_003Ek__BackingField = value;
				RaisePropertyChanged("Scheme");
			}
		}
	}

	public CardItemViewModel(CardModel model)
	{
		Id = model.Id;
		Pan = model.Pan.Replace("_", "••••••").Insert(12, " ").Insert(8, " ")
			.Insert(4, " ");
		Scheme = model.Scheme;
	}
}
