using System.Collections.Generic;

namespace Auchan.Common.LoyaltyProgram.Models;

public class StepTwo
{
	public bool IsEnabled { get; set; }

	public List<string>? PositiveBalanceTexts { get; set; }

	public List<string>? ZeroBalanceText { get; set; }

	public List<string>? OnStartTriggerText { get; set; }

	public string? APayRefillText { get; set; }

	public string? PersonalDataWarningText { get; set; }

	public string? RegistrationSuccessfulText { get; set; }

	public string? AuchanPayInfoMessage { get; set; }
}
