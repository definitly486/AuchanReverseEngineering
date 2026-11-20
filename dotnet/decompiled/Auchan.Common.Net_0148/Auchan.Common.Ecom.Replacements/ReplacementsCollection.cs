using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Replacements;

public class ReplacementsCollection : ReadOnlyCollection<ReplacementDto>
{
	private new static ReplacementsCollection Empty => new ReplacementsCollection(new List<ReplacementDto>());

	[JsonConstructor]
	private ReplacementsCollection(IList<ReplacementDto> replacements)
		: base(replacements)
	{
	}

	public static ReplacementsCollection CreateInstance(IEnumerable<ReplacementDto> replacements, out Exception? exception)
	{
		exception = null;
		List<ReplacementDto> list = replacements.ToList();
		if (list.Count == 0)
		{
			return Empty;
		}
		if (list.Count((ReplacementDto x) => x.IsDefault) > 1)
		{
			exception = new ArgumentException("ReplacementsCollection,CreateInstance: Only one default replacement is allowed");
			return Empty;
		}
		if (list.Count((ReplacementDto x) => x.IsDefault) < 1 && list.Count > 0)
		{
			list[0].IsDefault = true;
		}
		if (list.Select((ReplacementDto x) => x.Id).Distinct().Count() != list.Select((ReplacementDto x) => x.Id).Count())
		{
			exception = new ArgumentException("ReplacementsCollection,CreateInstance: Replacement methods must be unique");
			return Empty;
		}
		return new ReplacementsCollection(list);
	}
}
