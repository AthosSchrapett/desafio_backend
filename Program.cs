using desafio_backend.Data;
using desafio_backend.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddNpgsql<AppDbContext>(builder.Configuration["ConnectionString:desafio_backendDB"]);

builder.Services.AddScoped<QueryTroco>();
builder.Services.AddScoped<QueryPagamento>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapMethods(PagamentoPost.Template, PagamentoPost.Methods, PagamentoPost.Action);
app.MapMethods(PagamentoGet.Template, PagamentoGet.Methods, PagamentoGet.Action);
app.MapMethods(PagamentoPut.Template, PagamentoPut.Methods, PagamentoPut.Action);
app.MapMethods(PagamentoDelete.Template, PagamentoDelete.Methods, PagamentoDelete.Action);

app.MapMethods(TrocoGet.Template, TrocoGet.Methods, TrocoGet.Action);

app.Run();
