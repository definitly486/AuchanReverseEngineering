using System;
using AndroidX.Lifecycle;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Base;

internal static class RetainExtensions
{
	private static readonly ViewModelProvider.IFactory _viewModelInstanceFactory = new ViewModelProvider.NewInstanceFactory();

	internal static T Retain<TOwner, T>(this TOwner owner, string key, Func<T> newValueFactory, Action<T>? onClean = null) where TOwner : IViewModelStoreOwner, ILifecycleOwner
	{
		RetainerViewModel retainerViewModel = new ViewModelProvider(owner, _viewModelInstanceFactory).Get(Class.FromType(typeof(RetainerViewModel))).JavaCast<RetainerViewModel>();
		if (retainerViewModel.RetainedObjects.TryGetValue(key, out var value))
		{
			return (T)value.Item1;
		}
		T newValue = newValueFactory();
		retainerViewModel.RetainedObjects[key] = new Tuple<object, Action>(newValue, delegate
		{
			onClean?.Invoke(newValue);
		});
		return newValue;
	}
}
