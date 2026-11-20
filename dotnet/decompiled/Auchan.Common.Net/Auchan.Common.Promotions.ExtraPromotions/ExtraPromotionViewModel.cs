using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Enums;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram;
using Auchan.Common.Navigation;
using Auchan.Common.Profile;
using Auchan.Common.Profile.Stores;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Promotions.ExtraPromotions;

public class ExtraPromotionViewModel : ScreenViewModel
{
	public class Parameter
	{
		public ExtraPromotion ExtraPromotion { get; }

		public Parameter(ExtraPromotion extraPromotion)
		{
			ExtraPromotion = extraPromotion;
		}
	}

	private readonly Subject<Unit> _closePromoScreen = new Subject<Unit>();

	private readonly Subject<Unit> _onNavigate = new Subject<Unit>();

	private readonly ExtraPromotion _extraPromotion;

	private readonly IAdminContext _adminContext;

	private readonly IDataBroker _dataBroker;

	private readonly INavigationService _navigationService;

	private readonly ICategoryRepository _categoryRepository;

	public string ImageUrl => _extraPromotion.Picture;

	public IObservable<Unit> OnClosePromoScreenCommand => _closePromoScreen.Debounce();

	public ExtraPromotionViewModel(Parameter parameter, INavigationService navigationService, ICategoryRepository categoryRepository, IAdminContext adminContext, IDataBroker dataBroker)
	{
		_extraPromotion = parameter.ExtraPromotion;
		_navigationService = navigationService;
		_categoryRepository = categoryRepository;
		_adminContext = adminContext;
		_dataBroker = dataBroker;
		_onNavigate.PerformDebouncingTask(NavigateTo).Subscribe().AddTo(base.CloseDisposable);
	}

	protected override async Task Start()
	{
		await base.Start();
		_adminContext.AddShowedExtraPromotion(_extraPromotion.Id);
	}

	public void Close()
	{
		_closePromoScreen.OnNext(Unit.Default);
	}

	public void OpenPromo()
	{
		_onNavigate.OnNext(Unit.Default);
	}

	private async Task NavigateTo()
	{
		var (type, parameter) = await GetDestination();
		_closePromoScreen.OnNext(Unit.Default);
		if (type != null)
		{
			_navigationService.NavigateTo(type, parameter);
		}
	}

	private async Task<(Type?, object?)> GetDestination()
	{
		return _extraPromotion.Transition switch
		{
			ExtraPromotionTransition.ToCabinet => (typeof(ProfileViewModel), null), 
			ExtraPromotionTransition.ToCategory => await GetCategoryCaseDestination(_extraPromotion.TransitionCode), 
			ExtraPromotionTransition.ToStore => GetStoreCaseDestination(_extraPromotion.TransitionCode), 
			ExtraPromotionTransition.ToCashback => (typeof(LoyaltyTabViewModel), null), 
			ExtraPromotionTransition.ToCart => (typeof(CartScreenViewModel), null), 
			_ => default((Type, object)), 
		};
	}

	private async Task<(Type?, object?)> GetCategoryCaseDestination(string? transitionCode)
	{
		if (string.IsNullOrWhiteSpace(transitionCode))
		{
			return default((Type, object));
		}
		Result<(Type, object), DomainError> result = await ResolveCategory(transitionCode);
		if (result.IsFailure)
		{
			return default((Type, object));
		}
		return result.Value;
	}

	private (Type?, object?) GetStoreCaseDestination(string? transitionCode)
	{
		if (string.IsNullOrEmpty(transitionCode))
		{
			return default((Type, object));
		}
		if (!int.TryParse(transitionCode, out var result))
		{
			return default((Type, object));
		}
		return (typeof(StoreDetailsViewModel), new StoreDetailsViewModel.Parameter(result));
	}

	private async Task<Result<(Type?, object?), DomainError>> ResolveCategory(string categoryCode)
	{
		Result<List<Category>, DomainError> result = await _categoryRepository.GetCategoriesTree(categoryCode, showHidden: true);
		if (result.IsFailure)
		{
			return Result.Failure<(Type, object), DomainError>(result.Error);
		}
		Category category = result.Value.FirstOrDefault();
		if (category != null)
		{
			if (category.Items != null)
			{
				if (category.Items.Count > 1)
				{
					return Result.Success<(Type, object), DomainError>((typeof(CategoryViewModel), new CategoryViewModel.Parameter(category)));
				}
				if (category.Items.Count == 1)
				{
					return Result.Success<(Type, object), DomainError>((typeof(CollectionProductsViewModel), _dataBroker.Push(new CollectionProductsViewModel.Parameter(category.Items.First()))));
				}
			}
			return Result.Success<(Type, object), DomainError>((typeof(CollectionProductsViewModel), _dataBroker.Push(new CollectionProductsViewModel.Parameter(category))));
		}
		return Result.Failure<(Type, object), DomainError>(new UnknownError());
	}
}
