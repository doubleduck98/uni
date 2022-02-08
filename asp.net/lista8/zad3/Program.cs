var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Write();
app.MapGet("/", () => {});
app.Run();

public class Config
{
    private readonly RequestDelegate _next;

    public Config(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IConfiguration config)
    {
        await context.Response.WriteAsync(config["AppSettings:foo"] + "\n");
        await context.Response.WriteAsync(config["AppSettings:hehe"] + "\n");
        await context.Response.WriteAsync("lista: " + config["AppSettings:lista"] + "\n");
    }
}

public static class WriteConfig
{
    public static void Write(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<Config>();
    }
}