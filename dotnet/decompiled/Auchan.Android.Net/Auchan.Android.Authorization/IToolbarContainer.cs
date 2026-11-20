using System;
using System.Reactive;
using Android.Views;
using AndroidX.AppCompat.Widget;

namespace Auchan.Android.Authorization;

internal interface IToolbarContainer
{
	string Title { set; }

	string? CloseButtonText { set; }

	View CloseButton { get; }

	Toolbar Toolbar { get; }

	IDisposable CustomBackAction(Action<Unit> action);
}
