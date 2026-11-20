namespace Auchan.Common.AuchanPay.ViewModels;

public class RefillAmountItemViewModel
{
	public int Amount { get; }

	public string AmountString => $"{Amount} ₽";

	public bool Selected { get; set; }

	public RefillAmountItemViewModel(int amount)
	{
		Amount = amount;
	}
}
