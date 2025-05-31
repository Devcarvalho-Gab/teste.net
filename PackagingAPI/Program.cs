using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PackagingAPI.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();  
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.MapPost("/embalar", static (List<Produto> produtos, PackagingAPI.Services.EmbalagemService embalagemService) =>
{
    var caixas = embalagemService.EmbalagemPedido(produtos);
    return Results.Ok(caixas);
});

app.Run();
