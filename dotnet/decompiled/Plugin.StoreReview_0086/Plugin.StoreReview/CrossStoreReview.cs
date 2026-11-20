using System;
using System.Threading;
using Plugin.StoreReview.Abstractions;

namespace Plugin.StoreReview;

public class CrossStoreReview
{
	private static readonly Lazy<IStoreReview> implementation = new Lazy<IStoreReview>(() => CreateStoreReview(), LazyThreadSafetyMode.PublicationOnly);

	public static bool IsSupported => implementation.Value != null;

	public static IStoreReview Current
	{
		get
		{
			IStoreReview value = implementation.Value;
			if (value != null)
			{
				return value;
			}
			throw NotImplementedInReferenceAssembly();
		}
	}

	private static IStoreReview CreateStoreReview()
	{
		return new StoreReviewImplementation();
	}

	internal static Exception NotImplementedInReferenceAssembly()
	{
		return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
	}
}
