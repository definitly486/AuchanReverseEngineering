using AndroidX.Fragment.App;
using DryIoc;
using Java.Lang;

namespace Auchan.Android.DependencyInjection;

internal class DIFragmentFactory : FragmentFactory
{
	private readonly DIBackgroundFragmentRegistrar _fragmentContainer;

	public DIFragmentFactory(DIBackgroundFragmentRegistrar fragmentContainer)
	{
		_fragmentContainer = fragmentContainer;
	}

	public override Fragment Instantiate(ClassLoader classLoader, string className)
	{
		Fragment fragment = _fragmentContainer.GetResolver().Resolve<Fragment>(className, IfUnresolved.ReturnDefault);
		if (fragment == null)
		{
			fragment = base.Instantiate(classLoader, className);
		}
		return fragment;
	}
}
