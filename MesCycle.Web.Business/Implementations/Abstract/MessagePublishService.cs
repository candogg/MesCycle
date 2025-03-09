using MassTransit;
using MesCycle.Web.Business.Contracts;
using MesCycle.Web.Business.Interfaces;
using MesCycle.Web.Business.Items;

namespace MesCycle.Web.Business.Implementations.Abstract
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public class MessagePublishService(IPublishEndpoint publishEndpoint) : IMessagePublishService
    {
        public async Task<ResponseItem> Publish(string message)
        {
            try
            {
                var contract = new MessageContract
                {
                    Text = message
                };

                await publishEndpoint.Publish(contract);

                return new ResponseItem { IsOk = true };
            }
            catch
            { }

            return new ResponseItem { IsOk = false };
        }
    }
}
