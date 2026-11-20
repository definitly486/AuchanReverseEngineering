using System.IO;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net;

public class FileWebRequest : WebRequest, ISerializable
{
	private readonly WebHeaderCollection _headers = new WebHeaderCollection();

	private string _method = "GET";

	private FileAccess _fileAccess = FileAccess.Read;

	private ManualResetEventSlim _blockReaderUntilRequestStreamDisposed;

	private FileWebResponse _response;

	private readonly Uri _uri;

	private int _timeout = 100000;

	private bool _readPending;

	private bool _writePending;

	private bool _writing;

	private bool _syncHint;

	private int _aborted;

	internal bool Aborted => _aborted != 0;

	public override ICredentials? Credentials { get; }

	public override string Method
	{
		get
		{
			return _method;
		}
		set
		{
			ArgumentException.ThrowIfNullOrEmpty(value, "value");
			_method = value;
		}
	}

	public override bool PreAuthenticate { get; }

	public override int Timeout
	{
		get
		{
			return _timeout;
		}
		set
		{
			if (value < 0 && value != -1)
			{
				throw new ArgumentOutOfRangeException("value", "net_io_timeout_use_ge_zero");
			}
			_timeout = value;
		}
	}

	public override Uri RequestUri => _uri;

	internal FileWebRequest(Uri uri)
	{
		if ((object)uri.Scheme != Uri.UriSchemeFile)
		{
			throw new ArgumentOutOfRangeException("uri");
		}
		_uri = uri;
	}

	[Obsolete("Serialization has been deprecated for FileWebRequest.")]
	void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{
		GetObjectData(serializationInfo, streamingContext);
	}

	[Obsolete("Serialization has been deprecated for FileWebRequest.")]
	protected override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{
		throw new PlatformNotSupportedException();
	}

	private static WebException CreateRequestAbortedException()
	{
		return new WebException(System.SR.Format("net_requestaborted", WebExceptionStatus.RequestCanceled), WebExceptionStatus.RequestCanceled);
	}

	private void CheckAndMarkAsyncGetResponsePending()
	{
		if (Aborted)
		{
			throw CreateRequestAbortedException();
		}
		lock (this)
		{
			if (_readPending)
			{
				throw new InvalidOperationException("net_repcall");
			}
			_readPending = true;
		}
	}

	private WebResponse CreateResponse()
	{
		if (_writePending || _writing)
		{
			lock (this)
			{
				if (_writePending || _writing)
				{
					_blockReaderUntilRequestStreamDisposed = new ManualResetEventSlim();
				}
			}
		}
		_blockReaderUntilRequestStreamDisposed?.Wait();
		try
		{
			return _response ?? (_response = new FileWebResponse(this, _uri, _fileAccess, !_syncHint));
		}
		catch (Exception ex)
		{
			throw new WebException(ex.Message, ex);
		}
	}

	public override IAsyncResult BeginGetResponse(AsyncCallback? callback, object? state)
	{
		CheckAndMarkAsyncGetResponsePending();
		return TaskToAsyncResult.Begin(Task.Factory.StartNew((object s) => ((FileWebRequest)s).CreateResponse(), this, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default), callback, state);
	}

	public override Task<WebResponse> GetResponseAsync()
	{
		CheckAndMarkAsyncGetResponsePending();
		return Task.Factory.StartNew(delegate(object s)
		{
			WebResponse result = ((FileWebRequest)s).CreateResponse();
			_readPending = false;
			return result;
		}, this, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
	}

	public override WebResponse EndGetResponse(IAsyncResult asyncResult)
	{
		WebResponse result = TaskToAsyncResult.End<WebResponse>(asyncResult);
		_readPending = false;
		return result;
	}

	internal void UnblockReader()
	{
		lock (this)
		{
			_blockReaderUntilRequestStreamDisposed?.Set();
		}
		_writing = false;
	}
}
