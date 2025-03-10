using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Net.Http.Headers;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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


builder.Services.AddAuthentication(options => { 
    options.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true, //jwt
        ValidateAudience = true, // user which is connecting
        ValidateLifetime= true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience= builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
    };
});






var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthentication();


app.UseAuthorization();

//app.UseCors();

//app.UseEndpoints(endpoints => {  

//    endpoints.MapGet("/api/Employees")
//});    
app.MapControllers();

app.Run();
