using System.Reflection;

namespace CsvHelper.Configuration;

public class MemberReferenceMapData
{
	private string prefix = string.Empty;

	public virtual string Prefix
	{
		get
		{
			return prefix;
		}
		set
		{
			prefix = value;
			foreach (MemberMap memberMap in Mapping.MemberMaps)
			{
				memberMap.Data.Names.Prefix = value;
			}
			if (!Inherit)
			{
				return;
			}
			foreach (MemberReferenceMap referenceMap in Mapping.ReferenceMaps)
			{
				referenceMap.Data.Prefix = ((referenceMap.Data.Prefix == null) ? value : (value + referenceMap.Data.Prefix));
			}
		}
	}

	public virtual bool Inherit { get; set; }

	public virtual MemberInfo Member { get; private set; }

	public ClassMap Mapping { get; private set; }

	public MemberReferenceMapData(MemberInfo member, ClassMap mapping)
	{
		Member = member;
		Mapping = mapping;
	}
}
