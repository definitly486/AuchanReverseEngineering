namespace Auchan.Common.Ecom.Products.Gluings;

public static class GluingValueStateExtensions
{
	public static GluingValueState ToState(this int x)
	{
		return x switch
		{
			0 => GluingValueState.Selected, 
			1 => GluingValueState.Default, 
			_ => GluingValueState.GrayedOut, 
		};
	}
}
