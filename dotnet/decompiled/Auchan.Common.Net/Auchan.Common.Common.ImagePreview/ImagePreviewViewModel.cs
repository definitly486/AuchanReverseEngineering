using Auchan.Common.Base;

namespace Auchan.Common.Common.ImagePreview;

public class ImagePreviewViewModel : ScreenViewModel
{
	public class Parameter
	{
		public string Title { get; }

		public string ImageUrl { get; }

		public Parameter(string title, string imageUrl)
		{
			Title = title;
			ImageUrl = imageUrl;
		}
	}

	private readonly Parameter _parameter;

	public string Title => _parameter.Title;

	public string ImageUrl => _parameter.ImageUrl;

	public ImagePreviewViewModel(Parameter parameter)
	{
		_parameter = parameter;
	}
}
