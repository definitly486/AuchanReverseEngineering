using System.Collections.Generic;

namespace NanoXLSX.Styles;

public class StyleRepository
{
	private readonly object lockObject = new object();

	private static StyleRepository instance;

	private Dictionary<int, Style> styles;

	public static StyleRepository Instance
	{
		get
		{
			instance = instance ?? new StyleRepository();
			return instance;
		}
	}

	internal bool ImportInProgress { get; }

	private StyleRepository()
	{
		styles = new Dictionary<int, Style>();
	}

	public Style AddStyle(Style style)
	{
		lock (lockObject)
		{
			if (style == null)
			{
				return null;
			}
			int hashCode = style.GetHashCode();
			if (!styles.ContainsKey(hashCode))
			{
				styles.Add(hashCode, style);
			}
			return styles[hashCode];
		}
	}
}
