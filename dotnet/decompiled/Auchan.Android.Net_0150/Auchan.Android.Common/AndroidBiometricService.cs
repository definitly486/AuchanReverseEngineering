using System;
using System.Linq;
using System.Threading.Tasks;
using AndroidX.Biometric;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using Auchan.Common.SafeEntrance.Enums;
using Auchan.Common.SafeEntrance.Managers;
using Java.Lang;
using Java.Util.Concurrent;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Common;

public class AndroidBiometricService : BiometricPrompt.AuthenticationCallback, IBiometryManager
{
	private TaskCompletionSource<bool> _authTcs;

	public BiometryTypes CanAuthenticate()
	{
		if (BiometricManager.From(Platform.CurrentActivity).CanAuthenticate() == 0)
		{
			return BiometryTypes.Other;
		}
		return BiometryTypes.None;
	}

	public Task<bool> AuthenticateAsync()
	{
		FragmentActivity fragmentActivity = Platform.CurrentActivity as FragmentActivity;
		IExecutor mainExecutor = ContextCompat.GetMainExecutor(fragmentActivity);
		BiometricPrompt.PromptInfo info = new BiometricPrompt.PromptInfo.Builder().SetTitle("Войти").SetDescription("Используйте данные биометрии для входа в приложение").SetNegativeButtonText("Отменить")
			.SetDeviceCredentialAllowed(deviceCredentialAllowed: false)
			.Build();
		Fragment fragment = fragmentActivity.SupportFragmentManager.Fragments.Last();
		BiometricPrompt biometricPrompt = ((fragment != null) ? new BiometricPrompt(fragment, mainExecutor, this) : new BiometricPrompt(fragmentActivity, mainExecutor, this));
		biometricPrompt.Authenticate(info);
		_authTcs = new TaskCompletionSource<bool>();
		return _authTcs.Task;
	}

	public void OpenBiometrySettings()
	{
		throw new NotSupportedException();
	}

	public override void OnAuthenticationError(int errorCode, ICharSequence errString)
	{
		base.OnAuthenticationError(errorCode, errString);
		_authTcs.TrySetResult(result: false);
	}

	public override void OnAuthenticationSucceeded(BiometricPrompt.AuthenticationResult result)
	{
		base.OnAuthenticationSucceeded(result);
		_authTcs.TrySetResult(result: true);
	}
}
