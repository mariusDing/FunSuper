using FunSuper.Server.Extensions;
using FunSuper.Server.Infrastructure.Super;

var builder = WebApplication.CreateBuilder(args);

// Register Controller
builder.Services.AddControllers();

// Register Service
builder.Services.RegisterCommonServices();

// Register Db Context
builder.Services.RegisterDbContext(builder.Configuration, builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();

    // Inmemory DB requires Database ensure created
    using var scope = app.Services.CreateScope();
    scope.ServiceProvider.GetRequiredService<SuperContext>().Database.EnsureCreated(); 
    
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapControllers();
app.MapFallbackToFile("index.html");

// Add encodings for ExcelDataReader to work under .Net Core
// https://github.com/ExcelDataReader/ExcelDataReader/blob/develop/README.md#important-note-on-net-core
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

app.Run();
