using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Admin.Security
{
    public class Settings
    {
        #region Security Roles
        public static string AdminRole => ConfigurationManager.AppSettings["adminRole"];
        /* The above is the same as typing:
         * public static string AdminRole
         * {
         *      get { return ConfigurationManager.AppSettings["adminRole"];
         * }
         */
        public static string UserRole => ConfigurationManager.AppSettings["userRole"];
        #endregion

        #region Startup Roles
        #endregion
    }
}