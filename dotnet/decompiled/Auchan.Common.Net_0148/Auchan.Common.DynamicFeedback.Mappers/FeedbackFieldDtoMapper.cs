using Auchan.Common.DynamicFeedback.Responses;

namespace Auchan.Common.DynamicFeedback.Mappers;

public static class FeedbackFieldDtoMapper
{
	public static FieldItemViewModel ToFieldViewModel(this FeedbackFieldDto fieldDto)
	{
		long type = fieldDto.Type;
		long num = type - 1;
		if ((ulong)num <= 10uL)
		{
			switch (num)
			{
			case 0L:
				return new FieldItemViewModel(FieldType.Bool, fieldDto);
			case 1L:
				return new FieldItemViewModel(FieldType.DateTime, fieldDto);
			case 2L:
				return new FieldItemViewModel(FieldType.Date, fieldDto);
			case 3L:
				return new FieldItemViewModel(FieldType.Integer, fieldDto);
			case 4L:
				return new FieldItemViewModel(FieldType.Float, fieldDto);
			case 5L:
				return new FieldItemViewModel(FieldType.ListSelection, fieldDto);
			case 6L:
				return new FieldItemViewModel(FieldType.TextField50, fieldDto);
			case 7L:
				return new FieldItemViewModel(FieldType.TextField250, fieldDto);
			case 8L:
				return new FieldItemViewModel(FieldType.TextField500, fieldDto);
			case 9L:
				return new FieldItemViewModel(FieldType.TextFieldUnlimited, fieldDto);
			case 10L:
				return new FieldItemViewModel(FieldType.File, fieldDto);
			}
		}
		return new FieldItemViewModel(FieldType.Undefined, fieldDto);
	}
}
