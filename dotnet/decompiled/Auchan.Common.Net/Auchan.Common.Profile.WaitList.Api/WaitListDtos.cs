using System.Collections.Generic;
using Auchan.Common.Ecom.DTO;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.WaitList.Api;

public class WaitListDtos
{
	public class DeleteDto
	{
		[JsonProperty("data")]
		public ProductData Data { get; set; } = new ProductData();

		[JsonProperty("errors")]
		public List<ErrorDto>? Errors { get; set; }
	}

	public class AddDto
	{
		[JsonProperty("data")]
		public ProductData Data { get; set; } = new ProductData();

		[JsonProperty("errors")]
		public List<ErrorDto>? Errors { get; set; }
	}

	public class AddRequestDto
	{
		[JsonProperty("gima_id")]
		public int GimaId { get; set; }

		[JsonProperty("merchant_id")]
		public int StoreId { get; set; }
	}

	public class DeleteRequestDto
	{
		[JsonProperty("gima_id")]
		public int GimaId { get; set; }
	}

	public class WaitListRequestDto
	{
		[JsonProperty("merchant_id")]
		public int StoreId { get; set; }

		[JsonProperty("only_active")]
		public bool OnlyActive { get; set; }

		[JsonProperty("category_code")]
		public string? Category { get; set; }
	}

	public class NotificationRequestDto
	{
		[JsonProperty("merchant_id")]
		public int StoreId { get; set; }
	}

	public class NotificationResponseDto
	{
		[JsonProperty("data")]
		public WaitListNotificationDto DataForNotification { get; set; } = new WaitListNotificationDto();
	}

	public class ProductData
	{
		[JsonProperty("qty_all_products_in_waitlist")]
		public int QtyAllProductsInWaitList { get; set; }

		[JsonProperty("qty_active_products_in_waitlist")]
		public int QtyActiveProductsInWaitList { get; set; }

		[JsonProperty("gima_ids")]
		public List<int> GimaIds { get; set; } = new List<int>();
	}

	public class WaitListProductsDto
	{
		[JsonProperty("data")]
		public WaitListData Data { get; set; }
	}

	public class WaitListData
	{
		[JsonProperty("qty_all_products_in_waitlist")]
		public int QtyAllProductsInWaitList { get; set; }

		[JsonProperty("qty_active_products_in_waitlist")]
		public int QtyActiveProductsInWaitList { get; set; }

		[JsonProperty("gima_ids")]
		public List<int> GimaIds { get; set; } = new List<int>();

		[JsonProperty("categories")]
		public List<WaitListCategory> Categories { get; set; } = new List<WaitListCategory>();

		[JsonProperty("categories_preview")]
		public List<WaitListCategoryPreview> CategoriesPreview { get; set; } = new List<WaitListCategoryPreview>();
	}

	public class ErrorDto
	{
		[JsonProperty("code")]
		public string? Code { get; set; }

		[JsonProperty("message")]
		public string? Message { get; set; }
	}

	public class WaitListCategoryPreview
	{
		[JsonProperty("code")]
		public string? Code { get; set; }

		[JsonProperty("name")]
		public string? Name { get; set; }

		[JsonProperty("products_counter")]
		public int? ProductsCounter { get; set; }
	}

	public class WaitListCategory
	{
		[JsonProperty("id")]
		public int? Id { get; set; }

		[JsonProperty("code")]
		public string? Code { get; set; }

		[JsonProperty("name")]
		public string? Name { get; set; }

		[JsonProperty("products_counter")]
		public int? ProductsCounter { get; set; }

		[JsonProperty("products")]
		public List<ProductDto> Products { get; set; } = new List<ProductDto>();
	}

	public class WaitListNotificationDto
	{
		[JsonProperty("notification_required")]
		public bool NotificationRequired { get; set; }

		[JsonProperty("notification_data")]
		public NotificationData Data { get; set; } = new NotificationData();

		[JsonProperty("qty_all_products_in_waitlist")]
		public int QtyAllProductsInWaitList { get; set; }

		[JsonProperty("qty_active_products_in_waitlist")]
		public int QtyActiveProductsInWaitList { get; set; }

		[JsonProperty("qty_products_for_notification")]
		public int QtyProductsForNotification { get; set; }
	}

	public class NotificationData
	{
		[JsonProperty("qty_products_for_notification")]
		public int QtyProductsForNotification { get; set; }

		[JsonProperty("product_for_notification")]
		public ProductDto Product { get; set; }
	}
}
