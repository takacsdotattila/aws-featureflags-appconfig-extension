using Extensions.AwsFeatureFlags;
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// The feature we want to use is this:
// https://docs.microsoft.com/en-us/azure/azure-app-configuration/use-feature-flags-dotnet-core?tabs=core5x
// And we want to use with aws AppConfig.


//Configure the AWS FeatureFlags by adding it to configurations

builder.Configuration.AddAmazonFeatureFlags(c =>
{
    //these can be the id and the name as well...
    c.ApplicationId = "Your_ApplicationID_orName"; 
    c.EnvironmentId = "Your_EnvironmentId_orName";
    c.ConfigurationProfileId = "Your_ConfigProfileId_orName";
    c.DataPollFrequency = TimeSpan.FromSeconds(30);
    c.ConfigSectionNaming = "CustomFeatureFlags"; //this is what you should use when u add the feature management service (next line), also can be empty.
});

builder.Services.AddFeatureManagement(builder.Configuration.GetSection("CustomFeatureFlags"));

// To see how to use the feature management check docs.microsoft... (link above)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
