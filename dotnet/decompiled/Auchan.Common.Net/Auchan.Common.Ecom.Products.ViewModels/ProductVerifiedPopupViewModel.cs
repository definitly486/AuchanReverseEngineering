using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;
using Auchan.Common.UniversalLinks;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Ecom.Products.ViewModels;

public sealed class ProductVerifiedPopupViewModel : ScreenViewModel
{
	public sealed class Parameter
	{
		public required IReadOnlyList<ProductCertificate> Certificates { get; init; }
	}

	private const string IntroTemplate = "Безопасность товара подтверждена";

	private const string SingleLinkText = "документами из реестра Росаккредитации";

	private const string MultiLinkText = "документом из реестра Росаккредитации";

	private readonly Lazy<IUniversalLinksService> _universalLinksService;

	public string Title => "Товар проверен";

	public string ButtonText => "Хорошо";

	public LinkedText IntroText { get; }

	public IReadOnlyList<ProductVerifiedLinkItemViewModel> Items { get; }

	public bool IsListVisible => Items.Count > 0;

	public UICommand<string> OpenLinkCommand { get; } = new UICommand<string>();

	public UICommand DismissCommand { get; } = new UICommand();

	public ProductVerifiedPopupViewModel(Parameter argument, Lazy<IUniversalLinksService> universalLinksService)
	{
		_universalLinksService = universalLinksService;
		IReadOnlyList<ProductCertificate> certificates = argument.Certificates;
		if (certificates.Count == 1)
		{
			string url = certificates[0].Url;
			IntroText = new LinkedText("Безопасность товара подтверждена {0}", "документами из реестра Росаккредитации", delegate
			{
				OpenLinkCommand.Trigger(url);
			});
			Items = Array.Empty<ProductVerifiedLinkItemViewModel>();
		}
		else
		{
			IntroText = new LinkedText("Безопасность товара подтверждена");
			Items = certificates.Select((ProductCertificate c) => new ProductVerifiedLinkItemViewModel(c.Url, "документом из реестра Росаккредитации", OpenLinkCommand)).ToImmutableList();
		}
		OpenLinkCommand.PerformDebouncingTask(OnOpenLink).Subscribe().AddTo(base.CloseDisposable);
	}

	private async Task OnOpenLink(string link)
	{
		DismissCommand.Trigger();
		await WaitForPause();
		if (_universalLinksService.Value.ShouldHandleLink(link))
		{
			_universalLinksService.Value.HandleLink(link).SafeFireAndForget((Action<Exception>)null, false);
			return;
		}
		try
		{
			Browser.OpenAsync(link);
		}
		catch
		{
		}
	}
}
