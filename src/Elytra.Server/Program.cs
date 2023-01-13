using Elytra.App;
using Elytra.Database;
using Elytra.Server.Hubs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Response Compression Middleware


//Enable SignalR
builder.Services.AddSignalR(o =>
{    
    o.EnableDetailedErrors = true;
});

builder.Services.AddDbContext<ElytraContext>(options =>
{
    options.UseSqlite("Data Source = ElytraDatabase.db");
});

builder.Services.AddScoped<IMessageService, MessageService>();

var app = builder.Build();

using (IServiceScope scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ElytraContext>();
    context.Database.EnsureCreated();
}


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
