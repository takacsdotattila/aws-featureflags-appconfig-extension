# aws-featureflags-appconfig-extension
Aws AppConfig FeatureFlag config data provider for asp.net (core) projects

This example project can be a temporary solution for u if u want to use the feature flags from aws in asp.net core. I am sure someone will implement the official package from mirosoft or aws, its just a matter of time, until then feel free to fork / improove / create a nugetpackage.

This project inspired by:

[Microsoft Feature Flags Docs](https://docs.microsoft.com/en-us/azure/azure-app-configuration/use-feature-flags-dotnet-core)

[AWS Feature Flags](https://aws.amazon.com/blogs/mt/using-aws-appconfig-feature-flags/)

[Azure Config Extension](https://github.com/Azure/AppConfiguration-DotnetProvider)

I know this is not complete implementation, so i am open to feedback. No tests, no exceptionhandling, no logging included.

The following example shows how to configure in the program.cs. U can also use the appsettings.json, but for that u have to build the builder here and read the config from there.
This is how u configure the feature management with aws:

```c#
//Configure the AWS FeatureFlags by adding it to configurations

builder.Configuration.AddAmazonFeatureFlags(c =>
{
    //these can be the id and the name as well...
    c.ApplicationId = "Your_ApplicationID_orName"; 
    c.EnvironmentId = "Your_EnvironmentId_orName";
    c.ConfigurationProfileId = "Your_ConfigProfileId_orName";
    c.DataPollFrequency = TimeSpan.FromSeconds(30);
    c.ConfigSectionNaming = "CustomFeatureFlags"; //this is what you should use when u add the feature management service (next line), also can be empty.
}
                                          );
builder.Services.AddFeatureManagement(builder.Configuration.GetSection("CustomFeatureFlags"));
```

Note: <b>AddAmazonFeatureFlags</b> has an overload where u can supply the <b>AmazonAppConfigDataClient</b> if needed. 