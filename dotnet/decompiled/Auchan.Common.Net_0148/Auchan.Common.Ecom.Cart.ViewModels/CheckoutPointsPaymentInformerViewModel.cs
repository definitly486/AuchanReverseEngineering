using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public class CheckoutPointsPaymentInformerViewModel : ScreenViewModel
{
	public class Parameter
	{
		public string Text { get; set; }

		public string Link { get; set; }

		public Parameter(string text, string link)
		{
			Text = text;
			Link = link;
		}
	}

	private Subject<Unit> _onClose = new Subject<Unit>();

	[CompilerGenerated]
	private LinkedText _003CDescription_003Ek__BackingField;

	public IObservable<Unit> CloseCommand => _onClose.Debounce();

	public string Title => "Списание баллов";

	public LinkedText Description
	{
		[CompilerGenerated]
		get
		{
			return _003CDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CDescription_003Ek__BackingField, value))
			{
				_003CDescription_003Ek__BackingField = value;
				RaisePropertyChanged("Description");
			}
		}
	}

	public CheckoutPointsPaymentInformerViewModel(Parameter parameter)
	{
		Description = new LinkedText(parameter.Text, parameter.Link, delegate
		{
		});
	}

	public void OnCloseClick()
	{
		_onClose.OnNext(Unit.Default);
	}
}
