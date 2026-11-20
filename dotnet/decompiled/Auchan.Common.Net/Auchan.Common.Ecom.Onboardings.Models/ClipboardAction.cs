using System;
using System.Threading.Tasks;
using Auchan.Common.Common;
using DryIoc;
using Microsoft.Maui.ApplicationModel.DataTransfer;

namespace Auchan.Common.Ecom.Onboardings.Models;

internal sealed class ClipboardAction : IOnboardingAction
{
	private readonly string _content;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	public string Text { get; }

	public ClipboardAction(IResolver resolver, string? text, string content)
	{
		_content = content;
		_infoMessageService = resolver.Resolve<Lazy<IInfoMessageService>>();
		Text = text ?? "";
	}

	public async Task ActivateAsync(ShowAt showAt, IOnboardingActionSupport actionSupport)
	{
		await Clipboard.SetTextAsync(_content);
		_infoMessageService.Value.ShowSnackbar("Скопировано в буфер обмена", SnackbarStyle.Success);
		actionSupport.NextCommand.Trigger();
	}
}
