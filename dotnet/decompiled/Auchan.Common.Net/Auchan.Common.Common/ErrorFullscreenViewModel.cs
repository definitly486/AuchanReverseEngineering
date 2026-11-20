using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.PersonalCabinet;

namespace Auchan.Common.Common;

public class ErrorFullscreenViewModel : ScreenViewModel, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public class Parameter
	{
		public FullscreenErrorType ErrorType { get; }

		public bool IsCloseButtonVisible { get; }

		public Parameter(FullscreenErrorType errorType, bool isCloseButtonVisible)
		{
			ErrorType = errorType;
			IsCloseButtonVisible = isCloseButtonVisible;
		}
	}

	private readonly IUserContext _userContext;

	private readonly Parameter _parameter;

	private readonly Dictionary<FullscreenErrorType, string> _titleValues = new Dictionary<FullscreenErrorType, string>
	{
		{
			FullscreenErrorType.Retry,
			"Упс! Что-то пошло не так."
		},
		{
			FullscreenErrorType.IncorrectAddress,
			"Адрес не соответствует выбранному магазину."
		}
	};

	private readonly Dictionary<FullscreenErrorType, string> _messageValues = new Dictionary<FullscreenErrorType, string>
	{
		{
			FullscreenErrorType.Retry,
			"Небольшие технические проблемы,\nпопробуйте обновить экран."
		},
		{
			FullscreenErrorType.IncorrectAddress,
			"Выберите ближайший магазин на экране корзины и повторите попытку."
		}
	};

	private readonly Dictionary<FullscreenErrorType, string> _buttonValues = new Dictionary<FullscreenErrorType, string>
	{
		{
			FullscreenErrorType.Retry,
			"Повторить"
		},
		{
			FullscreenErrorType.IncorrectAddress,
			"Вернуться в корзину"
		}
	};

	[CompilerGenerated]
	private UICommand _003COnNextCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003COnCloseCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003COnQRCodeCommand_003Ek__BackingField;

	public UICommand OnNextCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COnNextCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COnNextCommand_003Ek__BackingField, value))
			{
				_003COnNextCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OnNextCommand");
			}
		}
	} = new UICommand();

	public UICommand OnCloseCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COnCloseCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COnCloseCommand_003Ek__BackingField, value))
			{
				_003COnCloseCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OnCloseCommand");
			}
		}
	} = new UICommand();

	public UICommand OnQRCodeCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COnQRCodeCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COnQRCodeCommand_003Ek__BackingField, value))
			{
				_003COnQRCodeCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OnQRCodeCommand");
			}
		}
	} = new UICommand();

	public string Title => _titleValues[_parameter.ErrorType];

	public string Message => _messageValues[_parameter.ErrorType];

	public string ButtonText => _buttonValues[_parameter.ErrorType];

	public bool IsCloseButtonVisible => _parameter.IsCloseButtonVisible;

	public bool IsActionButtonVisible => false;

	public bool IsQRCodeButtonVisible
	{
		get
		{
			if (_userContext.Authorized)
			{
				return _userContext.Profile != null;
			}
			return false;
		}
	}

	public string QRCodeButtonText => "Показать карту лояльности";

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "";

	string IYandexMetricaScreenViewModel.ScreenName => "ErrorFullscreen";

	public ErrorFullscreenViewModel(IUserContext userContext, Parameter parameter)
	{
		_userContext = userContext;
		_parameter = parameter;
	}
}
