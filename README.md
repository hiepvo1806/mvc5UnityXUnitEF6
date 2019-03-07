# mvc5UnityXUnitEF6
a boilder plate for mvc5 , ef 6 and unity ,with xUnit test
- add swagger
    1. install nuget swashbugg...
    2. Edit swaggerConfig.cs
        c.IncludeXmlComments(string.Format(@"{0}\bin\PresentationLayer.XML",
            System.AppDomain.CurrentDomain.BaseDirectory));
        c.DescribeAllEnumsAsStrings();
    3. Add WebApiConfig.cs
        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                // Web API configuration and services

                // Web API routes
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }
        }
    4. add a api controller and add comment like below
        /// <summary>  
        /// Get Company List  
        /// </summary>  
        /// <returns code="200"></returns>  
        [ResponseType(typeof(IEnumerable<string>))]
        [Route("api/Value")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    5. edit global.asax.cs
        {
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                GlobalConfiguration.Configure(WebApiConfig.Register); <---this
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
            }
        }   
    