using System.Runtime.InteropServices;

namespace System.IO;

internal static class PersistedFiles
{
	internal unsafe static string GetHomeDirectory()
	{
		string path = Environment.GetEnvironmentVariable("HOME");
		if (!string.IsNullOrEmpty(path))
		{
			return path;
		}
		if (TryGetHomeDirectoryFromPasswd(stackalloc byte[256], 256, out path))
		{
			return path;
		}
		int num = 256;
		while (true)
		{
			num *= 2;
			byte[] array = new byte[num];
			fixed (byte* buf = &array[0])
			{
				if (TryGetHomeDirectoryFromPasswd(buf, array.Length, out path))
				{
					return path;
				}
			}
		}
	}

	private unsafe static bool TryGetHomeDirectoryFromPasswd(byte* buf, int bufLen, out string path)
	{
		Interop.Sys.Passwd pwd;
		int pwUidR = Interop.Sys.GetPwUidR(Interop.Sys.GetEUid(), out pwd, buf, bufLen);
		switch (pwUidR)
		{
		case 0:
			path = Marshal.PtrToStringUTF8((nint)pwd.HomeDirectory);
			return true;
		case -1:
			path = null;
			return true;
		default:
		{
			Interop.ErrorInfo errorInfo = new Interop.ErrorInfo(pwUidR);
			if (errorInfo.Error == Interop.Error.ERANGE)
			{
				path = null;
				return false;
			}
			throw new IOException(errorInfo.GetErrorMessage(), errorInfo.RawErrno);
		}
		}
	}
}
