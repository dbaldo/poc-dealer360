using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Dealer360WebApi.Models;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace Dealer360WebApi
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Serviços e configuração da API da Web

			// Rotas da API da Web
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			// New code:
			ODataModelBuilder builder = new ODataConventionModelBuilder();
			builder.EntitySet<ProductSales>("ProductSales");
			config.MapODataServiceRoute(
				routeName: "ODataRoute",
				routePrefix: null,
				model: builder.GetEdmModel());
		}
	}
}
