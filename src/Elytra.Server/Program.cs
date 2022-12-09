using Elytra.Server.Hubs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Response Compression Middleware


//Enable SignalR
builder.Services.AddSignalR(o =>
{    
    o.EnableDetailedErrors = true;
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    // Might cause issues on local development, only use in prod.
    app.UseHttpsRedirection();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

//Unfamiliar with what this does, maybe we can use it for hubs?
app.MapBlazorHub();

app.MapFallbackToPage("/_Host");

//ChatHub
app.MapHub<ChatHub>("/chat");

app.Run();
