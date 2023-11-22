var builder = WebApplication.CreateBuilder(args);
builder.Host.AddSerilog("http://192.168.1.1", "", "");
var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddCustomApiVersioning()
    .AddMediatr(typeof(UpdateTodoItemCommand).Assembly)
    .AddSwagger("/api/v1/user/Token")
    .AddControllers();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerAndUI();
}

app.UseHttpsRedirection();
app.UseCustomExceptionHandler();
app.MapControllers();
app.Run();
