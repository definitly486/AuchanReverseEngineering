using System;
using System.Threading.Tasks;
using Android.Runtime;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;
using IO.Appmetrica.Analytics;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.AppAnalytics.YandexMetrica;

internal sealed class DeferredLinkSupport : IDeferredLinkSupport
{
	private sealed class DeferredDeeplinkListener : Java.Lang.Object, IDeferredDeeplinkListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private readonly TaskCompletionSource<Result<Uri, DomainError>> _tcs;

		public DeferredDeeplinkListener(TaskCompletionSource<Result<Uri, DomainError>> tcs)
		{
			_tcs = tcs;
		}

		public void OnDeeplinkLoaded(string p0)
		{
			if (Uri.TryCreate(p0, default(UriCreationOptions), out Uri result))
			{
				_tcs.TrySetResult(result);
				return;
			}
			_tcs.TrySetResult(new DeferredLinkError
			{
				NativeError = "can't parse uri: [" + p0 + "]"
			});
		}

		public void OnError(IDeferredDeeplinkListener.Error p0, string? p1)
		{
			_tcs.TrySetResult(new DeferredLinkError
			{
				NativeError = p0
			});
		}

		int IJavaPeerable.get_JniIdentityHashCode()
		{
			return base.JniIdentityHashCode;
		}

		JniObjectReference IJavaPeerable.get_PeerReference()
		{
			return base.PeerReference;
		}

		void IJavaPeerable.UnregisterFromRuntime()
		{
			UnregisterFromRuntime();
		}
	}

	public async Task<Result<Uri, DomainError>> GetAsync()
	{
		TaskCompletionSource<Result<Uri, DomainError>> taskCompletionSource = new TaskCompletionSource<Result<Uri, DomainError>>();
		IO.Appmetrica.Analytics.AppMetrica.RequestDeferredDeeplink(new DeferredDeeplinkListener(taskCompletionSource));
		Result<Uri, DomainError> result = await taskCompletionSource.Task;
		if (result.TryGetValue(out var value))
		{
			return value;
		}
		return result;
	}
}
