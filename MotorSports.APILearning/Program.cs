var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true);

builder.Services.AddProblemDetails(options => options.CustomizeProblemDetails = ctx =>
{
    ctx.ProblemDetails.Extensions.Add("additionalInfo", "AdditionalInfoExample");
    ctx.ProblemDetails.Extensions.Add("server", Environment.MachineName);
});

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

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
