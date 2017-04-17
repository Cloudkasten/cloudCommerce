
namespace cloudCommerce.Core.Events
{
    public interface IConsumer<T>
    {
        void HandleEvent(T eventMessage);
    }
}
