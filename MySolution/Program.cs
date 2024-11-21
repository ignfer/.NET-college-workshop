using MySolution.Components;
using MySolution.Data;
using MySolution.Repositories;
using MySolution.Services;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<QueueService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<DeskService>();

builder.Services.AddScoped<QueueRepository>();
builder.Services.AddScoped<AppointmentRepository>();
builder.Services.AddScoped<DeskRepository>();

// Add Services (ver si se saca)
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

    // Run test cases
    //RunTestCases(scope.ServiceProvider);
    RunSetup(scope.ServiceProvider);
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


void RunTestCases(IServiceProvider services)
{
    var queueService = services.GetRequiredService<QueueService>();
    var appointmentService = services.GetRequiredService<AppointmentService>();
    var deskService = services.GetRequiredService<DeskService>();

    Console.WriteLine("=== Test Cases ===");

    Console.WriteLine("Adding Puesto 1");
    deskService.AddDeskIfNotExists("Puesto 1");

    Console.WriteLine("Adding Puesto 2");
    deskService.AddDeskIfNotExists("Puesto 2");

	// Add to QUEUE
	Console.WriteLine("Adding to QUEUE: 123456");
    queueService.AddUserToQueue("123456");
    Thread.Sleep(1000);
    Console.WriteLine("Adding to QUEUE: 222222");
    queueService.AddUserToQueue("222222");
    Thread.Sleep(1000);


    // Visualize Queue
    Console.WriteLine("Queue Visualization 1:");
    var queue1 = queueService.GetQueue();
    foreach (var item in queue1)
    {
        Console.WriteLine($"Id: {item.Id}, CI: {item.CINumber}, Status: {item.Status}, Date: {item.Date}");
    }

    Console.WriteLine("Get next in Queue from Puesto 1");
    appointmentService.GetNextInQueue("Puesto 1");

    Console.WriteLine("Adding to QUEUE: 333333");
    queueService.AddUserToQueue("333333");

    Console.WriteLine("Queue Visualization 2:");
    var queue2 = queueService.GetQueue();
    foreach (var item in queue2)
    {
        Console.WriteLine($"Id: {item.Id}, CI: {item.CINumber}, Status: {item.Status}, Date: {item.Date}");
    }

    // Get Last Called Appointment
    Console.WriteLine("Last Called Appointment 1:");
    var lastAppointment = appointmentService.GetLastCalledAppointment();
    Console.WriteLine($"Appointment ID: {lastAppointment.Id}, CI Number: {lastAppointment.Queue.CINumber}");

    // Ending appointment with Id 1
    Console.WriteLine($"Ending Last Called Appointment with Id: {lastAppointment.Id}");
    appointmentService.EndAppointment(lastAppointment.Id, "Puesto 1");

    // Next in Queue should be called on previous line, checking now
    Console.WriteLine("Last Called Appointment 2:");
    lastAppointment = appointmentService.GetLastCalledAppointment();
    Console.WriteLine(lastAppointment != null
        ? $"Appointment ID: {lastAppointment.Id}, CI Number: {lastAppointment.Queue.CINumber}"
        : "No appointments found.");

    Console.WriteLine("Queue Visualization 3:");
    var queue3 = queueService.GetQueue();
    foreach (var item in queue3)
    {
        Console.WriteLine($"Id: {item.Id}, CI: {item.CINumber}, Status: {item.Status}, Date: {item.Date}");
    }

    Console.WriteLine("Appointment Visualization 1:");
    var appointments1 = appointmentService.GetAppointments();
    foreach (var item in appointments1)
    {
        Console.WriteLine($"Id: {item.Id}, CI: {item.Queue.CINumber}, Start Date: {item.StartDate}, End Date: {item.EndDate}");
    }

    // Appointments in Waiting
    var waitingCount = queueService.GetWaitingQueue();
    Console.WriteLine($"Queue in Waiting: {waitingCount}");

    // Average Waiting Time
    var averageWaitingTime = appointmentService.GetAverageWaitingTime();
    Console.WriteLine($"Average Waiting Time: {averageWaitingTime} minutes");

    // Appointment Stats
    var stats = appointmentService.GetAppointmentStats();
    Console.WriteLine("Appointment Stats:");
    Console.WriteLine($"Last Hour: {stats.LastHour}, Last Week: {stats.LastWeek}, Last Month: {stats.LastMonth}");
}

void RunSetup(IServiceProvider services)
{
	var queueService = services.GetRequiredService<QueueService>();
	var appointmentService = services.GetRequiredService<AppointmentService>();
	var deskService = services.GetRequiredService<DeskService>();

	Console.WriteLine("=== Setup ===");

	Console.WriteLine("Adding Puesto 1");
	deskService.AddDeskIfNotExists("Puesto 1");

	Console.WriteLine("Adding Puesto 2");
	deskService.AddDeskIfNotExists("Puesto 2");

	Console.WriteLine("Adding Puesto 2");
	deskService.AddDeskIfNotExists("Puesto 3");
}