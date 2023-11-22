var builder = WebApplication.CreateBuilder(args);
builder.Host.AddSerilog("http://192.168.1.1", "", "");
var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddCustomApiVersioning()
    .AddMediatr(typeof(UpdateTodoItemCommand).Assembly)
    @*#if (EnableSwaggerSupport)
    .AddSwagger("/api/v1/user/Token")
    #endif*@
    .AddControllers();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    @*#if (EnableSwaggerSupport)
    app.UseSwaggerAndUI();
    #endif*@
}

app.UseHttpsRedirection();
app.UseCustomExceptionHandler();
app.MapControllers();
app.Run();
