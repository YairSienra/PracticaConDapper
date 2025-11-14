
using PracticaConDapper.Extensions;
using System.Data.SqlClient;
using System.Data;
using Scrutor;
using Contract.Interfacees;
using System.Reflection;
using Contract.Repositorios;


namespace PracticaConDapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddTransient<IDbConnection>(sp =>
                    new SqlConnection(builder.Configuration.GetConnectionString("ConnexionDapper")));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Scan(scan => scan
                            .FromAssemblyOf<HeroeRepositorio>()
                            .AddClasses()
                            .AsMatchingInterface()
                            .WithScopedLifetime()

            );

            var app = builder.Build();

            app.UseSienraCustomMiddleWare();
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
