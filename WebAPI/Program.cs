using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using WebAPI;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// Add IUnitOfWork
builder.Services.AddSingleton<IUnitOfWork>((unitofwork) => new UnitOfWork(builder.Configuration.GetConnectionString("DbConnectionStringName")));
//Add Services
var assemblyService = AssemblyLoadContext.Default.LoadFromAssemblyPath(Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "Services.dll", SearchOption.AllDirectories).First());
builder.Services.Scan(scan => scan.FromAssemblies(new Assembly[] { assemblyService }).AddClasses().AsImplementedInterfaces().WithSingletonLifetime());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(a => a.AddProfile<AutoMapperProfile>());
builder.Services.AddResponseCaching();
//auth
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.IncludeErrorDetails = false;
    opt.SaveToken = true;
    opt.RequireHttpsMetadata = true;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
        ValidateLifetime = false,
        NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
        RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
    };
});
//jwthelp
builder.Services.AddSingleton<JwtHelper>();
//log4net
builder.Logging.AddProvider(new Log4netProvider("log4net.xml"));

builder.Services.AddCors(
    opt =>
    {
        opt.AddPolicy("CorsPolicy", policy =>
        {
            policy
             .WithOrigins("https://localhost:4200", "https://localhost")
                   .WithMethods("POST", "GET")
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
    }
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<JwtMiddleware>();
app.UseResponseCaching();
app.MapControllers();
app.Run();
