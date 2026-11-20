using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Akavache.Sqlite3.Internal;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Cart.Errors;
using Auchan.Common.Ecom.Cart.Managers;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Extensions;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices;

namespace Auchan.Common.Ecom.Cart;

public sealed class Cart
{
	private sealed class ItemsAccessor(Func<IReadOnlyList<ProductOffer>> getter, Action<IReadOnlyList<ProductOffer>> setter)
	{
		public IReadOnlyList<ProductOffer> Items
		{
			get
			{
				return getter();
			}
			set
			{
				setter(value);
			}
		}
	}

	private record struct PendingChanges(ProductOffer Offer, Guid RequestId);

	private bool _isCartScreenActive;

	private volatile ImmutableDictionary<ProductOfferKey, PendingChanges> _pendingChanges = ImmutableDictionary<ProductOfferKey, PendingChanges>.Empty;

	private object _pendingChangesLock = new object();

	private IReadOnlyList<ProductOffer>? _previousAvailableItems;

	private IReadOnlyList<ProductOffer>? _previousUnavailableItems;

	private readonly ItemsAccessor _itemsAccessor;

	private readonly ItemsAccessor _unavailalbeItemsAccessor;

	private readonly System.Timers.Timer _delayedItemChange = new System.Timers.Timer(TimeSpan.FromSeconds(1L))
	{
		AutoReset = false
	};

	private Result<ChangeItemsResult, DomainError> _previousPendingRequestResult = Result.Success<ChangeItemsResult, DomainError>(ChangeItemsResult.Empty);

	private volatile TaskCompletionSource<Result<ChangeItemsResult, DomainError>> _pendingRequestCompleted = new TaskCompletionSource<Result<ChangeItemsResult, DomainError>>();

	private volatile int _pendingRequests;

	private readonly AsyncLock _updateCartLock = new AsyncLock();

	private readonly Lazy<RemoteCartService> _remoteCartService;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	private readonly Lazy<CashbackLimitNotifier> _cashbackLimitNotifier;

	private readonly Lazy<AppMetrica> _appMetrica;

	private IReadOnlyList<ProductOffer> _items = Array.Empty<ProductOffer>();

	private IReadOnlyList<ProductOffer> _itemsUnavailable = Array.Empty<ProductOffer>();

	public bool HasAvailableAdultProducts => Items.Any((ProductOffer item) => item.IsAdult);

	public bool HasAnyAdultProducts
	{
		get
		{
			if (!HasAvailableAdultProducts)
			{
				return ItemsUnavailable.Any((ProductOffer i) => i.IsAdult);
			}
			return true;
		}
	}

	public bool IsAnyAdultProductSelected => Items.Any((ProductOffer item) => item.IsAdult && item.IsSelected);

	public UICommand OnAllAdultDelete { get; } = new UICommand();

	public CartModel CartModel { get; private set; } = Auchan.Common.Ecom.Cart.Models.CartModel.Empty;

	public IReadOnlyList<ProductOffer> Items
	{
		get
		{
			return _items;
		}
		private set
		{
			if (!_items.SequenceEqual(value))
			{
				_items = value;
				bool isHavePendingChanges;
				lock (_pendingChangesLock)
				{
					isHavePendingChanges = _pendingChanges.Count > 0;
				}
				this._availableItemsChanged?.Invoke(this, new AvailableItemsChangedEventArgs
				{
					Available = _items,
					IsHavePendingChanges = isHavePendingChanges
				});
				this._cartChanged?.Invoke(this, new CartChangedEventArgs
				{
					Available = _items,
					Unavailable = _itemsUnavailable,
					IsHavePendingChanges = isHavePendingChanges
				});
			}
		}
	}

	public IReadOnlyList<ProductOffer> ItemsUnavailable
	{
		get
		{
			return _itemsUnavailable;
		}
		private set
		{
			if (!_itemsUnavailable.SequenceEqual(value))
			{
				_itemsUnavailable = value;
				bool isHavePendingChanges;
				lock (_pendingChangesLock)
				{
					isHavePendingChanges = _pendingChanges.Count > 0;
				}
				this._cartChanged?.Invoke(this, new CartChangedEventArgs
				{
					Available = _items,
					Unavailable = _itemsUnavailable,
					IsHavePendingChanges = isHavePendingChanges
				});
			}
		}
	}

	public int TotalItemsQty => GetTotalItemsQty(Items, selectedOnly: false);

	public int TotalSelectedItemsQty => CartModel.TotalCount;

	public bool IsEmpty
	{
		get
		{
			if (GetTotalItemsQty(Items, selectedOnly: false) == 0)
			{
				return !ItemsUnavailable.Any();
			}
			return false;
		}
	}

	public Guid CartId { get; private set; }

	public bool IsSyncInProgress { get; private set; }

	private event EventHandler<CartChangedEventArgs>? _cartChanged;

	private event EventHandler<AvailableItemsChangedEventArgs>? _availableItemsChanged;

	private event EventHandler<OfferUpdatedEventArgs>? _itemChangedByUser;

	private event EventHandler<OfferUpdatedEventArgs>? _itemReceivedOnCartUpdate;

	private event EventHandler<ItemChangedEventArgs>? _itemChangeReceived;

	private event EventHandler<SilentCartUpdateCompletedEventArgs>? _silentCartUpdateCompleted;

	private event Action<int>? _requestPendingChanged;

	public event Action<string?>? ShowProductRecommendations;

	public event Action<string?>? CloseProductRecommendations;

	public Cart(Lazy<RemoteCartService> cartService, IUserContext userContext, Lazy<IInfoMessageService> infoMessageService, Lazy<CashbackLimitNotifier> cashbackLimitNotifier, Lazy<AppMetrica> appMetrica)
	{
		_remoteCartService = cartService;
		_infoMessageService = infoMessageService;
		_cashbackLimitNotifier = cashbackLimitNotifier;
		_appMetrica = appMetrica;
		_itemsAccessor = new ItemsAccessor(() => Items, delegate(IReadOnlyList<ProductOffer> value)
		{
			Items = value;
		});
		_unavailalbeItemsAccessor = new ItemsAccessor(() => ItemsUnavailable, delegate(IReadOnlyList<ProductOffer> value)
		{
			ItemsUnavailable = value;
		});
		_delayedItemChange.Elapsed += delegate
		{
			MainThread.BeginInvokeOnMainThread(delegate
			{
				FlushPendingChanges();
			});
		};
		userContext.AfterLoggedIn += SetOnlineState;
		userContext.BeforeLoggedOut += async delegate
		{
		};
		userContext.AfterLoggedOut += SetOfflineState;
	}

	public void SetCartScreenActive(bool isActive)
	{
		_isCartScreenActive = isActive;
	}

	public async Task<Result<Unit, DomainError>> AddSharedCartAsync(SharedCartModel sharedCartModel, bool withAdultGoods)
	{
		using (OnBeginRequest())
		{
			using (await _updateCartLock.LockAsync(default(CancellationToken)))
			{
				ImmutableList<ProductOffer>.Builder builder = ImmutableList.CreateBuilder<ProductOffer>();
				foreach (ProductOffer item in sharedCartModel.Available.Concat(sharedCartModel.Unavailable))
				{
					if (!(!item.IsAdult || withAdultGoods))
					{
						continue;
					}
					ProductOffer exact = GetExact(item);
					if (exact != null)
					{
						decimal num = item.Qty + exact.Qty;
						if (num > item.LastKnownStock)
						{
							num = item.LastKnownStock;
						}
						builder.Add(item with
						{
							Qty = num
						});
					}
					else
					{
						builder.Add(item);
					}
				}
				ImmutableList<ProductOffer> toSend = builder.ToImmutable();
				if ((await Task.Run(() => _remoteCartService.Value.ChangeItems(toSend))).TryGetError(out var error))
				{
					return error;
				}
				toSend.ForEach(delegate(ProductOffer product)
				{
					AppAnalytics.Ecom.AddToCart(product);
				});
				await UpdateCartSilentAsync();
				return Unit.Default;
			}
		}
	}

	public void SetItemSelected(ProductOffer offer, bool selected, Guid requestId)
	{
		ChangeItemsCore(new global::_003C_003Ez__ReadOnlySingleElementList<ProductOffer>(offer with
		{
			IsSelected = selected
		}), requestId, _itemsAccessor);
	}

	public async Task<bool> SetAllItemsSelected(bool selected)
	{
		if (!MainThread.IsMainThread)
		{
			throw new InvalidOperationException("main thread required");
		}
		using (OnBeginRequest())
		{
			await FlushPendingChangesAsync();
			using (await _updateCartLock.LockAsync(default(CancellationToken)))
			{
				IReadOnlyList<ProductOffer> previousState = Items;
				ImmutableList<ProductOffer> newState = (ImmutableList<ProductOffer>)(Items = Items.Select((ProductOffer i) => i with
				{
					IsSelected = selected
				}).ToImmutableList());
				Guid rid = Guid.NewGuid();
				foreach (ProductOffer item in newState)
				{
					NotifyItemChangedByUser(item, rid);
				}
				Result<Unit, DomainError> result = await _remoteCartService.Value.SetAllItemsSelected(selected);
				if (result.IsSuccess)
				{
					await UpdateCartSilentAsync();
				}
				else
				{
					Items = previousState;
					foreach (ProductOffer item2 in newState)
					{
						NotifyItemChangedByUser(item2, rid);
					}
				}
				return result.IsSuccess;
			}
		}
	}

	public void AddItem(ProductOffer product, Guid requestId)
	{
		ProductOffer exact = GetExact(product);
		if (exact != null)
		{
			IncrementItemQty(exact, product.BasketStep, requestId);
			return;
		}
		this.ShowProductRecommendations?.Invoke(product.GimaId);
		ChangeItemsCore(new global::_003C_003Ez__ReadOnlySingleElementList<ProductOffer>(product), requestId, _itemsAccessor);
	}

	public void AddItems(IReadOnlyList<ProductOffer> products, Guid requestId)
	{
		ImmutableArray<ProductOffer>.Builder builder = ImmutableArray.CreateBuilder<ProductOffer>();
		foreach (ProductOffer product in products)
		{
			ProductOffer exact = GetExact(product);
			decimal newQty = ((exact != null) ? (exact.Qty + product.Qty) : product.Qty);
			newQty = ManualQtyHandler.NormalizeRound(product, newQty);
			builder.Add(product with
			{
				Qty = newQty
			});
		}
		ChangeItemsCore(builder.ToImmutableArray(), requestId, _itemsAccessor);
	}

	public Task<Result<ChangeItemsResult, DomainError>> WaitForPendingChangesAsync()
	{
		int count;
		Result<ChangeItemsResult, DomainError> previousPendingRequestResult;
		lock (_pendingChangesLock)
		{
			count = _pendingChanges.Count;
			previousPendingRequestResult = _previousPendingRequestResult;
		}
		if (count <= 0)
		{
			return Task.FromResult(previousPendingRequestResult);
		}
		return _pendingRequestCompleted.Task;
	}

	public async Task<bool> AddCommentToItem(ProductOffer productOffer, string? comment)
	{
		using (OnBeginRequest())
		{
			using (await _updateCartLock.LockAsync(default(CancellationToken)))
			{
				ProductOffer exact = GetExact(productOffer);
				IReadOnlyList<ProductOffer> previousState = Items;
				if (exact != null)
				{
					Items = Replace(Items, exact, exact with
					{
						Comment = comment
					});
				}
				if ((await _remoteCartService.Value.AddCommentToItem(productOffer, comment)).IsFailure)
				{
					Items = previousState;
					_infoMessageService.Value.ShowSnackbar("Не удалось обновить комментарий");
					return false;
				}
				_infoMessageService.Value.ShowSnackbar("Комментарий обновлён", SnackbarStyle.Success);
				return true;
			}
		}
	}

	public void IncrementItemQty(ProductOffer product, decimal basketStep, Guid requestId)
	{
		decimal newQty = product.Qty + basketStep;
		ChangeItemQty(product, newQty, requestId);
	}

	public void DecrementItemQty(ProductOffer product, decimal basketStep, Guid requestId)
	{
		if (product.Qty <= product.BasketStep)
		{
			ChangeItemQty(product, 0.0m, requestId);
			return;
		}
		decimal newQty = product.Qty - basketStep;
		ChangeItemQty(product, newQty, requestId);
	}

	public void ChangeItemQty(ProductOffer product, decimal newQty, Guid requestId)
	{
		ProductOffer exact = GetExact(product);
		if (exact == null)
		{
			return;
		}
		if (newQty >= exact.LastKnownStock)
		{
			Vibration.Vibrate(50.0);
			if (newQty > exact.LastKnownStock)
			{
				return;
			}
		}
		ChangeItemsQty(new global::_003C_003Ez__ReadOnlySingleElementList<ProductOffer>(exact with
		{
			Qty = newQty
		}), requestId);
	}

	public void FlushPendingChanges()
	{
		FlushPendingChangesAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task FlushPendingChangesAsync()
	{
		if (!MainThread.IsMainThread)
		{
			throw new InvalidOperationException("main thread required");
		}
		_delayedItemChange.Stop();
		using (OnBeginRequest())
		{
			using (await _updateCartLock.LockAsync(default(CancellationToken)))
			{
				YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
				bool isCompleted = awaiter.IsCompleted;
				await awaiter;
				YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
				awaiter = yieldAwaiter;
				awaiter.GetResult();
				ImmutableDictionary<ProductOfferKey, PendingChanges> pendingChanges;
				IReadOnlyList<ProductOffer> prevAvailalbe;
				IReadOnlyList<ProductOffer> prevUnavaiable;
				lock (_pendingChangesLock)
				{
					pendingChanges = _pendingChanges;
					_pendingChanges = ImmutableDictionary<ProductOfferKey, PendingChanges>.Empty;
					prevAvailalbe = _previousAvailableItems;
					_previousAvailableItems = null;
					prevUnavaiable = _previousAvailableItems;
					_previousUnavailableItems = null;
				}
				NotifyOnPendingChanges();
				while (pendingChanges.Any())
				{
					RemoteCartService value = _remoteCartService.Value;
					List<ProductOffer> list = new List<ProductOffer>();
					list.AddRange(pendingChanges.Values.Select((PendingChanges i) => i.Offer));
					Result<ChangeItemsResult, DomainError> result = await value.ChangeItemsWithChangeHandling(new _003C_003Ez__ReadOnlyList<ProductOffer>(list));
					ImmutableDictionary<ProductOfferKey, PendingChanges> pendingChanges2;
					IReadOnlyList<ProductOffer> readOnlyList;
					IReadOnlyList<ProductOffer> readOnlyList2;
					lock (_pendingChangesLock)
					{
						pendingChanges2 = _pendingChanges;
						_pendingChanges = ImmutableDictionary<ProductOfferKey, PendingChanges>.Empty;
						readOnlyList = _previousAvailableItems;
						_previousAvailableItems = null;
						readOnlyList2 = _previousUnavailableItems;
						_previousUnavailableItems = null;
					}
					NotifyOnPendingChanges();
					ImmutableList<ProductOffer> immutableList = pendingChanges2.Values.Select((PendingChanges i) => i.Offer).ToImmutableList();
					ProductOffer Offer;
					Guid RequestId;
					DomainError error;
					if (result.TryGetValue(out var value2))
					{
						List<ItemChangedEventArgs> list2 = new List<ItemChangedEventArgs>();
						IReadOnlyList<ProductOffer> readOnlyList3 = Items;
						foreach (ChangedItem change in value2.Changes)
						{
							if (!change.IsAdded || change.OfferId == 0L)
							{
								continue;
							}
							foreach (ProductOfferKey key2 in pendingChanges.Keys)
							{
								if (key2.Id != change.OfferId)
								{
									continue;
								}
								foreach (ProductOfferChange item in value2.Items)
								{
									ProductOfferKey key = item.ToOffer().GetKey();
									ProductOfferKey productOfferKey = key2 with
									{
										Id = key.Id
									};
									if (productOfferKey == key)
									{
										PendingChanges pendingChanges3 = pendingChanges[key2];
										ProductOffer exact = GetExact(readOnlyList3, pendingChanges3.Offer);
										ProductOffer offer = pendingChanges3.Offer with
										{
											Id = key.Id
										};
										pendingChanges3 = pendingChanges3 with
										{
											Offer = offer
										};
										pendingChanges = pendingChanges.Remove(key2);
										pendingChanges = pendingChanges.Add(productOfferKey, pendingChanges3);
										if (exact != null)
										{
											readOnlyList3 = Replace(readOnlyList3, exact, pendingChanges3.Offer);
										}
									}
								}
							}
						}
						foreach (ProductOfferChange item2 in value2.Items)
						{
							ProductOffer offer2 = null;
							if (GetExact(immutableList, item2) != null)
							{
								continue;
							}
							ProductOffer exact2 = GetExact(readOnlyList3, item2);
							if (exact2 == null)
							{
								offer2 = item2.ToOffer();
								Offer = offer2;
								IReadOnlyList<ProductOffer> readOnlyList4 = readOnlyList3;
								int num = 0;
								ProductOffer[] array = new ProductOffer[1 + readOnlyList4.Count];
								array[num] = Offer;
								num++;
								foreach (ProductOffer item3 in readOnlyList4)
								{
									array[num] = item3;
									num++;
								}
								readOnlyList3 = new global::_003C_003Ez__ReadOnlyArray<ProductOffer>(array);
							}
							else if (exact2.TryUpdateWith(item2, out offer2))
							{
								readOnlyList3 = Replace(readOnlyList3, exact2, offer2);
							}
							else
							{
								offer2 = exact2;
							}
							if (!pendingChanges.TryGetValue(offer2.GetKey(), out var value3))
							{
								continue;
							}
							ItemChangedEventType eventType = ItemChangedEventType.Nothing;
							if (value3.Offer.Qty == 0m)
							{
								AppAnalytics.Ecom.RemoveFromCart(value3.Offer);
								eventType = ItemChangedEventType.Remove;
							}
							else
							{
								ProductOffer exact3 = GetExact(prevAvailalbe ?? Array.Empty<ProductOffer>(), value3.Offer);
								if (exact3 == null)
								{
									AppAnalytics.Ecom.AddToCart(value3.Offer);
									eventType = ItemChangedEventType.Add;
								}
								else if (exact3.Qty != value3.Offer.Qty)
								{
									AppAnalytics.Ecom.ChangeQuantity(value3.Offer, exact3.Qty, value3.Offer.Qty);
									eventType = ItemChangedEventType.Change;
								}
							}
							list2.Add(new ItemChangedEventArgs
							{
								Offer = offer2,
								Change = item2,
								RequestId = value3.RequestId,
								EventType = eventType
							});
						}
						foreach (PendingChanges item4 in pendingChanges.Values.Where((PendingChanges i) => i.Offer.Qty == 0m))
						{
							item4.Deconstruct(out Offer, out RequestId);
							ProductOffer productOffer = Offer;
							Guid requestId = RequestId;
							if (GetExact(value2.Items, productOffer) == null)
							{
								AppAnalytics.Ecom.RemoveFromCart(productOffer);
								list2.Add(new ItemChangedEventArgs
								{
									Offer = productOffer,
									Change = ProductOfferChange.FromOffer(productOffer),
									RequestId = requestId,
									EventType = ItemChangedEventType.Remove
								});
								readOnlyList3 = Remove(readOnlyList3, productOffer);
							}
						}
						Items = readOnlyList3;
						foreach (ItemChangedEventArgs item5 in list2)
						{
							this._itemChangeReceived?.Invoke(this, item5);
						}
					}
					else if (result.TryGetError(out error))
					{
						string text = (error as CartNotChanged)?.Message;
						if (prevAvailalbe != null)
						{
							Items = ReplaceWithPendingChanes(pendingChanges2, prevAvailalbe);
							if (readOnlyList != null)
							{
								readOnlyList = MoveBitsOfPreviousStateToNextStep(pendingChanges2, prevAvailalbe, readOnlyList);
							}
						}
						if (prevUnavaiable != null)
						{
							ItemsUnavailable = ReplaceWithPendingChanes(pendingChanges2, prevUnavaiable);
							if (readOnlyList2 != null)
							{
								readOnlyList2 = MoveBitsOfPreviousStateToNextStep(pendingChanges2, prevUnavaiable, readOnlyList2);
							}
						}
						foreach (PendingChanges value4 in pendingChanges.Values)
						{
							value4.Deconstruct(out Offer, out RequestId);
							ProductOffer productOffer2 = Offer;
							Guid requestId2 = RequestId;
							ProductOffer productOffer3 = GetExact(prevAvailalbe ?? Array.Empty<ProductOffer>(), productOffer2) ?? GetExact(prevUnavaiable ?? Array.Empty<ProductOffer>(), productOffer2);
							NotifyItemChangedByUser(productOffer3 ?? productOffer2, requestId2);
						}
						if (text != null)
						{
							_infoMessageService.Value.ShowSnackbar(text);
						}
						else if (pendingChanges.All<KeyValuePair<ProductOfferKey, PendingChanges>>((KeyValuePair<ProductOfferKey, PendingChanges> i) => i.Value.Offer.Qty == 0m))
						{
							_infoMessageService.Value.ShowSnackbar("Не удалось удалить товар");
						}
						else if (pendingChanges.Any<KeyValuePair<ProductOfferKey, PendingChanges>>((KeyValuePair<ProductOfferKey, PendingChanges> i) => i.Value.Offer.Qty == 0m))
						{
							_infoMessageService.Value.ShowSnackbar("Не удалось изменить количество товара");
						}
						else
						{
							bool flag = true;
							foreach (PendingChanges value5 in pendingChanges.Values)
							{
								value5.Deconstruct(out Offer, out RequestId);
								ProductOffer product = Offer;
								ProductOffer exact4 = GetExact(prevAvailalbe ?? Array.Empty<ProductOffer>(), product);
								flag = flag && exact4 == null;
							}
							_infoMessageService.Value.ShowSnackbar(flag ? "Не удалось добавить товар" : "Не удалось изменить количество товара");
						}
						_appMetrica.Value.TrackEvent("cartScreenNiEventError", ("errorId", error.GetType().Name + ": " + (error.Message ?? string.Empty)));
					}
					if (immutableList.Any())
					{
						pendingChanges = pendingChanges2;
						prevAvailalbe = readOnlyList;
						prevUnavaiable = readOnlyList2;
						continue;
					}
					lock (_pendingChangesLock)
					{
						_previousPendingRequestResult = result;
					}
					Interlocked.Exchange(ref _pendingRequestCompleted, new TaskCompletionSource<Result<ChangeItemsResult, DomainError>>()).TrySetResult(result);
					await UpdateCartSilentAsync();
					break;
				}
			}
		}
		static IReadOnlyList<ProductOffer> MoveBitsOfPreviousStateToNextStep(ImmutableDictionary<ProductOfferKey, PendingChanges> chanes, IReadOnlyList<ProductOffer> prev, IReadOnlyList<ProductOffer> next)
		{
			foreach (ProductOffer item6 in chanes.Values.Select((PendingChanges i) => i.Offer))
			{
				ProductOffer exact5 = GetExact(prev, item6);
				ProductOffer exact6 = GetExact(next, item6);
				if (exact5 != null && exact6 != null)
				{
					next = Replace(next, exact6, exact5);
				}
			}
			return next;
		}
		static IReadOnlyList<ProductOffer> ReplaceWithPendingChanes(ImmutableDictionary<ProductOfferKey, PendingChanges> replaceWith, IReadOnlyList<ProductOffer> replaceAt)
		{
			IReadOnlyList<ProductOffer> readOnlyList5 = replaceAt;
			foreach (ProductOffer item7 in replaceWith.Values.Select((PendingChanges i) => i.Offer))
			{
				ProductOffer exact5 = GetExact(replaceAt, item7);
				if (exact5 != null)
				{
					readOnlyList5 = Replace(readOnlyList5, exact5, item7);
				}
			}
			return readOnlyList5;
		}
	}

	private async Task UpdateCartSilentAsync()
	{
		if (_isCartScreenActive && _pendingRequests > 0)
		{
			Result<CartModel, DomainError> result = await _remoteCartService.Value.PrepareForCheckout();
			ProcessUpdateResult(result, Guid.NewGuid());
			if (result.TryGetValue(out var value))
			{
				this._silentCartUpdateCompleted?.Invoke(this, new SilentCartUpdateCompletedEventArgs
				{
					Cart = value
				});
			}
		}
	}

	private void ChangeItemsCore(IReadOnlyList<ProductOffer> offers, Guid requestId, ItemsAccessor itemsAccessor)
	{
		if (!offers.Any())
		{
			return;
		}
		AddToPendingChanges(offers, requestId);
		_delayedItemChange.Stop();
		IReadOnlyList<ProductOffer> items = itemsAccessor.Items;
		IReadOnlyList<ProductOffer> readOnlyList = items;
		foreach (ProductOffer offer in offers)
		{
			ProductOffer exact = GetExact(items, offer);
			if (exact != null)
			{
				readOnlyList = ((offer.Qty > 0m) ? Replace(readOnlyList, exact, offer) : Remove(readOnlyList, exact));
				continue;
			}
			ProductOffer productOffer = offer;
			IReadOnlyList<ProductOffer> readOnlyList2 = readOnlyList;
			int num = 0;
			ProductOffer[] array = new ProductOffer[1 + readOnlyList2.Count];
			array[num] = productOffer;
			num++;
			foreach (ProductOffer item in readOnlyList2)
			{
				array[num] = item;
				num++;
			}
			readOnlyList = new global::_003C_003Ez__ReadOnlyArray<ProductOffer>(array);
		}
		itemsAccessor.Items = readOnlyList;
		foreach (ProductOffer offer2 in offers)
		{
			NotifyItemChangedByUser(offer2, requestId);
		}
		_delayedItemChange.Start();
	}

	private void ChangeItemsQty(IReadOnlyList<ProductOffer> offers, Guid requestId)
	{
		ChangeItemsCore(offers, requestId, _itemsAccessor);
	}

	private void NotifyItemChangedByUser(ProductOffer productInCart, Guid requestId)
	{
		this._itemChangedByUser?.Invoke(this, new OfferUpdatedEventArgs
		{
			Offer = productInCart,
			RequestId = requestId
		});
		_cashbackLimitNotifier.Value.CheckLimitAndNotify(productInCart);
	}

	public void RemoveItems(IReadOnlyList<ProductOffer> products, Guid requestId)
	{
		_cashbackLimitNotifier.Value.RemoveProductNotificationsFromCache(products);
		RemoveRemoteItems(products, requestId, _itemsAccessor);
	}

	public void RemoveUnavailableItems(IReadOnlyList<ProductOffer> products, Guid requestId)
	{
		_cashbackLimitNotifier.Value.RemoveProductNotificationsFromCache(products);
		RemoveRemoteItems(products, requestId, _unavailalbeItemsAccessor);
	}

	private void RemoveRemoteItems(IReadOnlyList<ProductOffer> products, Guid requestId, ItemsAccessor itemsAccessor)
	{
		ImmutableList<ProductOffer> offers = products.Select((ProductOffer i) => i with
		{
			Qty = 0m
		}).ToImmutableList();
		ChangeItemsCore(offers, requestId, itemsAccessor);
	}

	public async Task WaitForCartUpdateCompletion()
	{
		using (await _updateCartLock.LockAsync(default(CancellationToken)))
		{
		}
	}

	public async Task<Result<CartModel, DomainError>> Update(Guid requestId)
	{
		using (OnBeginRequest())
		{
			using (await _updateCartLock.LockAsync(default(CancellationToken)))
			{
				IsSyncInProgress = true;
				using (Disposable.Create(delegate
				{
					IsSyncInProgress = false;
				}))
				{
					Result<CartModel, DomainError> result = await _remoteCartService.Value.PrepareForCheckout();
					ProcessUpdateResult(result, requestId);
					return result;
				}
			}
		}
	}

	private void ProcessUpdateResult(Result<CartModel, DomainError> result, Guid requestId)
	{
		if (!result.TryGetValue(out CartModel value))
		{
			return;
		}
		CartModel = value;
		Items = value.Items;
		ItemsUnavailable = value.ItemsUnavailable;
		foreach (ProductOffer item in value.Items)
		{
			this._itemReceivedOnCartUpdate?.Invoke(this, new OfferUpdatedEventArgs
			{
				Offer = item,
				RequestId = requestId
			});
		}
	}

	public async Task<Result<Unit, DomainError>> Clear(Guid requestId)
	{
		using (OnBeginRequest())
		{
			using (await _updateCartLock.LockAsync(default(CancellationToken)))
			{
				Result<CartModel, DomainError> result = await _remoteCartService.Value.ClearCart();
				if (result.TryGetValue(out var cartModel))
				{
					ImmutableList<ProductOffer> toCleanpup = (from i in Items.Concat(ItemsUnavailable)
						select i with
						{
							Qty = 0m
						}).ToImmutableList();
					Items = Array.Empty<ProductOffer>();
					ItemsUnavailable = Array.Empty<ProductOffer>();
					await ClearCache();
					foreach (ProductOffer item in toCleanpup)
					{
						NotifyItemChangedByUser(item with
						{
							Qty = 0m
						}, requestId);
					}
					CartModel = cartModel;
					this._silentCartUpdateCompleted?.Invoke(this, new SilentCartUpdateCompletedEventArgs
					{
						Cart = cartModel
					});
					return Unit.Default;
				}
				return result.Error;
			}
		}
	}

	public async Task<Result<Unit, DomainError>> ClearAllAdultProducts()
	{
		using (OnBeginRequest())
		{
			using (await _updateCartLock.LockAsync(default(CancellationToken)))
			{
				ImmutableList<ProductOffer> unAdultProducts = Items.Where((ProductOffer c) => !c.IsAdult).ToImmutableList();
				ImmutableList<ProductOffer> unAdultUnavailableProducts = ItemsUnavailable.Where((ProductOffer c) => !c.IsAdult).ToImmutableList();
				Result<Unit, DomainError> result = await _remoteCartService.Value.ClearAdultProductFromCart();
				if (result.IsSuccess)
				{
					Items = unAdultProducts;
					ItemsUnavailable = unAdultUnavailableProducts;
				}
				OnAllAdultDelete.Trigger();
				return result;
			}
		}
	}

	public Task ClearCache()
	{
		Items = Array.Empty<ProductOffer>();
		ItemsUnavailable = Array.Empty<ProductOffer>();
		return Task.CompletedTask;
	}

	public bool CanBeAdded(ProductOffer? offer)
	{
		if (offer == null)
		{
			return false;
		}
		ProductOffer exact = GetExact(offer);
		if (exact == null)
		{
			return true;
		}
		return exact.LastKnownStock >= exact.Qty + exact.BasketStep;
	}

	public void GenerateNewCartId()
	{
		CartId = Guid.NewGuid();
	}

	public IReadOnlyList<ProductOffer> GetAvailableOffers(Product product)
	{
		List<ProductOffer> list = new List<ProductOffer>();
		list.AddRange(Items.Where((ProductOffer i) => i.GimaId == product.GimaId));
		return new _003C_003Ez__ReadOnlyList<ProductOffer>(list);
	}

	public ProductOffer? GetExact(Product product, IReadOnlyList<SelectedModification> modifications)
	{
		return GetExact(Items, modifications, (ProductOffer offer) => offer.GimaId == product.GimaId);
	}

	public ProductOffer? GetExact(Product product)
	{
		return GetExact(product, Array.Empty<SelectedModification>());
	}

	public ProductOffer? GetExact(IProductOfferWithModifications product)
	{
		return GetExact(Items, product.SelectedModifications, (ProductOffer offer) => offer.Id == product.Id);
	}

	public ProductOffer? GetUnavailableExact(IProductOfferWithModifications product)
	{
		return GetExact(ItemsUnavailable, product.SelectedModifications, (ProductOffer offer) => offer.Id == product.Id);
	}

	private static T? GetExact<T>(IReadOnlyList<T> items, IProductOfferWithModifications product) where T : class, IProductOfferWithModifications
	{
		return GetExact(items, product.SelectedModifications, (T offer) => offer.Id == product.Id);
	}

	private static T? GetExact<T>(IReadOnlyList<T> items, IReadOnlyList<SelectedModification> selectedModifications, Func<T, bool> searchPredicate) where T : class, IProductOfferWithModifications
	{
		return items.FirstOrDefault((T offer) => searchPredicate(offer) && IsModificationsEqual(offer.SelectedModifications, selectedModifications));
	}

	private static IReadOnlyList<T> Replace<T>(IReadOnlyList<T> items, T product, T to) where T : class, IProductOfferWithModifications
	{
		return Replace(items, to, product.SelectedModifications, (T offer) => offer.Id == product.Id);
	}

	private static IReadOnlyList<T> Replace<T>(IReadOnlyList<T> items, T replacement, IReadOnlyList<SelectedModification> selectedModifications, Func<T, bool> searchPredicate) where T : class, IProductOfferWithModifications
	{
		return Modify(items, selectedModifications, searchPredicate, (IReadOnlyList<T> list, int i) => ReplaceAtPosition(list, i, replacement));
	}

	private static IReadOnlyList<T> Remove<T>(IReadOnlyList<T> items, T product) where T : class, IProductOfferWithModifications
	{
		return Remove(items, product.SelectedModifications, (T offer) => offer.Id == product.Id);
	}

	private static IReadOnlyList<T> Remove<T>(IReadOnlyList<T> items, IReadOnlyList<SelectedModification> selectedModifications, Func<T, bool> searchPredicate) where T : class, IProductOfferWithModifications
	{
		return Modify(items, selectedModifications, searchPredicate, RemoveAtPosition);
	}

	private static IReadOnlyList<T> Modify<T>(IReadOnlyList<T> items, IReadOnlyList<SelectedModification> selectedModifications, Func<T, bool> searchPredicate, Func<IReadOnlyList<T>, int, IReadOnlyList<T>> mutator) where T : class, IProductOfferWithModifications
	{
		if (selectedModifications.IsNotNullOrEmpty())
		{
			for (int i = 0; i < items.Count; i++)
			{
				T val = items[i];
				if (searchPredicate(val) && val.SelectedModifications.IsNotNullOrEmpty() && IsModificationsEqual(val.SelectedModifications, selectedModifications))
				{
					return mutator(items, i);
				}
			}
			return items;
		}
		for (int j = 0; j < items.Count; j++)
		{
			T arg = items[j];
			if (searchPredicate(arg))
			{
				return mutator(items, j);
			}
		}
		return items;
	}

	private static IReadOnlyList<T> ReplaceAtPosition<T>(IReadOnlyList<T> items, int position, T replacement)
	{
		ImmutableList<T>.Builder builder = ImmutableList.CreateBuilder<T>();
		builder.AddRange(items);
		builder[position] = replacement;
		return builder.ToImmutable();
	}

	private static IReadOnlyList<T> RemoveAtPosition<T>(IReadOnlyList<T> items, int position)
	{
		ImmutableList<T>.Builder builder = ImmutableList.CreateBuilder<T>();
		builder.AddRange(items);
		builder.RemoveAt(position);
		return builder.ToImmutable();
	}

	public static bool IsModificationsEqual(IReadOnlyList<SelectedModification> first, IReadOnlyList<SelectedModification> second)
	{
		return first.All((SelectedModification selectedModification) => selectedModification.Value?.Key == second.FirstOrDefault((SelectedModification c) => c.Code == selectedModification.Code)?.Value?.Key);
	}

	private async Task SetOnlineState()
	{
		await Update(Guid.NewGuid());
	}

	private async Task SetOfflineState()
	{
		Items = Array.Empty<ProductOffer>();
		ItemsUnavailable = Array.Empty<ProductOffer>();
	}

	private static int GetTotalItemsQty(IReadOnlyList<ProductOffer> offers, bool selectedOnly)
	{
		decimal num = default(decimal);
		object obj;
		if (!selectedOnly)
		{
			obj = offers;
		}
		else
		{
			obj = offers.Where((ProductOffer i) => i.IsSelected);
		}
		foreach (ProductOffer item in (IEnumerable<ProductOffer>)obj)
		{
			num += ((item.UnitType == ProductUnitType.Unit) ? item.Qty : 1m);
		}
		return (int)num;
	}

	private void AddToPendingChanges(IReadOnlyList<ProductOffer> offers, Guid requestId)
	{
		lock (_pendingChangesLock)
		{
			foreach (ProductOffer offer in offers)
			{
				_pendingChanges = _pendingChanges.SetItem(offer.GetKey(), new PendingChanges(offer, requestId));
			}
			if (_previousAvailableItems == null)
			{
				_previousAvailableItems = Items;
			}
			if (_previousUnavailableItems == null)
			{
				_previousUnavailableItems = ItemsUnavailable;
			}
		}
		NotifyOnPendingChanges();
	}

	private IDisposable OnBeginRequest()
	{
		Interlocked.Increment(ref _pendingRequests);
		NotifyOnPendingChanges();
		return Disposable.Create(delegate
		{
			Interlocked.Decrement(ref _pendingRequests);
			NotifyOnPendingChanges();
		});
	}

	private void NotifyOnPendingChanges()
	{
		MainThread.BeginInvokeOnMainThread(delegate
		{
			this._requestPendingChanged?.Invoke(_pendingRequests + _pendingChanges.Count);
		});
	}

	public IDisposable OnRequestPending(Action<int> handler)
	{
		_requestPendingChanged += handler;
		return Disposable.Create(delegate
		{
			_requestPendingChanged -= handler;
		});
	}

	public Task<Result<ComboSuggestion, DomainError>> GetComboSuggestionsAsync(ProductOffer offer, CancellationToken cancellationToken = default(CancellationToken))
	{
		return _remoteCartService.Value.GetComboSuggestionsAsync(offer, cancellationToken);
	}

	public IDisposable OnCartChanged(EventHandler<CartChangedEventArgs> handler)
	{
		_cartChanged += handler;
		return Disposable.Create(delegate
		{
			_cartChanged -= handler;
		});
	}

	public IDisposable OnCartChanged(Action handler)
	{
		return OnCartChanged((EventHandler<CartChangedEventArgs>)delegate
		{
			handler();
		});
	}

	public IDisposable OnAvailableItemsChanged(EventHandler<AvailableItemsChangedEventArgs> handler)
	{
		_availableItemsChanged += handler;
		return Disposable.Create(delegate
		{
			_availableItemsChanged -= handler;
		});
	}

	public IDisposable OnAvailableItemsChanged(Action handler)
	{
		return OnAvailableItemsChanged((EventHandler<AvailableItemsChangedEventArgs>)delegate
		{
			handler();
		});
	}

	public IDisposable OnItemChangedByUser(EventHandler<OfferUpdatedEventArgs> handler)
	{
		_itemChangedByUser += handler;
		return Disposable.Create(delegate
		{
			_itemChangedByUser -= handler;
		});
	}

	public IDisposable OnItemChangedByUser(Action handler)
	{
		return OnItemChangedByUser((EventHandler<OfferUpdatedEventArgs>)delegate
		{
			handler();
		});
	}

	public IDisposable OnItemReceivedOnCartUpdate(EventHandler<OfferUpdatedEventArgs> handler)
	{
		_itemReceivedOnCartUpdate += handler;
		return Disposable.Create(delegate
		{
			_itemReceivedOnCartUpdate -= handler;
		});
	}

	public IDisposable OnItemReceivedOnCartUpdate(Action handler)
	{
		return OnItemReceivedOnCartUpdate((EventHandler<OfferUpdatedEventArgs>)delegate
		{
			handler();
		});
	}

	public IDisposable OnItemChangeReceived(EventHandler<ItemChangedEventArgs> handler)
	{
		_itemChangeReceived += handler;
		return Disposable.Create(delegate
		{
			_itemChangeReceived -= handler;
		});
	}

	public IDisposable OnItemChangeReceived(Action handler)
	{
		return OnItemChangeReceived((EventHandler<ItemChangedEventArgs>)delegate
		{
			handler();
		});
	}

	public IDisposable OnSilentCartUpdateCompleted(EventHandler<SilentCartUpdateCompletedEventArgs> handler)
	{
		_silentCartUpdateCompleted += handler;
		return Disposable.Create(delegate
		{
			_silentCartUpdateCompleted -= handler;
		});
	}

	public IDisposable OnSilentCartUpdateCompleted(Action handler)
	{
		return OnSilentCartUpdateCompleted((EventHandler<SilentCartUpdateCompletedEventArgs>)delegate
		{
			handler();
		});
	}
}
