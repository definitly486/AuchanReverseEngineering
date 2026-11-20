using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Models;

namespace Auchan.Common.LoyaltyProgram.ViewModels;

public class HintItemViewModel : BaseItemViewModel
{
	private readonly Subject<Unit> _next = new Subject<Unit>();

	private readonly Subject<Unit> _close = new Subject<Unit>();

	[CompilerGenerated]
	private AttributedText? _003CText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsLast_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CIndex_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsVisible_003Ek__BackingField;

	public AttributedText? Text
	{
		[CompilerGenerated]
		get
		{
			return _003CText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CText_003Ek__BackingField, value))
			{
				_003CText_003Ek__BackingField = value;
				RaisePropertyChanged("Text");
			}
		}
	}

	public bool IsLast
	{
		[CompilerGenerated]
		get
		{
			return _003CIsLast_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsLast_003Ek__BackingField != value)
			{
				_003CIsLast_003Ek__BackingField = value;
				RaisePropertyChanged("IsLast");
			}
		}
	}

	public int Index
	{
		[CompilerGenerated]
		get
		{
			return _003CIndex_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIndex_003Ek__BackingField != value)
			{
				_003CIndex_003Ek__BackingField = value;
				RaisePropertyChanged("Index");
			}
		}
	}

	public bool IsVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsVisible_003Ek__BackingField != value)
			{
				_003CIsVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsVisible");
			}
		}
	}

	public string NextString => "Далее";

	public string CloseString => "Закрыть";

	public IObservable<Unit> NextCommand => _next.Debounce();

	public IObservable<Unit> CloseCommand => _close.Debounce();

	public void Next()
	{
		_next.OnNext(Unit.Default);
	}

	public void Close()
	{
		_close.OnNext(Unit.Default);
	}

	public void SetContext(HintEntity entity)
	{
		Text = entity.Text;
		IsLast = entity.IsLast;
		Index = entity.Index;
	}
}
