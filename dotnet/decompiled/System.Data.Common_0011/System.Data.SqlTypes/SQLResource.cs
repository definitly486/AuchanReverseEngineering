namespace System.Data.SqlTypes;

internal static class SQLResource
{
	internal static string InvalidOpStreamNonWritable(string method)
	{
		return System.SR.Format("SqlMisc_InvalidOpStreamNonWritable", method);
	}

	internal static string InvalidOpStreamNonReadable(string method)
	{
		return System.SR.Format("SqlMisc_InvalidOpStreamNonReadable", method);
	}

	internal static string InvalidOpStreamNonSeekable(string method)
	{
		return System.SR.Format("SqlMisc_InvalidOpStreamNonSeekable", method);
	}
}
