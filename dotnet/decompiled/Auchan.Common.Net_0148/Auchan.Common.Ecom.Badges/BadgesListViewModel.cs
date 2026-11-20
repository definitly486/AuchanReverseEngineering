using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.UniversalLinks;

namespace Auchan.Common.Ecom.Badges;

public sealed class BadgesListViewModel : ScreenViewModel
{
	public sealed class Parameter
	{
		public required BadgesListModel Badges { get; init; }
	}

	private readonly Lazy<IUniversalLinksService> _universalLinksService;

	[CompilerGenerated]
	private double _003CTextStartMargin_003Ek__BackingField;

	public IReadOnlyList<BadgeListItemViewModel> Items { get; }

	public UICommand<string> OpenLinkCommand { get; } = new UICommand<string>();

	public UICommand DismissCommand { get; } = new UICommand();

	public double TextStartMargin
	{
		[CompilerGenerated]
		get
		{
			return _003CTextStartMargin_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CTextStartMargin_003Ek__BackingField == value))
			{
				_003CTextStartMargin_003Ek__BackingField = value;
				RaisePropertyChanged("TextStartMargin");
			}
		}
	}

	public BadgesListViewModel(Parameter argument, Lazy<IUniversalLinksService> universalLinksService)
	{
		_universalLinksService = universalLinksService;
		Items = (from i in argument.Badges.Items
			where !string.IsNullOrEmpty(i.Item.Description)
			select new BadgeListItemViewModel(this, i, OpenLinkCommand)).ToImmutableList();
		OpenLinkCommand.PerformDebouncingTask(OnOpenLinkCommand).Subscribe().AddTo(base.CloseDisposable);
	}

	public void SetTextStartMargin(double margin)
	{
		TextStartMargin = Math.Max(TextStartMargin, margin);
	}

	private async Task OnOpenLinkCommand(string link)
	{
		DismissCommand.Trigger();
		await WaitForPause();
		if (_universalLinksService.Value.ShouldHandleLink(link))
		{
			_universalLinksService.Value.HandleLink(link).SafeFireAndForget((Action<Exception>)null, false);
		}
	}
}
