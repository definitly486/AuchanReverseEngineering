using System.ComponentModel;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Reviews.Model;

namespace Auchan.Common.Reviews;

public interface IProductReviewsViewModel : IBindable, INotifyPropertyChanged
{
	string ReviewsWithPhotoText { get; }

	bool IsPhotoFilterActive { get; }

	UICommand SortClickCommand { get; }

	UICommand PhotoFilterClickCommand { get; }

	Rate? Rate { get; }

	bool IsPhotoFilterButtonVisible { get; }

	ReviewSortItem SelectedSort { get; }
}
