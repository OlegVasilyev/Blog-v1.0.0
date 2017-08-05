using AuthenticationLayer.DAL.Context;
using AuthenticationLayer.DAL.Interfaces;
using Entities.IdentityEnties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationLayer.DAL.Repositories
{
    class ClientManager : IClientManager
    {
        public AuthenticationContext Database { get; set; }

        public ClientManager(AuthenticationContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
