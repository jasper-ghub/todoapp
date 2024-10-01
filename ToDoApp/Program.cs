using ToDoApp.Components;
using Microsoft.AspNetCore.Server.Kestrel.Core;

const int defaultPort = 5000;

// Configure the builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(GetPort(builder.Configuration));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
return;

int GetPort(IConfiguration configuration)
{
    var portString = Environment.GetEnvironmentVariable("PORT") ?? configuration.GetValue<string>("KestrelPort");
    return int.TryParse(portString, out var port) ? port : defaultPort;
}