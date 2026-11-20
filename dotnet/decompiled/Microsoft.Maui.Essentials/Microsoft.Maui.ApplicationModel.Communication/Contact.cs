using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Microsoft.Maui.ApplicationModel.Communication;

public class Contact
{
	private string displayName;

	[CompilerGenerated]
	private string _003CId_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CNamePrefix_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CMiddleName_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CNameSuffix_003Ek__BackingField;

	public string Id
	{
		[CompilerGenerated]
		set
		{
			_003CId_003Ek__BackingField = value;
		}
	}

	public string DisplayName
	{
		get
		{
			if (string.IsNullOrWhiteSpace(displayName))
			{
				return BuildDisplayName();
			}
			return displayName;
		}
		private set
		{
			displayName = value;
		}
	}

	public string NamePrefix
	{
		[CompilerGenerated]
		set
		{
			_003CNamePrefix_003Ek__BackingField = value;
		}
	}

	public string GivenName { get; set; }

	public string MiddleName
	{
		[CompilerGenerated]
		set
		{
			_003CMiddleName_003Ek__BackingField = value;
		}
	}

	public string FamilyName { get; set; }

	public string NameSuffix
	{
		[CompilerGenerated]
		set
		{
			_003CNameSuffix_003Ek__BackingField = value;
		}
	}

	public List<ContactPhone> Phones { get; } = new List<ContactPhone>();

	public List<ContactEmail> Emails { get; } = new List<ContactEmail>();

	public Contact(string id, string namePrefix, string givenName, string middleName, string familyName, string nameSuffix, IEnumerable<ContactPhone> phones, IEnumerable<ContactEmail> email, string displayName = null)
	{
		Id = id;
		NamePrefix = namePrefix;
		GivenName = givenName;
		MiddleName = middleName;
		FamilyName = familyName;
		NameSuffix = nameSuffix;
		Phones.AddRange(phones?.ToList());
		Emails.AddRange(email?.ToList());
		DisplayName = displayName;
	}

	public override string ToString()
	{
		return DisplayName;
	}

	private string BuildDisplayName()
	{
		if (string.IsNullOrWhiteSpace(GivenName))
		{
			return FamilyName;
		}
		if (string.IsNullOrWhiteSpace(FamilyName))
		{
			return GivenName;
		}
		return GivenName + " " + FamilyName;
	}
}
