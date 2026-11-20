using System;
using System.Collections;
using System.Collections.Generic;
using NLog.Common;
using NLog.Internal;

namespace NLog.MessageTemplates;

public sealed class MessageTemplateParameters : IEnumerable<MessageTemplateParameter>, IEnumerable
{
	internal static readonly MessageTemplateParameters Empty = new MessageTemplateParameters(string.Empty, ArrayHelper.Empty<object>());

	private readonly IList<MessageTemplateParameter> _parameters;

	public MessageTemplateParameter this[int index] => _parameters[index];

	public int Count => _parameters.Count;

	public bool IsPositional { get; }

	internal bool IsValidTemplate { get; }

	public IEnumerator<MessageTemplateParameter> GetEnumerator()
	{
		return _parameters.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _parameters.GetEnumerator();
	}

	internal MessageTemplateParameters(string message, object?[] parameters)
	{
		if (parameters == null || parameters.Length == 0)
		{
			_parameters = ArrayHelper.Empty<MessageTemplateParameter>();
			IsPositional = false;
			IsValidTemplate = true;
		}
		else
		{
			_parameters = ParseMessageTemplate(message, parameters, out var isPositional, out var isValidTemplate);
			IsPositional = isPositional;
			IsValidTemplate = isValidTemplate;
		}
	}

	internal MessageTemplateParameters(IList<MessageTemplateParameter> templateParameters, string message, object?[]? parameters)
	{
		_parameters = templateParameters ?? ArrayHelper.Empty<MessageTemplateParameter>();
		if (parameters != null && _parameters.Count != parameters.Length)
		{
			IsValidTemplate = false;
		}
	}

	private static IList<MessageTemplateParameter> ParseMessageTemplate(string template, object?[] parameters, out bool isPositional, out bool isValidTemplate)
	{
		isPositional = true;
		isValidTemplate = true;
		List<MessageTemplateParameter> list = new List<MessageTemplateParameter>(parameters.Length);
		try
		{
			short num = 0;
			TemplateEnumerator templateEnumerator = new TemplateEnumerator(template);
			while (templateEnumerator.MoveNext())
			{
				if (templateEnumerator.Current.Literal.Skip == 0)
				{
					continue;
				}
				Hole hole = templateEnumerator.Current.Hole;
				if ((hole.Index != -1) & isPositional)
				{
					num = GetMaxHoleIndex(num, hole.Index);
					object holeValueSafe = GetHoleValueSafe(parameters, hole.Index, ref isValidTemplate);
					list.Add(new MessageTemplateParameter(hole.Name, holeValueSafe, hole.Format, hole.CaptureType));
					continue;
				}
				if (isPositional)
				{
					isPositional = false;
					if (num != 0)
					{
						templateEnumerator = new TemplateEnumerator(template);
						num = 0;
						list.Clear();
						continue;
					}
				}
				object holeValueSafe2 = GetHoleValueSafe(parameters, num, ref isValidTemplate);
				list.Add(new MessageTemplateParameter(hole.Name, holeValueSafe2, hole.Format, hole.CaptureType));
				num++;
			}
			if (isPositional)
			{
				if (list.Count < parameters.Length || num != parameters.Length)
				{
					isValidTemplate = false;
				}
			}
			else if (list.Count != parameters.Length)
			{
				isValidTemplate = false;
			}
			return list;
		}
		catch (Exception ex)
		{
			isValidTemplate = false;
			InternalLogger.Warn(ex, "Error when parsing a message.");
			return list;
		}
	}

	private static short GetMaxHoleIndex(short maxHoleIndex, short holeIndex)
	{
		if (maxHoleIndex == 0)
		{
			maxHoleIndex++;
		}
		if (maxHoleIndex <= holeIndex)
		{
			maxHoleIndex = holeIndex;
			maxHoleIndex++;
		}
		return maxHoleIndex;
	}

	private static object? GetHoleValueSafe(object?[] parameters, short holeIndex, ref bool isValidTemplate)
	{
		if (parameters.Length > holeIndex)
		{
			return parameters[holeIndex];
		}
		isValidTemplate = false;
		return null;
	}
}
