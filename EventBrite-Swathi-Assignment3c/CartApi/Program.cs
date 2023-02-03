using System.IdentityModel.Tokens.Jwt;
using CartApi.Data;
using CartApi.Messaging.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;


var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddTransient<ICartRepository, RedisCartRepository>();
builder.Services.AddSingleton<ConnectionMultiplexer>(cm =>
{
    var config = ConfigurationOptions.Parse(
        configuration["ConnectionString"], true);
    config.ResolveDns = true;
    config.AbortOnConnectFail = true;
    return ConnectionMultiplexer.Connect(config);
});

// prevent from mapping "sub" claim to nameidentifier.
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

var identityUrl = configuration["IdentityUrl"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = identityUrl.ToString();
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = false,
        ValidateIssuer = false,
        ValidateAudience = false
    };
    options.Audience = "basket";
});

builder.Services.AddMassTransit(cfg =>
{
    cfg.AddConsumer<OrderCompletedEventConsumer>();
    cfg.AddBus(provider =>
    {
        return Bus.Factory.CreateUsingRabbitMq(rmq =>
        {
            rmq.Host(new Uri("rabbitmq://rabbitmq"), "/", h =>
            {
                h.Username("guest");
                h.Password("guest");
            });
            rmq.ReceiveEndpoint("EventsCartOct2022", e =>
            {
                e.ConfigureConsumer<OrderCompletedEventConsumer>(provider);

            });
        });

    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
