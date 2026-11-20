using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using NLog.Common;

namespace NLog.Internal;

internal sealed class MultiFileWatcher : IDisposable
{
	private readonly Dictionary<string, FileSystemWatcher> _watcherMap = new Dictionary<string, FileSystemWatcher>();

	public NotifyFilters NotifyFilters { get; set; }

	public event FileSystemEventHandler FileChanged;

	public MultiFileWatcher(NotifyFilters notifyFilters)
	{
		NotifyFilters = notifyFilters;
	}

	public void Dispose()
	{
		this.FileChanged = null;
		StopWatching();
	}

	public void StopWatching()
	{
		lock (_watcherMap)
		{
			foreach (KeyValuePair<string, FileSystemWatcher> item in _watcherMap)
			{
				StopWatching(item.Value);
			}
			_watcherMap.Clear();
		}
	}

	public void StopWatching(string fileName)
	{
		lock (_watcherMap)
		{
			if (_watcherMap.TryGetValue(fileName, out var value))
			{
				StopWatching(value);
				_watcherMap.Remove(fileName);
			}
		}
	}

	public void Watch(string fileName)
	{
		try
		{
			string directoryName = Path.GetDirectoryName(fileName);
			string fileName2 = Path.GetFileName(fileName);
			directoryName = Path.GetFullPath(directoryName);
			if (!Directory.Exists(directoryName))
			{
				InternalLogger.Warn("Cannot watch file-filter '{0}' when non-existing directory: {1}", fileName2, directoryName);
			}
			else if (TryAddWatch(fileName, directoryName, fileName2))
			{
				InternalLogger.Debug("Start watching file-filter '{0}' in directory: {1}", fileName2, directoryName);
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Debug(ex, "Failed to start FileSystemWatcher with file-path: {0}", fileName);
			if (LogManager.ThrowExceptions)
			{
				throw;
			}
		}
	}

	private bool TryAddWatch(string fileName, string directory, string fileFilter)
	{
		lock (_watcherMap)
		{
			if (_watcherMap.ContainsKey(fileName))
			{
				return false;
			}
			FileSystemWatcher fileSystemWatcher = null;
			try
			{
				fileSystemWatcher = new FileSystemWatcher
				{
					Path = directory,
					Filter = fileFilter,
					NotifyFilter = NotifyFilters
				};
				fileSystemWatcher.Created += OnFileChanged;
				fileSystemWatcher.Changed += OnFileChanged;
				fileSystemWatcher.Deleted += OnFileChanged;
				fileSystemWatcher.Renamed += OnFileChanged;
				fileSystemWatcher.Error += OnWatcherError;
				fileSystemWatcher.EnableRaisingEvents = true;
				_watcherMap.Add(fileName, fileSystemWatcher);
				return true;
			}
			catch (Exception ex)
			{
				InternalLogger.Error(ex, "Failed to start FileSystemWatcher with file-filter '{0}' in directory: {1}", fileFilter, directory);
				if (ex is SecurityException || ex is UnauthorizedAccessException || ex is NotSupportedException || ex is NotImplementedException || ex is PlatformNotSupportedException)
				{
					return false;
				}
				if (LogManager.ThrowExceptions)
				{
					throw;
				}
				if (fileSystemWatcher != null)
				{
					StopWatching(fileSystemWatcher);
				}
				return false;
			}
		}
	}

	private void StopWatching(FileSystemWatcher watcher)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		try
		{
			text = watcher.Filter;
			text2 = watcher.Path;
			InternalLogger.Debug("Stop watching file-filter '{0}' in directory: {1}", text, text2);
			watcher.EnableRaisingEvents = false;
			watcher.Created -= OnFileChanged;
			watcher.Changed -= OnFileChanged;
			watcher.Deleted -= OnFileChanged;
			watcher.Renamed -= OnFileChanged;
			watcher.Error -= OnWatcherError;
			watcher.Dispose();
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "Failed to stop FileSystemWatcher with file-filter '{0}' in directory: {1}", text, text2);
			if (LogManager.ThrowExceptions)
			{
				throw;
			}
		}
	}

	private static void OnWatcherError(object source, ErrorEventArgs e)
	{
		FileSystemWatcher obj = source as FileSystemWatcher;
		string text = obj?.Filter ?? string.Empty;
		string text2 = obj?.Path ?? string.Empty;
		InternalLogger.Warn(e.GetException(), "Error from FileSystemWatcher with file-filter '{0}' in directory: {1}", text, text2);
	}

	private void OnFileChanged(object source, FileSystemEventArgs e)
	{
		FileSystemEventHandler fileSystemEventHandler = this.FileChanged;
		if (fileSystemEventHandler != null)
		{
			try
			{
				fileSystemEventHandler(source, e);
			}
			catch (Exception ex)
			{
				InternalLogger.Error(ex, "Error handling event from FileSystemWatcher with file-filter: '{0}' in directory: {1}", e.Name, e.FullPath);
			}
		}
	}
}
