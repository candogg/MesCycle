using MesCycle.Web.Business.Items;

namespace MesCycle.Web.Business.Interfaces
{
    public interface IMessagePublishService
    {
        Task<ResponseItem> Publish(string message);
    }
}
