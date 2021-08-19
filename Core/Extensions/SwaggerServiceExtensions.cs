using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace Core.Extensions
{
    public static class SwaggerServiceExtensions
    {
        static string title = "Api Başlangıç Paketi";

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("CoreSwagger", new OpenApiInfo
                {
                    Title = title,
                    Version = "2.0.0",
                    Description = "API Service 2021 by Faruk Kaya",
                    Contact = new OpenApiContact()
                    {
                        Name = "Swagger Implementation Faruk Kaya",
                        Url = new Uri("https://github.com/farukkaya"),
                        Email = "farukkaya03@hotmail.com.tr"
                    },
                    TermsOfService = new Uri("http://swagger.io/terms/")
                });

                var securityScheme = new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Lütfen alana 'Bearer' kelimesini ve ardından bir boşluk ve JWT değerini girin.\r\n Örnek: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "bearer"

                };
                options.AddSecurityDefinition("Bearer", securityScheme);
                var securityRequirement = new OpenApiSecurityRequirement {{securityScheme, new string[] { }}};
                options.AddSecurityRequirement(securityRequirement);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", title);
                c.DocumentTitle = title;
                c.DocExpansion(DocExpansion.None);
            });

            return app;
        }
    }
}
