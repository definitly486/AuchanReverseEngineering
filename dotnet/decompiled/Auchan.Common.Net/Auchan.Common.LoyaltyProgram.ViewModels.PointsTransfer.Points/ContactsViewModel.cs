using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Extensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;

public class ContactsViewModel : ScreenViewModel
{
	private readonly IContactsLoader _contactsLoader;

	private readonly Subject<string> _setNumberAndClose = new Subject<string>();

	private List<ContactViewModel> _allContacts = new List<ContactViewModel>();

	[CompilerGenerated]
	private string _003CSearchString_003Ek__BackingField;

	public ObservableRangeCollection<ContactViewModel> ContactsToDisplay = new ObservableRangeCollection<ContactViewModel>();

	[CompilerGenerated]
	private bool _003CInProgressState_003Ek__BackingField;

	public string ScreenTitle => "Контакты";

	public string SearchString
	{
		[CompilerGenerated]
		get
		{
			return _003CSearchString_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CSearchString_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSearchString_003Ek__BackingField = value;
				RaisePropertyChanged("SearchString");
			}
		}
	} = string.Empty;

	public string SearchPlaceholder => "Имя или номер телефона";

	public bool InProgressState
	{
		[CompilerGenerated]
		get
		{
			return _003CInProgressState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CInProgressState_003Ek__BackingField != value)
			{
				_003CInProgressState_003Ek__BackingField = value;
				RaisePropertyChanged("InProgressState");
			}
		}
	} = true;

	public IObservable<string> SetNumberAndCloseCommand => _setNumberAndClose.Debounce();

	public ContactsViewModel(IContactsLoader contactsLoader)
	{
		_contactsLoader = contactsLoader;
	}

	protected override async Task Start()
	{
		await base.Start();
		Task.Run((Func<Task?>)LoadContactsIfNeeded).SafeFireAndForget((Action<Exception>)null, false);
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		this.OnPropertyChanges((ContactsViewModel x) => x.SearchString).Throttle(TimeSpan.FromMilliseconds(400L)).Subscribe(Search)
			.AddTo(base.PauseDisposable);
	}

	public void OnContactSelected(ContactViewModel contactViewModel)
	{
		string text = Regex.Replace(contactViewModel.Phone, "^(\\+)|\\D", "$1", RegexOptions.None, TimeSpan.FromSeconds(60L));
		int length = text.Length;
		if (length != 11)
		{
			if (length != 12 || text[0] != '+' || text[1] != '7')
			{
				goto IL_0074;
			}
			text = text.Remove(0, 2);
		}
		else
		{
			if (text[0] != '7' && text[0] != '8')
			{
				goto IL_0074;
			}
			text = text.Remove(0, 1);
		}
		goto IL_007a;
		IL_0074:
		text = string.Empty;
		goto IL_007a;
		IL_007a:
		_setNumberAndClose.OnNext(text);
	}

	private async Task LoadContactsIfNeeded()
	{
		if (!_contactsLoader.HasLoadedContacts)
		{
			await _contactsLoader.LoadContacts();
		}
		_allContacts.AddRange(_contactsLoader.LoadedContacts);
		ContactsToDisplay.ReplaceRange(_allContacts);
		InProgressState = false;
	}

	private void Search(string text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			ContactsToDisplay.ReplaceRange(_allContacts);
			return;
		}
		try
		{
			text = text[0] switch
			{
				'+' => text.TrimStart('+', '7'), 
				'7' => text.Remove(0, 1), 
				'8' => text.Remove(0, 1), 
				_ => text, 
			};
			text = text.ToLower();
			ContactsToDisplay.ReplaceRange(_allContacts.Where((ContactViewModel x) => x.FullName.ToLower().Contains(text) || x.Phone.Contains(text) || Regex.Replace(x.Phone, "^(\\+)|\\D", "$1", RegexOptions.None, TimeSpan.FromSeconds(60L)).Contains(text)));
		}
		catch
		{
		}
	}
}
