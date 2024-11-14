using MySolution.Components;
using MySolution.Data;
using MySolution.Services;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>();
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Add Office Service
builder.Services.AddSingleton<OfficeService>();

// Add Razor components
builder.Services.AddRadzenComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

// Automatically create the database at startup if it doesn't exist.
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    Console.WriteLine("Attempting to ensure the database is created...");
    dbContext.Database.EnsureCreated();
    Console.WriteLine("Database created or already exists.");
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
