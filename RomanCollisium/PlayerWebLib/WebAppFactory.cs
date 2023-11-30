using Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PlayerWebLib;

public static class WebAppFactory
{
    public static WebApplication CreateWebApp(string url, Player player, string[]? args = null)
    {
        var builder = WebApplication.CreateBuilder(args ?? Array.Empty<string>());

        builder.Services.AddScoped<Player>(_ => player);
        builder.Services.AddControllers();

        builder.WebHost.UseUrls(url);

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.MapControllers();

        return app;
    }
} 