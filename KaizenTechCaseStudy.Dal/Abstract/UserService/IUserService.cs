using KaizenTechCaseStudy.Entities.UserEntities;
using System.Collections.Generic;

namespace KaizenTechCaseStudy.Dal.Abstract.UserService
{
    public interface IUserService
    {
        bool AddNewUser(Users user, UserPassword userPassword);

        bool UpdateUser(Users user, UserPassword userPassword);

        bool DeleteUser(int userId);

        Users GetUserById(int userId);

        List<Users> GetUserList();
    }
}
