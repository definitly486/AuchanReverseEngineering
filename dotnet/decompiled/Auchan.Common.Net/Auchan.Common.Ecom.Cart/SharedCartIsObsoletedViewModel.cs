using System;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.Ecom.Cart;

public sealed class SharedCartIsObsoletedViewModel : ScreenViewModel<SharedCartIsObsoletedViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<Result>
	{
		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	public enum Result
	{
		Nothing,
		Catalog,
		Home
	}

	private Result _result;

	private readonly Lazy<AppMetrica> _appMetrica;

	public UICommand CloseCommand { get; } = new UICommand();

	public string TitleText => "Кажется, ссылка на корзину устарела";

	public string DescriptionText => "Не беспокойтесь, переходите в наш каталог и выбирайте товары, которые вам понравились!";

	public string ToCatalogText => "В каталог";

	public string ToHomeText => "На главную";

	public SharedCartIsObsoletedViewModel(BrokerToken parameter, Lazy<AppMetrica> appMetrica)
		: base(parameter)
	{
		_appMetrica = appMetrica;
	}

	public void OnCatalog()
	{
		_result = Result.Catalog;
		Close();
		Task.Run((Action)_appMetrica.Value.ExpiredLinkToCatalog).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void OnHome()
	{
		_result = Result.Home;
		Close();
		Task.Run((Action)_appMetrica.Value.ExpiredLinkToMain).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void Close()
	{
		CloseCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(_result);
	}
}
