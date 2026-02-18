using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<AppDbContext>)
                );

                if (descriptor != null)
                    services.Remove(descriptor);

                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("IntegrationTestDb");
                    options.ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopeServices = scope.ServiceProvider;
                    var db = scopeServices.GetRequiredService<AppDbContext>();
                    db.Database.EnsureCreated();
                }
            });
        }
    }
}

