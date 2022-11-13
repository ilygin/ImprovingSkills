var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run(HandleRequest);
app.Run();
async Task HandleRequest(HttpContext context)
{
    var response = context.Response;
    response.ContentType= "text/html";
    await context.Response.WriteAsync("<h2>Hello METANIT.COM</h2>");
}