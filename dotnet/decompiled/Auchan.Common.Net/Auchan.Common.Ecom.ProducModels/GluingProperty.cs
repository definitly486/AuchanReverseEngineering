namespace Auchan.Common.Ecom.ProducModels;

public class GluingProperty
{
	public string ProductCode { get; }

	public string Name { get; }

	public string PropertyCode { get; }

	public string Value { get; }

	public int SortOrder { get; }

	public GluingProperty(string productCode, string name, string propertyCode, string value, int sortOrder)
	{
		ProductCode = productCode;
		Name = name;
		PropertyCode = propertyCode;
		Value = value;
		SortOrder = sortOrder;
	}
}
