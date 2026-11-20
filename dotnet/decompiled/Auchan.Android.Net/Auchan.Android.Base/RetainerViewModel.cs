using System;
using System.Collections.Generic;
using AndroidX.Lifecycle;

namespace Auchan.Android.Base;

internal class RetainerViewModel : ViewModel
{
	public IDictionary<string, Tuple<object, Action>> RetainedObjects { get; } = new Dictionary<string, Tuple<object, Action>>();

	protected override void OnCleared()
	{
		base.OnCleared();
		foreach (KeyValuePair<string, Tuple<object, Action>> retainedObject in RetainedObjects)
		{
			retainedObject.Deconstruct(out var _, out var value);
			value.Deconstruct(out var _, out var item2);
			item2();
		}
		RetainedObjects.Clear();
	}
}
