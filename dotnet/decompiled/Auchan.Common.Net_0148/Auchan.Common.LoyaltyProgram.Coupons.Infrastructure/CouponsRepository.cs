using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Coupons.Models;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Coupons.Infrastructure;

public class CouponsRepository
{
	private const string SeenCouponsCacheKey = "seen_coupon_ids";

	private const char SeenCouponsCacheDelimiter = ',';

	private readonly TimeSpan CouponCacheTime = TimeSpan.FromHours(12);

	private readonly CouponsService _couponsService;

	private readonly ICache _cache;

	private SemaphoreSlim _semaphore = new SemaphoreSlim(1);

	private List<Coupon> Coupons { get; set; } = new List<Coupon>();

	private DateTime? CouponsRequestTime { get; set; }

	public int NewCouponsCount { get; private set; }

	public event EventHandler<long>? CouponSeen;

	public event EventHandler<int>? CouponsChanged;

	public CouponsRepository(CouponsService couponsService, ICache cache, IUserContext userContext)
	{
		_couponsService = couponsService;
		_cache = cache;
		userContext.AfterLoggedOut += delegate
		{
			Coupons.Clear();
			CouponsRequestTime = null;
			return _cache.Remove("seen_coupon_ids");
		};
		CouponsChanged += delegate(object? _, int newCount)
		{
			NewCouponsCount = newCount;
		};
		CouponSeen += delegate
		{
			this.CouponsChanged?.Invoke(this, Math.Max(0, NewCouponsCount - 1));
		};
	}

	internal async Task<Result<List<Coupon>, DomainError>> GetCoupons()
	{
		await _semaphore.WaitAsync();
		try
		{
			if (!CouponsRequestTime.HasValue)
			{
				goto IL_0160;
			}
			DateTime utcNow = DateTime.UtcNow;
			DateTime? couponsRequestTime = CouponsRequestTime;
			if (utcNow - couponsRequestTime > CouponCacheTime)
			{
				goto IL_0160;
			}
			goto end_IL_0093;
			IL_0160:
			Result<List<Coupon>, DomainError> result = await _couponsService.GetCoupons();
			if (result.IsFailure)
			{
				return Result.Failure<List<Coupon>, DomainError>(result.Error);
			}
			Coupons = result.Value.ToList();
			CouponsRequestTime = DateTime.UtcNow;
			end_IL_0093:;
		}
		finally
		{
			_semaphore.Release();
		}
		if (Coupons.IsNullOrEmpty())
		{
			return Result.Failure<List<Coupon>, DomainError>(new NoDataError());
		}
		List<string> seenCouponIds = (await _cache.TryGet<string>("seen_coupon_ids"))?.Split(',')?.ToList();
		if (seenCouponIds.IsNullOrEmpty())
		{
			this.CouponsChanged?.Invoke(this, Coupons.Count((Coupon c) => c.IsNew));
			return Result.Success<List<Coupon>, DomainError>(OrderCoupons(Coupons).ToList());
		}
		Coupons.ForEach(delegate(Coupon c)
		{
			c.IsNew = !seenCouponIds.Contains(c.Id.ToString());
		});
		this.CouponsChanged?.Invoke(this, Coupons.Count((Coupon c) => c.IsNew));
		return Result.Success<List<Coupon>, DomainError>(OrderCoupons(Coupons).ToList());
	}

	public IOrderedEnumerable<Coupon> OrderCoupons(IEnumerable<Coupon> coupons)
	{
		return from c in coupons
			orderby c.IsNew descending, c.ExpiryDate, c.Name
			select c;
	}

	internal async Task OnCouponSeen(long couponId)
	{
		List<string> list = (await _cache.TryGet<string>("seen_coupon_ids"))?.Split(',')?.ToList() ?? new List<string>();
		if (!list.Contains(couponId.ToString()))
		{
			list.Add(couponId.ToString());
			await _cache.Save("seen_coupon_ids", string.Join(','.ToString(), list));
			this.CouponSeen?.Invoke(this, couponId);
		}
	}
}
