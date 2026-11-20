using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Auchan.Common.Controls.AutoLayout;

public class AutoLayoutViewModel
{
	public class AutoLayoutElement(string type, object data, int order = int.MaxValue, object? tag = null)
	{
		public string Type => type;

		public object Data => data;

		public int Order => order;

		public object? Tag => tag;

		public static AutoLayoutElement New<T>(string type, object data, T order, object? tag = null) where T : struct, Enum, IConvertible
		{
			return new AutoLayoutElement(type, data, order.ToInt32(null), tag);
		}
	}

	public ObservableRangeCollection<AutoLayoutElement> Elements { get; private set; }

	public AutoLayoutViewModel(params AutoLayoutElement[] elements)
	{
		Elements = new ObservableRangeCollection<AutoLayoutElement>(elements.OrderBy((AutoLayoutElement e) => e.Order))
		{
			ShouldDeferEvents = false
		};
	}

	public void Insert(AutoLayoutElement element)
	{
		if (Elements.Count == 0)
		{
			Elements.Add(element);
			return;
		}
		if (element.Order >= Elements.Max((AutoLayoutElement e) => e.Order))
		{
			Elements.Add(element);
			return;
		}
		if (element.Order < Elements.Min((AutoLayoutElement e) => e.Order))
		{
			Elements.Insert(0, element);
			return;
		}
		Elements.Insert(Elements.IndexOf(Elements.First((AutoLayoutElement e) => e.Order > element.Order)), element);
	}

	public void InsertRange(IEnumerable<AutoLayoutElement> elements)
	{
		InsertRange(elements.ToArray());
	}

	public void InsertRange(params AutoLayoutElement[] elements)
	{
		if (!elements.Any())
		{
			return;
		}
		elements = elements.OrderBy((AutoLayoutElement e) => e.Order).ToArray();
		if (Elements.Count == 0)
		{
			Elements.AddRange(elements);
			return;
		}
		int firstInsertionIndex = GetInsertionIndex(elements.First());
		if (firstInsertionIndex == Elements.Count)
		{
			Elements.AddRange(elements);
			return;
		}
		if (elements.All((AutoLayoutElement e) => GetInsertionIndex(e) == firstInsertionIndex))
		{
			Elements.InsertRange(firstInsertionIndex, elements);
			return;
		}
		AutoLayoutElement[] array = elements;
		foreach (AutoLayoutElement element in array)
		{
			Insert(element);
		}
	}

	public void ReplaceOrInsertRange(IEnumerable<AutoLayoutElement> toRemove, IEnumerable<AutoLayoutElement> toAdd)
	{
		if (toRemove.Any())
		{
			Elements.ReplaceRange(Elements.IndexOf(toRemove.First()), toRemove.Count(), toAdd);
		}
		else
		{
			InsertRange(toAdd);
		}
	}

	private int GetInsertionIndex(AutoLayoutElement element)
	{
		AutoLayoutElement autoLayoutElement = Elements.FirstOrDefault((AutoLayoutElement e) => e.Order > element.Order);
		int result = Elements.Count;
		if (autoLayoutElement != null)
		{
			result = Elements.IndexOf(autoLayoutElement);
		}
		return result;
	}
}
