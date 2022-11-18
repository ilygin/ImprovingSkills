var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run(HandleRequest);
app.Run();
async Task HandleRequest(HttpContext context)
{
    var acceptHeaderValue = context.Request.Headers.Accept;
    string path = context.Request.Path;
    await context.Response.WriteAsync($"Accept: {acceptHeaderValue}");
    await context.Response.WriteAsync($"\n Path: {path}");
}