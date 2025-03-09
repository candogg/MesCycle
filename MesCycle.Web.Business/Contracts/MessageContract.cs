using MesCycle.Web.Business.Interfaces;

namespace MesCycle.Web.Business.Contracts
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public class MessageContract : IMessageContract
    {
        public string? Text { get; set; }
    }
}
