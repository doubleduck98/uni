var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache().AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
});

var app = builder.Build();

app.MapGet("/", (context) =>
{
    var cookie = context.Request.Cookies["ciastko"];
    if (string.IsNullOrEmpty(cookie))
    {
        cookie = "X";
        context.Response.Cookies.Append("ciastko", cookie);
    }
    else
    {
        context.Response.Cookies.Append("ciastko", cookie + "X");
    }
    return context.Response.WriteAsync(cookie);
});

app.Run();
