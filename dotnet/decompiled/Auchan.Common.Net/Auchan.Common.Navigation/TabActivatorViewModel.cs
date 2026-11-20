using System;
using Auchan.Common.Base;

namespace Auchan.Common.Navigation;

public sealed class TabActivatorViewModel : ScreenViewModel
{
	public sealed class Parameter
	{
		public Type? ActualDestination { get; set; }

		public BottomNavigationViewModel.TabbarItem Tab { get; set; }

		public object? ActualParameter { get; init; }
	}

	public Parameter Argument { get; }

	public TabActivatorViewModel(Parameter parameter)
	{
		Argument = parameter;
	}
}
