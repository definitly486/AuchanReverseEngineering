using System.Linq;
using Auchan.Common.Controls.AutoLayout;

namespace Auchan.Android.Common.UiUtils;

internal class LastItemDecoration : GridSpacesItemDecoration3
{
	public LastItemDecoration(int topOffsetDP, int bottomOffsetDP, int startOffsetDP, int endOffsetDP, AutoLayoutViewModel autoLayout)
		: base(topOffsetDP, bottomOffsetDP, startOffsetDP, endOffsetDP, delegate(int pos)
		{
			if (pos == autoLayout.Elements.Count - 1)
			{
				return true;
			}
			AutoLayoutViewModel.AutoLayoutElement autoLayoutElement = autoLayout.Elements.ElementAtOrDefault(pos);
			return (pos == autoLayout.Elements.Count - 2 && autoLayoutElement != null && (autoLayoutElement.Type == "Product" || autoLayoutElement.Type == "RecommendationProduct" || autoLayoutElement.Type == "RecommendationProductStub")) ? true : false;
		})
	{
	}
}
