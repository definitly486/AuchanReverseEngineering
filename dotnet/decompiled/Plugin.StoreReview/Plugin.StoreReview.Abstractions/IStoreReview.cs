using System.Threading.Tasks;

namespace Plugin.StoreReview.Abstractions;

public interface IStoreReview
{
	Task<ReviewStatus> RequestReview(bool testMode);
}
