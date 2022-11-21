var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
/*
app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";

    if (context.Request.Path == "/postuser")
    {
        var form = context.Request.Form;
        string? name = form["name"];
        string[]? languages = form["languages"];
        string[]? selectLanguages = form["selectLanguages"];
        string? age = form["age"];
        await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p></div><br>");
        if(selectLanguages?.Length>0)
        {
            foreach (string? leng in selectLanguages)
            {
                await context.Response.WriteAsync($"{leng}  ");
            }
        }
        
    }
    else
    {
        await context.Response.SendFileAsync("html/index.html");
    }
});
*/

//Переадресация
app.Run(async (context) =>
{
    if (context.Request.Path == "/MyFirstPage")
    {
        context.Response.Redirect("/NewPage");

    }
    else if (context.Request.Path == "/NewPage")
    {
        await context.Response.WriteAsync("NewPage");
    }
    else
    {
        await context.Response.WriteAsync("MainPage");
    }
});
app.Run();