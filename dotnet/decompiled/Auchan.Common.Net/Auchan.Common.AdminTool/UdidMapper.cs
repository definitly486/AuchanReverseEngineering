using Auchan.Common.AdminTool.DTO;
using Auchan.Common.AdminTool.Models;

namespace Auchan.Common.AdminTool;

public static class UdidMapper
{
	public static Udid ToModel(this UdidDto dto)
	{
		return new Udid(dto.UserId, dto.Key);
	}
}
