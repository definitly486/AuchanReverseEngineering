using System;
using System.IO;
using Android.App;
using Android.Database;
using Android.Net;
using Android.OS;
using Android.Provider;
using Android.Webkit;
using Java.IO;
using Microsoft.Maui.ApplicationModel;

namespace Microsoft.Maui.Storage;

internal static class FileSystemUtils
{
	private static readonly string[] contentUriPrefixes = new string[3] { "content://downloads/public_downloads", "content://downloads/my_downloads", "content://downloads/all_downloads" };

	public static Java.IO.File GetTemporaryFile(Java.IO.File root, string fileName)
	{
		Java.IO.File file = new Java.IO.File(root, "2203693cc04e0be7f4f024d5f9499e13");
		file.Mkdirs();
		file.DeleteOnExit();
		Java.IO.File file2 = new Java.IO.File(file, Guid.NewGuid().ToString("N"));
		file2.Mkdirs();
		file2.DeleteOnExit();
		Java.IO.File file3 = new Java.IO.File(file2, fileName);
		file3.DeleteOnExit();
		return file3;
	}

	public static string EnsurePhysicalPath(global::Android.Net.Uri uri, bool requireExtendedAccess = true)
	{
		if (uri.Scheme.Equals("file", StringComparison.OrdinalIgnoreCase))
		{
			return uri.Path;
		}
		string text = ResolvePhysicalPath(uri, requireExtendedAccess);
		if (!string.IsNullOrWhiteSpace(text) && Path.IsPathRooted(text))
		{
			return text;
		}
		string text2 = CacheContentFile(uri);
		if (!string.IsNullOrWhiteSpace(text2) && Path.IsPathRooted(text2))
		{
			return text2;
		}
		throw new FileNotFoundException($"Unable to resolve absolute path or retrieve contents of URI '{uri}'.");
	}

	private static string ResolvePhysicalPath(global::Android.Net.Uri uri, bool requireExtendedAccess = true)
	{
		if (uri.Scheme.Equals("file", StringComparison.OrdinalIgnoreCase))
		{
			string path = uri.Path;
			if (System.IO.File.Exists(path))
			{
				return path;
			}
		}
		else if (!requireExtendedAccess || !OperatingSystem.IsAndroidVersionAtLeast(29))
		{
			if (OperatingSystem.IsAndroidVersionAtLeast(19) && DocumentsContract.IsDocumentUri(Application.Context, uri))
			{
				string text = ResolveDocumentPath(uri);
				if (System.IO.File.Exists(text))
				{
					return text;
				}
			}
			else if (uri.Scheme.Equals("content", StringComparison.OrdinalIgnoreCase))
			{
				string text2 = ResolveContentPath(uri);
				if (System.IO.File.Exists(text2))
				{
					return text2;
				}
			}
		}
		return null;
	}

	private static string ResolveDocumentPath(global::Android.Net.Uri uri)
	{
		string[] array = DocumentsContract.GetDocumentId(uri)?.Split(':');
		if (array == null || array.Length == 0)
		{
			return null;
		}
		if (uri.Authority.Equals("com.android.externalstorage.documents", StringComparison.OrdinalIgnoreCase))
		{
			if (array.Length == 2)
			{
				string text = array[0];
				string path = array[1];
				if (text.Equals("primary", StringComparison.OrdinalIgnoreCase))
				{
					string path2 = global::Android.OS.Environment.ExternalStorageDirectory.Path;
					return Path.Combine(path2, path);
				}
			}
		}
		else if (uri.Authority.Equals("com.android.providers.downloads.documents", StringComparison.OrdinalIgnoreCase))
		{
			if (array.Length == 2)
			{
				string text2 = array[0];
				string result = array[1];
				if (text2.Equals("raw", StringComparison.OrdinalIgnoreCase))
				{
					return result;
				}
			}
			string text3 = ((array.Length == 2) ? array[1] : array[0]);
			string[] array2 = contentUriPrefixes;
			foreach (string text4 in array2)
			{
				string uriString = text4 + "/" + text3;
				global::Android.Net.Uri contentUri = global::Android.Net.Uri.Parse(uriString);
				string dataFilePath = GetDataFilePath(contentUri);
				if (dataFilePath != null)
				{
					return dataFilePath;
				}
			}
		}
		else if (uri.Authority.Equals("com.android.providers.media.documents", StringComparison.OrdinalIgnoreCase) && array.Length == 2)
		{
			string text5 = array[0];
			string text6 = array[1];
			global::Android.Net.Uri uri2 = null;
			if (text5.Equals("image", StringComparison.OrdinalIgnoreCase))
			{
				uri2 = MediaStore.Images.Media.ExternalContentUri;
			}
			else if (text5.Equals("video", StringComparison.OrdinalIgnoreCase))
			{
				uri2 = MediaStore.Video.Media.ExternalContentUri;
			}
			else if (text5.Equals("audio", StringComparison.OrdinalIgnoreCase))
			{
				uri2 = MediaStore.Audio.Media.ExternalContentUri;
			}
			if (uri2 != null)
			{
				string dataFilePath2 = GetDataFilePath(uri2, "_id=?", new string[1] { text6 });
				if (dataFilePath2 != null)
				{
					return dataFilePath2;
				}
			}
		}
		return null;
	}

	private static string ResolveContentPath(global::Android.Net.Uri uri)
	{
		string dataFilePath = GetDataFilePath(uri);
		if (dataFilePath != null)
		{
			return dataFilePath;
		}
		return null;
	}

	private static string CacheContentFile(global::Android.Net.Uri uri)
	{
		if (!uri.Scheme.Equals("content", StringComparison.OrdinalIgnoreCase))
		{
			return null;
		}
		string extension;
		using Stream stream = OpenContentStream(uri, out extension);
		if (stream == null)
		{
			return null;
		}
		string text = GetColumnValue(uri, "_display_name") ?? Guid.NewGuid().ToString("N");
		if (!Path.HasExtension(text) && !string.IsNullOrEmpty(extension))
		{
			text = Path.ChangeExtension(text, extension);
		}
		Java.IO.File root = (Permissions.IsDeclaredInManifest("android.permission.WRITE_EXTERNAL_STORAGE") ? Application.Context.ExternalCacheDir : Application.Context.CacheDir);
		Java.IO.File temporaryFile = GetTemporaryFile(root, text);
		using FileStream destination = System.IO.File.Create(temporaryFile.CanonicalPath);
		stream.CopyTo(destination);
		return temporaryFile.CanonicalPath;
	}

	private static Stream OpenContentStream(global::Android.Net.Uri uri, out string extension)
	{
		if (IsVirtualFile(uri))
		{
			return GetVirtualFileStream(uri, out extension);
		}
		extension = GetFileExtension(uri);
		return Application.Context.ContentResolver.OpenInputStream(uri);
	}

	private static bool IsVirtualFile(global::Android.Net.Uri uri)
	{
		if (!DocumentsContract.IsDocumentUri(Application.Context, uri))
		{
			return false;
		}
		string columnValue = GetColumnValue(uri, "flags");
		if (!string.IsNullOrEmpty(columnValue) && int.TryParse(columnValue, out var result))
		{
			DocumentContractFlags documentContractFlags = (DocumentContractFlags)result;
			return documentContractFlags.HasFlag(DocumentContractFlags.VirtualDocument);
		}
		return false;
	}

	private static Stream GetVirtualFileStream(global::Android.Net.Uri uri, out string extension)
	{
		string[] streamTypes = Application.Context.ContentResolver.GetStreamTypes(uri, "*/*");
		if (streamTypes != null && streamTypes.Length >= 1)
		{
			string mimeType = streamTypes[0];
			Stream result = Application.Context.ContentResolver.OpenTypedAssetFileDescriptor(uri, mimeType, null).CreateInputStream();
			extension = MimeTypeMap.Singleton.GetExtensionFromMimeType(mimeType);
			return result;
		}
		extension = null;
		return null;
	}

	private static string GetColumnValue(global::Android.Net.Uri contentUri, string column, string selection = null, string[] selectionArgs = null)
	{
		try
		{
			string text = QueryContentResolverColumn(contentUri, column, selection, selectionArgs);
			if (!string.IsNullOrEmpty(text))
			{
				return text;
			}
		}
		catch
		{
		}
		return null;
	}

	private static string GetDataFilePath(global::Android.Net.Uri contentUri, string selection = null, string[] selectionArgs = null)
	{
		string columnValue = GetColumnValue(contentUri, "_data", selection, selectionArgs);
		if (!string.IsNullOrEmpty(columnValue) && Path.IsPathRooted(columnValue))
		{
			return columnValue;
		}
		return null;
	}

	private static string GetFileExtension(global::Android.Net.Uri uri)
	{
		string type = Application.Context.ContentResolver.GetType(uri);
		if (type == null)
		{
			return null;
		}
		return MimeTypeMap.Singleton.GetExtensionFromMimeType(type);
	}

	private static string QueryContentResolverColumn(global::Android.Net.Uri contentUri, string columnName, string selection = null, string[] selectionArgs = null)
	{
		string result = null;
		string[] projection = new string[1] { columnName };
		using ICursor cursor = Application.Context.ContentResolver.Query(contentUri, projection, selection, selectionArgs, null);
		if (cursor != null && cursor.MoveToFirst())
		{
			int columnIndex = cursor.GetColumnIndex(columnName);
			if (columnIndex != -1)
			{
				result = cursor.GetString(columnIndex);
			}
		}
		if (cursor != null && !cursor.IsClosed)
		{
			cursor.Close();
		}
		return result;
	}

	internal static global::Android.Net.Uri GetShareableFileUri(FileBase file)
	{
		Java.IO.File file2;
		if (FileProvider.IsFileInPublicLocation(file.FullPath))
		{
			file2 = new Java.IO.File(file.FullPath);
		}
		else
		{
			Java.IO.File temporaryRootDirectory = FileProvider.GetTemporaryRootDirectory();
			Java.IO.File temporaryFile = GetTemporaryFile(temporaryRootDirectory, file.FileName);
			System.IO.File.Copy(file.FullPath, temporaryFile.CanonicalPath);
			file2 = temporaryFile;
		}
		if (OperatingSystem.IsAndroidVersionAtLeast(24))
		{
			return FileProvider.GetUriForFile(file2);
		}
		return global::Android.Net.Uri.FromFile(file2);
	}
}
