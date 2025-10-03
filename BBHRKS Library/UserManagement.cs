using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JunX.NET8.MySQL;

namespace BBHRKS.UserManagement
{
    public static class UserManagement
    {
        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Determines whether a user with the specified username exists in the database.
        /// </summary>
        /// <param name="Username">The username to search for. Cannot be null or empty.</param>
        /// <param name="Execute">An instance of the MySQLExecute class used to execute the database query. Cannot be null.</param>
        /// <returns>true if a user with the specified username exists; otherwise, false.</returns>
        public static bool UserExists(string Username, MySQLExecute Execute)
        {
            Execute.CommandString = Construct.SelectCommand(
                Select: tbusers.UserID.ToString(),
                From: tbusers.tbusers.ToString(),
                Where: tbusers.Username.ToString() + "=@Username");
            Execute.ExecuteSelect(new ParametersMetadata("@Username", Username));
            return Execute.HasRows;
        }
        /// <summary>
        /// Generates a unique user key based on the specified username.
        /// </summary>
        /// <param name="Username">The username to use as the basis for generating the user key. Cannot be null.</param>
        /// <returns>A string representing the generated user key for the specified username.</returns>
        public static string GenerateUserKey(string Username)
        {
            return Username + Metadata.Metadata.User.Keys.BBHRKS.ToString();
        }
        #endregion
    }
}
