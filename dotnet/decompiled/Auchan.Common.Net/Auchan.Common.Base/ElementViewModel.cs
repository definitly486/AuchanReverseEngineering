using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.Base;

public abstract class ElementViewModel : INotifyPropertyChanged, IDisposable, IBindable
{
	[CompilerGenerated]
	private ScreenViewModel? _003CParentViewModel_003Ek__BackingField;

	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	public ScreenViewModel? ParentViewModel
	{
		[CompilerGenerated]
		get
		{
			return _003CParentViewModel_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CParentViewModel_003Ek__BackingField, value))
			{
				_003CParentViewModel_003Ek__BackingField = value;
				RaisePropertyChanged("ParentViewModel");
			}
		}
	}

	public UICommand StateUpdatedCommand { get; } = new UICommand();

	protected ICollection<IDisposable> Disposables => _disposables;

	public event PropertyChangedEventHandler? PropertyChanged;

	protected ElementViewModel(ScreenViewModel parentViewModel)
	{
		ParentViewModel = parentViewModel;
	}

	protected ElementViewModel()
	{
	}

	public virtual Task Start()
	{
		return Task.CompletedTask;
	}

	public virtual Task OnResumed()
	{
		return Task.CompletedTask;
	}

	public virtual Task OnPaused()
	{
		return Task.CompletedTask;
	}

	protected void RaisePropertyChanged(string property)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
	}

	public void Dispose()
	{
		_disposables.Dispose();
	}
}
