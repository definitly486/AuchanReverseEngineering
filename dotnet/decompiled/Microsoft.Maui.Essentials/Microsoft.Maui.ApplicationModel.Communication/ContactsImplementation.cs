using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Database;
using Android.Net;
using Android.Provider;

namespace Microsoft.Maui.ApplicationModel.Communication;

internal class ContactsImplementation : IContacts
{
	public Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken)
	{
		ICursor cursor = Application.Context.ContentResolver.Query(ContactsContract.Contacts.ContentUri, null, null, null, null);
		return Task.FromResult(GetEnumerable());
		IEnumerable<Contact> GetEnumerable()
		{
			if (cursor?.MoveToFirst() ?? false)
			{
				do
				{
					Contact contact = GetContact(cursor);
					if (contact != null)
					{
						yield return contact;
					}
				}
				while (cursor.MoveToNext());
			}
			cursor?.Close();
		}
	}

	private static Contact GetContact(ICursor cursor)
	{
		string id = GetString(cursor, "_id");
		string displayName = GetString(cursor, "display_name");
		IEnumerable<ContactPhone> phones = GetNumbers(id)?.Select((string p) => new ContactPhone(p));
		IEnumerable<ContactEmail> email = GetEmails(id)?.Select((string e) => new ContactEmail(e));
		var (namePrefix, givenName, middleName, familyName, nameSuffix) = GetName(id);
		return new Contact(id, namePrefix, givenName, middleName, familyName, nameSuffix, phones, email, displayName);
	}

	private static IEnumerable<string> GetNumbers(string id)
	{
		Uri uri = ContactsContract.CommonDataKinds.Phone.ContentUri.BuildUpon().AppendQueryParameter("remove_duplicate_entries", "1").Build();
		ICursor cursor = Application.Context.ContentResolver.Query(uri, null, "contact_id=?", new string[1] { id }, null);
		return ReadCursorItems(cursor, "data1");
	}

	private static IEnumerable<string> GetEmails(string id)
	{
		Uri uri = ContactsContract.CommonDataKinds.Email.ContentUri.BuildUpon().AppendQueryParameter("remove_duplicate_entries", "1").Build();
		ICursor cursor = Application.Context.ContentResolver.Query(uri, null, "contact_id=?", new string[1] { id }, null);
		return ReadCursorItems(cursor, "data1");
	}

	private static IEnumerable<string> ReadCursorItems(ICursor cursor, string dataKey)
	{
		if (cursor?.MoveToFirst() ?? false)
		{
			do
			{
				string text = GetString(cursor, dataKey);
				if (text != null)
				{
					yield return text;
				}
			}
			while (cursor.MoveToNext());
		}
		cursor?.Close();
	}

	private static (string Prefix, string Given, string Middle, string Family, string Suffix) GetName(string id)
	{
		string selection = "mimetype=? AND contact_id=?";
		string[] selectionArgs = new string[2] { "vnd.android.cursor.item/name", id };
		using ICursor cursor = Application.Context.ContentResolver.Query(ContactsContract.Data.ContentUri, null, selection, selectionArgs, null);
		if (cursor == null || !cursor.MoveToFirst())
		{
			return (Prefix: null, Given: null, Middle: null, Family: null, Suffix: null);
		}
		(string, string, string, string, string) result = (GetString(cursor, "data4"), GetString(cursor, "data2"), GetString(cursor, "data5"), GetString(cursor, "data3"), GetString(cursor, "data6"));
		cursor?.Close();
		return result;
	}

	private static string GetString(ICursor cursor, string column)
	{
		return cursor.GetString(cursor.GetColumnIndex(column));
	}
}
