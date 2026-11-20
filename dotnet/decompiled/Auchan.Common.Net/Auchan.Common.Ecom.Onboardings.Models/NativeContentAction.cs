using System.Threading.Tasks;
using Auchan.Common.Common;
using DryIoc;

namespace Auchan.Common.Ecom.Onboardings.Models;

internal sealed class NativeContentAction : IOnboardingAction
{
	private readonly string _nativeContent;

	public string Text { get; }

	public NativeContentAction(IResolver resolver, string? text, string nativeContent)
	{
		_nativeContent = nativeContent;
		Text = text ?? "";
	}

	public Task ActivateAsync(ShowAt showAt, IOnboardingActionSupport actionSupport)
	{
		if (showAt == ShowAt.BeforeAuth)
		{
			return Task.CompletedTask;
		}
		actionSupport.WebCommand.Trigger(new WebViewModel.Parameter
		{
			Content = _nativeContent
		});
		return Task.CompletedTask;
	}
}
