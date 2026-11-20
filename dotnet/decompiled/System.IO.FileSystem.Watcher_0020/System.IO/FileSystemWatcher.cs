using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace System.IO;

public class FileSystemWatcher : Component
{
	private sealed class NormalizedFilterCollection : Collection<string>
	{
		private sealed class ImmutableStringList : IList<string>, ICollection<string>, IEnumerable<string>, IEnumerable
		{
			public string[] Items = Array.Empty<string>();

			public string this[int index]
			{
				get
				{
					string[] items = Items;
					ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual((uint)index, (uint)items.Length, "index");
					return items[index];
				}
				set
				{
					string[] array = (string[])Items.Clone();
					array[index] = value;
					Items = array;
				}
			}

			public int Count => Items.Length;

			public bool IsReadOnly => false;

			public void Add(string item)
			{
				throw new NotSupportedException();
			}

			public void Clear()
			{
				Items = Array.Empty<string>();
			}

			public bool Contains(string item)
			{
				return Array.IndexOf(Items, item) != -1;
			}

			public void CopyTo(string[] array, int arrayIndex)
			{
				Items.CopyTo(array, arrayIndex);
			}

			public IEnumerator<string> GetEnumerator()
			{
				return ((IEnumerable<string>)Items).GetEnumerator();
			}

			public int IndexOf(string item)
			{
				return Array.IndexOf(Items, item);
			}

			public void Insert(int index, string item)
			{
				string[] items = Items;
				string[] array = new string[items.Length + 1];
				items.AsSpan(0, index).CopyTo(array);
				items.AsSpan(index).CopyTo(array.AsSpan(index + 1));
				array[index] = item;
				Items = array;
			}

			public bool Remove(string item)
			{
				throw new NotSupportedException();
			}

			public void RemoveAt(int index)
			{
				string[] items = Items;
				string[] array = new string[items.Length - 1];
				items.AsSpan(0, index).CopyTo(array);
				items.AsSpan(index + 1).CopyTo(array.AsSpan(index));
				Items = array;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		internal NormalizedFilterCollection()
			: base((IList<string>)new ImmutableStringList())
		{
		}

		protected override void InsertItem(int index, string item)
		{
			base.InsertItem(index, (string.IsNullOrEmpty(item) || item == "*.*") ? "*" : item);
		}

		protected override void SetItem(int index, string item)
		{
			base.SetItem(index, (string.IsNullOrEmpty(item) || item == "*.*") ? "*" : item);
		}

		internal string[] GetFilters()
		{
			return ((ImmutableStringList)base.Items).Items;
		}
	}

	private sealed class RunningInstance
	{
		private struct NotifyEvent
		{
			internal int wd;

			internal uint mask;

			internal uint cookie;

			internal string name;
		}

		private sealed class WatchedDirectory
		{
			[ThreadStatic]
			private static StringBuilder t_builder;

			internal WatchedDirectory Parent;

			internal int WatchDescriptor;

			internal string Name;

			internal List<WatchedDirectory> Children;

			internal List<WatchedDirectory> InitializedChildren => Children ?? (Children = new List<WatchedDirectory>());

			internal string GetPath(bool relativeToRoot, string additionalName = null)
			{
				StringBuilder stringBuilder = t_builder ?? (t_builder = new StringBuilder());
				stringBuilder.Clear();
				Write(stringBuilder, relativeToRoot);
				if (additionalName != null)
				{
					AppendSeparatorIfNeeded(stringBuilder);
					stringBuilder.Append(additionalName);
				}
				return stringBuilder.ToString();
			}

			private void Write(StringBuilder builder, bool relativeToRoot)
			{
				if (Parent != null)
				{
					Parent.Write(builder, relativeToRoot);
					AppendSeparatorIfNeeded(builder);
				}
				if (Parent != null || !relativeToRoot)
				{
					builder.Append(Name);
				}
			}

			private static void AppendSeparatorIfNeeded(StringBuilder builder)
			{
				if (builder.Length > 0)
				{
					char c = builder[builder.Length - 1];
					if (c != System.IO.Path.DirectorySeparatorChar && c != System.IO.Path.AltDirectorySeparatorChar)
					{
						builder.Append(System.IO.Path.DirectorySeparatorChar);
					}
				}
			}
		}

		private readonly WeakReference<FileSystemWatcher> _weakWatcher;

		private readonly string _directoryPath;

		private readonly SafeFileHandle _inotifyHandle;

		private readonly byte[] _buffer;

		private int _bufferAvailable;

		private int _bufferPos;

		private readonly NotifyFilters _notifyFilters;

		private readonly global::Interop.Sys.NotifyEvents _watchFilters;

		private readonly bool _includeSubdirectories;

		private readonly CancellationToken _cancellationToken;

		private readonly Dictionary<int, WatchedDirectory> _wdToPathMap = new Dictionary<int, WatchedDirectory>();

		private object SyncObj => _wdToPathMap;

		internal RunningInstance(FileSystemWatcher watcher, SafeFileHandle inotifyHandle, string directoryPath, bool includeSubdirectories, NotifyFilters notifyFilters, CancellationToken cancellationToken)
		{
			_weakWatcher = new WeakReference<FileSystemWatcher>(watcher);
			_inotifyHandle = inotifyHandle;
			_directoryPath = directoryPath;
			_buffer = watcher.AllocateBuffer();
			_includeSubdirectories = includeSubdirectories;
			_notifyFilters = notifyFilters;
			_watchFilters = TranslateFilters(notifyFilters);
			_cancellationToken = cancellationToken;
			AddDirectoryWatchUnlocked(null, directoryPath);
		}

		internal void Start()
		{
			Thread thread = new Thread(delegate(object obj)
			{
				((RunningInstance)obj).ProcessEvents();
			});
			thread.IsBackground = true;
			thread.Name = ".NET File Watcher";
			thread.Start(this);
		}

		private void AddDirectoryWatch(WatchedDirectory parent, string directoryName)
		{
			lock (SyncObj)
			{
				if (_wdToPathMap.Count > 0)
				{
					AddDirectoryWatchUnlocked(parent, directoryName);
				}
			}
		}

		private void AddDirectoryWatchUnlocked(WatchedDirectory parent, string directoryName)
		{
			bool flag = parent != null;
			string text = (flag ? parent.GetPath(relativeToRoot: false, directoryName) : directoryName);
			if (flag && global::Interop.Sys.LStat(text, out var output) == 0 && ((ulong)output.Mode & 0xF000uL) == 40960)
			{
				return;
			}
			uint mask = (uint)(_watchFilters | global::Interop.Sys.NotifyEvents.IN_EXCL_UNLINK) | (uint)(flag ? 33554432 : 0);
			int num = global::Interop.Sys.INotifyAddWatch(_inotifyHandle, text, mask);
			if (num == -1)
			{
				global::Interop.ErrorInfo lastErrorInfo = global::Interop.Sys.GetLastErrorInfo();
				if (!flag || (lastErrorInfo.Error != global::Interop.Error.ENOENT && lastErrorInfo.Error != global::Interop.Error.ENOTDIR))
				{
					Exception exception;
					if (lastErrorInfo.Error == global::Interop.Error.ENOSPC)
					{
						string text2 = ReadMaxUserLimit("/proc/sys/fs/inotify/max_user_watches");
						exception = new IOException((!string.IsNullOrEmpty(text2)) ? System.SR.Format("IOException_INotifyWatchesUserLimitExceeded_Value", text2) : "IOException_INotifyWatchesUserLimitExceeded", lastErrorInfo.RawErrno);
					}
					else
					{
						exception = global::Interop.GetExceptionForIoErrno(lastErrorInfo, text);
					}
					if (_weakWatcher.TryGetTarget(out var target))
					{
						target.OnError(new ErrorEventArgs(exception));
					}
				}
				return;
			}
			bool flag2 = false;
			if (_wdToPathMap.TryGetValue(num, out var value))
			{
				if (value.Parent != parent)
				{
					if (value.Parent != null)
					{
						value.Parent.Children.Remove(value);
					}
					value.Parent = parent;
					if (flag)
					{
						parent.InitializedChildren.Add(value);
					}
				}
				value.Name = directoryName;
			}
			else
			{
				value = new WatchedDirectory
				{
					Parent = parent,
					WatchDescriptor = num,
					Name = directoryName
				};
				if (flag)
				{
					parent.InitializedChildren.Add(value);
				}
				_wdToPathMap.Add(num, value);
				flag2 = true;
			}
			if (!flag2 || !_includeSubdirectories)
			{
				return;
			}
			try
			{
				foreach (string item in Directory.EnumerateDirectories(text))
				{
					AddDirectoryWatchUnlocked(value, System.IO.Path.GetFileName(item));
				}
			}
			catch (DirectoryNotFoundException)
			{
			}
			catch (IOException ex2) when (ex2.HResult == global::Interop.Error.ENOTDIR.Info().RawErrno)
			{
			}
			catch (Exception exception2)
			{
				if (_weakWatcher.TryGetTarget(out var target2))
				{
					target2.OnError(new ErrorEventArgs(exception2));
				}
			}
		}

		private void RemoveWatchedDirectory(WatchedDirectory directoryEntry, bool removeInotify = true)
		{
			lock (SyncObj)
			{
				if (directoryEntry.Parent != null)
				{
					directoryEntry.Parent.Children.Remove(directoryEntry);
				}
				RemoveWatchedDirectoryUnlocked(directoryEntry, removeInotify);
			}
		}

		private void RemoveWatchedDirectoryUnlocked(WatchedDirectory directoryEntry, bool removeInotify)
		{
			if (directoryEntry.Children != null)
			{
				foreach (WatchedDirectory child in directoryEntry.Children)
				{
					RemoveWatchedDirectoryUnlocked(child, removeInotify);
				}
				directoryEntry.Children = null;
			}
			_wdToPathMap.Remove(directoryEntry.WatchDescriptor);
			if (removeInotify)
			{
				global::Interop.Sys.INotifyRemoveWatch(_inotifyHandle, directoryEntry.WatchDescriptor);
			}
		}

		private void CancellationCallback()
		{
			lock (SyncObj)
			{
				foreach (int key in _wdToPathMap.Keys)
				{
					global::Interop.Sys.INotifyRemoveWatch(_inotifyHandle, key);
				}
				_wdToPathMap.Clear();
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool ProcessEvent(NotifyEvent nextEvent, ref ReadOnlySpan<char> previousEventName, ref WatchedDirectory previousEventParent, ref uint previousEventCookie)
		{
			if (!_weakWatcher.TryGetTarget(out var target))
			{
				return false;
			}
			uint mask = nextEvent.mask;
			if ((mask & 0x4000) != 0)
			{
				target.NotifyInternalBufferOverflowEvent();
				if (_includeSubdirectories)
				{
					target.Restart();
				}
				return false;
			}
			WatchedDirectory value = null;
			lock (SyncObj)
			{
				if (!_wdToPathMap.TryGetValue(nextEvent.wd, out value))
				{
					return true;
				}
			}
			ReadOnlySpan<char> readOnlySpan = value.GetPath(relativeToRoot: true, nextEvent.name).AsSpan();
			if (readOnlySpan.IsEmpty)
			{
				return true;
			}
			bool flag = (mask & 0x40008000) != 0;
			if (!previousEventName.IsEmpty && ((mask & 0x80) == 0 || previousEventCookie != nextEvent.cookie))
			{
				if (previousEventParent != null && previousEventParent.Children != null)
				{
					foreach (WatchedDirectory child in previousEventParent.Children)
					{
						if (MemoryExtensions.Equals(previousEventName, child.Name.AsSpan(), StringComparison.Ordinal))
						{
							RemoveWatchedDirectory(child);
							return false;
						}
					}
				}
				target.NotifyFileSystemEventArgs(WatcherChangeTypes.Deleted, previousEventName);
				previousEventName = null;
				previousEventParent = null;
				previousEventCookie = 0u;
			}
			if ((mask & 0x180) != 0 && flag && _includeSubdirectories)
			{
				AddDirectoryWatch(value, nextEvent.name);
			}
			if ((0x3C0 & mask) != 0 && ((flag && (_notifyFilters & NotifyFilters.DirectoryName) == 0) || (!flag && (_notifyFilters & NotifyFilters.FileName) == 0)))
			{
				return true;
			}
			switch ((global::Interop.Sys.NotifyEvents)(mask & 0x83C7))
			{
			case global::Interop.Sys.NotifyEvents.IN_CREATE:
				target.NotifyFileSystemEventArgs(WatcherChangeTypes.Created, readOnlySpan);
				break;
			case global::Interop.Sys.NotifyEvents.IN_IGNORED:
				RemoveWatchedDirectory(value, removeInotify: false);
				break;
			case global::Interop.Sys.NotifyEvents.IN_DELETE:
				target.NotifyFileSystemEventArgs(WatcherChangeTypes.Deleted, readOnlySpan);
				break;
			case global::Interop.Sys.NotifyEvents.IN_ACCESS:
			case global::Interop.Sys.NotifyEvents.IN_MODIFY:
			case global::Interop.Sys.NotifyEvents.IN_ATTRIB:
				target.NotifyFileSystemEventArgs(WatcherChangeTypes.Changed, readOnlySpan);
				break;
			case global::Interop.Sys.NotifyEvents.IN_MOVED_FROM:
				if (_bufferPos == _bufferAvailable)
				{
					global::Interop.Sys.Poll(_inotifyHandle, global::Interop.PollEvents.POLLIN, 2, out var triggered);
					if (triggered == global::Interop.PollEvents.POLLNONE)
					{
						target.NotifyFileSystemEventArgs(WatcherChangeTypes.Deleted, readOnlySpan);
						break;
					}
				}
				previousEventName = readOnlySpan;
				previousEventParent = (flag ? value : null);
				previousEventCookie = nextEvent.cookie;
				break;
			case global::Interop.Sys.NotifyEvents.IN_MOVED_TO:
				if (!previousEventName.IsEmpty)
				{
					target.NotifyRenameEventArgs(WatcherChangeTypes.Renamed, readOnlySpan, previousEventName);
				}
				else
				{
					target.NotifyFileSystemEventArgs(WatcherChangeTypes.Created, readOnlySpan);
				}
				previousEventName = ReadOnlySpan<char>.Empty;
				previousEventParent = null;
				previousEventCookie = 0u;
				break;
			}
			return true;
		}

		private void ProcessEvents()
		{
			CancellationTokenRegistration cancellationTokenRegistration = _cancellationToken.UnsafeRegister(delegate(object obj)
			{
				((RunningInstance)obj).CancellationCallback();
			}, this);
			try
			{
				ReadOnlySpan<char> previousEventName = ReadOnlySpan<char>.Empty;
				WatchedDirectory previousEventParent = null;
				uint previousEventCookie = 0u;
				NotifyEvent notifyEvent;
				while (!_cancellationToken.IsCancellationRequested && TryReadEvent(out notifyEvent) && ProcessEvent(notifyEvent, ref previousEventName, ref previousEventParent, ref previousEventCookie))
				{
				}
			}
			catch (Exception exception)
			{
				if (_weakWatcher.TryGetTarget(out var target))
				{
					target.OnError(new ErrorEventArgs(exception));
				}
			}
			finally
			{
				cancellationTokenRegistration.Dispose();
				_inotifyHandle.Dispose();
			}
		}

		private unsafe bool TryReadEvent(out NotifyEvent notifyEvent)
		{
			if (_bufferAvailable == 0 || _bufferPos == _bufferAvailable)
			{
				try
				{
					fixed (byte* buffer = &_buffer[0])
					{
						_bufferAvailable = global::Interop.CheckIo(global::Interop.Sys.Read(_inotifyHandle, buffer, _buffer.Length));
					}
				}
				catch (ArgumentException)
				{
					_bufferAvailable = 0;
				}
				if (_bufferAvailable == 0)
				{
					notifyEvent = default(NotifyEvent);
					return false;
				}
				_bufferPos = 0;
			}
			Unsafe.SkipInit(out NotifyEvent notifyEvent2);
			notifyEvent2.wd = BitConverter.ToInt32(_buffer, _bufferPos);
			notifyEvent2.mask = BitConverter.ToUInt32(_buffer, _bufferPos + 4);
			notifyEvent2.cookie = BitConverter.ToUInt32(_buffer, _bufferPos + 8);
			int num = (int)BitConverter.ToUInt32(_buffer, _bufferPos + 12);
			notifyEvent2.name = ReadName(_bufferPos + 16, num);
			_bufferPos += 16 + num;
			notifyEvent = notifyEvent2;
			return true;
		}

		private string ReadName(int position, int nameLength)
		{
			int num = ((ReadOnlySpan<byte>)_buffer.AsSpan(position, nameLength)).IndexOf((byte)0);
			if (num < 0)
			{
				num = nameLength;
			}
			if (num <= 0)
			{
				return string.Empty;
			}
			return Encoding.UTF8.GetString(_buffer, position, num);
		}
	}

	private readonly NormalizedFilterCollection _filters = new NormalizedFilterCollection();

	private string _directory;

	private NotifyFilters _notifyFilters = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite;

	private bool _includeSubdirectories;

	private bool _enabled;

	private bool _initializing;

	private uint _internalBufferSize = 8192u;

	private bool _disposed;

	private FileSystemEventHandler _onChangedHandler;

	private FileSystemEventHandler _onCreatedHandler;

	private FileSystemEventHandler _onDeletedHandler;

	private RenamedEventHandler _onRenamedHandler;

	private ErrorEventHandler _onErrorHandler;

	private CancellationTokenSource _cancellation;

	public NotifyFilters NotifyFilter
	{
		get
		{
			return _notifyFilters;
		}
		set
		{
			if ((value & ~(NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Attributes | NotifyFilters.Size | NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.CreationTime | NotifyFilters.Security)) != 0)
			{
				throw new ArgumentException(System.SR.Format("InvalidEnumArgument", "value", (int)value, "NotifyFilters"));
			}
			if (_notifyFilters != value)
			{
				_notifyFilters = value;
				Restart();
			}
		}
	}

	public Collection<string> Filters => _filters;

	public bool EnableRaisingEvents
	{
		set
		{
			if (_enabled != value)
			{
				if (IsSuspended())
				{
					_enabled = value;
				}
				else if (value)
				{
					StartRaisingEventsIfNotDisposed();
				}
				else
				{
					StopRaisingEvents();
				}
			}
		}
	}

	public string Filter
	{
		get
		{
			if (Filters.Count != 0)
			{
				return Filters[0];
			}
			return "*";
		}
		set
		{
			Filters.Clear();
			Filters.Add(value);
		}
	}

	public bool IncludeSubdirectories => _includeSubdirectories;

	[Editor("System.Diagnostics.Design.FSWPathEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public string Path
	{
		get
		{
			return _directory;
		}
		set
		{
			if (value == null)
			{
				value = string.Empty;
			}
			if (!string.Equals(_directory, value, StringComparison.Ordinal))
			{
				if (value.Length == 0)
				{
					throw new ArgumentException(System.SR.Format("InvalidDirName", value), "Path");
				}
				if (!Directory.Exists(value))
				{
					throw new ArgumentException(System.SR.Format("InvalidDirName_NotExists", value), "Path");
				}
				_directory = value;
				Restart();
			}
		}
	}

	public override ISite? Site
	{
		get
		{
			return base.Site;
		}
		set
		{
			base.Site = value;
			if (Site != null && Site.DesignMode)
			{
				EnableRaisingEvents = true;
			}
		}
	}

	public ISynchronizeInvoke? SynchronizingObject { get; }

	public event FileSystemEventHandler? Changed
	{
		add
		{
			_onChangedHandler = (FileSystemEventHandler)Delegate.Combine(_onChangedHandler, value);
		}
		remove
		{
			_onChangedHandler = (FileSystemEventHandler)Delegate.Remove(_onChangedHandler, value);
		}
	}

	public event FileSystemEventHandler? Created
	{
		add
		{
			_onCreatedHandler = (FileSystemEventHandler)Delegate.Combine(_onCreatedHandler, value);
		}
		remove
		{
			_onCreatedHandler = (FileSystemEventHandler)Delegate.Remove(_onCreatedHandler, value);
		}
	}

	public event FileSystemEventHandler? Deleted
	{
		add
		{
			_onDeletedHandler = (FileSystemEventHandler)Delegate.Combine(_onDeletedHandler, value);
		}
		remove
		{
			_onDeletedHandler = (FileSystemEventHandler)Delegate.Remove(_onDeletedHandler, value);
		}
	}

	public event ErrorEventHandler? Error
	{
		add
		{
			_onErrorHandler = (ErrorEventHandler)Delegate.Combine(_onErrorHandler, value);
		}
		remove
		{
			_onErrorHandler = (ErrorEventHandler)Delegate.Remove(_onErrorHandler, value);
		}
	}

	public event RenamedEventHandler? Renamed
	{
		add
		{
			_onRenamedHandler = (RenamedEventHandler)Delegate.Combine(_onRenamedHandler, value);
		}
		remove
		{
			_onRenamedHandler = (RenamedEventHandler)Delegate.Remove(_onRenamedHandler, value);
		}
	}

	public FileSystemWatcher()
	{
		_directory = string.Empty;
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing)
			{
				StopRaisingEvents();
				_onChangedHandler = null;
				_onCreatedHandler = null;
				_onDeletedHandler = null;
				_onRenamedHandler = null;
				_onErrorHandler = null;
			}
			else
			{
				FinalizeDispose();
			}
		}
		finally
		{
			_disposed = true;
			base.Dispose(disposing);
		}
	}

	private bool MatchPattern(ReadOnlySpan<char> relativePath)
	{
		ReadOnlySpan<char> fileName = System.IO.Path.GetFileName(relativePath);
		if (fileName.Length == 0)
		{
			return false;
		}
		string[] filters = _filters.GetFilters();
		if (filters.Length == 0)
		{
			return true;
		}
		string[] array = filters;
		for (int i = 0; i < array.Length; i++)
		{
			if (FileSystemName.MatchesSimpleExpression(array[i].AsSpan(), fileName, 1 == 0))
			{
				return true;
			}
		}
		return false;
	}

	private void NotifyInternalBufferOverflowEvent()
	{
		if (_onErrorHandler != null)
		{
			OnError(new ErrorEventArgs(new InternalBufferOverflowException(System.SR.Format("FSW_BufferOverflow", _directory))));
		}
	}

	private void NotifyRenameEventArgs(WatcherChangeTypes action, ReadOnlySpan<char> name, ReadOnlySpan<char> oldName)
	{
		if (_onRenamedHandler != null && (MatchPattern(name) || MatchPattern(oldName)))
		{
			OnRenamed(new RenamedEventArgs(action, _directory, name.IsEmpty ? null : name.ToString(), oldName.IsEmpty ? null : oldName.ToString()));
		}
	}

	private FileSystemEventHandler GetHandler(WatcherChangeTypes changeType)
	{
		return changeType switch
		{
			WatcherChangeTypes.Created => _onCreatedHandler, 
			WatcherChangeTypes.Deleted => _onDeletedHandler, 
			WatcherChangeTypes.Changed => _onChangedHandler, 
			_ => null, 
		};
	}

	private void NotifyFileSystemEventArgs(WatcherChangeTypes changeType, ReadOnlySpan<char> name)
	{
		FileSystemEventHandler handler = GetHandler(changeType);
		if (handler != null && MatchPattern(name.IsEmpty ? _directory.AsSpan() : name))
		{
			InvokeOn(new FileSystemEventArgs(changeType, _directory, name.IsEmpty ? null : name.ToString()), handler);
		}
	}

	private void InvokeOn(FileSystemEventArgs e, FileSystemEventHandler handler)
	{
		if (handler != null)
		{
			ISynchronizeInvoke synchronizingObject = SynchronizingObject;
			if (synchronizingObject != null && synchronizingObject.InvokeRequired)
			{
				synchronizingObject.BeginInvoke(handler, new object[2] { this, e });
			}
			else
			{
				handler(this, e);
			}
		}
	}

	protected void OnError(ErrorEventArgs e)
	{
		ErrorEventHandler onErrorHandler = _onErrorHandler;
		if (onErrorHandler != null)
		{
			ISynchronizeInvoke synchronizingObject = SynchronizingObject;
			if (synchronizingObject != null && synchronizingObject.InvokeRequired)
			{
				synchronizingObject.BeginInvoke(onErrorHandler, new object[2] { this, e });
			}
			else
			{
				onErrorHandler(this, e);
			}
		}
	}

	protected void OnRenamed(RenamedEventArgs e)
	{
		RenamedEventHandler onRenamedHandler = _onRenamedHandler;
		if (onRenamedHandler != null)
		{
			ISynchronizeInvoke synchronizingObject = SynchronizingObject;
			if (synchronizingObject != null && synchronizingObject.InvokeRequired)
			{
				synchronizingObject.BeginInvoke(onRenamedHandler, new object[2] { this, e });
			}
			else
			{
				onRenamedHandler(this, e);
			}
		}
	}

	private void Restart()
	{
		if (!IsSuspended() && _enabled)
		{
			StopRaisingEvents();
			StartRaisingEventsIfNotDisposed();
		}
	}

	private void StartRaisingEventsIfNotDisposed()
	{
		ObjectDisposedException.ThrowIf(_disposed, this);
		StartRaisingEvents();
	}

	private bool IsSuspended()
	{
		if (!_initializing)
		{
			return base.DesignMode;
		}
		return true;
	}

	private void StartRaisingEvents()
	{
		if (IsSuspended())
		{
			_enabled = true;
		}
		else
		{
			if (_cancellation != null)
			{
				return;
			}
			SafeFileHandle safeFileHandle = global::Interop.Sys.INotifyInit();
			if (safeFileHandle.IsInvalid)
			{
				global::Interop.ErrorInfo lastErrorInfo = global::Interop.Sys.GetLastErrorInfo();
				safeFileHandle.Dispose();
				switch (lastErrorInfo.Error)
				{
				case global::Interop.Error.EMFILE:
				{
					string text = ReadMaxUserLimit("/proc/sys/fs/inotify/max_user_instances");
					throw new IOException((!string.IsNullOrEmpty(text)) ? System.SR.Format("IOException_INotifyInstanceUserLimitExceeded_Value", text) : "IOException_INotifyInstanceUserLimitExceeded", lastErrorInfo.RawErrno);
				}
				case global::Interop.Error.ENFILE:
					throw new IOException("IOException_INotifyInstanceSystemLimitExceeded", lastErrorInfo.RawErrno);
				default:
					throw global::Interop.GetExceptionForIoErrno(lastErrorInfo);
				}
			}
			try
			{
				CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
				RunningInstance runningInstance = new RunningInstance(this, safeFileHandle, _directory, IncludeSubdirectories, NotifyFilter, cancellationTokenSource.Token);
				_cancellation = cancellationTokenSource;
				_enabled = true;
				runningInstance.Start();
			}
			catch
			{
				safeFileHandle.Dispose();
				throw;
			}
		}
	}

	private byte[] AllocateBuffer()
	{
		try
		{
			return new byte[_internalBufferSize];
		}
		catch (OutOfMemoryException)
		{
			throw new OutOfMemoryException(System.SR.Format("BufferSizeTooLarge", _internalBufferSize));
		}
	}

	private void StopRaisingEvents()
	{
		_enabled = false;
		if (!IsSuspended())
		{
			CancellationTokenSource cancellation = _cancellation;
			if (cancellation != null)
			{
				_cancellation = null;
				cancellation.Cancel();
			}
		}
	}

	private void FinalizeDispose()
	{
		StopRaisingEvents();
	}

	private static string ReadMaxUserLimit(string path)
	{
		try
		{
			return File.ReadAllText(path).Trim();
		}
		catch
		{
			return null;
		}
	}

	private static global::Interop.Sys.NotifyEvents TranslateFilters(NotifyFilters filters)
	{
		global::Interop.Sys.NotifyEvents notifyEvents = (global::Interop.Sys.NotifyEvents)0;
		notifyEvents |= global::Interop.Sys.NotifyEvents.IN_ONLYDIR | global::Interop.Sys.NotifyEvents.IN_EXCL_UNLINK;
		notifyEvents |= global::Interop.Sys.NotifyEvents.IN_CREATE | global::Interop.Sys.NotifyEvents.IN_DELETE;
		if ((filters & NotifyFilters.LastAccess) != 0)
		{
			notifyEvents |= global::Interop.Sys.NotifyEvents.IN_ACCESS;
		}
		if ((filters & (NotifyFilters.Size | NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.Security)) != 0)
		{
			notifyEvents |= global::Interop.Sys.NotifyEvents.IN_MODIFY;
		}
		if ((filters & (NotifyFilters.Attributes | NotifyFilters.Size | NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.CreationTime | NotifyFilters.Security)) != 0)
		{
			notifyEvents |= global::Interop.Sys.NotifyEvents.IN_ATTRIB;
		}
		if ((filters & (NotifyFilters.FileName | NotifyFilters.DirectoryName)) != 0)
		{
			notifyEvents |= global::Interop.Sys.NotifyEvents.IN_MOVED_FROM | global::Interop.Sys.NotifyEvents.IN_MOVED_TO;
		}
		return notifyEvents;
	}
}
