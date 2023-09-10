
using Challenge.Movies.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

//Reset database 
await app.ResetDatabaseAsync();

app.Run();
