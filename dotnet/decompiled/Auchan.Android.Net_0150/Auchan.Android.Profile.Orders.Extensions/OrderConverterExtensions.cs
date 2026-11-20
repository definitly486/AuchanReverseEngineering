using System;
using Android.Graphics;
using Auchan.Common.Profile.Orders.Enums;

namespace Auchan.Android.Profile.Orders.Extensions;

public static class OrderConverterExtensions
{
	public static Color GetBackgroundArgb(this CustomerStatus status)
	{
		return status switch
		{
			CustomerStatus.Canceled => Color.Rgb(240, 242, 245), 
			CustomerStatus.Completed => Color.Rgb(0, 152, 95), 
			CustomerStatus.ReadyToIssue => Color.Rgb(229, 250, 225), 
			CustomerStatus.Delivered => Color.Rgb(11, 115, 219), 
			CustomerStatus.OnWay => Color.Rgb(226, 238, 251), 
			CustomerStatus.InProcessBuild => Color.Rgb(240, 100, 0), 
			CustomerStatus.InForm => Color.Rgb(255, 236, 222), 
			CustomerStatus.Takeout => Color.Rgb(255, 149, 1), 
			CustomerStatus.Accepted => Color.Rgb(255, 236, 222), 
			_ => Color.Rgb(0, 0, 0), 
		};
	}

	public static Color GetTextArgb(this CustomerStatus status)
	{
		return status switch
		{
			CustomerStatus.Canceled => Color.Rgb(99, 108, 120), 
			CustomerStatus.Completed => Color.Rgb(255, 255, 255), 
			CustomerStatus.ReadyToIssue => Color.Rgb(0, 152, 95), 
			CustomerStatus.Delivered => Color.Rgb(255, 255, 255), 
			CustomerStatus.OnWay => Color.Rgb(11, 115, 219), 
			CustomerStatus.InProcessBuild => Color.Rgb(255, 255, 255), 
			CustomerStatus.InForm => Color.Rgb(240, 100, 0), 
			CustomerStatus.Takeout => Color.Rgb(255, 255, 255), 
			CustomerStatus.Accepted => Color.Rgb(240, 100, 0), 
			_ => Color.Rgb(0, 0, 0), 
		};
	}

	public static int ToIconResourceId(this CustomerStatus status)
	{
		return status switch
		{
			CustomerStatus.Completed => 2131231164, 
			CustomerStatus.ReadyToIssue => 2131231265, 
			CustomerStatus.Delivered => 2131231193, 
			CustomerStatus.OnWay => 2131231144, 
			CustomerStatus.InProcessBuild => 2131231076, 
			CustomerStatus.InForm => 2131231324, 
			CustomerStatus.Takeout => 2131231348, 
			CustomerStatus.Accepted => 2131231324, 
			_ => throw new NotImplementedException("dead code"), 
		};
	}
}
