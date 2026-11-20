using System.IO;
using System.Text;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Logs;

internal static class Statistics
{
	private const double ONE_MEGABYTE = 1048576.0;

	public static string CollectAppDirectoryStatistics()
	{
		StringBuilder stringBuilder = new StringBuilder();
		string appDataDirectory = FileSystem.AppDataDirectory;
		long size = CollectStatisticsForDirectory(appDataDirectory, new DirectoryInfo(appDataDirectory), stringBuilder);
		AppendSizeInfo("total: ", size, stringBuilder);
		return stringBuilder.ToString();
	}

	private static long CollectStatisticsForDirectory(string directoryPath, DirectoryInfo directory, StringBuilder output)
	{
		long num = 0L;
		DirectoryInfo[] directories = directory.GetDirectories();
		foreach (DirectoryInfo directoryInfo in directories)
		{
			num += CollectStatisticsForDirectory(Path.Combine(directoryPath, directoryInfo.Name), directoryInfo, output);
		}
		FileInfo[] files = directory.GetFiles();
		foreach (FileInfo file in files)
		{
			num += CollectStatisticsForFile(directoryPath, file, output);
		}
		AppendSizeInfo("subtotal for directory [" + directoryPath + "]: ", num, output);
		output.AppendLine();
		return num;
	}

	private static long CollectStatisticsForFile(string directoryPath, FileInfo file, StringBuilder output)
	{
		AppendSizeInfo(Path.Combine(directoryPath, file.Name) + ": ", file.Length, output);
		return file.Length;
	}

	private static void AppendSizeInfo(string prefix, long size, StringBuilder output)
	{
		StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(13, 3, output);
		handler.AppendFormatted(prefix);
		handler.AppendFormatted((double)size / 1048576.0, "F2");
		handler.AppendLiteral(" MB == ");
		handler.AppendFormatted(size);
		handler.AppendLiteral(" bytes");
		output.AppendLine(ref handler);
	}
}
