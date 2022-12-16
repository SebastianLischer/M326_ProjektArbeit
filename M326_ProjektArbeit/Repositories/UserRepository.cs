using M326_ProjektArbeit.Model;
using M326_ProjektArbeit.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Principal;
using System.Threading;

namespace M326_ProjektArbeit.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }
        public static bool DbCheckIfAdmin()
        {
            IPrincipal threadPrincipal = Thread.CurrentPrincipal;
            using (var ctx = new DatabaseContext())
            {
                //var students = ctx.Users.ToList<User>();
                var user = ctx.Users
                    .Where(s => s.Username == threadPrincipal.Identity.Name)
                    .FirstOrDefault<UserModel>();

                if (user != null)
                {
                    return user.IsAdmin;
                }
                else
                {
                    return false;
                }
            }
         
        }
        public bool AuthenticateUser(NetworkCredential credential)
        {
            using (var ctx = new DatabaseContext())
            {
                //var students = ctx.Users.ToList<User>();
                var user = ctx.Users
                    .Where(s => s.Username == credential.UserName && s.Password == credential.Password)
                    .FirstOrDefault<UserModel>();

                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }
        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }
        public UserModel GetByUsername(string username)
        {
            using (var ctx = new DatabaseContext())
            {
                var user = ctx.Users
                    .Where(s => s.Username == username)
                    .FirstOrDefault<UserModel>();
                return user;
            }
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
