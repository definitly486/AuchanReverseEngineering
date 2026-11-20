using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Recommendations.Models;
using EBind;
using Microsoft.Maui.Devices;

namespace Auchan.Common.Recommendations.ViewModels;

public sealed class ProductRecommendationsViewModel : BaseItemViewModel
{
	public delegate void AddOrRemoveHandler(ref IReadOnlyList<BaseItemViewModel> collection);

	private bool _canShowProductRecommendations = true;

	private readonly Func<RecommendationBuilder> _recommendationBuilderFactory;

	private readonly IEcomContext _ecomContext;

	private readonly Cart _cart;

	private readonly Func<string?, bool> _isExist;

	private ProductItemViewModel? _currentProduct;

	private bool _blocked;

	[CompilerGenerated]
	private bool _003CIsLeftAlignment_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsLast_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsVisible_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CIndex_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CSectionIndex_003Ek__BackingField;

	public RecommendationsViewModel RecommendationsViewModel { get; }

	public bool IsLeftAlignment
	{
		[CompilerGenerated]
		get
		{
			return _003CIsLeftAlignment_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsLeftAlignment_003Ek__BackingField != value)
			{
				_003CIsLeftAlignment_003Ek__BackingField = value;
				RaisePropertyChanged("IsLeftAlignment");
			}
		}
	}

	public bool IsLast
	{
		[CompilerGenerated]
		get
		{
			return _003CIsLast_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsLast_003Ek__BackingField != value)
			{
				_003CIsLast_003Ek__BackingField = value;
				RaisePropertyChanged("IsLast");
			}
		}
	}

	public bool IsVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsVisible_003Ek__BackingField != value)
			{
				_003CIsVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsVisible");
			}
		}
	}

	public int Index
	{
		[CompilerGenerated]
		get
		{
			return _003CIndex_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIndex_003Ek__BackingField != value)
			{
				_003CIndex_003Ek__BackingField = value;
				RaisePropertyChanged("Index");
			}
		}
	}

	public int SectionIndex
	{
		[CompilerGenerated]
		get
		{
			return _003CSectionIndex_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CSectionIndex_003Ek__BackingField != value)
			{
				_003CSectionIndex_003Ek__BackingField = value;
				RaisePropertyChanged("SectionIndex");
			}
		}
	}

	public event Action<AddOrRemoveHandler>? OnAddedOrRemoved;

	public ProductRecommendationsViewModel(ICollection<IDisposable> closeDisposable, ScreenViewModel viewModel, Func<RecommendationBuilder> recommendationBuilderFactory, IEcomContext ecomContext, RecommendationsViewModel recommendationsViewModel, Cart cart, Func<string?, bool> isExist)
	{
		_recommendationBuilderFactory = recommendationBuilderFactory;
		_ecomContext = ecomContext;
		_cart = cart;
		_isExist = isExist;
		RecommendationsViewModel = recommendationsViewModel.Setup(closeDisposable, viewModel);
		_cart.ShowProductRecommendations += new DisposableDelegate<Action<string>>(delegate(string? gimaId)
		{
			TryShow(gimaId).SafeFireAndForget((Action<Exception>)null, false);
		}, delegate(Action<string?> h)
		{
			_cart.ShowProductRecommendations -= h;
		}).AddTo(closeDisposable);
		_cart.CloseProductRecommendations += new DisposableDelegate<Action<string>>(Close, delegate(Action<string?> h)
		{
			_cart.CloseProductRecommendations -= h;
		}).AddTo(closeDisposable);
	}

	private async Task TryShow(string? gimaId)
	{
		if (_canShowProductRecommendations && _isExist(gimaId))
		{
			await LoadRecommendations(gimaId);
			IsVisible = RecommendationsViewModel.HasItems && _isExist(gimaId);
			if (IsVisible)
			{
				UpdateState(gimaId);
			}
		}
	}

	private void UpdateState(string? gimaId)
	{
		this.OnAddedOrRemoved?.Invoke(delegate(ref IReadOnlyList<BaseItemViewModel> products)
		{
			List<BaseItemViewModel> list = products.ToList();
			_currentProduct = products.OfType<ProductItemViewModel>().FirstOrDefault((ProductItemViewModel x) => x.Product.GimaId == gimaId);
			if (_currentProduct != null && !list.Contains(this))
			{
				int num = products.IndexOf(_currentProduct);
				if (products.Count - 1 == num || (products.Count - 2 == num && num % 2 == 0))
				{
					list.Add(this);
				}
				else
				{
					int index = ((num % 2 == 1) ? (num + 1) : (num + 2));
					list.Insert(index, this);
				}
				IsLeftAlignment = num % 2 == 0;
				IsLast = list.Last() == this;
				Index = list.IndexOf(this);
				_canShowProductRecommendations = false;
				products = list;
			}
		});
	}

	private async Task LoadRecommendations(string? gimaId)
	{
		LoadRequest loadRequest = _recommendationBuilderFactory().AddRelated("С этим товаром покупают", "relatedToAddedFromSearch", new global::_003C_003Ez__ReadOnlySingleElementList<string>(gimaId ?? "")).Build();
		await RecommendationsViewModel.Load(loadRequest);
	}

	public void ResetData()
	{
		if (!_blocked)
		{
			_canShowProductRecommendations = true;
			Close();
			RecommendationsViewModel.Clear().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void Close(string? gimaId = null)
	{
		if (_currentProduct != null && (gimaId == null || _currentProduct == null || !(_currentProduct.Product.GimaId != gimaId)))
		{
			_currentProduct = null;
			this.OnAddedOrRemoved?.Invoke(delegate(ref IReadOnlyList<BaseItemViewModel> products)
			{
				List<BaseItemViewModel> list = products.ToList();
				list.Remove(this);
				products = list;
				RecommendationsViewModel.Clear().SafeFireAndForget((Action<Exception>)null, false);
				IsVisible = false;
			});
		}
	}

	public bool IsEqualIndex(int index)
	{
		return SectionIndex == index;
	}

	public bool ItemIndexLessThanStub(int index)
	{
		if (DeviceInfo.Platform == DevicePlatform.iOS)
		{
			return index < SectionIndex;
		}
		if (IsVisible)
		{
			if (!IsLast || Index % 2 == 0)
			{
				if (index >= Index - 1)
				{
					return index < Index + 1;
				}
				return false;
			}
			return index < Index + 1;
		}
		return false;
	}

	public bool ItemIndexGreaterThanStub(int index)
	{
		if (DeviceInfo.Platform == DevicePlatform.iOS)
		{
			return index > SectionIndex;
		}
		if (IsVisible)
		{
			return index > Index + 1;
		}
		return false;
	}

	public void ForceUpdate()
	{
		_blocked = false;
		if (_isExist(_currentProduct?.Product.GimaId))
		{
			UpdateState(_currentProduct?.Product.GimaId);
		}
	}

	public void BlockResetData()
	{
		_blocked = true;
	}
}
