using EstanteLivros.Data;
using EstanteLivros.Models;
using DBEstantes context = new DBEstantes();

var builder = WebApplication.CreateBuilder(args);

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


Autor Pedro = new Autor()
{
    NomeAutor = "Pedro"
};

Autor Joao = new Autor()
{
    NomeAutor = "João"
};

Autor Luis = new Autor()
{
    NomeAutor = "Luís"
};

Autor Antonio = new Autor()
{
    NomeAutor = "António"
};

Autor Joana = new Autor()
{
    NomeAutor = "Joana"
};

Autor Ines = new Autor()
{
    NomeAutor = "Inês"
};

Livro Legend = new Livro()
{
    ISBN = 925868656,
    nomeLivro = "The Legend Himself",
    precoLivro = (decimal)15.99,
    IDAutor = 1

};

Livro oParaiso = new Livro()
{
    ISBN = 945712856,
    nomeLivro = "O Paraíso",
    precoLivro = (decimal)20.00,
    IDAutor = 2

};

Livro Odisseia = new Livro()
{
    ISBN = 928563135,
    nomeLivro = "Odisseia",
    precoLivro = (decimal)12.99,
    IDAutor = 3
};

Livro Frankenstein = new Livro()
{
    ISBN = 935835738,
    nomeLivro = "Frankenstein",
    precoLivro = (decimal)10.00,
    IDAutor = 4
};

Livro Hamlet = new Livro()
{
    ISBN = 951238578,
    nomeLivro = "Hamlet",
    precoLivro = (decimal)7.99,
    IDAutor = 5
};

Livro MilNoites = new Livro()
{
    ISBN = 982137395,
    nomeLivro = "As Mil e Uma Noites",
    precoLivro = (decimal)17.99,
    IDAutor = 6
};

context.Add(Pedro);
context.Add(Joao);
context.Add(Luis);
context.Add(Antonio);
context.Add(Joana);
context.Add(Ines);
context.Add(Legend);
context.Add(oParaiso);
context.Add(Odisseia);
context.Add(Frankenstein);
context.Add(Hamlet);
context.Add(MilNoites);

context.SaveChanges();
