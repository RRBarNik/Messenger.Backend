namespace Messenger.Backend.Api.Data.PostgreSql
{
    public class DbInitializer
    {
        public static void Initialize(MessengerDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
