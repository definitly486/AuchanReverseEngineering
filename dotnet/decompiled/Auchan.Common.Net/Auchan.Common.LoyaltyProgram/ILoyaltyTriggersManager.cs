using System.Collections.Generic;
using Auchan.Common.LoyaltyProgram.Enums;

namespace Auchan.Common.LoyaltyProgram;

public interface ILoyaltyTriggersManager
{
	string APayRefillString { get; }

	string PersonalDataWarningString { get; }

	string RegistrationSuccessfulString { get; }

	string AuchanPayInfoMessage { get; }

	bool IsStepOneLoyaltyEnabled(LoyaltyTriggerSource source);

	bool IsStepTwoLoyaltyEnabled(LoyaltyTriggerSource source);

	List<string> ShowStepOneLoyalty(LoyaltyTriggerSource source);

	List<string> ShowStepTwoLoyalty();
}
