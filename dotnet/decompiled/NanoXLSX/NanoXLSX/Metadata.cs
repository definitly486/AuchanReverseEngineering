using System;
using System.Reflection;
using NanoXLSX.Exceptions;

namespace NanoXLSX;

public class Metadata
{
	private string applicationVersion;

	public string Application { get; set; }

	public string ApplicationVersion
	{
		get
		{
			return applicationVersion;
		}
		set
		{
			applicationVersion = value;
			CheckVersion();
		}
	}

	public string Category { get; }

	public string Company { get; }

	public string ContentStatus { get; }

	public string Creator { get; }

	public string Description { get; }

	public string HyperlinkBase { get; }

	public string Keywords { get; }

	public string Manager { get; }

	public string Subject { get; }

	public string Title { get; }

	public Metadata()
	{
		Application = "NanoXLSX";
		Version version = Assembly.GetExecutingAssembly().GetName().Version;
		ApplicationVersion = ParseVersion(version.Major, version.Minor, version.Revision, version.Build);
	}

	private void CheckVersion()
	{
		if (string.IsNullOrEmpty(applicationVersion))
		{
			return;
		}
		string[] array = applicationVersion.Split(new char[1] { '.' });
		bool flag = true;
		if (array.Length != 2)
		{
			flag = false;
		}
		else
		{
			if (array[1].Length < 1 || array[1].Length > 5)
			{
				flag = false;
			}
			if (array[0].Length < 1 || array[0].Length > 5)
			{
				flag = false;
			}
		}
		if (flag)
		{
			return;
		}
		throw new NanoXLSX.Exceptions.FormatException("The format of the version in the meta data is wrong (" + applicationVersion + "). Should be in the format and a range from '0.0' to '99999.99999'");
	}

	public static string ParseVersion(int major, int minor, int build, int revision)
	{
		if (major < 0 || minor < 0 || build < 0 || revision < 0)
		{
			throw new NanoXLSX.Exceptions.FormatException("The format of the passed version is wrong. No negative number allowed.");
		}
		if (major > 99999)
		{
			throw new NanoXLSX.Exceptions.FormatException("The major number may not be bigger than 99999. The passed value is " + major);
		}
		string text = Utils.ToString(major);
		string text2 = Utils.ToString(minor) + Utils.ToString(build) + Utils.ToString(revision);
		text2 = text2.TrimEnd(new char[1] { '0' });
		if (text2 == "")
		{
			text2 = "0";
		}
		else if (text2.Length > 5)
		{
			text2 = text2.Substring(0, 5);
		}
		return text + "." + text2;
	}
}
