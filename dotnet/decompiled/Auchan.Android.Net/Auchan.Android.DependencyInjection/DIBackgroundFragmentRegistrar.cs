using System;
using System.Linq;
using System.Threading.Tasks;
using AndroidX.Fragment.App;
using DryIoc;
using Java.Lang;

namespace Auchan.Android.DependencyInjection;

internal class DIBackgroundFragmentRegistrar
{
	private readonly IContainer _parent;

	private readonly Task _registerFragmentsInBackground;

	public DIBackgroundFragmentRegistrar(IContainer parent)
	{
		_parent = parent;
		_registerFragmentsInBackground = Task.Run((Action)RegisterAllFragments);
	}

	private void RegisterAllFragments()
	{
		Type androidFragmentType = typeof(Fragment);
		foreach (Type item in from type in typeof(DependencyRegistry).Assembly.GetTypes()
			where type.IsClass && !type.IsAbstract && androidFragmentType.IsAssignableFrom(type)
			select type)
		{
			IContainer parent = _parent;
			Type serviceType = androidFragmentType;
			object name = Class.FromType(item).Name;
			parent.Register(serviceType, item, null, null, null, null, name);
			_parent.Register(item);
		}
	}

	public IResolver GetResolver()
	{
		if (_registerFragmentsInBackground.IsCompleted)
		{
			return _parent;
		}
		_registerFragmentsInBackground.GetAwaiter().GetResult();
		return _parent;
	}
}
