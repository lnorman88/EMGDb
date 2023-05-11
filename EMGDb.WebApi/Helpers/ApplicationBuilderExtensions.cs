using System.Diagnostics.CodeAnalysis;

namespace EMGDb.WebApi.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureSwagger(this WebApplication application)
        {
            //IApiVersionDescriptionProvider provider = application.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            //if (application.Environment.IsDevelopment())
            //{
            //    application.UseSwagger();
            //    application.UseSwaggerUI(options =>
            //    {
            //        foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
            //            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
            //                description.GroupName.ToUpperInvariant());
            //    });
            //}
        }
    }
}
