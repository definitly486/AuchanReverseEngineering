namespace Auchan.Common.Ecom.Cart.ViewModels;

public class ListItemModificationValueViewModel
{
	public string Name { get; private set; }

	public string Value { get; private set; }

	public ListItemModificationValueViewModel(string name, string value)
	{
		Name = name + ": ";
		Value = value;
	}
}
