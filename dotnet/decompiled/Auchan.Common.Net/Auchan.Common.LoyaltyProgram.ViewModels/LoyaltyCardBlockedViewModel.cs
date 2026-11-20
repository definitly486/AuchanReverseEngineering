using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.LoyaltyProgram.ViewModels;

public class LoyaltyCardBlockedViewModel : ScreenViewModel
{
	[CompilerGenerated]
	private (int, int) _003CBoldMessageStartEnd_003Ek__BackingField;

	public string CloseString => "Закрыть";

	public string Title => "Ваша карта лояльности заблокирована";

	public string Phone => "8\u00a0800\u00a0700-58-00";

	public string Message => "Поэтому вы не можете войти в\u00a0личный кабинет. За\u00a0информацией необходимо обращаться в контактный центр: " + "8\u00a0800\u00a0700-58-00" + "\n\nРежим работы: круглосуточно.";

	public (int, int) BoldMessageStartEnd
	{
		[CompilerGenerated]
		get
		{
			return _003CBoldMessageStartEnd_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!EqualityComparer<(int, int)>.Default.Equals(_003CBoldMessageStartEnd_003Ek__BackingField, value))
			{
				_003CBoldMessageStartEnd_003Ek__BackingField = value;
				RaisePropertyChanged("BoldMessageStartEnd");
			}
		}
	}

	public UICommand CloseCommand { get; } = new UICommand();

	protected override async Task Start()
	{
		await base.Start();
		BoldMessageStartEnd = (Message.IndexOf(Phone.First()), Phone.Length);
	}
}
