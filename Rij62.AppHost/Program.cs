using Aspire;
using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// Use a friendly ASCII-only resource name
builder.AddPostgres("rij62-db");

var app = builder.Build();

app.Run();