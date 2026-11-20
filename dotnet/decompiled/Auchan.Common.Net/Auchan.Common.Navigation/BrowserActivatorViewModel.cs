using System;
using Auchan.Common.Base;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Navigation;

public sealed class BrowserActivatorViewModel : ScreenViewModel
{
	public sealed class Parameter
	{
		public required Uri Uri { get; init; }

		public required BrowserLaunchMode LaunchMode { get; set; }
	}

	public Parameter Argument { get; }

	public BrowserActivatorViewModel(Parameter parameter)
	{
		Argument = parameter;
	}
}
