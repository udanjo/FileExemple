using System;
using System.Collections.Generic;
using fileExemple.Interfaces;
using fileExemple.Repositories;
using fileExemple.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var assembly = AppDomain.CurrentDomain.Load("fileExemple");
builder.Services.AddMediatR(assembly);

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IExcelFileBuilderService, ExcelFileBuilderService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.CustomSchemaIds(x => x.FullName);
    c.SwaggerDoc("v1", new OpenApiInfo{
        Version = "v1",
        Title = "Exemplo de Importação e Exportação de Arquivo",
        Description = "Exemplos"
    });
    //c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles();
    app.UseSwagger(setup => {
        setup.PreSerializeFilters.Add((document, request) => document.Servers = new List<OpenApiServer>
        {
            new OpenApiServer
            {
                Url = $"https://{request.Host.Value}{(request.Host.Host.ToLower() != "localhost" ? "xpto" : "")}"
            }
        });        
    });
    app.UseSwaggerUI(setup => {
        setup.RoutePrefix = "swagger";
        setup.OAuthAppName("Customer Swagger UI");

        //setup.SwaggerEndpoint($"./fileExemple/swagger.json", )
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
