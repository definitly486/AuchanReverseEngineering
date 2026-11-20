using Auchan.Common.Base;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.Profile.Stores;

public class TextDetailsViewModel : ScreenViewModel
{
	public class Parameter
	{
		public string Description { get; }

		public string Title { get; }

		public Parameter(string title, string description)
		{
			Description = description;
			Title = title;
		}
	}

	public readonly UICommand CloseCommand = new UICommand();

	public string Title { get; }

	public string Description { get; }

	public void Close()
	{
		CloseCommand.Trigger();
	}

	public TextDetailsViewModel(Parameter parameter)
	{
		Description = parameter.Description;
		Title = parameter.Title;
	}
}
