using ApiLegal.DB;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Livros", Description = "Biblioteca diversa.", Version = "v1" });
});
    
var app = builder.Build();
    
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Produtos API V1");
   });
}
    
app.MapGet("/", () => "Hello World!");

app.MapGet("/livros/{id}", (int id) => LivrosDB.GetLivro(id));
app.MapGet("/livros", () => LivrosDB.GetLivros());
app.MapPost("/livros", (Livro livro) => LivrosDB.CreateLivro(livro));
app.MapPut("/livros", (Livro livro) => LivrosDB.UpdateLivro(livro));
app.MapDelete("/livros/{id}", (int id) => LivrosDB.RemoveLivro(id)); 
    
app.Run();