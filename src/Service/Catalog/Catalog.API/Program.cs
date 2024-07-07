var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR( config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
//var connectionString = builder.Configuration["ConnectionString:Database"];
//if (string.IsNullOrEmpty(connectionString))
//{
//    throw new ArgumentNullException("Database", "Database connection string is missing in the configuration.");
//}

//builder.Services.AddMarten(opts =>
//{
//    opts.Connection(connectionString);
//}).UseLightweightSessions();


var app = builder.Build();
app.MapCarter();

app.Run();
 