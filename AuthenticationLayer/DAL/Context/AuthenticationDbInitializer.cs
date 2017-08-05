using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationLayer.DAL.Context
{
    /// <summary>
    /// Drops database on each restart of the server
    /// Should be changed/removed before deployment
    /// </summary>
    class AuthenticationDbInitializer : DropCreateDatabaseAlways<AuthenticationContext>
    {
        protected override void Seed(AuthenticationContext db)
        {
        }
    }
}
