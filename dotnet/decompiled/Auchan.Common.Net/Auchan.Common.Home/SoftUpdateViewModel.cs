using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.HardUpdate;

namespace Auchan.Common.Home;

public class SoftUpdateViewModel : ScreenViewModel
{
	private readonly Subject<Unit> _cancelClickedCommand = new Subject<Unit>();

	private readonly IAdminContext _adminContext;

	private readonly Lazy<IUpdateService> _updateService;

	public string PopupTitle = "У нас обновление!";

	[CompilerGenerated]
	private string _003CSoftUpdateTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CSoftUpdateMessage_003Ek__BackingField;

	public string UpdateButtonText = "Обновить";

	public IObservable<Unit> CancelClickedCommand => _cancelClickedCommand.Debounce();

	public string SoftUpdateTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CSoftUpdateTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CSoftUpdateTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSoftUpdateTitle_003Ek__BackingField = value;
				RaisePropertyChanged("SoftUpdateTitle");
			}
		}
	} = string.Empty;

	public string SoftUpdateMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CSoftUpdateMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CSoftUpdateMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSoftUpdateMessage_003Ek__BackingField = value;
				RaisePropertyChanged("SoftUpdateMessage");
			}
		}
	} = string.Empty;

	public SoftUpdateViewModel(IAdminContext adminContext, Lazy<IUpdateService> updateService)
	{
		_adminContext = adminContext;
		_updateService = updateService;
	}

	protected override Task Start()
	{
		SoftUpdateTitle = _adminContext.AppConfig.AppVersion.PopupTitle;
		SoftUpdateMessage = _adminContext.AppConfig.AppVersion.PopupMessage;
		return base.Start();
	}

	public void UpdateClicked()
	{
		_updateService.Value.NavigateToStoreAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void CancelClicked()
	{
		_cancelClickedCommand.OnNext(Unit.Default);
	}
}
