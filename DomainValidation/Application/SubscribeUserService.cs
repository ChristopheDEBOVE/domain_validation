using Domain;

namespace Application;

public interface ISubscribeUserService
{
    Task Subscribe(User user);
}
public class SubscribeUserService : ISubscribeUserService
{
    public async Task Subscribe(User user)
    {
        return;
    }
}