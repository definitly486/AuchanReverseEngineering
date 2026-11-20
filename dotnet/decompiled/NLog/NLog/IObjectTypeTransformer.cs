namespace NLog;

internal interface IObjectTypeTransformer
{
	object? TryTransformObject(object obj);
}
