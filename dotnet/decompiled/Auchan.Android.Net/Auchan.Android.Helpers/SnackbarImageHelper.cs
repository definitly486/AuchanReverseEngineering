using Auchan.Common.Common;

namespace Auchan.Android.Helpers;

public static class SnackbarImageHelper
{
	public static int GetImageId(SnackbarStyle style)
	{
		return style switch
		{
			SnackbarStyle.Success => 2131231357, 
			SnackbarStyle.Warning => 2131231409, 
			SnackbarStyle.Error => 2131231358, 
			_ => -1, 
		};
	}
}
