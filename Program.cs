var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "¡Hola desde mi contenedor Docker en Debian (WSL)!");

app.Run();
