using Android.Content;
using Android.Views;
using AndroidX.Fragment.App;

namespace Auchan.Android.Base;

internal interface IFragment
{
	LayoutInflater LayoutInflater { get; }

	Context? Context { get; }

	FragmentManager ParentFragmentManager { get; }
}
