
using Microsoft.Extensions.Options;
using OperationOOP.Api.Endpoints;
using OperationOOP.Core.Data;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace OperationOOP.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName?.Replace('+', '.'));
                options.InferSecuritySchemes();
            });

            builder.Services.AddSingleton<IWineService, WineService>();
            builder.Services.AddSingleton<IBeerService, BeerService>();
            builder.Services.AddSingleton<ISodaService, SodaService>();
            builder.Services.AddSingleton<IBeverageService, BeverageService>();
            builder.Services.AddSingleton<IDatabase, Database>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.DefaultModelsExpandDepth(-1);
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapEndpoints<Program>();

            app.Run();
        }
    }
}
