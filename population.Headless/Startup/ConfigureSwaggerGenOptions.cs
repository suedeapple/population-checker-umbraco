using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;

using Swashbuckle.AspNetCore.SwaggerGen;
using Umbraco.Cms.Api.Common.OpenApi;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Web.Common.ApplicationBuilder;

namespace population.Headless.Startup;

internal class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {


    }
}

public class SwaggerRouteProductionPipelineFilter() : SwaggerRouteTemplatePipelineFilter("umbraco")
{
    /// <summary>
    /// This is how you configure Swagger to be available always.
    /// Please note that this is NOT recommended.
    /// </summary>
    protected override bool SwaggerIsEnabled(IApplicationBuilder applicationBuilder) => true;
}

public static class MyConfigureSwaggerRouteUmbracoBuilderExtensions
{
    public static IUmbracoBuilder ConfigureProductionSwaggerRoute(this IUmbracoBuilder builder)
    {
        builder.Services.Configure<UmbracoPipelineOptions>(options =>
        {
            var filtersToRemove = options.PipelineFilters
                .Where(filter => filter is SwaggerRouteTemplatePipelineFilter)
                .ToList();

            foreach (var filter in filtersToRemove)
            {
                options.PipelineFilters.Remove(filter);
            }

            options.AddFilter(new SwaggerRouteProductionPipelineFilter());
        });
        return builder;
    }
}




