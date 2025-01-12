
#region Configurations and Services
using LearningControllers.Data;

var builder = WebApplication.CreateBuilder(args);

//Add Controller Services; automatically configures a Scoped lifetime
builder.Services.AddControllers();

//Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Associate LearningDbContext with an SQL Server database using connectionString
builder.Services.AddSqlServer<LearningDbContext>(connectionString);

//Add Swagger services
builder.Services.AddSwaggerGen();


var app = builder.Build();
#endregion

#region Routing and Middleware

//If in a development enviornment create swagger endpoints and UI
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Set up routing for incoming HTTP request
app.UseRouting();

//Map controller actions to routes defined by [Route()] & [HttpX} attributes
app.MapControllers();

//Automagically update database if there are any new migrations
await app.MigrateDbAsync();

#endregion

app.Run();
