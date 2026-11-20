namespace DryIoc.Messages;

public interface IMessage<out TResponse>
{
}
public interface IMessage : IMessage<EmptyResponse>
{
}
