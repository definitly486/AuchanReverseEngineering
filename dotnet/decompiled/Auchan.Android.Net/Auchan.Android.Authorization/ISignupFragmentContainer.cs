using AndroidX.AppCompat.Widget;

namespace Auchan.Android.Authorization;

public interface ISignupFragmentContainer
{
	Toolbar Toolbar { get; set; }

	string Title { get; set; }

	string CloseButtonText { set; }
}
