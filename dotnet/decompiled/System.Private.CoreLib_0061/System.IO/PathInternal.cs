using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.IO;

internal static class PathInternal
{
	internal static bool StartsWithDirectorySeparator(ReadOnlySpan<char> path)
	{
		if (path.Length > 0)
		{
			return IsDirectorySeparator(path[0]);
		}
		return false;
	}

	internal static string EnsureTrailingSeparator(string path)
	{
		if (!EndsInDirectorySeparator(path.AsSpan()))
		{
			return path + "/";
		}
		return path;
	}

	internal static bool IsRoot(ReadOnlySpan<char> path)
	{
		return path.Length == GetRootLength(path);
	}

	internal static int GetCommonPathLength(string first, string second, bool ignoreCase)
	{
		int num = EqualStartingCharacterCount(first, second, ignoreCase);
		if (num == 0)
		{
			return num;
		}
		if (num == first.Length && (num == second.Length || IsDirectorySeparator(second[num])))
		{
			return num;
		}
		if (num == second.Length && IsDirectorySeparator(first[num]))
		{
			return num;
		}
		while (num > 0 && !IsDirectorySeparator(first[num - 1]))
		{
			num--;
		}
		return num;
	}

	internal unsafe static int EqualStartingCharacterCount(string first, string second, bool ignoreCase)
	{
		//The blocks IL_0034, IL_0058, IL_0068, IL_006e, IL_0074, IL_007c, IL_007f are reachable both inside and outside the pinned region starting at IL_0031. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second))
		{
			return 0;
		}
		int num = 0;
		fixed (char* ptr = first)
		{
			char* intPtr;
			if (second == null)
			{
				char* ptr2;
				intPtr = (ptr2 = null);
				char* ptr3 = ptr;
				char* ptr4 = ptr2;
				char* ptr5 = ptr3 + first.Length;
				char* ptr6 = ptr4 + second.Length;
				while (ptr3 != ptr5 && ptr4 != ptr6 && (*ptr3 == *ptr4 || (ignoreCase && char.ToUpperInvariant(*ptr3) == char.ToUpperInvariant(*ptr4))))
				{
					num++;
					ptr3++;
					ptr4++;
				}
			}
			else
			{
				fixed (char* ptr7 = &second.GetPinnableReference())
				{
					char* ptr2;
					intPtr = (ptr2 = ptr7);
					char* ptr3 = ptr;
					char* ptr4 = ptr2;
					char* ptr5 = ptr3 + first.Length;
					char* ptr6 = ptr4 + second.Length;
					while (ptr3 != ptr5 && ptr4 != ptr6 && (*ptr3 == *ptr4 || (ignoreCase && char.ToUpperInvariant(*ptr3) == char.ToUpperInvariant(*ptr4))))
					{
						num++;
						ptr3++;
						ptr4++;
					}
				}
			}
		}
		return num;
	}

	internal static bool AreRootsEqual(string first, string second, StringComparison comparisonType)
	{
		int rootLength = GetRootLength(first.AsSpan());
		int rootLength2 = GetRootLength(second.AsSpan());
		if (rootLength == rootLength2)
		{
			return string.Compare(first, 0, second, 0, rootLength, comparisonType) == 0;
		}
		return false;
	}

	internal static string RemoveRelativeSegments(string path, int rootLength)
	{
		Span<char> initialBuffer = stackalloc char[260];
		ValueStringBuilder sb = new ValueStringBuilder(initialBuffer);
		if (RemoveRelativeSegments(path.AsSpan(), rootLength, ref sb))
		{
			path = sb.ToString();
		}
		sb.Dispose();
		return path;
	}

	internal static bool RemoveRelativeSegments(ReadOnlySpan<char> path, int rootLength, ref ValueStringBuilder sb)
	{
		bool flag = false;
		int num = rootLength;
		if (IsDirectorySeparator(path[num - 1]))
		{
			num--;
		}
		if (num > 0)
		{
			sb.Append(path.Slice(0, num));
		}
		for (int i = num; i < path.Length; i++)
		{
			char c = path[i];
			if (IsDirectorySeparator(c) && i + 1 < path.Length)
			{
				if (IsDirectorySeparator(path[i + 1]))
				{
					continue;
				}
				if ((i + 2 == path.Length || IsDirectorySeparator(path[i + 2])) && path[i + 1] == '.')
				{
					i++;
					continue;
				}
				if (i + 2 < path.Length && (i + 3 == path.Length || IsDirectorySeparator(path[i + 3])) && path[i + 1] == '.' && path[i + 2] == '.')
				{
					int num2;
					for (num2 = sb.Length - 1; num2 >= num; num2--)
					{
						if (IsDirectorySeparator(sb[num2]))
						{
							sb.Length = ((i + 3 >= path.Length && num2 == num) ? (num2 + 1) : num2);
							break;
						}
					}
					if (num2 < num)
					{
						sb.Length = num;
					}
					i += 2;
					continue;
				}
			}
			if (c != '/' && c == '/')
			{
				c = '/';
				flag = true;
			}
			sb.Append(c);
		}
		if (!flag && sb.Length == path.Length)
		{
			return false;
		}
		if (num != rootLength && sb.Length < rootLength)
		{
			sb.Append(path[rootLength - 1]);
		}
		return true;
	}

	[return: NotNullIfNotNull("path")]
	internal static string TrimEndingDirectorySeparator(string path)
	{
		if (!EndsInDirectorySeparator(path) || IsRoot(path.AsSpan()))
		{
			return path;
		}
		return path.Substring(0, path.Length - 1);
	}

	internal static bool EndsInDirectorySeparator([NotNullWhen(true)] string path)
	{
		if (!string.IsNullOrEmpty(path))
		{
			return IsDirectorySeparator(path[path.Length - 1]);
		}
		return false;
	}

	internal static ReadOnlySpan<char> TrimEndingDirectorySeparator(ReadOnlySpan<char> path)
	{
		if (!EndsInDirectorySeparator(path) || IsRoot(path))
		{
			return path;
		}
		return path.Slice(0, path.Length - 1);
	}

	internal static bool EndsInDirectorySeparator(ReadOnlySpan<char> path)
	{
		if (path.Length > 0)
		{
			return IsDirectorySeparator(path[path.Length - 1]);
		}
		return false;
	}

	internal static int GetRootLength(ReadOnlySpan<char> path)
	{
		if (path.Length <= 0 || !IsDirectorySeparator(path[0]))
		{
			return 0;
		}
		return 1;
	}

	internal static bool IsDirectorySeparator(char c)
	{
		return c == '/';
	}

	[return: NotNullIfNotNull("path")]
	internal static string NormalizeDirectorySeparators(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return path;
		}
		bool flag = true;
		for (int i = 0; i < path.Length; i++)
		{
			if (IsDirectorySeparator(path[i]) && i + 1 < path.Length && IsDirectorySeparator(path[i + 1]))
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			return path;
		}
		StringBuilder stringBuilder = new StringBuilder(path.Length);
		for (int j = 0; j < path.Length; j++)
		{
			char c = path[j];
			if (!IsDirectorySeparator(c) || j + 1 >= path.Length || !IsDirectorySeparator(path[j + 1]))
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	internal static bool IsPartiallyQualified(ReadOnlySpan<char> path)
	{
		return !Path.IsPathRooted(path);
	}

	internal static bool IsEffectivelyEmpty(string path)
	{
		return string.IsNullOrEmpty(path);
	}

	internal static bool IsEffectivelyEmpty(ReadOnlySpan<char> path)
	{
		return path.IsEmpty;
	}
}
