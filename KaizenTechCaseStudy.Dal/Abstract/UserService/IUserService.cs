using KaizenTechCaseStudy.Entities.UserEntities;
using System.Collections.Generic;

namespace KaizenTechCaseStudy.Dal.Abstract.UserService
{
    public interface IUserService
    {
        bool AddNewUser(Users user);

        bool UpdateUser(Users user);

        bool DeleteUser(int userId);

        Users GetUserById(int userId);

        List<Users> GetUserList();
    }
}
