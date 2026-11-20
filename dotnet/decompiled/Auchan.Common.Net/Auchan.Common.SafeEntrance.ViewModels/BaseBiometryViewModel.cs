using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Navigation;
using Auchan.Common.SafeEntrance.Enums;

namespace Auchan.Common.SafeEntrance.ViewModels;

public abstract class BaseBiometryViewModel : ScreenViewModel
{
	private readonly Subject<Unit> _close = new Subject<Unit>();

	[CompilerGenerated]
	private IList<CodeStates> _003CCodeStates_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CEnteredPinCode_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsWrongPinCodeEntered_003Ek__BackingField;

	public int PinCodeLength => 4;

	public IObservable<Unit> CloseCommand => _close.Debounce();

	public virtual string Title { get; } = string.Empty;

	public virtual string Description => string.Empty;

	public virtual string Subtitle => string.Empty;

	public virtual string EnteredWrongPinCode => string.Empty;

	public IList<CodeStates> CodeStates
	{
		[CompilerGenerated]
		get
		{
			return _003CCodeStates_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CCodeStates_003Ek__BackingField, value))
			{
				_003CCodeStates_003Ek__BackingField = value;
				RaisePropertyChanged("CodeStates");
			}
		}
	} = new List<CodeStates>();

	protected string EnteredPinCode
	{
		[CompilerGenerated]
		get
		{
			return _003CEnteredPinCode_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CEnteredPinCode_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CEnteredPinCode_003Ek__BackingField = value;
				RaisePropertyChanged("EnteredPinCode");
			}
		}
	} = string.Empty;

	public bool IsWrongPinCodeEntered
	{
		[CompilerGenerated]
		get
		{
			return _003CIsWrongPinCodeEntered_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsWrongPinCodeEntered_003Ek__BackingField != value)
			{
				_003CIsWrongPinCodeEntered_003Ek__BackingField = value;
				RaisePropertyChanged("IsWrongPinCodeEntered");
			}
		}
	}

	protected BaseBiometryViewModel()
	{
		Init();
	}

	protected void Init()
	{
		CodeStates.Clear();
		for (int i = 0; i < 4; i++)
		{
			CodeStates.Add(Auchan.Common.SafeEntrance.Enums.CodeStates.Empty);
		}
		EnteredPinCode = string.Empty;
	}

	public void AddPinCodeDigit(int digit)
	{
		if (char.TryParse(digit.ToString(), out var result))
		{
			EnteredPinCode += result;
			CodeStates.Clear();
			for (int i = 0; i < 4; i++)
			{
				CodeStates.Add((i < EnteredPinCode.Length) ? Auchan.Common.SafeEntrance.Enums.CodeStates.Field : Auchan.Common.SafeEntrance.Enums.CodeStates.Empty);
			}
			RaisePropertyChanged("CodeStates");
			if (EnteredPinCode.Length == 4)
			{
				ProcceedWithEnteredPinCodeAsync(EnteredPinCode);
			}
		}
	}

	public void RemovePinCodeDigit()
	{
		if (EnteredPinCode.Length > 0)
		{
			EnteredPinCode = EnteredPinCode.Remove(EnteredPinCode.Length - 1);
			CodeStates.Clear();
			for (int i = 0; i < 4; i++)
			{
				CodeStates.Add((i < EnteredPinCode.Length) ? Auchan.Common.SafeEntrance.Enums.CodeStates.Field : Auchan.Common.SafeEntrance.Enums.CodeStates.Empty);
			}
			RaisePropertyChanged("CodeStates");
		}
	}

	public override NavigationPossibilityType OnNavigateFrom()
	{
		return NavigationPossibilityType.Impossible;
	}

	protected virtual Task ProcceedWithEnteredPinCodeAsync(string pinCode)
	{
		return Task.FromResult(result: true);
	}

	protected virtual Task WrongPinCodeEntered()
	{
		IsWrongPinCodeEntered = true;
		EnteredPinCode = string.Empty;
		CodeStates.Clear();
		for (int i = 0; i < 4; i++)
		{
			CodeStates.Add(Auchan.Common.SafeEntrance.Enums.CodeStates.Error);
		}
		RaisePropertyChanged("CodeStates");
		RaisePropertyChanged("EnteredWrongPinCode");
		RaisePropertyChanged("Subtitle");
		RaisePropertyChanged("Description");
		return Task.FromResult(result: true);
	}

	protected virtual void Close()
	{
		_close.OnNext(Unit.Default);
	}
}
