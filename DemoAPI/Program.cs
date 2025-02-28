using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//var myEmployeePolicy = "_MyEmployeePolicy";
//var myOtherPolicy = "_MyOtherPolicy";

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: myEmployeePolicy,
//        policy => {
//            policy.WithOrigins("http://localhost:3000").AllowAnyMethod()
//            .WithHeaders(HeaderNames.ContentType,"custom-header");
//        });

//    options.AddPolicy(name: myOtherPolicy,
//        policy => {
//            policy.WithOrigins("http://localhost:3000").WithMethods("GET","POST");
//        });
//    //options.AddDefaultPolicy(policy => {
//    //    policy.WithOrigins("http://localhost:3000");
//    //});
//});

builder.Services.AddControllers(option =>
{
    option.RespectBrowserAcceptHeader = true;
}).AddXmlSerializerFormatters();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

//app.UseCors();

//app.UseEndpoints(endpoints => {  

//    endpoints.MapGet("/api/Employees")
//});    
app.MapControllers();

app.Run();
