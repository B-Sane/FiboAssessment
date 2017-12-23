using System.Web.Http;
using Swashbuckle.Application;
using System;
using System.Configuration;


namespace FiboApp.Configuration
{
    /// <summary>
    /// SwaggerConfig
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            if (ConfigurationManager.AppSettings["EnableSwagger"] != null &&
                Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSwagger"]))
            {
                var thisAssembly = typeof(SwaggerConfig).Assembly;

                config
                    .EnableSwagger(c =>
                        {
                            c.SingleApiVersion("v1", "FiboApp")
                                .Description("Fibonacci API")
                                .TermsOfService("ITG Assessment");

                            c.PrettyPrint();
                            c.IncludeXmlComments(GetXmlCommentsPath());

                        })
                    .EnableSwaggerUi(c =>
                        {
                            c.DocExpansion(DocExpansion.List);
                        });
            }
        }

        private static string GetXmlCommentsPath()
        {
            return $@"{AppDomain.CurrentDomain.BaseDirectory}\bin\FiboApp.XML";
        }
    }
}
