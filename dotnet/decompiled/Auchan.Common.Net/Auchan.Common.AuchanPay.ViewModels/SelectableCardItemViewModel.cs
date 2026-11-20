using Auchan.Common.Profile.UserCards;

namespace Auchan.Common.AuchanPay.ViewModels;

public class SelectableCardItemViewModel
{
	public int Id { get; private set; }

	public string Pan { get; private set; }

	public CardSchemeType Scheme { get; private set; }

	public bool Selected { get; set; }

	public SelectableCardItemViewModel(CardModel model)
	{
		Id = model.Id;
		Pan = model.Pan.Replace("_", "••••••").Insert(12, " ").Insert(8, " ")
			.Insert(4, " ");
		Scheme = model.Scheme;
	}
}
