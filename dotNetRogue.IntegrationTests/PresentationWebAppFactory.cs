using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotNetRogue.Application.Database;
using dotNetRogue.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotNetRogue.IntegrationTests
{
    public class PresentationWebAppFactory<TEntryPoint>
        : WebApplicationFactory<TEntryPoint>
        where TEntryPoint : class
    {
        protected override IHostBuilder CreateHostBuilder() =>
            base.CreateHostBuilder().UseEnvironment("Testing");

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(IAppDbContext));

                services.Remove(descriptor);

                services.AddDbContext<IAppDbContext, AppDbContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "dotNetRogueTests "));
            });
        }
    }
}
