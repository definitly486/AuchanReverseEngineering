using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record CheckoutDate
{
	public required DateTimeOffset Date { get; init; }

	public required string Day { get; init; }

	public required IReadOnlyList<CheckoutTime> Time { get; init; }

	public string DayOfMonth => Date.ToString("d MMMM");

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CheckoutDate(CheckoutDate original)
	{
		Date = original.Date;
		Day = original.Day;
		Time = original.Time;
	}

	public CheckoutDate()
	{
	}
}
