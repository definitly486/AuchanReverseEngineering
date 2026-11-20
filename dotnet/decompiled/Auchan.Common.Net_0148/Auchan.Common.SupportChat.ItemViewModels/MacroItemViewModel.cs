using Auchan.Common.Base;

namespace Auchan.Common.SupportChat.ItemViewModels;

public class MacroItemViewModel : BaseItemViewModel
{
	public string MacroText { get; }

	public bool IsRating
	{
		get
		{
			if (!(MacroText == "1") && !(MacroText == "2") && !(MacroText == "3") && !(MacroText == "4"))
			{
				return MacroText == "5";
			}
			return true;
		}
	}

	public MacroItemViewModel(string macroText)
	{
		MacroText = macroText;
	}
}
