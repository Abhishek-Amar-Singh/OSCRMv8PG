
using Newtonsoft.Json;
using JsonStringEnumConverter = Newtonsoft.Json.Converters.StringEnumConverter;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Data.Warehouse.PostgreSQL.OSCRM.DAL;
using Data.Warehouse.PostgreSQL.Rehearsal.DAL;
using Data.Warehouse.PostgreSQL.LakeMaster.DAL;
using Asp.Versioning;
using OSCRMV1Services = OSCRM.Web.Api.Services.v1;
using OSCRMStorages = OSCRM.Web.Api.Storages;
using RehearsalV1Services = Rehearsal.Web.Api.Services.v1;


public static partial class StartupSetting
{
    public static IServiceCollection AddPersistenceServices(
            this IServiceCollection services,
            IConfiguration configuration)
    {
        AddNewtonSoftJson(services);

        var connection = configuration.GetConnectionString("OSCRMDbConnection");

        AddSwagger(services);

        AddPostgreDBContexts(services, configuration);

        AddFoundationServices(services);

        AddRepositories(services);

        AddResponseCompression(services);

        AddApiVersioning(services);

        return services;
    }


    private static void AddNewtonSoftJson(IServiceCollection services)
    {
        //--AddNewtonSoftJson(services)
        /*
        If AddNewtonSoftJson services are not added the we'll get an error
        Some services are not able to be constructed (Error while validating the service descriptor 'ServiceType: Microsoft.AspNetCore.Identity.DataProtectorTokenProvider`1[OSCRM.Web.Api.Models.Users.User] Lifetime: Transient 
        When an exception comes, it will give you error 'MethodBase'(every thing runs fine but this error will come on the return statement in the catch block),
        so, to resolve this we add this so that we can get proper exception json response
         */
        services.AddMvc().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            options.SerializerSettings.Converters.Add(new JsonStringEnumConverter());
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        });
    }

    private static void AddSwagger(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "OSCRM.Web.Api",
                Description = "OSCRM API"
            });
            options.SwaggerDoc("v2", new OpenApiInfo
            {
                Version = "v2",
                Title = "OSCRM.Web.Api",
                Description = "OSCRM API"
            });
            options.ResolveConflictingActions(x => x.First());
        });
    }

    private static void AddPostgreDBContexts(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OSCRMDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("OSCRMDbConnection")));

        services.AddDbContext<RehearsalDbContext>(options => options
            .UseNpgsql(
                configuration.GetConnectionString("RehearsalDbConnection"),
                npgsqlOptionsAction: npgsqlOptions =>
                {
                    //--allow database connection resiliency
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorCodesToAdd: null
                    );
                    npgsqlOptions.MaxBatchSize(maxBatchSize: 42);
                }
            )
            .EnableDetailedErrors(true)
        );

        services.AddDbContext<LakeMasterDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("LakeMasterDbConnection")));
    }

    private static void AddFoundationServices(IServiceCollection services)
    {
        services.AddScoped<OSCRMV1Services.Customers.ICustomerService, OSCRMV1Services.Customers.CustomerService>();
        services.AddScoped<RehearsalV1Services.Eulers.IEulerService, RehearsalV1Services.Eulers.EulerService>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<OSCRMStorages.IStorageRepository, OSCRMStorages.StorageRepository>();
    }

    private static void AddResponseCompression(IServiceCollection services)
    {
        //--improves reponse times, especially for users with slower internet connections
        //--can improve overall user experience and performance of web applications
        //--common compression algorithms: gzip, brotli, and deflate
        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
        });
    }

    private static void AddApiVersioning(IServiceCollection services)
    {
        services.AddApiVersioning(o =>
        {
            o.AssumeDefaultVersionWhenUnspecified = true;
            o.DefaultApiVersion = new ApiVersion(1, 0);
            o.ReportApiVersions = true;
            o.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Version"));
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
    }
}
