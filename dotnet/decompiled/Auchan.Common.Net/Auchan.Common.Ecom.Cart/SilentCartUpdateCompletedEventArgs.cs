using System;
using Auchan.Common.Ecom.Cart.Models;

namespace Auchan.Common.Ecom.Cart;

public sealed class SilentCartUpdateCompletedEventArgs : EventArgs
{
	public required CartModel Cart { get; init; }
}
