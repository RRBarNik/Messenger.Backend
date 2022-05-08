using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
