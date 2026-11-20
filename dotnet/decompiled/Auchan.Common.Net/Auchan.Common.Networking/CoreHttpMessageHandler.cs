using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Microsoft.Maui.Networking;

namespace Auchan.Common.Networking;

public class CoreHttpMessageHandler : DelegatingHandler
{
	private readonly IHeaderInjector _injector;

	private readonly IHeaderInjector2 _injector2;

	private readonly IBasicAuthorizationHeaderInjector _basicAuthorizationHeaderInjector;

	private readonly Func<CookieContainer, IHttpMessageHandler> _messageHandlerFactory;

	private readonly CookieContainer _cookieContainer;

	private IHttpMessageHandler _handler;

	private CancellationTokenSource _tokenSource;

	private object _lock;

	public CoreHttpMessageHandler(IHeaderInjector injector, IHeaderInjector2 injector2, IBasicAuthorizationHeaderInjector basicAuthorizationHeaderInjector, Func<CookieContainer, IHttpMessageHandler> messageHandlerFactory)
	{
		_injector = injector;
		_injector2 = injector2;
		_basicAuthorizationHeaderInjector = basicAuthorizationHeaderInjector;
		_messageHandlerFactory = messageHandlerFactory;
		_cookieContainer = new CookieContainer();
		_handler = messageHandlerFactory(_cookieContainer);
		_tokenSource = new CancellationTokenSource();
		_lock = new object();
		Connectivity.ConnectivityChanged += OnConnectivityChanged;
	}

	private void OnConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
	{
		ReplaceHandler();
	}

	private void ReplaceHandler()
	{
		IHttpMessageHandler handler;
		CancellationTokenSource tokenSource;
		lock (_lock)
		{
			handler = _handler;
			tokenSource = _tokenSource;
			_handler = _messageHandlerFactory(_cookieContainer);
			_tokenSource = new CancellationTokenSource();
		}
		tokenSource.Cancel();
		tokenSource.Dispose();
		handler.Dispose();
	}

	private (IHttpMessageHandler, CancellationTokenSource) GetLocked()
	{
		lock (_lock)
		{
			return (_handler, _tokenSource);
		}
	}

	public Task<HttpResponseMessage> SendAsync(HttpRequestMessage message)
	{
		return SendAsync(message, CancellationToken.None);
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		await _basicAuthorizationHeaderInjector.Inject(request, cancellationToken);
		_injector.Inject(request);
		_injector2.Inject(request);
		(IHttpMessageHandler, CancellationTokenSource) locked = GetLocked();
		IHttpMessageHandler item = locked.Item1;
		CancellationTokenSource item2 = locked.Item2;
		TaskCompletionSource<HttpResponseMessage> tcs = new TaskCompletionSource<HttpResponseMessage>();
		try
		{
			using CancellationTokenSource linked = CancellationTokenSource.CreateLinkedTokenSource(item2.Token, cancellationToken);
			using (linked.Token.Register(delegate
			{
				if (cancellationToken.IsCancellationRequested)
				{
					tcs.TrySetCanceled();
				}
				else
				{
					tcs.TrySetException(new NetworkChangedException());
				}
			}))
			{
				DoSendAsync(item, tcs, request, linked.Token).SafeFireAndForget((Action<Exception>)null, false);
				return await tcs.Task;
			}
		}
		catch (TaskCanceledException ex) when (ex.InnerException is ObjectDisposedException ex2 && ex2.ObjectName == "MobileAuthenticatedStream")
		{
			ReplaceHandler();
			throw;
		}
		static async Task DoSendAsync(IHttpMessageHandler handler, TaskCompletionSource<HttpResponseMessage> taskCompletionSource, HttpRequestMessage request2, CancellationToken cancellationToken2)
		{
			_ = 2;
			try
			{
				using HttpResponseMessage response = await handler.SendAsync(request2, cancellationToken2);
				cancellationToken2.ThrowIfCancellationRequested();
				using Stream stream = await response.Content.ReadAsStreamAsync();
				cancellationToken2.ThrowIfCancellationRequested();
				MemoryStream ms = new MemoryStream();
				await stream.CopyWithCancellationToAsync(ms, cancellationToken2);
				ms.Position = 0L;
				HttpResponseMessage result = response.Clone(new StreamContent(ms));
				cancellationToken2.ThrowIfCancellationRequested();
				taskCompletionSource.TrySetResult(result);
			}
			catch (Exception exception)
			{
				taskCompletionSource.TrySetException(exception);
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (disposing)
		{
			_tokenSource.Dispose();
			_handler.Dispose();
			Connectivity.ConnectivityChanged -= OnConnectivityChanged;
		}
	}
}
