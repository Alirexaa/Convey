﻿using System.Threading.Tasks;
using Convey;
using Convey.CQRS.Events;
using Convey.Discovery.Consul;
using Convey.LoadBalancing.Fabio;
using Convey.Logging;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Metrics.AppMetrics;
using Convey.Tracing.Jaeger;
using Convey.Tracing.Jaeger.RabbitMQ;
using Convey.WebApi;
using Conveyor.Services.Deliveries.Events.External;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Conveyor.Services.Deliveries
{
    public class Program
    {
        public static Task Main(string[] args)
            => CreateHostBuilder(args).Build().RunAsync();

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices(services => services
                        .Configure<KestrelServerOptions>(o => o.AllowSynchronousIO = true)
                        .AddOpenTracing()
                        .AddConvey()
                        .AddConsul()
                        .AddFabio()
                        .AddJaeger()
                        .AddEventHandlers()
                        .AddInMemoryEventDispatcher()
                        .AddRabbitMq(plugins: p => p.AddJaegerRabbitMqPlugin())
                        .AddMetrics()
                        .AddWebApi()
                        .Build())
                    .Configure(app => app
                        .UseErrorHandler()
                        .UseEndpoints(endpoints => endpoints
                            .Get("", ctx => ctx.Response.WriteAsync("Deliveries Service")))
                        .UseJaeger()
                        .UseMetrics()
                        .UseRabbitMq()
                        .SubscribeEvent<OrderCreated>())
                    .UseLogging();
            });
    }
}