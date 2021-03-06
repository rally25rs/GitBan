﻿using System.Web.Mvc;

namespace GitBan
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new Infrastructure.RequireHttpsAttribute());
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new SetCurrentUserAttribute());
        }
    }
}