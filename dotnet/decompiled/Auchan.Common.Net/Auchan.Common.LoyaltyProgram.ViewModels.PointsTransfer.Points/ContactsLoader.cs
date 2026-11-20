using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel.Communication;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;

public class ContactsLoader : IContactsLoader
{
	private readonly List<ContactViewModel> _loadedContacts = new List<ContactViewModel>();

	public bool HasLoadedContacts => _loadedContacts.Count > 0;

	public IReadOnlyList<ContactViewModel> LoadedContacts => _loadedContacts;

	public async Task LoadContacts()
	{
		try
		{
			IEnumerable<Contact> enumerable = await Contacts.GetAllAsync();
			if (enumerable == null)
			{
				return;
			}
			IEnumerable<ContactViewModel> collection = from contact in enumerable
				select new ContactViewModel(contact.GivenName ?? string.Empty, contact.FamilyName ?? string.Empty, contact.Phones.FirstOrDefault((ContactPhone phone) => !string.IsNullOrWhiteSpace(phone.PhoneNumber) && phone.PhoneNumber.Length > 10)?.PhoneNumber ?? contact.Phones.FirstOrDefault((ContactPhone phone) => !string.IsNullOrWhiteSpace(phone.PhoneNumber))?.PhoneNumber ?? string.Empty) into x
				where !string.IsNullOrEmpty(x.Phone)
				select x;
			_loadedContacts.Clear();
			_loadedContacts.AddRange(collection);
		}
		catch (Exception)
		{
		}
	}
}
