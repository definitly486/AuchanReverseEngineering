using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;

public interface IContactsLoader
{
	bool HasLoadedContacts { get; }

	IReadOnlyList<ContactViewModel> LoadedContacts { get; }

	Task LoadContacts();
}
