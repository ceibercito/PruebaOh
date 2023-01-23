using PruebaOh.Db;
using PruebaOh.Models;

var builder = WebApplication.CreateBuilder(args);

#region Routing

builder.Services.AddControllers();

#endregion

#region Documentation

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc(
        "v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Prueba Oh",
            Description = "Documentacion de API Oh",
            Version = "v1"
        }
        );
});

#endregion

#region Storage

var connectionString = "Server=mssql-107024-0.cloudclusters.net,10243;Initial Catalog=pruebaOh;User ID=ceiber;Password=TECINF2k10$;";
builder.Services.AddSqlServer<DbEmpleadoDbContext>(connectionString);

#endregion

var app = builder.Build();

#region Documentacion

app.UseSwagger();
app.UseSwaggerUI(C =>
{
    C.SwaggerEndpoint("/swagger/v1/swagger.json", "Prueba Oh");
});

#endregion

#region Routing

app.MapControllers();

#endregion

app.Run();
