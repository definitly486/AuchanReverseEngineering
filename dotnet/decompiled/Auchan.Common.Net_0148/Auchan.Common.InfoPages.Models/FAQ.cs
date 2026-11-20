using System.Collections.Generic;

namespace Auchan.Common.InfoPages.Models;

public class FAQ
{
	public int Id { get; set; }

	public string Name { get; set; }

	public List<FAQEntry> Entries { get; set; }

	public FAQ(int id, string name, List<FAQEntry> entries)
	{
		Id = id;
		Name = name;
		Entries = entries;
	}
}
