using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.InfoPages;
using Auchan.Common.LoyaltyProgram.Services;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels;

public class FavoriteCategoriesPopupViewModel(Parameter parameter, FavoriteCategoriesRepository categoriesRepository, IInfoMessageService infoMessageService, Lazy<IUniversalLinksService> universalLinksService) : ScreenViewModel()
{
	public enum ForCase
	{
		InfoItem,
		InfoCategories,
		AcceptingItems
	}

	public class Parameter(string title, string description, FavoriteCategoryItemViewModel[] categories, ForCase forCase)
	{
		public string Title => title;

		public string Description => description;

		public FavoriteCategoryItemViewModel[] Categories => categories;

		public ForCase ForCase => forCase;
	}

	public ForCase Case => parameter.ForCase;

	public FavoriteCategoryItemViewModel[] Categories => parameter.Categories;

	public string Title => parameter.Title;

	public LinkedText Description => FormatDescription();

	public string ButtonText => GetButtonText();

	public UICommand<Parameter> ShowPopupCommand { get; } = new UICommand<Parameter>();

	public UICommand DismissCommand { get; } = new UICommand();

	public UICommand<BrokerToken> NavigateToCategoryCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<MyFavoriteCategoriesViewModel.Parameter> NavigateToMyFavoriteCategories { get; } = new UICommand<MyFavoriteCategoriesViewModel.Parameter>();

	public UICommand<InfoPageViewModel.Parameter> OpenInfoPageCommand { get; } = new UICommand<InfoPageViewModel.Parameter>();

	public bool DescriptionVisible
	{
		get
		{
			ForCase forCase = Case;
			if ((uint)forCase <= 1u)
			{
				return true;
			}
			return false;
		}
	}

	private string GetButtonText()
	{
		return Case switch
		{
			ForCase.InfoItem => "Понятно", 
			ForCase.InfoCategories => "Понятно", 
			ForCase.AcceptingItems => "Подтвердить", 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	private LinkedText FormatDescription()
	{
		string text = "";
		List<string> list = new List<string>();
		List<Action> list2 = new List<Action>();
		string description = parameter.Description;
		if (description.ContainsIgnoreCase("<p>"))
		{
			if (description.ContainsIgnoreCase("</a>"))
			{
				text = description.Substring("<p>", "<a href") + description.Substring("\">", "</a>") + description.Substring("</a>", "</p>");
				string item = description.Substring("\">", "</a>");
				string link = description.Substring("<a href=\"", "\">");
				list.Add(item);
				list2.Add(delegate
				{
					OpenLink(link);
				});
			}
			else
			{
				text = description.Substring("<p>", "</p>") ?? "";
			}
		}
		if (description.ContainsIgnoreCase("<ul>"))
		{
			IEnumerable<string> enumerable = from x in (description.Substring("<ul>\n", "</ul") ?? "").Split("<li>")
				where !string.IsNullOrWhiteSpace(x)
				select x;
			if (description.ContainsIgnoreCase("</a>"))
			{
				foreach (string item2 in enumerable)
				{
					string text2 = item2.Substring("\"> ", "</a>");
					string link2 = item2.Substring("<a href=\"", "\">");
					list2.Add(delegate
					{
						OpenLink(link2);
					});
					list.Add(text2);
					text = text + " • " + item2.Substring("", "<a") + text2 + "\n";
				}
			}
			else
			{
				foreach (string item3 in enumerable)
				{
					text = text + " • " + item3.Substring("", "</li>") + "\n";
				}
			}
			text = text.Remove(text.Length - 1);
		}
		return new LinkedText(text, list.ToArray(), list2.ToArray());
	}

	private void OpenLink(string link)
	{
		if (link.ContainsIgnoreCase("http"))
		{
			universalLinksService.Value.HandleLink(link);
		}
		else
		{
			OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(link));
		}
	}

	public void ShowCategoryInfo(FavoriteCategoryItemViewModel category)
	{
		ShowPopupCommand.Trigger(new Parameter(category.Name, category.Description, Array.Empty<FavoriteCategoryItemViewModel>(), ForCase.InfoItem));
	}

	public async Task ButtonClick()
	{
		if (Case == ForCase.AcceptingItems)
		{
			AppAnalytics.AppMetrica.TrackEvent("Tap_MainPersonal_offer_confirm");
			Result<FavoriteCategoriesItemViewModel, DomainError> result = await categoriesRepository.SendCategories(Categories.Select((FavoriteCategoryItemViewModel x) => x.Id).ToArray());
			if (result.IsSuccess)
			{
				NavigateToMyFavoriteCategories.Trigger(new MyFavoriteCategoriesViewModel.Parameter(result.Value.Data.Title, result.Value.Data.Subtitle, result.Value.Data.DetailDescription, Categories, result.Value.Data.MaxCount, accepted: true));
			}
			else
			{
				infoMessageService.ShowSnackbar("Не удалось загрузить. Обновите страницу или попробуйте позже.");
			}
		}
		else
		{
			DismissCommand.Trigger();
		}
	}
}
