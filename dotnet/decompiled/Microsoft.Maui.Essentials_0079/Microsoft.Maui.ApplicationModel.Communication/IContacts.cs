using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Maui.ApplicationModel.Communication;

public interface IContacts
{
	Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
}
