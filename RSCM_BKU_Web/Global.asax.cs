using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;
using System.Configuration;
using System.Collections;

using EntitySpaces.Loader;


namespace RSCM_BKU_Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            EntitySpaces.Interfaces.esProviderFactory.Factory = new esDataProviderFactory();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected static void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected static void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected static void Application_Error(object sender, EventArgs e)
        {

        }

        protected static void Session_End(object sender, EventArgs e)
        {

        }

        protected static void Application_End(object sender, EventArgs e)
        {

        }
    }
}