using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.PersonalCabinet;

namespace Auchan.Common.LoyaltyProgram;

public class LoyaltyTriggersManager : ILoyaltyTriggersManager
{
	private readonly IUserContext _userContext;

	private readonly IAdminContext _adnimContext;

	private bool isStepOneShownOnCurrentLifecycle;

	private bool isStepTwoShownOnCurrentLifecycle;

	private Loyalty _loyalty => _adnimContext.AppConfig?.Loyalty ?? new Loyalty();

	public int StepOneNumbersToShow => _loyalty.StepOne?.TimesToShowCount ?? 0;

	private bool StepOneShowCountHasRemainingShows => _userContext.LoyaltyTriggersTimesShown < StepOneNumbersToShow;

	public string APayRefillString => _loyalty.StepTwo?.APayRefillText ?? string.Empty;

	public string PersonalDataWarningString => _loyalty.StepTwo?.PersonalDataWarningText ?? string.Empty;

	public string RegistrationSuccessfulString => _loyalty.StepTwo?.RegistrationSuccessfulText ?? string.Empty;

	public string AuchanPayInfoMessage => _loyalty.StepTwo?.AuchanPayInfoMessage ?? string.Empty;

	public LoyaltyTriggersManager(IAdminContext adnimContext, IUserContext userContext)
	{
		_userContext = userContext;
		_adnimContext = adnimContext;
		_userContext.AfterLoggedIn += OnLoggedIn;
	}

	public bool IsStepOneLoyaltyEnabled(LoyaltyTriggerSource source)
	{
		if (_loyalty.StepOne == null)
		{
			return false;
		}
		if (_loyalty.StepTwo != null && _loyalty.StepTwo.IsEnabled)
		{
			return false;
		}
		if (StepOneShowCountHasRemainingShows && _loyalty.StepOne.IsEnabled && !isStepOneShownOnCurrentLifecycle && source == LoyaltyTriggerSource.Home)
		{
			return true;
		}
		if (_loyalty.StepOne.IsEnabled && source == LoyaltyTriggerSource.Cashback)
		{
			return true;
		}
		return false;
	}

	public bool IsStepTwoLoyaltyEnabled(LoyaltyTriggerSource source)
	{
		bool flag = _userContext.Profile?.LoyaltyFlag ?? false;
		if (_loyalty.StepTwo == null)
		{
			return false;
		}
		if (_loyalty.StepTwo.IsEnabled && !isStepTwoShownOnCurrentLifecycle && source == LoyaltyTriggerSource.Home)
		{
			return true;
		}
		if (_loyalty.StepTwo.IsEnabled && !flag && source == LoyaltyTriggerSource.Cashback)
		{
			return true;
		}
		return false;
	}

	public List<string> ShowStepOneLoyalty(LoyaltyTriggerSource source)
	{
		List<string> list = new List<string>();
		switch (source)
		{
		case LoyaltyTriggerSource.Home:
			if (IsStepOneLoyaltyEnabled(LoyaltyTriggerSource.Home))
			{
				list = _loyalty.StepOne?.LoyaltyPopupTexts;
				_userContext.LoyaltyTriggersTimesShown++;
			}
			else
			{
				list = _loyalty.StepTwo?.OnStartTriggerText;
			}
			break;
		case LoyaltyTriggerSource.Cashback:
			list = _loyalty.StepOne?.AuchanPayPopupTexts;
			break;
		}
		isStepOneShownOnCurrentLifecycle = true;
		isStepTwoShownOnCurrentLifecycle = true;
		return list ?? new List<string>();
	}

	public List<string> ShowStepTwoLoyalty()
	{
		return _loyalty.StepTwo?.ZeroBalanceText ?? new List<string>();
	}

	private Task OnLoggedIn()
	{
		isStepOneShownOnCurrentLifecycle = true;
		isStepTwoShownOnCurrentLifecycle = true;
		return Task.CompletedTask;
	}
}
