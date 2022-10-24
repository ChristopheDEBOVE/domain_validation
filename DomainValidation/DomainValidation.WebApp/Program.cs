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
    if (string.IsNullOrEmpty(userDto?.Name))
        return Results.BadRequest("Name of user is mandatory");
    
    var user = new User(userDto.Name);
    await subscribeUserService.Subscribe(user);
    return Results.Ok();
});




app.Run();