using AuthenticationLayer.DAL.Context;
using AuthenticationLayer.DAL.Identity;
using AuthenticationLayer.DAL.Interfaces;
using Entities.IdentityEnties;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationLayer.DAL.Repositories
{
    public class IdentityBlogAuth : IBlogAuth
    {
        private readonly AuthenticationContext _db;

        private readonly ApplicationUserManager userManager;
        private readonly ApplicationRoleManager roleManager;
        private readonly IClientManager clientManager;

        public IdentityBlogAuth(string connectionString)
        {
            _db = new AuthenticationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
            clientManager = new ClientManager(_db);
        }

        public ApplicationUserManager UserManager => userManager;

        public IClientManager ClientManager => clientManager;

        public ApplicationRoleManager RoleManager => roleManager;

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
