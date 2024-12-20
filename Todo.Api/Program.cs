using Todo.Api.Common.Api;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
// builder.Services.AddDbContext<AppDbContext>(options =>
// {
//     options.UseSqlServer(ConnectionString);
// });
builder.AddConfiguration();
builder.AddDataContexts();

var app = builder.Build();


// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.Run();
