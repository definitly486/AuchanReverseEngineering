using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reactive.Disposables;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Banners.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Banners;

public interface IBannersRepository
{
	IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>> NoBanners => ImmutableDictionary<BannerType, IReadOnlyList<Banner>>.Empty;

	event EventHandler<BannersUpdatedEventArgs>? BannersUpdateWeakEvent;

	Task<Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError>> GetBannersAsync(CancellationToken cancellationToken = default(CancellationToken));

	IDisposable OnBannersUpdate(EventHandler<BannersUpdatedEventArgs> handler)
	{
		BannersUpdateWeakEvent += handler;
		return Disposable.Create(delegate
		{
			BannersUpdateWeakEvent -= handler;
		});
	}
}
