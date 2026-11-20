using System;
using System.ComponentModel;
using System.Reactive.Disposables;

namespace Auchan.Common.Base;

public abstract class BaseItemViewModel : NotifyPropertyChanged, IDisposable, IBindable, INotifyPropertyChanged
{
	protected CompositeDisposable Disposables { get; } = new CompositeDisposable();

	protected override void RaisePropertyChanged(string propertyName)
	{
		base.RaisePropertyChanged(propertyName);
	}

	public void Dispose()
	{
		if (Disposables != null && !Disposables.IsDisposed)
		{
			Disposables.Dispose();
		}
	}
}
