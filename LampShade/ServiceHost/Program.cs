using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using ShopManagement.Configuration;
using System;
using System.Data.SqlTypes;

public static class Program
{
    public static void Main(params string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.ConfigureServices(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
        app.UseEndpoints(Endpoints =>
        {
            app.MapRazorPages();
            app.MapDefaultControllerRoute();
        });

        app.Run();
    }

    private static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("LampshadeDb");
        ShopManagementBootstrapper.Configure(services, connectionString);

        services.AddRazorPages();

        return services;
    }
}


