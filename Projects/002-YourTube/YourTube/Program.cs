using YourTube.Core.IServices;
using YourTube.Core.Models;
using YourTube.Core.Services;

var builder = WebApplication.CreateBuilder(args);

 builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<YouTubeKeys>(builder.Configuration.GetSection("YouTube"));
builder.Services.AddScoped<IYouTubeClientService, YouTubeClientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
