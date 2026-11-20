using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Models;

namespace Auchan.Common.LoyaltyProgram.ViewModels;

public class LoyaltyPersonalizedGreetingViewModel : ScreenViewModel
{
	private readonly ILoyaltyPersonalizedGreetingsManager _personalizedGreetingsManager;

	[CompilerGenerated]
	private string _003CTextHtml_003Ek__BackingField;

	protected override string ScreenName
	{
		get
		{
			if (_personalizedGreetingsManager.GreetingFor != ILoyaltyPersonalizedGreetingsManager.GreetingType.Retired)
			{
				return "entry_popup_existing_customer";
			}
			return "entry_popup_pensioner";
		}
	}

	public string TextHtml
	{
		[CompilerGenerated]
		get
		{
			return _003CTextHtml_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTextHtml_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTextHtml_003Ek__BackingField = value;
				RaisePropertyChanged("TextHtml");
			}
		}
	} = string.Empty;

	public string ContinueButtonText => "Продолжить";

	public LoyaltyPersonalizedGreetingViewModel(ILoyaltyPersonalizedGreetingsManager personalizedGreetingsManager)
	{
		_personalizedGreetingsManager = personalizedGreetingsManager;
	}

	protected override async Task Start()
	{
		await base.Start();
		LoyaltyPersonalizedGreetingEntity personalizedGreeting = _personalizedGreetingsManager.GetPersonalizedGreeting();
		TextHtml = personalizedGreeting.GreetingMessage;
	}

	public void OnClose()
	{
		_personalizedGreetingsManager.SetGreetingShouldBeShown(shouldBeShown: false);
	}
}
