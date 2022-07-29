using EventStore.ClientAPI;

namespace EventSourcing.API.EventStores
{
    public static class EventStoreExtension
    {
        public static void AddEventStore(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = EventStoreConnection.Create(configuration.GetConnectionString("EventStore"));
            connection.ConnectAsync().Wait();
            services.AddSingleton(connection);
            using var loggerFac = LoggerFactory.Create(
                builder =>
                {
                    builder.SetMinimumLevel(LogLevel.Information);
                    builder.AddConsole();
                });
            var logger = loggerFac.CreateLogger("Startup");
            connection.Connected += (sender, args) =>
            {
                logger.LogInformation("Bağlantı kuruldu");
            };
            connection.ErrorOccurred += (sender, args) =>
            {
                logger.LogError(args.Exception.Message);
            };
        }
    }
}
