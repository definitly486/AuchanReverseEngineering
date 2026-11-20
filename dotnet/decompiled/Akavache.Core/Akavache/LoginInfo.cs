namespace Akavache;

public class LoginInfo(string username, string password)
{
	public string UserName { get; } = username;

	public string Password { get; } = password;

	internal LoginInfo((string UserName, string Password) usernameAndLogin)
		: this(usernameAndLogin.UserName, usernameAndLogin.Password)
	{
	}
}
