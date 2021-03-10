using KaizenTechCaseStudy.Dal.Abstract.UserService;
using KaizenTechCaseStudy.Dal.Manager.EntityFramework;
using KaizenTechCaseStudy.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KaizenTechCaseStudy.Dal.Concrete.UserService
{
    public class UserService : IUserService
    {
        public bool AddNewUser(Users user)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    //TODO Loglama
                    return false;
                }
            }
        }

        public bool DeleteUser(int userId)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    var user = context.Users.FirstOrDefault(u => u.Id == userId);
                    if(user != null)
                    {
                        context.Users.Remove(user);
                        context.SaveChanges();
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    //TODO Loglama
                    return false;
                }
            }
        }

        public Users GetUserById(int userId)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    var user = context.Users.FirstOrDefault(u => u.Id == userId);
                    return user;
                }
                catch (Exception ex)
                {
                    //TODO Loglama
                    return null;
                }
            }
        }

        public List<Users> GetUserList()
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    var userList = context.Users.Where(u => !u.Deleted).ToList();
                    return userList;
                }
                catch (Exception ex)
                {
                    //TODO Loglama
                    return null;
                }
            }
        }

        public bool UpdateUser(Users user)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    var foundUser = context.Users.Where(u => u.Id == user.Id).FirstOrDefault();
                    if(foundUser != null)
                    {
                        foundUser = user;
                        context.Users.Update(foundUser);
                        context.SaveChanges();
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    //TODO Loglama
                    return false;
                }
            }
        }
    }
}
