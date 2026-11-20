using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security;

namespace System.IO.IsolatedStorage;

internal static class Helper
{
	private static string s_machineRootDirectory;

	private static string s_roamingUserRootDirectory;

	private static string s_userRootDirectory;

	internal static string GetRootDirectory(IsolatedStorageScope scope)
	{
		if (IsRoaming(scope))
		{
			if (string.IsNullOrEmpty(s_roamingUserRootDirectory))
			{
				s_roamingUserRootDirectory = GetDataDirectory(scope);
			}
			return s_roamingUserRootDirectory;
		}
		if (IsMachine(scope))
		{
			if (string.IsNullOrEmpty(s_machineRootDirectory))
			{
				s_machineRootDirectory = GetRandomDirectory(GetDataDirectory(scope), scope);
			}
			return s_machineRootDirectory;
		}
		if (string.IsNullOrEmpty(s_userRootDirectory))
		{
			s_userRootDirectory = GetRandomDirectory(GetDataDirectory(scope), scope);
		}
		return s_userRootDirectory;
	}

	internal static string GetExistingRandomDirectory(string rootDirectory)
	{
		if (!Directory.Exists(rootDirectory))
		{
			return null;
		}
		string[] directories = Directory.GetDirectories(rootDirectory);
		foreach (string path in directories)
		{
			string? fileName = Path.GetFileName(path);
			if (fileName == null || fileName.Length != 12)
			{
				continue;
			}
			string[] directories2 = Directory.GetDirectories(path);
			foreach (string text in directories2)
			{
				string? fileName2 = Path.GetFileName(text);
				if (fileName2 != null && fileName2.Length == 12)
				{
					return text;
				}
			}
		}
		return null;
	}

	[UnconditionalSuppressMessage("SingleFile", "IL3000:Avoid accessing Assembly file path when publishing as a single file", Justification = "Code handles single-file deployment by using the information of the .exe file")]
	internal static void GetDefaultIdentityAndHash(out object identity, out string hash, char separator)
	{
		Assembly entryAssembly = Assembly.GetEntryAssembly();
		string text = null;
		if (entryAssembly != null)
		{
			AssemblyName name = entryAssembly.GetName();
			hash = IdentityHelper.GetNormalizedStrongNameHash(name);
			if (hash != null)
			{
				hash = string.Concat("StrongName".AsSpan(), new ReadOnlySpan<char>(in separator), hash.AsSpan());
				identity = name;
				return;
			}
			text = entryAssembly.Location;
		}
		if (string.IsNullOrEmpty(text))
		{
			text = Environment.ProcessPath;
		}
		if (string.IsNullOrEmpty(text))
		{
			throw new IsolatedStorageException("IsolatedStorage_Init");
		}
		Uri uri = new Uri(text);
		hash = string.Concat("Url".AsSpan(), new ReadOnlySpan<char>(in separator), IdentityHelper.GetNormalizedUriHash(uri).AsSpan());
		identity = uri;
	}

	internal static bool IsMachine(IsolatedStorageScope scope)
	{
		return (scope & IsolatedStorageScope.Machine) != 0;
	}

	internal static bool IsApplication(IsolatedStorageScope scope)
	{
		return (scope & IsolatedStorageScope.Application) != 0;
	}

	internal static bool IsRoaming(IsolatedStorageScope scope)
	{
		return (scope & IsolatedStorageScope.Roaming) != 0;
	}

	internal static bool IsDomain(IsolatedStorageScope scope)
	{
		return (scope & IsolatedStorageScope.Domain) != 0;
	}

	internal static string GetDataDirectory(IsolatedStorageScope scope)
	{
		string folderPath = Environment.GetFolderPath(IsMachine(scope) ? Environment.SpecialFolder.CommonApplicationData : (IsRoaming(scope) ? Environment.SpecialFolder.ApplicationData : Environment.SpecialFolder.LocalApplicationData));
		folderPath = Path.Combine(folderPath, ".isolated-storage");
		if (Directory.Exists(folderPath))
		{
			return folderPath;
		}
		_ = 1;
		if (IsRoaming(scope))
		{
			folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + ".local/share";
			Directory.CreateDirectory(folderPath);
		}
		else
		{
			folderPath = Environment.GetFolderPath(IsMachine(scope) ? Environment.SpecialFolder.CommonApplicationData : (IsRoaming(scope) ? Environment.SpecialFolder.LocalApplicationData : Environment.SpecialFolder.ApplicationData), Environment.SpecialFolderOption.Create);
		}
		return Path.Combine(folderPath, ".isolated-storage");
	}

	internal static string GetRandomDirectory(string rootDirectory, IsolatedStorageScope _)
	{
		return GetExistingRandomDirectory(rootDirectory) ?? rootDirectory;
	}

	internal static void CreateDirectory(string path, IsolatedStorageScope _)
	{
		Directory.CreateDirectory(path);
	}
}
