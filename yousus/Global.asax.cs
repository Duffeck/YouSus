﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using yousus.Models;
using yousus.Models.DTO;

namespace yousus
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //var config = this.ConfigurarMapper();
        }

        /*
        protected MapperConfiguration ConfigurarMapper()
        {
            //return new MapperConfiguration(cfg => cfg.CreateMap<Categoria, CategoriaDTO>());
            Mapper.Map<Categoria, CategoriaDTO>();
        }*/
    }
}
