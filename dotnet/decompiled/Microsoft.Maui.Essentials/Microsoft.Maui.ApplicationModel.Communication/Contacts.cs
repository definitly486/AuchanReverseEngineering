using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Maui.ApplicationModel.Communication;

public static class Contacts
{
	private static IContacts? defaultImplementation;

	public static IContacts Default => defaultImplementation ?? (defaultImplementation = new ContactsImplementation());

	public static Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		return Default.GetAllAsync(cancellationToken);
	}
}
