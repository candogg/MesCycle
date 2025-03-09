using MassTransit;
using MesCycle.Web.Business.Implementations.Abstract;
using MesCycle.Web.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MesCycle.Web.Business.Extensions
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public static class ServiceExtensions
    {
        public static void RegisterBusinessDIServices(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    x.AddConsumer<MessageConsumerService>();

                    cfg.Host("rabbitmq://localhost", configurator =>
                    {
                        configurator.Username("guest");
                        configurator.Password("guest");
                    });
                    cfg.ReceiveEndpoint("AgentQueue", e =>
                    {
                        e.Durable = true;
                        e.AutoDelete = false;

                        e.UseMessageRetry(r => r.Interval(6, TimeSpan.FromSeconds(5)));
                        e.ConfigureConsumer<MessageConsumerService>(context);
                    });
                });

                x.AddConsumer<MessageConsumerService>();
            });

            services.AddSignalR();
            services.AddSingleton<AgentMessagingService>();

            services.AddScoped<IMessagePublishService, MessagePublishService>();
        }
    }
}
