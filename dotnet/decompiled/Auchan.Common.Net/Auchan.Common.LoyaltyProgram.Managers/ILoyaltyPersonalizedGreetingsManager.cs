using System.ComponentModel;
using System.Threading.Tasks;
using Auchan.Common.LoyaltyProgram.Models;

namespace Auchan.Common.LoyaltyProgram.Managers;

public interface ILoyaltyPersonalizedGreetingsManager : INotifyPropertyChanged
{
	public enum GreetingType
	{
		ExistingCustomer,
		Retired
	}

	bool GreetingShouldBeShown { get; }

	GreetingType GreetingFor { get; }

	void TrySetupGreetingForOldUsers();

	void TrySetupGreetingForRetiredUsers();

	void SetGreetingShouldBeShown(bool shouldBeShown);

	Task LoadGreetingsToCacheIfNeeded();

	LoyaltyPersonalizedGreetingEntity GetPersonalizedGreeting();
}
