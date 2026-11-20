using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.Managers.Dialogs;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Products.ViewModels;

public sealed class CollectionProductsPreloaderViewModel : ScreenViewModel
{
	public sealed class Parameter
	{
		public required string Url { get; init; }
	}

	private bool _firstTime = true;

	private readonly Parameter _parameter;

	private readonly ICategoryRepository _categoryRepository;

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<IAgeGateDialog> _ageGateDialog;

	private readonly Lazy<IDataBroker> _dataBroker;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.InProgress;

	public string ProgressTitle => "Загружаем товары…";

	public string ErrorTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorTitle");
			}
		}
	} = "Упс! Что-то пошло не так.";

	public string ErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorMessage");
			}
		}
	} = "Небольшие технические проблемы,\nпопробуйте обновить экран.";

	public UICommand RetryCommand { get; } = new UICommand();

	public UICommand GoBackCommand { get; } = new UICommand();

	public UICommand<BrokerToken> OpenCollectionProductsCommand { get; } = new UICommand<BrokerToken>();

	public CollectionProductsPreloaderViewModel(Parameter parameter, ICategoryRepository categoryRepository, Lazy<IEcomContext> ecomContext, Lazy<IAgeGateDialog> ageGateDialog, Lazy<IDataBroker> dataBroker)
	{
		_parameter = parameter;
		_categoryRepository = categoryRepository;
		_ecomContext = ecomContext;
		_ageGateDialog = ageGateDialog;
		_dataBroker = dataBroker;
	}

	protected override async Task Start()
	{
		await base.Start();
		Category category = await GetCategoryAsync();
		if (category == null)
		{
			GoBackCommand.Trigger();
			return;
		}
		bool flag = category.IsAdult && _ecomContext.Value.AgeGateAgreement != AgreeState.Yes;
		if (flag)
		{
			flag = await _ageGateDialog.Value.ShowAgeGateDialogAsync() != AgreeState.Yes;
		}
		if (flag)
		{
			GoBackCommand.Trigger();
			return;
		}
		Category category2 = category;
		IReadOnlyList<Category> items = category.Items;
		if (items != null && items.Count == 1)
		{
			category2 = category.Items[0];
		}
		OpenCollectionProductsCommand.Trigger(_dataBroker.Value.Push(new CollectionProductsViewModel.Parameter(category2)));
		State = VisualState.Default;
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		if (_firstTime)
		{
			_firstTime = false;
		}
		else
		{
			GoBackCommand.Trigger();
		}
	}

	private async Task<Category?> GetCategoryAsync()
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		Uri uri = new Uri(_parameter.Url);
		NameValueCollection query = HttpUtility.ParseQueryString(uri.Query);
		if (long.TryParse(query["id"], out var id) && (await _categoryRepository.GetCachedTopCategories(promoOnly: false, activeOnly: false, cashbackOnly: false, showHidden: true)).TryGetValue(out var value))
		{
			return value.FirstOrDefaultRecursive((Category x) => x.Id == id, (Category x) => x.Items);
		}
		string pathCode = query["code"];
		string text = uri.LocalPath.Trim('/');
		if (string.IsNullOrEmpty(pathCode) && text.StartsWith("catalog/kollekcii/"))
		{
			pathCode = text.Substring("catalog/kollekcii/".Length);
		}
		if (pathCode == null && text.StartsWith("catalog/"))
		{
			string[] pathComponents = text.Substring("catalog/".Length).Split("/");
			if (pathComponents.Length != 0)
			{
				Result<IReadOnlyList<Category>, DomainError> result = await _categoryRepository.GetCachedTopCategories(promoOnly: false, activeOnly: false, cashbackOnly: false, showHidden: true);
				Category category = null;
				if (result.TryGetValue(out var value2))
				{
					string[] array = pathComponents;
					foreach (string subpath in array)
					{
						category = value2.FirstOrDefault((Category c) => c.PathCode == subpath);
						if (category == null)
						{
							break;
						}
						value2 = category.Items.ToList();
					}
				}
				return category;
			}
		}
		if (pathCode != null)
		{
			string code = pathCode.Replace('-', '_');
			if ((await _categoryRepository.GetCachedTopCategories(promoOnly: false, activeOnly: false, cashbackOnly: false, showHidden: true)).TryGetValue(out var value3))
			{
				if (uri.AbsolutePath.ContainsIgnoreCase("kollekcii"))
				{
					return value3.FirstOrDefault((Category c) => c.Code.EqualsIgnoreCase("kollekcii"))?.Items?.FirstOrDefaultRecursive((Category c) => c.PathCode?.EqualsIgnoreCase(pathCode) ?? false, (Category c) => c.Items) ?? value3.Where((Category c) => !c.Code.EqualsIgnoreCase("kollekcii")).FirstOrDefaultRecursive((Category c) => c.PathCode?.EqualsIgnoreCase(pathCode) ?? false, (Category c) => c.Items) ?? value3.FirstOrDefaultRecursive((Category c) => c.Code.EqualsIgnoreCase(code), (Category c) => c.Items);
				}
				return value3.FirstOrDefaultRecursive((Category x) => x.Code.EqualsIgnoreCase(code), (Category x) => x.Items);
			}
		}
		return null;
	}
}
