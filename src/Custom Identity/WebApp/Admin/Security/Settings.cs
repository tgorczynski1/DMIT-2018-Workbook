using System;
using System.Collections.Generic;
using System.Configuration;
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

        public static IEnumerable<string> DefaultSecurityRoles => new List<string> { AdminRole, UserRole };
        #endregion

        #region Startup Roles
        public static string AdminUserName => ConfigurationManager.AppSettings["adminUserName"];
        public static string AdminPassword => ConfigurationManager.AppSettings["adminPassword"];
        public static string AdminEmail => ConfigurationManager.AppSettings["adminEmail"];
        public static string TempPassword => ConfigurationManager.AppSettings["temporaryUserPassword"];

        #endregion
    }
}