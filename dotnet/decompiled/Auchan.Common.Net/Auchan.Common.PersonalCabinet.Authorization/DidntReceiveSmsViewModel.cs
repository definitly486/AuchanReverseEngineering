using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;

namespace Auchan.Common.PersonalCabinet.Authorization;

public class DidntReceiveSmsViewModel : ScreenViewModel
{
	public class Parameter
	{
		public string PhoneNumber { get; }

		public bool SendLogs { get; }

		public Parameter(string phoneNumber, bool sendLogs)
		{
			PhoneNumber = phoneNumber;
			SendLogs = sendLogs;
		}
	}

	public string Title => "Если вам не приходит SMS или вы не можете войти";

	public string CheckYourPhoneHint => "Проверьте введенный вами номер телефона:";

	public string PhoneMask => "+7 ([000]) [000]-[00]-[00]";

	public string PhoneNumberHint => "Телефон";

	public string PhoneNumber { get; }

	public string SupportHint => "Если номер телефона правильный, но SMS все равно не приходит или вы не можете войти, обратитесь в службу поддержки:";

	public string ButtonTitle => "Отправить обращение";

	public UICommand DismissCommand { get; } = new UICommand();

	public UICommand CallSupportCommand { get; } = new UICommand();

	public IReadOnlyList<string> InfoText { get; } = new global::_003C_003Ez__ReadOnlyArray<string>(new string[6] { "Проверьте введенный вами номер телефона", "Проверьте стабильность сотовой связи", "Убедитесь, что на устройстве достаточно памяти", "Убедитесь, что авиарежим или \"Не беспокоить\" выключены", "Проверьте, не находится ли номер в черном списке", "Перезагрузите телефон" });

	public bool SendLogs { get; }

	public DidntReceiveSmsViewModel(Parameter parameter)
	{
		PhoneNumber = parameter.PhoneNumber;
		SendLogs = parameter.SendLogs;
		CallSupportCommand.Subscribe(delegate
		{
			AppAnalytics.AppMetrica.TrackEvent("helphelpScreenViewScreenButtonForm");
		}).AddTo(base.CloseDisposable);
		DismissCommand.Subscribe(delegate
		{
			AppAnalytics.AppMetrica.TrackEvent("helpScreenButtonClose");
		}).AddTo(base.CloseDisposable);
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		AppAnalytics.AppMetrica.TrackEvent("helphelpScreenView");
	}
}
