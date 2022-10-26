using Application;
using Domain;
using DomainValidation.WebApp;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ISubscribeUserService, SubscribeUserService>();
var app = builder.Build();


app.MapPut("/user", 
async (UserDto? userDto,
             ISubscribeUserService subscribeUserService) =>
{
    var result = User.Create(userDto?.Name);
    if (result.IsFailure)
        return Results.BadRequest(result.Error);
        
    await subscribeUserService.Subscribe(result.Value);
    return Results.Ok();
});

// intro ,  la première video d'une série qui va parler de la validation en C# asp.net core





app.Run();