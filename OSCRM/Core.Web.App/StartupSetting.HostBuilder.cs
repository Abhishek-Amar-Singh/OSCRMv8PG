
using Amazon.SecretsManager.Model;
using Amazon.SecretsManager;
using Amazon;
using System.Text.Json;

public static partial class StartupSetting
{
    public static IHostBuilder ConfigureHostBuilderServices(this IHostBuilder hostBuilder)
    {
        AddAWSSecretsToConfiguration(hostBuilder);

        return hostBuilder;
    }

    private static void AddAWSSecretsToConfiguration(IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureAppConfiguration((hostingContext, config) =>
        {
            var secretName = config.Build()["AWSSecretManager:SecretName"];
            var accessKeyID = config.Build()["AWSSecretManager:AccessKeyID"];
            var secretAccessKey = config.Build()["AWSSecretManager:SecretAccessKey"];
            RegionEndpoint region = RegionEndpoint.GetBySystemName(config.Build()["AWS_Region"]);

            GetSecretValueResponse secret;
            AmazonSecretsManagerClient secretsManager;
            if (accessKeyID is null || secretAccessKey is null)
            {
                secretsManager = new AmazonSecretsManagerClient(region);
            }
            else
            {
                secretsManager = new AmazonSecretsManagerClient(accessKeyID, secretAccessKey, region);
            }

            secret = secretsManager.GetSecretValueAsync(new GetSecretValueRequest
            {
                SecretId = secretName
            }).Result;

            var connectionStrings = JsonSerializer.Deserialize<Dictionary<string, string>>(secret.SecretString);
            config.AddInMemoryCollection(connectionStrings!);
        });
    }
}

#region A

//builder.Host.ConfigureAppConfiguration((config) =>
//{
//    var secretName = config.Build()["AWSSecretManager:SecretName"];
//    var keyId = config.Build()["AWSSecretManager:AccessKeyID"];
//    var accessKey = config.Build()["AWSSecretManager:SecretAccessKey"];
//    RegionEndpoint region = RegionEndpoint.GetBySystemName(config.Build()["AWS_Region"]);
//    GetSecretValueResponse secret;
//    if (keyId is null || accessKey is null)
//    {
//        var secretsManager = new AmazonSecretsManagerClient(region);
//        secret = secretsManager.GetSecretValueAsync(new GetSecretValueRequest
//        {
//            SecretId = secretName,
//        }).Result;
//    }
//    else
//    {
//        var secretsManager = new AmazonSecretsManagerClient(keyId, accessKey, region);
//        secret = secretsManager.GetSecretValueAsync(new GetSecretValueRequest
//        {
//            SecretId = secretName,
//        }).Result;
//    }
//    var connectionStrings = JsonSerializer.Deserialize<Dictionary<string, string>>(secret.SecretString);
//    config.AddInMemoryCollection(connectionStrings);
//});

#endregion

#region B

//builder.Host.ConfigureAppConfiguration((h, c) =>
//{
//    c = AddAWSSecretsToConfiguration(c);
//});


//static IConfigurationBuilder AddAWSSecretsToConfiguration(IConfigurationBuilder config)
//{
//    var secretName = config.Build()["AWSSecretManager:SecretName"];
//    var keyId = config.Build()["AWSSecretManager:AccessKeyID"];
//    var accessKey = config.Build()["AWSSecretManager:SecretAccessKey"];
//    RegionEndpoint region = RegionEndpoint.GetBySystemName(config.Build()["AWS_Region"]);

//    var client = new AmazonSecretsManagerClient(keyId, accessKey, region);

//    var request = new GetSecretValueRequest
//    {
//        SecretId = secretName,
//        VersionStage = "AWSCURRENT" // Retrieve the current version of the secret
//    };

//    var response = client.GetSecretValueAsync(request).GetAwaiter().GetResult();

//    if (response.SecretString != null)
//    {
//        var secretString = response.SecretString;
//        config.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(secretString)));
//    }
//    else
//    {
//        // Handle binary secrets if needed
//        // var secretBinary = response.SecretBinary;
//    }

//    return config;
//}

#endregion

#region C

//private static void AddAWSSecretManagerServices(ConfigureHostBuilder host)
//{
//    host.ConfigureAppConfiguration(async config =>
//    {
//        var secretName = config.Build()["AWSSecretManager:SecretName"];
//        var keyId = config.Build()["AWSSecretManager:AccessKeyID"];
//        var accessKey = config.Build()["AWSSecretManager:SecretAccessKey"];
//        RegionEndpoint region = RegionEndpoint.GetBySystemName(config.Build()["AWS_Region"]);
//        GetSecretValueResponse secret;
//        if (keyId == null || accessKey == null)
//        {
//            var secretsManager = new AmazonSecretsManagerClient(region);
//            secret = await secretsManager.GetSecretValueAsync(new GetSecretValueRequest
//            {
//                SecretId = secretName,
//            });
//        }
//        else
//        {
//            var secretsManager = new AmazonSecretsManagerClient(keyId, accessKey, region);
//            secret = await secretsManager.GetSecretValueAsync(new GetSecretValueRequest
//            {
//                SecretId = secretName,
//            });
//        }
//        var connectionStrings = JsonSerializer.Deserialize<IDictionary<string, string>>(secret.SecretString);
//        config.AddInMemoryCollection(connectionStrings);
//    });
//}
#endregion