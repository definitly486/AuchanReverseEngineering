using System;

namespace Auchan.Common.Navigation;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class RequiresAuthorizationAttribute : Attribute
{
}
