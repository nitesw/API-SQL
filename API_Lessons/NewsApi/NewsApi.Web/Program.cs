using NewsApi.Core;
using NewsApi.Core.DTOs;
using NewsApi.Core.Entities;
using NewsApi.Core.Interfaces;
using NewsApi.Infrastructure;

namespace NewsApi.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Create connection string
            string conStr = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add AddDbContext
            builder.Services.AddDbContext(conStr);

            // Add Repository
            builder.Services.AddRepositories();

            // Add Mapping
            builder.Services.AddMapping();

            // Add Core Services
            builder.Services.AddCoreServices();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}