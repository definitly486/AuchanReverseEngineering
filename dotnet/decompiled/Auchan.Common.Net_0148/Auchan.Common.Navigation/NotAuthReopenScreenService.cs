using System;

namespace Auchan.Common.Navigation;

public class NotAuthReopenScreenService(INavigationService navigationService, INavigationContext navigationContext)
{
	private Type? _type;

	private object? _parameter;

	public void NavigateIfNeeded()
	{
		if (_type != null)
		{
			navigationService.NavigateTo(_type, _parameter);
		}
		_type = null;
		_parameter = null;
	}

	public void SaveParameterForType<T, TP>(T viewModelType, TP parameter) where T : Type where TP : class
	{
		navigationContext.IsNavigatedFromStart = true;
		_type = viewModelType;
		_parameter = parameter;
	}

	public void Clear()
	{
		_type = null;
		_parameter = null;
	}
}
