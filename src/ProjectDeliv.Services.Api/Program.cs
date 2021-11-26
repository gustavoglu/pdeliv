using ProjectDeliv.Domain.Interfaces;
using ProjectDeliv.Infra.Data.Contexts;
using ProjectDeliv.Infra.Data.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(
    opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    ); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextSQL>();
builder.Services.AddScoped<IProdutoGrupoRepositorio, ProdutoGrupoRepositorio>();
builder.Services.AddScoped<IProdutoClassRepositorio, ProdutoClassRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
