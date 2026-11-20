using System.Collections.Generic;
using System.Linq;
using Auchan.Common.AdminTool.DTO;
using Auchan.Common.AdminTool.Models;

namespace Auchan.Common.AdminTool.Mappers;

public static class StampsConfigMapper
{
	private const string CollectibleExpirationInformer = "collectible_expiration_mobile";

	private const string CollectibleDetailsInformer = "collectible_detail_mobile";

	private const string CollectibleStampsLimitInformer = "collectible_transaction_limit_mobile";

	private const int HomeScreenSectionCode = 2;

	private const int StampsTransferSectionCode = 3;

	private const int HistorySectionCode = 4;

	public static StampsConfig? GetStampsConfig(SectionVisibleDto sectionVisible, InformersDto informers, IEnumerable<string> segments, bool isEmployee)
	{
		string productStampsInformer = "";
		string stampsLimitInformer = "";
		bool showStampsAtHomeScreen = false;
		bool showStampsInHistory = false;
		bool allowStampsTransfer = false;
		InformerDto informerDto = informers.Data.Where((InformerDto inf) => inf.InformerType.ToLower().Equals("collectible_detail_mobile")).FirstOrDefault();
		if (informerDto != null)
		{
			productStampsInformer = informerDto.Value;
		}
		InformerDto informerDto2 = informers.Data.Where((InformerDto inf) => inf.InformerType.ToLower().Equals("collectible_transaction_limit_mobile")).FirstOrDefault();
		if (informerDto2 != null)
		{
			stampsLimitInformer = informerDto2.Value ?? "";
		}
		InformerDto informerDto3 = informers.Data.Where((InformerDto inf) => inf.InformerType.ToLower().Equals("collectible_expiration_mobile")).FirstOrDefault();
		if (informerDto3 != null)
		{
			string value = informerDto3.Value;
			string additionalLink = informerDto3.AdditionalLink;
			SectionDto sectionDto = sectionVisible.Sections.Where((SectionDto s) => s.Code == 2).FirstOrDefault();
			if (sectionDto != null)
			{
				showStampsAtHomeScreen = sectionDto.Visible;
			}
			SectionDto sectionDto2 = sectionVisible.Sections.Where((SectionDto s) => s.Code == 4).FirstOrDefault();
			if (sectionDto2 != null)
			{
				showStampsInHistory = sectionDto2.Visible;
			}
			SectionDto sectionDto3 = sectionVisible.Sections.Where((SectionDto s) => s.Code == 3).FirstOrDefault();
			if (sectionDto3 != null)
			{
				allowStampsTransfer = sectionDto3.Visible;
			}
			if (sectionVisible.Collectible == null)
			{
				return null;
			}
			StampsConfig stampsConfig = new StampsConfig(productStampsInformer, stampsLimitInformer, value, additionalLink, sectionVisible.Collectible.UserSegmentCode, sectionVisible.Collectible.Active, sectionVisible.Collectible.IsForEmployees, sectionVisible.Collectible.IsForSegment, sectionVisible.Collectible.StartDate, sectionVisible.Collectible.EndDate, showStampsAtHomeScreen, showStampsInHistory, allowStampsTransfer);
			stampsConfig.SetSocialStatus(segments, isEmployee);
			return stampsConfig;
		}
		return null;
	}
}
