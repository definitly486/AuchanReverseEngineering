using Auchan.Common.Base.Errors.Domain;

namespace Auchan.Common.Base.Errors;

public class DefaultErrorTranslator : IErrorTranslator
{
	public const string UNKNOWN_TITLE = "Упс! Что-то пошло не так.";

	public const string NO_DATA_TITLE = "Не удалось загрузить данные.";

	public const string UNKNOWN_MESSAGE = "Небольшие технические проблемы,\nпопробуйте обновить экран.";

	public const string ConnectionErrorTitle = "Нет соединения с интернетом";

	public const string ConnectionErrorMessage = "Проверьте интернет-соединение и повторите попытку";

	public (string title, string description) Translate<T>(T error) where T : DomainError
	{
		string item = ((error is ConnectionError) ? "Нет соединения с интернетом" : ((error is TimeoutError) ? "Не удалось загрузить данные." : ((error is NoDataError) ? "Не удалось загрузить данные." : ((error is CancellationError) ? "Упс! Что-то пошло не так." : ((!(error is DisableVpnError)) ? "Упс! Что-то пошло не так." : "Упс! Что-то пошло не так.")))));
		string item2 = ((error is ConnectionError) ? "Проверьте интернет-соединение и повторите попытку" : "Небольшие технические проблемы,\nпопробуйте обновить экран.");
		return (title: item, description: item2);
	}
}
