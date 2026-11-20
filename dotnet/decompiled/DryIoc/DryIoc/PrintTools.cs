using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DryIoc.ImTools;

namespace DryIoc;

public static class PrintTools
{
	public static string DefaultItemSeparator = ", " + "\n";

	public static Func<Type, string> GetTypeNameDefault = (Type t) => (t.FullName == null || t.Namespace == null || t.Namespace.StartsWith("System")) ? t.Name : t.FullName;

	public static StringBuilder Print(this StringBuilder s, object x, string quote = "\"", string itemSeparator = null, Func<Type, string> getTypeName = null)
	{
		if (x != null)
		{
			if (!(x is string))
			{
				if (!(x is Type))
				{
					if (!(x is IPrintable))
					{
						if (!(x is IScope) && !(x is Request))
						{
							if (!x.GetType().IsEnum)
							{
								if ((!(x is IEnumerable<Type>) && !(x is IEnumerable)) || x.GetType().IsAssignableTo(typeof(IEnumerable<>).MakeGenericType(x.GetType())))
								{
									return s.Append(x);
								}
								return s.Print((IEnumerable)x, itemSeparator ?? DefaultItemSeparator, delegate(StringBuilder _, object o)
								{
									_.Print(o, quote, null, getTypeName);
								});
							}
							return s.Print(x.GetType()).Append('.').Append(Enum.GetName(x.GetType(), x));
						}
						return s.Append(x);
					}
					return ((IPrintable)x).Print(s, (StringBuilder b, object p) => b.Print(p, quote, itemSeparator, getTypeName));
				}
				return s.Print((Type)x, getTypeName);
			}
			return s.Print((string)x, quote);
		}
		return s.Append("null");
	}

	public static StringBuilder Print(this StringBuilder s, string str, string quote = "\"")
	{
		if (quote != null)
		{
			return s.Append(quote).Append(str).Append(quote);
		}
		return s.Append(str);
	}

	public static StringBuilder Print(this StringBuilder s, IEnumerable items, string separator = ", ", Action<StringBuilder, object> printItem = null)
	{
		if (items == null)
		{
			return s;
		}
		printItem = printItem ?? ((Action<StringBuilder, object>)delegate(StringBuilder _, object x)
		{
			_.Print(x);
		});
		int num = 0;
		foreach (object item in items)
		{
			printItem((num++ == 0) ? s : s.Append(separator), item);
		}
		return s;
	}

	public static StringBuilder Print(this StringBuilder s, Type type, Func<Type, string> getTypeName = null)
	{
		if (type == null)
		{
			return s;
		}
		bool isArray = type.IsArray;
		if (isArray)
		{
			type = type.GetElementType();
		}
		string text = (getTypeName ?? GetTypeNameDefault)(type);
		if (!type.IsGenericType)
		{
			return s.Append(text.Replace('+', '.'));
		}
		int num = text.IndexOf('`');
		if (num != -1)
		{
			text = text.Substring(0, num);
		}
		s.Append(text.Replace('+', '.'));
		s.Append('<');
		Type[] genericArguments = type.GetGenericArguments();
		if (type.IsGenericTypeDefinition)
		{
			s.Append(',', genericArguments.Length - 1);
		}
		else
		{
			s.Print(genericArguments, ", ", delegate(StringBuilder b, object t)
			{
				b.Print((Type)t, getTypeName);
			});
		}
		s.Append('>');
		if (isArray)
		{
			s.Append("[]");
		}
		return s;
	}

	public static string Print(this Type type, Func<Type, string> getTypeName = null)
	{
		return new StringBuilder().Print(type, getTypeName).ToString();
	}
}
