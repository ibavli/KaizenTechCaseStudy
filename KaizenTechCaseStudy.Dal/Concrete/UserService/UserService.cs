using KaizenTechCaseStudy.Dal.Abstract.UserService;
using KaizenTechCaseStudy.Dal.Manager.EntityFramework;
using KaizenTechCaseStudy.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaizenTechCaseStudy.Dal.Concrete.UserService
{
    //TODO Hepsini sp çevir

    public class UserService : IUserService
    {
        public bool AddNewUser(Users user, UserPassword userPassword)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    context.Users.Add(user);

                    userPassword.Salt = GenerateSalt();
                    var mixedPassword = MixPasswordAndSalt(password: userPassword.Password, salt: userPassword.Salt);
                    userPassword.Password = PasswordCrypto(mixedPassword: mixedPassword);

                    context.UserPassword.Add(userPassword);
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
                        user.Deleted = false;
                        context.Users.Update(user);
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

        public bool UpdateUser(Users user, UserPassword userPassword)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    var foundUser = context.Users.FirstOrDefault(u => u.Id == user.Id);
                    if(foundUser != null)
                    {
                        foundUser = user;
                        context.Users.Update(foundUser);

                        var foundUserPassword = context.UserPassword.FirstOrDefault(u => u.UserId == userPassword.UserId);
                        if (foundUserPassword != null)
                        {
                            foundUserPassword.Salt = GenerateSalt();
                            var mixedPassword = MixPasswordAndSalt(password: userPassword.Password, salt: foundUserPassword.Salt);
                            foundUserPassword.Password = PasswordCrypto(mixedPassword: mixedPassword);

                            context.UserPassword.Update(foundUserPassword);
                        }

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

        #region Utilities

        //TODO Crypto servisi yazılabilir (Solid için)
        private string GenerateSalt()
        {
            var salt = new byte[16];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return BitConverter.ToString(salt).Replace("-", "").ToLower();
        }

        //TODO Crypto servisi yazılabilir (Solid için)
        private string MixPasswordAndSalt(string password, string salt)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < password.Length; i++)
            {
                sb.Append(password[i]);
                if (salt.Length > i)
                    sb.Append(salt[i]);
            }

            for (int i = password.Length; i < salt.Length; i++)
            {
                sb.Append(salt[i]);
            }
            return sb.ToString();

        }

        //TODO Crypto servisi yazılabilir (Solid için)
        private string PasswordCrypto(string mixedPassword)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(mixedPassword);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));

                return hashedInputStringBuilder.ToString();
            }

        }
        #endregion
    }
}
